using System;

namespace Editor
{
    internal class AddFigureCommand : ACommand
    {
        private IFigure f;
        private CompositeFigure figures;

        public AddFigureCommand(CompositeFigure figures, IFigure f)
        {
            this.figures = figures;
            this.f = f;
        }

        public override void Execute()
        {
            figures.Add(f);
        }

        public override void UnExecute()
        {
            figures.Remove(f);
        }
    }
}