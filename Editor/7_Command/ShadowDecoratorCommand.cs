using System;

namespace Editor
{
    internal class ShadowDecoratorCommand : ACommand
    {
        IFigure f;

        public ShadowDecoratorCommand(ref IFigure f)
        {
            this.f = f;
            f = new ShadowDecorator(f);
        }

        public override void Execute()
        {
            f = new ShadowDecorator(f);
        }
    }
}