using System;

namespace Editor
{
    internal class ClearCommand : ACommand
    {
        private CompositeFigure figures;

        public ClearCommand(CompositeFigure figures)
        {
            this.figures = figures;
        }

        public override void Execute()
        {
            figures.DelAll();
        }
    }
}