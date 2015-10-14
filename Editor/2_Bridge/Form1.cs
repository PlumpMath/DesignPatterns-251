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
    partial class Form1 : Form
    {
        // -250 +250
        private CompositeFigure cf;
        private double transparency;
        private double kScale;
        public Form1(CompositeFigure cf, double transparency, double scale)
        {
            InitializeComponent();

            this.cf = cf;
            this.transparency = transparency;
            this.kScale = scale / 100.0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Output(e, cf);
            //e.Graphics.FillEllipse(Brushes.Azure, 100, 100, 100, 100);
        }

        private void Output(PaintEventArgs e, CompositeFigure cf)
        {
            PointF screenMid = new PointF(this.Width / 2.0f, this.Height /  2.0f);
            Pen pen = new Pen(Brushes.Black);

            List<AFigure> childrens = cf.GetChildren();

            foreach (AFigure pf in childrens)
            {
                switch (pf.GetType().ToString())
                {
                    case "Editor.CompositeFigure":
                        Output(e, (CompositeFigure)pf);
                        break;
                    case "Editor.Circle":
                        Circle pfc = (Circle)pf;
                        float r = (float)(pfc.R * kScale);
                        PointF center = new PointF(screenMid.X - (float)(kScale * pfc.Center.X) - r, screenMid.Y - (float)(kScale * pfc.Center.Y) - r);
                        SizeF size = new SizeF(2.0f * r, 2.0f * r);
                        e.Graphics.DrawEllipse(pen, new RectangleF(center, size));
                        break;
                    case "Editor.Rectangle":
                        Rectangle pfr = (Rectangle)pf;
                        PointF pr1 = new PointF(screenMid.X - (float)(kScale * pfr.a1.X), screenMid.Y - (float)(kScale * pfr.a1.Y));
                        PointF pr2 = new PointF(screenMid.X - (float)(kScale * pfr.a2.X), screenMid.Y - (float)(kScale * pfr.a2.Y));
                        PointF pr3 = new PointF(screenMid.X - (float)(kScale * pfr.a3.X), screenMid.Y - (float)(kScale * pfr.a3.Y));
                        PointF pr4 = new PointF(screenMid.X - (float)(kScale * pfr.a4.X), screenMid.Y - (float)(kScale * pfr.a4.Y));
                        e.Graphics.DrawLines(pen, new PointF[] { pr1, pr2, pr3, pr4, pr1 });
                        break;
                    case "Editor.Triangle":
                        Triangle pft = (Triangle)pf;
                        PointF pt1 = new PointF(screenMid.X - (float)(kScale * pft.a1.X), screenMid.Y - (float)(kScale * pft.a1.Y));
                        PointF pt2 = new PointF(screenMid.X - (float)(kScale * pft.a2.X), screenMid.Y - (float)(kScale * pft.a2.Y));
                        PointF pt3 = new PointF(screenMid.X - (float)(kScale * pft.a3.X), screenMid.Y - (float)(kScale * pft.a3.Y));
                        e.Graphics.DrawLines(pen, new PointF[] { pt1, pt2, pt3, pt1 });
                        break;
                    default:
                        MessageBox.Show("unsupported type " + pf.GetType().ToString());
                        break;
                }
            }
        }
    }
}
