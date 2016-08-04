namespace TraktApiSharp.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class OAuthAuthorizationOptionalAttribute : Attribute
    {
        public OAuthAuthorizationOptionalAttribute() : this("OAuth authorization is optional") { }

        public OAuthAuthorizationOptionalAttribute(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
