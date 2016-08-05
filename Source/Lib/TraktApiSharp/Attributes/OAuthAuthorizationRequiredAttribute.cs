namespace TraktApiSharp.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class OAuthAuthorizationRequiredAttribute : Attribute
    {
        public OAuthAuthorizationRequiredAttribute() : this(true) { }

        public OAuthAuthorizationRequiredAttribute(bool required)
        {
            Required = required;
        }

        public string Message => Required ? "OAuth authorization is required" : "OAuth authorization is not required";

        public bool Required { get; }
    }
}
