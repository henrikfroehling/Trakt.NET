using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace TraktNET.SourceGeneration.Common
{
    public abstract class SourceEmitter<T>(SourceProductionContext context)
    {
        protected readonly SourceProductionContext _context = context;

        public abstract void Emit(T generationSpecification);

        protected void AddSource(string name, SourceText sourceText) => _context.AddSource(name, sourceText);
    }
}
