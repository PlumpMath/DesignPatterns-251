using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    sealed class MyRef<T>
    {
        public T Value { get; set; }
    }

    class User
    {
        public User()
        {
            ACommand command = new ClearCommand(figures);
            command.Execute();

            HandleAddCommand(command);
        }

        // Initializers
        private CompositeFigure figures = new CompositeFigure();
        private List<ACommand> _commands = new List<ACommand>();

        private int _current = 0;

        public void Redo(int levels)
        {
            int neededLvl = _current - levels;
            if (neededLvl < 0 || neededLvl >= _current)
            {
                throw new Exception("OLOLO");
            }

            for (int i=0; i<neededLvl; i++)
            {
                _commands[i].Execute();
            }
        }

        public void Undo(int levels)
        {
            int neededLvl = _current - levels;
            if (neededLvl < 0 || neededLvl >= _current)
            {
                throw new Exception("OLOLO");
            }

            for (int i = 0; i < neededLvl; i++)
            {
                _commands[i].Execute();
            }
        }

        internal void Show(AShower shower)
        {
            figures.SetShower(shower);
            figures.Show();
            figures.EndShow();
        }

        private void HandleAddCommand(ACommand command)
        {
            if (_current < _commands.Count)
            {
                _commands.RemoveRange(_current, _commands.Count - _current);
            }
            _commands.Add(command);
            _current++;
        }

        internal void DecorateWithShadow(ref IFigure f)
        {
            ACommand command = new ShadowDecoratorCommand(ref f);
            command.Execute();

            HandleAddCommand(command);
        }

        public void AddFigure(IFigure f)
        {
            ACommand command = new AddFigureCommand(figures, f);
            command.Execute();

            HandleAddCommand(command);
        }
        public void DelFigure(IFigure f)
        {
            ACommand command = new DelFigureCommand(figures, f);
            command.Execute();

            HandleAddCommand(command);
        }
        internal void MakeComposite(params IFigure[] arr)
        {
            ACommand command = new MakeCompositeCommand(figures, arr);
            command.Execute();

            HandleAddCommand(command);
        }
    }
}
