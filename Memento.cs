using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class Memento
    {
        // Memento: Represents the state to be stored or restored
        public class TextMemento
        {
            public string Text { get; }

            public TextMemento(string text)
            {
                Text = text;
            }
        }

        // Originator: Object whose state needs to be saved
        public class TextEditor
        {
            private string _text;

            public string Text
            {
                get => _text;
                set
                {
                    _text = value;
                    Console.WriteLine($"Text set to: {value}");
                }
            }

            public TextMemento Save()
            {
                return new TextMemento(_text);
            }

            public void Restore(TextMemento memento)
            {
                _text = memento.Text;
                Console.WriteLine($"Text restored to: {_text}");
            }
        }

        // Caretaker: Manages and keeps track of multiple mementos
        public class TextEditorHistory
        {
            private readonly Stack<TextMemento> _history = new Stack<TextMemento>();

            public void Push(TextMemento memento)
            {
                _history.Push(memento);
            }

            public TextMemento Pop()
            {
                return _history.Pop();
            }
        }
        //----------------------------------------------------------------
        // Memento: Represents the state to be stored or restored
        public class SettingsMemento
        {
            public string Theme { get; }
            public int FontSize { get; }

            public SettingsMemento(string theme, int fontSize)
            {
                Theme = theme;
                FontSize = fontSize;
            }
        }

        // Originator: Object whose state needs to be saved
        public class SettingsManager
        {
            public string Theme { get; set; }
            public int FontSize { get; set; }

            public SettingsMemento Save()
            {
                return new SettingsMemento(Theme, FontSize);
            }

            public void Restore(SettingsMemento memento)
            {
                Theme = memento.Theme;
                FontSize = memento.FontSize;
                Console.WriteLine($"Settings restored - Theme: {Theme}, FontSize: {FontSize}");
            }
        }

        // Caretaker: Manages and keeps track of multiple mementos
        public class SettingsHistory
        {
            private SettingsMemento _memento;

            public SettingsMemento Memento
            {
                get => _memento;
                set => _memento = value;
            }
        }
    }
}
