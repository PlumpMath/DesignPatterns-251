using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class User
    {
        // Initializers
        private CompositeFigure figures = new CompositeFigure();
        private List<ACommand> _commands = new List<ACommand>();

        private int _current = 0;

        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);

            // Делаем возврат операций
            for (int i = 0; i < levels; i++)
                if (_current < _commands.Count)
                    _commands[_current++].Execute();
        }

        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);

            // Делаем отмену операций
            for (int i = 0; i < levels; i++)
                if (_current > 0)
                    _commands[--_current].UnExecute();
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
