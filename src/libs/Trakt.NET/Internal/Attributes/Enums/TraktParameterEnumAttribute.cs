namespace TraktNET
{
    ///<summary>Provides extension methods for an enum which can be used as a request parameter.</summary>
    [AttributeUsage(AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
    internal sealed class TraktParameterEnumAttribute(string uriParameterName) : TraktEnumAttribute
    {
        public string UriParameterName { get; } = uriParameterName;
    }
}
