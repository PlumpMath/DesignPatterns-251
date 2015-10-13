using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Editor
{
    //class OutputterAbstraction
    //{
    //    // Property
    //    public Implementor Outputter { get; set; }

    //    public virtual void Output()
    //    {
    //        Outputter.Output();
    //    }
    //}
    //class RefinedAbstraction : OutputterAbstraction
    //{
    //    public override void Output()
    //    {
    //        Outputter.Output();
    //    }
    //}

    abstract class Implementor
    {
        public abstract void Output(CompositeFigure cf);
    }
    class ConsoleOutputter : Implementor
    {
        public override void Output(CompositeFigure cf)
        {
            Output(cf, 0);
        }
        private void Output(CompositeFigure cf, int lvl)
        {
            List<PrototypeFigure> childrens = cf.GetChildren();
            Console.WriteLine(childrens.Count + " childs :");

            foreach (PrototypeFigure pf in childrens)
            {
                String common = (new String('-', 2*lvl)) + pf.GetName() + ": P=" + pf.Perimeter() + ", S=" + pf.Area() + " : ";
                Console.Write(common);

                String additional = "";
                switch (pf.GetType().ToString())
                {
                    case "Editor.CompositeFigure":
                        Output((CompositeFigure)pf, lvl+1);
                        break;
                    case "Editor.Circle":
                        Circle pfc = (Circle)pf;
                        additional += "Center=" + pfc.Center.ToString() + ", R=" + pfc.R;
                        Console.WriteLine(additional);
                        break;
                    case "Editor.Rectangle":
                        Rectangle pfr = (Rectangle)pf;
                        additional += "Points=" + pfr.a1.ToString() + "," + pfr.a2.ToString() + "," + pfr.a3.ToString() + "," + pfr.a4.ToString();
                        Console.WriteLine(additional);
                        break;
                    case "Editor.Triangle":
                        Triangle pft = (Triangle)pf;
                        additional += "Points=" + pft.a1.ToString() + "," + pft.a2.ToString() + "," + pft.a3.ToString();
                        Console.WriteLine(additional);
                        break;
                    default:
                        additional += "unsupported type";
                        break;
                }
            }
        }
    }
    class WindowOutputter : Implementor
    {
        private double transparency;
        private double scale;
        public WindowOutputter(double transparency, double scale)
        {
            this.transparency = transparency;
            this.scale = scale;
        }

        public override void Output(CompositeFigure cf)
        {
            Form1 f1 = new Form1(cf, transparency, scale);
            f1.ShowDialog();
        }
    }
}
