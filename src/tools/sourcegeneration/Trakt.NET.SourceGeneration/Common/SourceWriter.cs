using Microsoft.CodeAnalysis.Text;
using System.Diagnostics;
using System.Text;

namespace TraktNET.SourceGeneration.Common
{
    internal sealed class SourceWriter
    {
        private const char IndentationChar = ' ';
        private const uint CharsPerIndentation = 4;

        private readonly StringBuilder _stringBuilder = new();

        public uint Indentation { get; set; }

        public void Indent() => Indentation++;

        public void DecrementIndent() => Indentation--;

        public void WriteLine(char value)
        {
            WriteIndendation();
            _stringBuilder.Append(value);
            _stringBuilder.AppendLine();
        }

        public void WriteLine(string text)
        {
            WriteIndendation();
            _stringBuilder.Append(text);
            _stringBuilder.AppendLine();
        }

        public void WriteEmptyLine() => _stringBuilder.AppendLine();

        public SourceText ToSourceText()
        {
            Debug.Assert(Indentation == 0 && _stringBuilder.Length > 0);
            return SourceText.From(_stringBuilder.ToString(), Encoding.UTF8);
        }

        private void WriteIndendation() => _stringBuilder.Append(IndentationChar, (int)(CharsPerIndentation * Indentation));
    }
}
