﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public abstract class AFigure : IFigure
    {
        #region IFigure
        public virtual IFigure Clone()
        {
            return (AFigure)this.MemberwiseClone();
        }

        private String Name;
        public String GetName() { return Name; }
        public void SetName(String Name) { this.Name = Name; }
        public abstract Double Area();
        public abstract Double Perimeter();

        public abstract void MoveTo(Point x);
        public abstract void MoveOn(Point dx);

        public virtual void SetShower(IShower shower) { this.Shower = shower; }     // overrided in CompositeFigure
        public void Show() { myShow(0); }
        public abstract void myShow(int lvl);   // public for CompositeFigure
        #endregion

        #region for Shower
        private IShower Shower;
        protected void DrawPoligon(params Point[] Points) { Shower.DrawPoligon(Points); }
        protected void DrawEllipse(Point Center, Double R) { Shower.DrawEllipse(Center, R); }
        protected void DrawText(String text) { Shower.DrawText(text); }
        public void EndShow() { if (Shower != null) Shower.EndShow(); }
        #endregion
    }
}
