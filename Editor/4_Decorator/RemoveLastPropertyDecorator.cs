using System;

namespace Editor
{
    public class RemoveLastPropertyDecorator : ADecorator
    {
        public override IFigure Clone()
        {
            return new RemoveLastPropertyDecorator(decoratedFigure);
        }

        public RemoveLastPropertyDecorator(IFigure figureToDecorate) : base(figureToDecorate)
        {
            Console.WriteLine("RemoveLastPropertyDecorator");

            IFigure lastDecorator = figureToDecorate;
            while (lastDecorator is RemoveLastPropertyDecorator)
                lastDecorator = ((ADecorator)lastDecorator).RemoveLastDecorator();

            if (lastDecorator is ADecorator)
            {
                decoratedFigure = ((ADecorator)lastDecorator).RemoveLastDecorator();

                while (decoratedFigure is RemoveLastPropertyDecorator)
                    decoratedFigure = ((ADecorator)decoratedFigure).RemoveLastDecorator();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            RemoveLastPropertyDecorator f = obj as RemoveLastPropertyDecorator;
            if (f == null) return false;

            return decoratedFigure.Equals(f.decoratedFigure);
        }
    }
}
