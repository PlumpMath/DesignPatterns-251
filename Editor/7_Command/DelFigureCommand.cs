using System;

namespace Editor
{
    internal class DelFigureCommand : ACommand
    {
        private IFigure f;
        private CompositeFigure figures;

        public DelFigureCommand(CompositeFigure figures, IFigure f)
        {
            this.figures = figures;
            this.f = f;
        }

        public override void Execute()
        {
            figures.Remove(f);
        }

        public override void UnExecute()
        {
            figures.Add(f);
        }
    }
}