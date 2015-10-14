using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public abstract class AShower : IShower
    {
        // IShower
        public abstract void DrawEllipse(Point Center, Double R);
        public abstract void DrawPoligon(params Point[] Points);

        // own
        protected String msg;
        public virtual void SetMsg(String msg) { this.msg = msg; }
    }

    public class ConsoleShower : AShower
    {
        public override void DrawEllipse(Point Center, double R)
        {
            Console.WriteLine(msg + " : center=" + Center.ToString() + " , R=" + R);
        }
        public override void DrawPoligon(params Point[] Points)
        {
            Console.WriteLine(msg + " : points=");
            for (int i=0; i<Points.Length; i++)
            {
                Console.Write(Points[i].ToString());
                if (i != Points.Length - 1)
                    Console.Write(",");
            }
        }
    }
}
