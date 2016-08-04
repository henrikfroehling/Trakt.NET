namespace TraktApiSharp.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Delegate | AttributeTargets.Event
                    | AttributeTargets.Field | AttributeTargets.Parameter
                    | AttributeTargets.Property | AttributeTargets.ReturnValue)]
    public sealed class NotNullAttribute : Attribute
    {
        public NotNullAttribute() : this("element must not be null") { }

        public NotNullAttribute(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
