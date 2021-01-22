using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Translator
{
    public partial class Form1
    {
        private Bitmap OriginalImage = null;

        private void btn_img_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdOriginal = new OpenFileDialog();
            if (ofdOriginal.ShowDialog() == DialogResult.OK)
            {
                OriginalImage = new Bitmap(ofdOriginal.FileName);
                picImage.Image = OriginalImage;
                picImage.Visible = true;
                ShowImage();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfdResult = new SaveFileDialog();
            if (sfdResult.ShowDialog() == DialogResult.OK)
            {
                SaveImage(picImage.Image, sfdResult.FileName);
            }
        }
        // Save the file with the appropriate format.
        public void SaveImage(Image image, string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension.ToLower())
            {
                case ".bmp":
                    image.Save(filename, ImageFormat.Bmp);
                    break;
                case ".exif":
                    image.Save(filename, ImageFormat.Exif);
                    break;
                case ".gif":
                    image.Save(filename, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    image.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    image.Save(filename, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    image.Save(filename, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unknown file extension " + extension);
            }
        }

        private void scrXRadius_Scroll(object sender, ScrollEventArgs e)
        {
            txtbx_x_radius.Text = scrXRadius.Value.ToString();
           // ShowImage();
        }

        private void scrYRadius_Scroll(object sender, ScrollEventArgs e)
        {
            txtbx_y_radius.Text = scrYRadius.Value.ToString();
            ShowImage();
        }

        // Make and display the image with rounded corners.
        private void ShowImage()
        {
            // If the corners are not rounded,
            // just use the original image.
            if ((scrXRadius.Value == 0) || (scrYRadius.Value == 0))
            {
                picImage.Image = OriginalImage;
                return;
            }

            // Make a bitmap of the proper size.
            int width = OriginalImage.Width;
            int height = OriginalImage.Height;
            Bitmap bm = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Clear with a transparent background.
                gr.Clear(Color.Transparent);
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.InterpolationMode = InterpolationMode.High;

                // Make the rounded rectangle path.
                GraphicsPath path = MakeRoundedRect(
                    new Rectangle(0, 0, width, height),
                    scrXRadius.Value, scrYRadius.Value,
                    true, true, true, true);

                // Fill with the original image.
                using (TextureBrush brush = new TextureBrush(OriginalImage))
                {
                    gr.FillPath(brush, path);
                }
            }
            picImage.Image = bm;
        }

        // Draw a rectangle in the indicated Rectangle
        // rounding the indicated corners.
        private GraphicsPath MakeRoundedRect(
            RectangleF rect, float xradius, float yradius,
            bool round_ul, bool round_ur, bool round_lr, bool round_ll)
        {
            // Make a GraphicsPath to draw the rectangle.
            PointF point1, point2;
            GraphicsPath path = new GraphicsPath();

            // Upper left corner.
            if (round_ul)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 180, 90);
                point1 = new PointF(rect.X + xradius, rect.Y);
            }
            else point1 = new PointF(rect.X, rect.Y);

            // Top side.
            if (round_ur)
                point2 = new PointF(rect.Right - xradius, rect.Y);
            else
                point2 = new PointF(rect.Right, rect.Y);
            path.AddLine(point1, point2);

            // Upper right corner.
            if (round_ur)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 270, 90);
                point1 = new PointF(rect.Right, rect.Y + yradius);
            }
            else point1 = new PointF(rect.Right, rect.Y);

            // Right side.
            if (round_lr)
                point2 = new PointF(rect.Right, rect.Bottom - yradius);
            else
                point2 = new PointF(rect.Right, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower right corner.
            if (round_lr)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius,
                    rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 0, 90);
                point1 = new PointF(rect.Right - xradius, rect.Bottom);
            }
            else point1 = new PointF(rect.Right, rect.Bottom);

            // Bottom side.
            if (round_ll)
                point2 = new PointF(rect.X + xradius, rect.Bottom);
            else
                point2 = new PointF(rect.X, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower left corner.
            if (round_ll)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 90, 90);
                point1 = new PointF(rect.X, rect.Bottom - yradius);
            }
            else point1 = new PointF(rect.X, rect.Bottom);

            // Left side.
            if (round_ul)
                point2 = new PointF(rect.X, rect.Y + yradius);
            else
                point2 = new PointF(rect.X, rect.Y);
            path.AddLine(point1, point2);

            // Join with the start point.
            path.CloseFigure();

            return path;
        }



        private void txtbx_x_radius_TextChanged(object sender, EventArgs e)
        {
            scrXRadius.Value = Int32.Parse(txtbx_x_radius.Text);
        }

        private void scrXRadius_ValueChanged(object sender, EventArgs e)
        {
            ShowImage();
        }

        private void txtbx_y_radius_TextChanged(object sender, EventArgs e)
        {
            scrYRadius.Value = Int32.Parse(txtbx_y_radius.Text);
        }


        private void scrYRadius_ValueChanged(object sender, EventArgs e)
        {
            ShowImage();
        }

    }
}
