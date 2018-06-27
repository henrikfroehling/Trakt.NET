namespace UriTemplates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// See <a href="https://github.com/tavis-software/Tavis.UriTemplates/blob/master/src/UriTemplates/UriTemplateExtensions.cs" />
    /// </summary>
    internal static class UriExtensions
    {
        internal static UriTemplate MakeTemplate(this Uri uri)
        {
            Dictionary<string, object> parameters = uri.GetQueryStringParameters();
            return MakeTemplate(uri, parameters);
        }

        internal static UriTemplate MakeTemplate(this Uri uri, IDictionary<string, object> parameters)
        {
            string target = uri.GetComponents(UriComponents.AbsoluteUri & ~UriComponents.Query & ~UriComponents.Fragment, UriFormat.Unescaped);
            UriTemplate template = new UriTemplate(target + "{?" + string.Join(",", parameters.Keys.ToArray()) + "}");
            template.AddParametersFromDictionary(parameters);
            return template;
        }

        internal static Dictionary<string, object> GetQueryStringParameters(this Uri target)
        {
            Uri uri = target;
            var parameters = new Dictionary<string, object>();
            var reg = new Regex("([-A-Za-z0-9._~]*)=([^&]*)&?"); // Unreserved characters: http://tools.ietf.org/html/rfc3986#section-2.3

            foreach (Match m in reg.Matches(uri.Query))
            {
                string key = m.Groups[1].Value.ToLowerInvariant();
                string value = m.Groups[2].Value;
                parameters.Add(key, value);
            }

            return parameters;
        }
    }
}
