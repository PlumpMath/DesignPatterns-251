using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class Form1 : Form
    {
        public Bitmap bmp = new Bitmap(500, 500);
        public Graphics graphics;

        public Form1()
        {
            InitializeComponent();

            graphics = Graphics.FromImage(bmp);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImageUnscaled(bmp, 0, 0); // нарисуем все накопленное в картинке
        }
    }
}
