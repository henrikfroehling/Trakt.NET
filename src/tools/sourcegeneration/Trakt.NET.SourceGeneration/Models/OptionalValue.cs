namespace TraktNET.SourceGeneration.Models
{
    public readonly struct OptionalValue<T>(T value)
    {
        public readonly bool HasValue = true;

        public readonly T Value = value;
    }
}
