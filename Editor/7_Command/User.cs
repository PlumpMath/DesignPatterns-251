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

        private void Clear()
        {
            figures.DelAll();
        }

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

        //public void Compute(char @operator, int operand)
        //{

        //    // Создаем команду операции и выполняем её
        //    Command command = new CalculatorCommand(
        //      _calculator, @operator, operand);
        //    command.Execute();

        //    if (_current < _commands.Count)
        //    {
        //        // если "внутри undo" мы запускаем новую операцию, 
        //        // надо обрубать список команд, следующих после текущей, 
        //        // иначе undo/redo будут некорректны
        //        _commands.RemoveRange(_current, _commands.Count - _current);
        //    }

        //    // Добавляем операцию к списку отмены
        //    _commands.Add(command);
        //    _current++;
        //}

        private void HandleAddCommand(ACommand command)
        {
            if (_current < _commands.Count)
            {
                _commands.RemoveRange(_current, _commands.Count - _current);
            }
            _commands.Add(command);
            _current++;
        }

        internal void DecorateWithShadow(IFigure f)
        {
            ACommand command = new ShadowDecoratorCommand(f);
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
        internal void AddDecorator(IFigure f, ADecorator d)
        {
            ACommand command = new AddDecoratorCommand(f, d);
            command.Execute();

            HandleAddCommand(command);
        }
    }
}
