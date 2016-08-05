namespace UriTemplates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

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

        internal static UriTemplate AddParameters(this UriTemplate template, object parametersObject)
        {
            if (parametersObject != null)
            {
                IEnumerable<PropertyInfo> properties;

                var type = parametersObject.GetType().GetTypeInfo();
                properties = type.DeclaredProperties.Where(p => p.CanRead);

                foreach (var propinfo in properties)
                    template.SetParameter(propinfo.Name, propinfo.GetValue(parametersObject, null));
            }

            return template;
        }

        internal static UriTemplate AddParametersFromDictionary(this UriTemplate uriTemplate, IDictionary<string, object> linkParameters)
        {
            if (linkParameters != null)
            {
                foreach (var parameter in linkParameters)
                    uriTemplate.SetParameter(parameter.Key, parameter.Value);
            }

            return uriTemplate;
        }
    }

    internal static class UriExtensions
    {
        internal static UriTemplate MakeTemplate(this Uri uri)
        {
            var parameters = uri.GetQueryStringParameters();
            return MakeTemplate(uri, parameters);
        }

        internal static UriTemplate MakeTemplate(this Uri uri, IDictionary<string, object> parameters)
        {
            var target = uri.GetComponents(UriComponents.AbsoluteUri
                                                     & ~UriComponents.Query
                                                     & ~UriComponents.Fragment, UriFormat.Unescaped);

            var template = new UriTemplate(target + "{?" + string.Join(",", parameters.Keys.ToArray()) + "}");
            template.AddParametersFromDictionary(parameters);

            return template;
        }

        internal static Dictionary<string, object> GetQueryStringParameters(this Uri target)
        {
            Uri uri = target;
            var parameters = new Dictionary<string, object>();

            var reg = new Regex(@"([-A-Za-z0-9._~]*)=([^&]*)&?"); // Unreserved characters: http://tools.ietf.org/html/rfc3986#section-2.3

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
