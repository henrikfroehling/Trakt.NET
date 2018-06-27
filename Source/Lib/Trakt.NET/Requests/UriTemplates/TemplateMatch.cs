namespace UriTemplates
{
    using System.Collections.Generic;

    /// <summary>
    /// See <a href="https://github.com/tavis-software/Tavis.UriTemplates/blob/master/src/UriTemplates/UriTemplateTable.cs" />
    /// </summary>
    internal class TemplateMatch
    {
        internal string Key { get; set; }

        internal UriTemplate Template { get; set; }

        internal IDictionary<string, object> Parameters { get; set; }
    }
}
