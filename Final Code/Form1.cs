using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Code
{
    public partial class Form1 : Form
    {
        //camera thread start
        VideoCapture _capture;
        Thread _captureThread;

        //serial communication thread
        SerialPort arduinoSerial = new SerialPort();
        bool enableCoordinateSending = false;
        Thread serialMonitoringThread;
        public Form1()
        {
            InitializeComponent();
        }
        public void ProcessImage()
        { 
            while (_capture.IsOpened)
            {
                //start image
                Mat workingImage = _capture.QueryFrame();
                var imgConv = workingImage.ToImage<Bgr, byte>();
                imgConv.ROI = new Rectangle(227, 95, workingImage.Width - 450, workingImage.Height - 335);
                workingImage = imgConv.Mat;
                // resize to PictureBox aspect ratio
                int newHeight = (workingImage.Size.Height * rawPictureBox.Size.Width) / workingImage.Size.Width;
                Size newSize = new Size(rawPictureBox.Size.Width, newHeight);
                CvInvoke.Resize(workingImage, workingImage, newSize);
                // as a test for comparison, create a copy of the image with a binary filter:
                var binaryImage = workingImage.ToImage<Gray, byte>().ThresholdBinary(new Gray(100), new Gray(255)).Mat;
                // Sample for gaussian blur:
                // var blurredImage = new Mat();
                // var cannyImage = new Mat();
                var decoratedImage = new Mat();
                var artedImage = workingImage.Clone();

                CvInvoke.CvtColor(binaryImage, decoratedImage, typeof(Gray), typeof(Bgr));

                // find contours:
                using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                using (VectorOfPoint approxContour = new VectorOfPoint())
                {
                    int contoursFound = 0;
                    int shape = 0;
                    // Build list of contours
                    CvInvoke.FindContours(binaryImage, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                    Point center = new Point();
                    for (int i = 0; i < contours.Size; i++)
                    {
                        VectorOfPoint contour = contours[i];
                        double area = CvInvoke.ContourArea(contour);
                        if (area >= 50 && area <= 9000)
                        {

                            contoursFound++;
                            CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                            CvInvoke.Polylines(decoratedImage, contour, true, new Bgr(Color.Red).MCvScalar);
                            Point[] points = approxContour.ToArray();
                            Rectangle boundingBox = CvInvoke.BoundingRectangle(contours[i]);
                            center = new Point(boundingBox.X + boundingBox.Width / 2, boundingBox.Y + boundingBox.Height / 2);
                            MarkDetectedObject(artedImage, contours[i], boundingBox, area, center);

                            //identify squares vs triangles
                            if (points.Length == 3)
                            {
                                CvInvoke.Polylines(artedImage, contour, true, new Bgr(Color.Green).MCvScalar, 2);
                                shape = 0;

                            }
                            else if (points.Length == 4)
                            {
                                CvInvoke.Polylines(artedImage, contour, true, new Bgr(Color.Blue).MCvScalar, 2);
                                shape = 1;
                            }
                            else //unknown object
                            {
                                CvInvoke.Polylines(artedImage, contour, true, new Bgr(Color.Red).MCvScalar, 2);
                            }
                        }

                        //send coordinates
                        if (enableCoordinateSending)
                        {
                            double xCoord = Math.Round((center.X * 22.0) / workingImage.Width);
                            double yCoord = Math.Round((center.Y * 17.0) / workingImage.Height);
                            if (xCoord >= 0 && yCoord >= 0)
                            {
                                byte[] buffer = new byte[5]
                                {
                                Encoding.ASCII.GetBytes("<")[0],
                                Convert.ToByte(shape),
                                Convert.ToByte(xCoord),
                                Convert.ToByte(yCoord),
                                Encoding.ASCII.GetBytes(">")[0]
                                };
                                arduinoSerial.Write(buffer, 0, 5);
                                enableCoordinateSending = false;
                            }
                            else
                            {
                                MessageBox.Show("X and Y values must be integers", "Unable to parse coordinates");
                            }
                        }
                        

                        //label1.Text($"There are {contours.Size} contours detected");
                        Invoke(new Action(() =>
                        {
                            label1.Text = $"There are {contoursFound} contours detected";
                        }));

                
                    }
                    // output images:
                    Invoke(new Action(() =>
                    {
                        rawPictureBox.Image = workingImage.Bitmap;
                        contourPictureBox.Image = decoratedImage.Bitmap;
                        coloredPictureBox.Image = artedImage.Bitmap;
                    }));

                    //start of determining coordinates

                    //scale image
                    double scaleWidth = Math.Round((center.X * 22.0) / workingImage.Width);
                    double scaleLength = Math.Round((center.Y * 17.0) / workingImage.Height);
                    Invoke(new Action(() =>
                    {
                        coordLabel.Text = $"This is the scale of the {contoursFound} images: {scaleWidth}, {scaleLength}";
                    }));

                    if (contoursFound > 0)
                    {
                        double pointWidth = Math.Round((center.X * 22.0)/workingImage.Width);
                        double pointLength = Math.Round((center.Y * 17.0)/workingImage.Height);
                        Invoke(new Action(() =>
                        {
                            coordLabel.Text = $"{pointWidth}, {pointLength}";
                        }));
                    }
                }
            }
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            _capture = new VideoCapture(1);
            _captureThread = new Thread(ProcessImage);
            _captureThread.Start();

            //open serial monitor thread
            try
            {
                arduinoSerial.PortName = "COM4";
                arduinoSerial.BaudRate = 9600;
                arduinoSerial.Open();
                serialMonitoringThread = new Thread(MonitorSerialData);
                serialMonitoringThread.Start();
                xCoordBox.Text = "130";
                yCoordBox.Text = "224";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Initializing COM port");
                Close();
            }
        }
        
        private void MonitorSerialData()
        {
            while (true)
            {
                // block until \n character is received, extract command data
                string msg = arduinoSerial.ReadLine();
                // confirm the string has both < and > characters
                if (msg.IndexOf("<") == -1 || msg.IndexOf(">") == -1)
                {
                    continue;
                }
                // remove everything before (and including) the < character
                msg = msg.Substring(msg.IndexOf("<") + 1);
                // remove everything after (and including) the > character
                msg = msg.Remove(msg.IndexOf(">"));
                // if the resulting string is empty, disregard and move on
                if (msg.Length == 0)
                {
                    continue;
                }
                // parse the command
                if (msg.Substring(0, 1) == "S")
                {
                    // command is to suspend, toggle states accordingly:
                    ToggleFieldAvailability(msg.Substring(1, 1) == "1");
                }
                else if (msg.Substring(0, 1) == "P")
                {
                    // command is to display the point data, output to the text field:
                    Invoke(new Action(() =>
                    {
                        returnedPointLabel.Text = $"Returned Point Data: {msg.Substring(1)}";
                    }));
                }
                else if (msg.Substring(0,1) == "D")
                {
                    Invoke(new Action(() =>
                    {
                        debugLabel.Text = $"Returned Point Data: {msg.Substring(1)}";
                    }));
                }
            }
        }

        //lock and unlock
        private void ToggleFieldAvailability(bool suspend)
        {
            Invoke(new Action(() =>
            {
                enableCoordinateSending = !suspend;
                toolStrip1.Text = $"State: {(suspend ? "Locked" : "Unlocked")}";
            }));
        }

        //smother the threads so they don't cause problems in the future
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _captureThread.Abort();
            serialMonitoringThread.Abort();
        }


        private static void MarkDetectedObject(Mat frame, VectorOfPoint contour, Rectangle boundingBox, double area, Point center)
        {
            // Drawing contour and box around it
            CvInvoke.Polylines(frame, contour, true, new Bgr(Color.Red).MCvScalar);
            CvInvoke.Rectangle(frame, boundingBox, new Bgr(Color.Red).MCvScalar);
            // Write information next to marked object
            var info = new string[] {
                $"Area: {area}",
                $"Position: {center.X}, {center.Y}"
                };
            WriteMultilineText(frame, info, new Point(center.X, boundingBox.Bottom + 12));
            CvInvoke.Circle(frame, center, 5, new Bgr(Color.Orange).MCvScalar, 5);
        }

        //write many lines at a time on the image
        private static void WriteMultilineText(Mat frame, string[] lines, Point origin)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                int y = i * 10 + origin.Y; // Moving down on each line
                CvInvoke.PutText(frame, lines[i], new Point(origin.X, y),
                FontFace.HersheyPlain, 0.8, new Bgr(Color.Red).MCvScalar);
            }
        }

        //start the program
        private void startButton_Click(object sender, EventArgs e)
        {
            enableCoordinateSending = true;
        }

        //STAHP
        private void estopButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //send coordinates from the input boxes
        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (!enableCoordinateSending)
            {
                MessageBox.Show("Temporarily locked...");
                return;
            }
            int x = -1;
            int y = -1;
            if (int.TryParse(xCoordBox.Text, out x) && int.TryParse(yCoordBox.Text, out y))
            {
                byte[] buffer = new byte[4]
                {
                    Encoding.ASCII.GetBytes("<")[0],
                    Convert.ToByte(x),
                    Convert.ToByte(y),
                    Encoding.ASCII.GetBytes(">")[0]
                };
                arduinoSerial.Write("coord");
                arduinoSerial.Write(buffer, 0, 4);
            }
            else
            {
                MessageBox.Show("X and Y values must be integers", "Unable to parse coordinates");
            }
        }
    }
}