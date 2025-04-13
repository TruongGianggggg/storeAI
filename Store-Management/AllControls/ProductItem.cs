using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllControls
{
    public partial class ProductItem : UserControl
    {
        public ProductItem(string linkimg, string masp, string tensp)
        {
            InitializeComponent();
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\Toys\"+linkimg+""));
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Size = label1.Size;
            label1.Controls.Add(pictureBox1);

            label2.Text = masp;
            richTextBox1.Text = tensp;
        }
    }
}
