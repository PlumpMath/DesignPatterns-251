using System;
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
            return (IFigure)this.MemberwiseClone();
        }

        private String Name;
        public String GetName() { return Name; }
        public void SetName(String Name) { this.Name = Name; }
        public abstract Double Area();
        public abstract Double Perimeter();

        public abstract void MoveTo(Point x);
        public abstract void MoveOn(Point dx);

        public virtual void SetShower(IShower shower) { this.Shower = shower; }     // overrided in CompositeFigure
        public abstract void Show(int lvl = 0);   // public for CompositeFigure
        #endregion

        #region for Shower
        private IShower _Shower;
        private IShower Shower
        {
            set
            {
                _Shower = value;
            }
            get
            {
                if (_Shower == null) throw new MemberAccessException("do 'SetShower' first");
                return _Shower;
            }
        }
        protected void DrawPoligon(params Point[] Points) { Shower.DrawPoligon(Points); }
        protected void DrawEllipse(Point Center, Double R) { Shower.DrawEllipse(Center, R); }
        protected void DrawText(String text) { Shower.DrawText(text); }
        public void EndShow() { Shower.EndShow(); }
        public void SetBrushForShow(System.Drawing.Brush brush) { Shower.SetBrushForShow(brush); }
        #endregion
    }
}
