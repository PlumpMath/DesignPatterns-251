using System;

namespace Editor
{
    internal class MakeCompositeCommand : ACommand
    {
        private IFigure[] arr;
        private CompositeFigure figures;
        CompositeFigure cf;

        public MakeCompositeCommand(CompositeFigure figures, params IFigure[] arr)
        {
            this.figures = figures;
            this.arr = arr;
            cf = new CompositeFigure(arr);
        }

        public override void Execute()
        {
            foreach (IFigure f in arr)
            {
                figures.Remove(f);
            }

            figures.Add(cf);
        }

        public override void UnExecute()
        {
            figures.Remove(cf);

            foreach (IFigure f in arr)
            {
                figures.Add(f);
            }
        }
    }
}