namespace TraktNET
{
    /// <summary>Provides a custom Json value and optional display name for an enum member.</summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    internal sealed class TraktEnumMemberAttribute(string jsonValue) : Attribute
    {
        public string JsonValue { get; } = jsonValue;

        public string? DisplayName { get; set; }
    }
}
