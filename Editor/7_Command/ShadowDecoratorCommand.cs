using System;

namespace Editor
{
    internal class ShadowDecoratorCommand : ACommand
    {
        private IFigure f;

        public ShadowDecoratorCommand(IFigure f)
        {
            this.f = f;
        }

        public override void Execute()
        {
            f = new ShadowDecorator(f);
        }
    }
}