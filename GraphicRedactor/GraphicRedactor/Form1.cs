using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicRedactor
{
    public partial class GraphRed : Form
    {
        Graphics g;
        bool isPresed = false;
        Color currentColor = Color.Green;
        Point point;
        Point PreviousPoint;

        public GraphRed()
        {
            InitializeComponent();
            var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;
            g = Graphics.FromImage(bitmap);

            panel1.AutoScroll = true;
        }

        private void for_paint()
        {
            
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf"; ;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openFileDialog1.FileName);
                int width = image.Width;
                int height = image.Height;
                pictureBox1.Width = width;
                pictureBox1.Height = height;
                var bitmap = new Bitmap(Image.FromFile(openFileDialog1.FileName), width, height);
                pictureBox1.Image = bitmap;
            }    
            else return;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить картинку как ...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter =
                "Bitmap File(*.bmp)|*.bmp|" +
                "GIF File(*.gif)|*.gif|" +
                "JPEG File(*.jpg)|*.jpg|" +
                "TIF File(*.tif)|*.tif|" +
                "PNG File(*.png)|*.png";
            savedialog.ShowHelp = true;

            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = savedialog.FileName;
                string strFilExtn =
                    fileName.Remove(0, fileName.Length - 3);
                switch (strFilExtn)
                {
                    case "bmp":
                        pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isPresed = true;
            point = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPresed)
            {
                PreviousPoint = point;
                point = e.Location;

                Pen Pen = new Pen(currentColor, 1);

                // Рисовать так: 
                Graphics g = Graphics.FromImage(pictureBox1.Image);

                g.DrawLine(Pen, PreviousPoint, point);

                Pen.Dispose();
                g.Dispose();

                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isPresed = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            currentColor = Color.Black;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            currentColor = Color.White;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            currentColor = Color.Red;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            currentColor = Color.Green;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            currentColor = Color.Blue;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            currentColor = Color.Yellow;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            currentColor = Color.Pink;
        }

        private void изменитьРазмерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Owner = this;
            f2.ShowDialog();
        }
    }
}
