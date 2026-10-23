using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using VisioForge.Core.Types.X;

namespace Xray_image_new_Project
{
    public partial class ColorMapForm : Form
    {
        Bitmap ColorMapImage;
        public bool IsMousDown = false;
        public Point StartPoint;
        public Point EndPoint;
        public Rectangle rect;


        //circle parameters
        Point selectionCenter;
        int selectionRadius;

        Point end_point;

        //line
        List<Point> line = new List<Point>();  
        //

        public ColorMapForm()
        {
            InitializeComponent();
            this.pictureBox1.Size = new Size(256, 256);
            this.pictureBox1.Image = MainForm.instance.pictureBox1.Image;
            ColorMapImage = (Bitmap)MainForm.instance.pictureBox1.Image;
            this.pictureBox1.Cursor = Cursors.Hand;
            

        }
        //Hot ColorMap
        Color[] HotMap = {
            Color.Black,  // 0.0
            Color.Red,    // 0.33
            Color.Orange, // 0.66
            Color.Yellow, // 1.0
        };
        //Heat ColorMap
        Color[] HeatMap = {
            Color.Blue,   // 0.0
            Color.Cyan,   // 0.25
            Color.Green,  // 0.5
            Color.Yellow, // 0.75
            Color.Red     // 1.0
        };
        //Spring ColorMap
        Color[] SpringMap = {
            Color.Green,    // 0.0
            Color.Yellow,   // 0.5
            Color.FromArgb(255, 255, 182, 193) // Light Pink
        };
        //Jet ColorMap
        Color[] JetMap = {
            Color.FromArgb(0, 0, 127),   // Blue
            Color.FromArgb(0, 0, 255),    // Cyan
            Color.FromArgb(0, 255, 255),  // Green
            Color.FromArgb(255, 255, 0),  // Yellow
            Color.FromArgb(255, 0, 0)     // Red
        };
        //CoolMap
        Color[] CoolMap = {
                Color.Black,  // 0.0
                Color.Blue,   // 0.25
                Color.Cyan,   // 0.5
                Color.Green,  // 0.75
                Color.White   // 1.0
            };

        private Bitmap ConvertToGrayscale(Bitmap original)
        {
            // Create a new Bitmap with the same dimensions
            Bitmap grayscale = new Bitmap(original.Width, original.Height);

            // Iterate over each pixel in the original image
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    // Get the color of the pixel
                    Color originalColor = original.GetPixel(x, y);

                    // Calculate luminance (average of R, G, and B components)
                    int luminance = (int)(0.2126 * originalColor.R + 0.7152 * originalColor.G + 0.0722 * originalColor.B);

                    // Set the grayscale value for each channel
                    Color grayscaleColor = Color.FromArgb(luminance, luminance, luminance);

                    // Set the pixel in the grayscale image
                    grayscale.SetPixel(x, y, grayscaleColor);
                }
            }

