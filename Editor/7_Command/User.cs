using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
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
                throw new Exception("Wrong User.Redo(lvl)");
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
                throw new Exception("Wrong User.Undo(lvl)");
            }

            for (int i = 0; i < neededLvl; i++)
            {
                _commands[i].Execute();
            }
        }



        internal void Show(AShower shower)
        {
            shower.Clean();

            IFigure fc = figures.Clone();
            fc.SetShower(shower);
            fc.Show();
            fc.EndShow();

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

        internal void DecorateWithShadow(int ind)
        {
            IFigure f = figures.Get(ind);

            ACommand command = new ShadowDecoratorCommand(figures, f);
            command.Execute();

            HandleAddCommand(command);
        }
        internal void DecorateWithBorder(int ind)
        {
            IFigure f = figures.Get(ind);

            ACommand command = new BorderDecoratorCommand(figures, f);
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
        internal void MakeComposite(params int[] indices)
        {
            IFigure[] arr = new IFigure[indices.Length];
            for (int i=0; i<indices.Length; i++)
                arr[i] = figures.Get(indices[i]);

            ACommand command = new MakeCompositeCommand(figures, arr);
            command.Execute();

            HandleAddCommand(command);
        }
    }
}
