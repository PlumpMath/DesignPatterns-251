using System;

namespace Editor
{
    internal class AddDecoratorCommand : ACommand
    {
        private ADecorator d;
        private IFigure f;

        public AddDecoratorCommand(IFigure f, ADecorator d)
        {
            this.f = f;
            this.d = d;
        }

        public override void Execute()
        {
            // TODO: Decorator
        }

        public override void UnExecute()
        {
            f = new RemoveLastPropertyDecorator(f);
        }
    }
}