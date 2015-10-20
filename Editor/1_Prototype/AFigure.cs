﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public abstract class AFigure : IFigure, IShower//, IDecorator
    {
        public AFigure()
        {
            //this.DPs = new DecoratorParams();
        }

        // IFigure
        public virtual IFigure Clone()
        {
            return (AFigure)this.MemberwiseClone();
        }

        protected String Name;
        public virtual String GetName() { return Name; }
        public abstract Double Area();
        public abstract Double Perimeter();

        // IShower
        protected AShower Shower;
        public virtual void DrawPoligon(params Point[] Points)  // private
        {
            Shower.DrawPoligon(Points);
        }
        public virtual void DrawEllipse(Point Center, Double R)    // private
        {
            Shower.DrawEllipse(Center, R);
        }
        public virtual void DrawText(String text)
        {
            Shower.DrawText(text);
        }
        public virtual void EndShow()
        {
            Shower.EndShow();
        }
        //protected DecoratorParams DPs;
        //public void IShower_SetDecoratorParams(DecoratorParams DPs)
        //{
        //    Shower.IShower_SetDecoratorParams(DPs);
        //}

        // own
        public virtual void SetShower(AShower shower) { this.Shower = shower; }
        public abstract void Show(int lvl = 0);
        //public void SetDecoratorParams(DecoratorParams DPs)
        //{
        //    this.DPs = DPs;
        //}
    }
}
