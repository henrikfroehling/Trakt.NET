namespace UriTemplates
{
    /// <summary>
    /// See <a href="https://github.com/tavis-software/Tavis.UriTemplates/blob/master/src/UriTemplates/UriTemplateExtensions.cs" />
    /// </summary>
    internal static class UriTemplateExtensions
    {
        internal static UriTemplate AddParameterFromKeyValuePair(this UriTemplate template, string name, object value)
        {
            template.SetParameter(name, value);
            return template;
        }
    }
}
