using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class Command
    {

        // Command Interface
        public interface IEditorCommand
        {
            void Execute();
            void Undo();
        }

        // Concrete Command 1: CutCommand
        public class CutCommand : IEditorCommand
        {
            private readonly Editor _editor;
            private string _text;

            public CutCommand(Editor editor)
            {
                _editor = editor;
            }

            public void Execute()
            {
                _text = _editor.GetSelectedText();
                _editor.DeleteSelectedText();
            }

            public void Undo()
            {
                _editor.InsertText(_text);
            }
        }

        // Concrete Command 2: PasteCommand
        public class PasteCommand : IEditorCommand
        {
            private readonly Editor _editor;
            private string _text;

            public PasteCommand(Editor editor, string text)
            {
                _editor = editor;
                _text = text;
            }

            public void Execute()
            {
                _editor.InsertText(_text);
            }

            public void Undo()
            {
                _editor.DeleteSelectedText();
            }
        }

        // Receiver
        public class Editor
        {
            private string _text = "";

            public void InsertText(string text)
            {
                _text += text;
                Console.WriteLine($"Text inserted: {text}");
            }

            public void DeleteSelectedText()
            {
                // For simplicity, just clear the text here
                _text = "";
                Console.WriteLine("Text deleted");
            }

            public string GetSelectedText()
            {
                return _text;
            }
        }

        // Invoker
        public class TextEditor1
        {
            private readonly Stack<IEditorCommand> _commands = new Stack<IEditorCommand>();

            public void ExecuteCommand(IEditorCommand command)
            {
                _commands.Push(command);
                command.Execute();
            }

            public void Undo()
            {
                if (_commands.Count > 0)
                {
                    var command = _commands.Pop();
                    command.Undo();
                }
                else
                {
                    Console.WriteLine("Nothing to undo");
                }
            }
        }
        //--    -----------------------------------------------------------------
        // Command Interface
        public interface ICommand
        {
            void Execute();
        }

        // Concrete Command 1: TurnOnCommand
        public class TurnOnCommand : ICommand
        {
            private readonly Light _light;

            public TurnOnCommand(Light light)
            {
                _light = light;
            }

            public void Execute()
            {
                _light.TurnOn();
            }
        }

        // Concrete Command 2: TurnOffCommand
        public class TurnOffCommand : ICommand
        {
            private readonly Light _light;

            public TurnOffCommand(Light light)
            {
                _light = light;
            }

            public void Execute()
            {
                _light.TurnOff();
            }
        }

        // Receiver
        public class Light
        {
            public void TurnOn()
            {
                Console.WriteLine("Light is ON");
            }

            public void TurnOff()
            {
                Console.WriteLine("Light is OFF");
            }
        }

        // Invoker
        public class RemoteControl
        {
            private ICommand _command;

            public void SetCommand(ICommand command)
            {
                _command = command;
            }

            public void PressButton()
            {
                _command?.Execute();
            }
        }

    }
}
