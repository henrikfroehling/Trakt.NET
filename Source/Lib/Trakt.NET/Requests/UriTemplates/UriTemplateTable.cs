namespace UriTemplates
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// See <a href="https://github.com/tavis-software/Tavis.UriTemplates/blob/master/src/UriTemplates/UriTemplateTable.cs" />
    /// </summary>
    internal class UriTemplateTable
    {
        private Dictionary<string, UriTemplate> _Templates = new Dictionary<string, UriTemplate>();

        internal void Add(string key, UriTemplate template)
        {
            _Templates.Add(key, template);
        }

        internal TemplateMatch Match(Uri url)
        {
            foreach (var template in _Templates)
            {
                var parameters = template.Value.GetParameters(url);

                if (parameters != null)
                    return new TemplateMatch() { Key = template.Key, Parameters = parameters, Template = template.Value };
            }

            return null;
        }

        internal UriTemplate this[string key]
        {
            get
            {
                UriTemplate value;

                if (_Templates.TryGetValue(key, out value))
                    return value;
                else
                    return null;
            }
        }
    }

    internal class TemplateMatch
    {
        internal string Key { get; set; }
        internal UriTemplate Template { get; set; }
        internal IDictionary<string, object> Parameters { get; set; }
    }
}
