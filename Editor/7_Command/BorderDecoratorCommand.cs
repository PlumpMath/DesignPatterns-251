namespace Editor
{
    internal class BorderDecoratorCommand : ACommand
    {
        private IFigure f;
        private CompositeFigure cf;

        public BorderDecoratorCommand(CompositeFigure figures, IFigure f)
        {
            this.f = f;
            this.cf = figures;
        }

        public override void Execute()
        {
            IFigure tmp = new BorderDecorator(f);
            cf.Replace(f, tmp);
        }
    }
}