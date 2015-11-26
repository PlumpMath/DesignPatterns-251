using System;

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
        public abstract void Show(int lvl = 0);                                     // public for CompositeFigure
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
        protected void FillPoligon(IShower shower, params Point[] Points) { shower.FillPoligon(Points); }
        protected void FillEllipse(IShower shower, Point Center, Double R) { shower.FillEllipse(Center, R); }
        protected void FillPoligon(params Point[] Points) { Shower.FillPoligon(Points); }
        protected void FillEllipse(Point Center, Double R) { Shower.FillEllipse(Center, R); }
        protected void DrawText(String text) { Shower.DrawText(text); }
        public void EndShow() { Shower.EndShow(); }
        public void SetBrushForShow(System.Drawing.Brush brush) { Shower.SetBrushForShow(brush); }
        #endregion

        #region for Decorator
        public abstract Point[] GetBorder();
        public abstract void ShowShadow(int lvl, IShower shower, Point dx);
        public abstract void ShowBorder(int lvl, IShower shower);
        #endregion

        public override bool Equals(object obj)
        {
            throw new Exception("You have to override Equals for YourClass:AFigure");
        }
    }
}
