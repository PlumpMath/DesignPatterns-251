namespace Editor
{
    interface IKit
    {
        int Register(IFigure f);
        IFigure Create(int key);
    }
}
