namespace UriTemplates
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

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
                TypeInfo type = parametersObject.GetType().GetTypeInfo();
                properties = type.DeclaredProperties.Where(p => p.CanRead);

                foreach (PropertyInfo propinfo in properties)
                    template.SetParameter(propinfo.Name, propinfo.GetValue(parametersObject, null));
            }

            return template;
        }

        internal static UriTemplate AddParametersFromDictionary(this UriTemplate uriTemplate, IDictionary<string, object> linkParameters)
        {
            if (linkParameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in linkParameters)
                    uriTemplate.SetParameter(parameter.Key, parameter.Value);
            }

            return uriTemplate;
        }
    }
}
