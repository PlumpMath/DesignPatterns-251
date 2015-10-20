using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor._4
{
    public class DecoratorParams
    {
        private int len;
        private List<double> arr;

        public DecoratorParams()
        {
            len = -1;
            arr = new List<double>();
        }
        public void ChangeParams(params double[] p)
        {
            while (p.Length > arr.Count)
                arr.Add(0.0);

            for (int i = 0; i < p.Length; i++)
                arr[i] += p[i];
        }

        private double get(int pos)
        {
            if (len >= pos)
                return arr[pos];

            return 0.0;
        }

        public double getShadow() { return get(0); }
    }
}