            return grayscale;
        }

        public Bitmap ApplyColorMap(Bitmap grayscaleImage, Color[] ColorMap)
        {
            
            // Create a new bitmap with the same dimensions as the original grayscale image
            Rectangle rect = this.rect;

            for (int x = 0; x < grayscaleImage.Width; x++)
            {
                for (int y = 0; y < grayscaleImage.Height; y++)
                {
                    
                    //if ((y > rect.Y && y <= rect.Height + rect.Y) && (x >= rect.X && x <= rect.Width + rect.X))
                    //if(disatance <= selectionRadius)
                    //if(r == true)
                    if(RectangelRadio_Button.Checked == true)
                    { 
                       if((y > rect.Y && y <= rect.Height + rect.Y) && (x >= rect.X && x <= rect.Width + rect.X))
                       {

                        // Get the grayscale value from the original image
                        Color grayColor = grayscaleImage.GetPixel(x, y);

                        int grayValue = grayColor.R; // Assuming it's a grayscale image, R=G=B

                        // Normalize the grayscale value to [0, 1]
                        double normalizedValue = grayValue / 255.0;

                        // Get the heatmap color based on the normalized grayscale value
                        Color heatmapColor = GetColorMap(normalizedValue, ColorMap);

                        // Set the pixel color in the heatmap image
                        grayscaleImage.SetPixel(x, y, heatmapColor);
                       }
                    }
                    else if(CircleRadio_Button.Checked == true)
                    {

                    int disatance =(int) Math.Sqrt(Math.Pow(x - selectionCenter.X, 2) + Math.Pow(y - selectionCenter.Y, 2));

                        if (disatance <= selectionRadius)
                        {

                            // Get the grayscale value from the original image
                            Color grayColor = grayscaleImage.GetPixel(x, y);

                            int grayValue = grayColor.R; // Assuming it's a grayscale image, R=G=B

                            // Normalize the grayscale value to [0, 1]
                            double normalizedValue = grayValue / 255.0;

                            // Get the heatmap color based on the normalized grayscale value
                            Color heatmapColor = GetColorMap(normalizedValue, ColorMap);

                            // Set the pixel color in the heatmap image
                            grayscaleImage.SetPixel(x, y, heatmapColor);
                        }
                    }
                    else if(PenRadio_Button.Checked == true)
                    {
                        Point point = new Point(x,y);

                        bool InsideShape = IsPointInsidePolygon(line, point);
                        if (InsideShape == true)
                        {

                            // Get the grayscale value from the original image
                            Color grayColor = grayscaleImage.GetPixel(x, y);

                            int grayValue = grayColor.R; // Assuming it's a grayscale image, R=G=B

                            // Normalize the grayscale value to [0, 1]
                            double normalizedValue = grayValue / 255.0;

                            // Get the heatmap color based on the normalized grayscale value
                            Color heatmapColor = GetColorMap(normalizedValue, ColorMap);

                            // Set the pixel color in the heatmap image
                            grayscaleImage.SetPixel(x, y, heatmapColor);
                        }
                    }


                }
            }

            return grayscaleImage;
        }
        private bool IsPointInsidePolygon(List<Point> polygon, Point point)
        {
            bool result = false;
            int j = polygon.Count - 1;
            for (int i = 0; i < polygon.Count; i++)
            {
                if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                {
                    if (polygon[i].X + (point.Y - polygon[i].Y) / (float)(polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < point.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        private static Color GetColorMap(double value, Color[] ColorMap)
        {
            // Ensure value is clamped between 0 and 1
            value = Math.Max(0, Math.Min(1, value));

            // Define color points (gradient from blue to red)


            // Determine which segment of the gradient value falls into
            //الغرض من هذا السطر هو تعيين قيمة الإدخال، التي تم تسويتها بين 0 و1، إلى الموضع المقابل ضمن نطاق مؤشرات مصفوفة الألوان.
            double scaledValue = value * (ColorMap.Length - 1);
            int index1 = (int)Math.Floor(scaledValue); // Lower index
            int index2 = (int)Math.Ceiling(scaledValue); // Upper index
            double fraction = scaledValue - index1; // Fraction between indices
                                                    // الغرض من هذا السطر هو تحديد مدى المسافة المقاسة بين المؤشرين
                                                    // (index1 وindex2)

            // Interpolate between the two colors
            Color color1 = ColorMap[index1];
            Color color2 = ColorMap[index2];

            byte r = (byte)((color2.R - color1.R) * fraction + color1.R);
            byte g = (byte)((color2.G - color1.G) * fraction + color1.G);
            byte b = (byte)((color2.B - color1.B) * fraction + color1.B);

            return Color.FromArgb(r, g, b);
        }

        private void HeatMap_Button_Click(object sender, EventArgs e)
        {
            if (rect.X != 0 || selectionRadius != 0 || line.Count >=2 )
            {
                Bitmap Gray_image = ConvertToGrayscale(ColorMapImage);
                //MainForm.instance.pictureBox1.Image = ApplyColorMap(Gray_image, HeatMap);
                this.pictureBox1.Image= ApplyColorMap(Gray_image, HeatMap);
            }
            else
            {
                MessageBox.Show
                    (
                    "You dont select any Area!!!"
                    ,"Error",MessageBoxButtons.OK
                    ,MessageBoxIcon.Error
                    );
            }


        }
        private void HotMap_Button_Click(object sender, EventArgs e)
        {
            if (rect.X != 0 || selectionRadius != 0 || line.Count >= 2)
            {
                Bitmap Gray_image = ConvertToGrayscale(ColorMapImage);
                //MainForm.instance.pictureBox1.Image = ApplyColorMap(Gray_image, HeatMap);
                this.pictureBox1.Image = ApplyColorMap(Gray_image, HotMap);
            }
            else
            {
                MessageBox.Show
                    (
                    "You dont select any Area!!!"
                    , "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error
                    );
            }

        }
        private void JetMap_Button_Click(object sender, EventArgs e)
        {
            if (rect.X != 0 || selectionRadius != 0 || line.Count >= 2)
            {
                Bitmap Gray_image = ConvertToGrayscale(ColorMapImage);
                //MainForm.instance.pictureBox1.Image = ApplyColorMap(Gray_image, HeatMap);
                this.pictureBox1.Image = ApplyColorMap(Gray_image, JetMap);
            }
            else
            {
                MessageBox.Show
                    (
                    "You dont select any Area!!!"
                    , "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error
                    );
            }

        }
        private void CoolMap_Button_Click(object sender, EventArgs e)
        {
            if(rect.X != 0 || selectionRadius != 0 || line.Count >= 2)
            {
                Bitmap Gray_image = ConvertToGrayscale(ColorMapImage);
                //MainForm.instance.pictureBox1.Image = ApplyColorMap(Gray_image, HeatMap);
                this.pictureBox1.Image = ApplyColorMap(Gray_image, CoolMap);
            }
            else
            {
                MessageBox.Show
                    (
                    "You dont select any Area!!!"
                    , "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error
                    );
            }

        }
        private void SpringMap_Button_Click(object sender, EventArgs e)
        {
            if (rect.X != 0 || selectionRadius != 0 || line.Count >= 2)
            {
                Bitmap Gray_image = ConvertToGrayscale(ColorMapImage);
                //MainForm.instance.pictureBox1.Image = ApplyColorMap(Gray_image, HeatMap);
                this.pictureBox1.Image = ApplyColorMap(Gray_image, SpringMap);
            }
            else
            {
                MessageBox.Show
                    (
                    "You dont select any Area!!!"
                    , "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error
                    );
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {  //rectangel
                if(RectangelRadio_Button.Checked)
                {

                IsMousDown = true;
                StartPoint = e.Location;
                
                }
                //
                //circle
                else if(CircleRadio_Button.Checked)
                {
                selectionCenter = e.Location;
                IsMousDown= true;
                }
                //
                //line
                else if (PenRadio_Button.Checked)
                {
                IsMousDown = true;
                line.Clear();
                line.Add(e.Location);
                }
                //

            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                //rectangel
                if (RectangelRadio_Button.Checked)
                {

                if (IsMousDown == true)
                {
                    EndPoint = e.Location;

                    Refresh();
                }
                }
                //
                //circle
                else if (CircleRadio_Button.Checked)
                {
                if (IsMousDown == true)
                {
                 selectionRadius= (int)Math.Sqrt(Math.Pow(e.X - selectionCenter.X, 2) + Math.Pow(e.Y - selectionCenter.Y, 2));
                 Refresh();
                }
                }
                //
                //line
                if (PenRadio_Button.Checked)
                {
                    if (IsMousDown == true)
                    {

                        line.Add(e.Location);
                        Refresh();
                    }

                }
                //
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            if (pictureBox1.Image != null)
            {
                // rectangel
                if(RectangelRadio_Button.Checked)
                {
                    if (IsMousDown == true)
                    {
                        EndPoint = e.Location;
                        IsMousDown = false;
                    
                    }

                }
                //
                //circle
                else if(CircleRadio_Button.Checked)
                {
                   IsMousDown = false;
                   Refresh();
                }
                
                //
                //line
                
                else if (PenRadio_Button.Checked)
                {
                    if (IsMousDown == true)
                    {
                         IsMousDown = false;
                    
                        if (line.Count > 2 && e.Location == line[0])
                        {
                            line.Add(line[0]);
                        }
                    }
                    Refresh();
                }

            }
        }

        public Rectangle GetRect()
        {
            rect = new Rectangle();
            //This ensures that the rectangle starts at the leftmost point between the two coordinates
            rect.X = Math.Min(EndPoint.X, StartPoint.X);
            rect.Y = Math.Min(EndPoint.Y, StartPoint.Y);

            rect.Width = Math.Abs(EndPoint.X - StartPoint.X);
            rect.Height = Math.Abs(EndPoint.Y - StartPoint.Y);
            
            return rect;


        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (RectangelRadio_Button.Checked)
                {
                    e.Graphics.DrawRectangle(Pens.Yellow, GetRect());
                }
                else if (CircleRadio_Button.Checked)
                {
                     
                e.Graphics.DrawEllipse(
                    Pens.Yellow,
                    selectionCenter.X - selectionRadius,
                    selectionCenter.Y - selectionRadius,
                    selectionRadius * 2, selectionRadius * 2
                    );
                }
                if (PenRadio_Button.Checked)
                {

                    {
                    if (line.Count > 1)
                        e.Graphics.DrawLines(Pens.Yellow, line.ToArray());
                    }
                }
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if(this.pictureBox1.Image!=null)
            {

            MainForm.instance.Save(sender,e,this.pictureBox1);
            }
        }

        private void Done_Button_Click(object sender, EventArgs e)
        {
               
                MainForm.instance.pictureBox1.Image = (Bitmap)pictureBox1.Image;
                this.Close();
        }

        private void Erase_Button_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ColorMapImage;
        }
    }
}
