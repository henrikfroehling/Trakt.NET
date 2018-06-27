namespace UriTemplates
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// See <a href="https://github.com/tavis-software/Tavis.UriTemplates/blob/master/src/UriTemplates/UriTemplateTable.cs" />
    /// </summary>
    internal class UriTemplateTable
    {
        private readonly Dictionary<string, UriTemplate> _Templates = new Dictionary<string, UriTemplate>();

        internal void Add(string key, UriTemplate template)
        {
            _Templates.Add(key, template);
        }

        internal TemplateMatch Match(Uri url)
        {
            foreach (KeyValuePair<string, UriTemplate> template in _Templates)
            {
                IDictionary<string, object> parameters = template.Value.GetParameters(url);

                if (parameters != null)
                    return new TemplateMatch() { Key = template.Key, Parameters = parameters, Template = template.Value };
            }

            return null;
        }

        internal UriTemplate this[string key]
        {
            get
            {
                if (_Templates.TryGetValue(key, out UriTemplate value))
                    return value;
                else
                    return null;
            }
        }
    }
}
