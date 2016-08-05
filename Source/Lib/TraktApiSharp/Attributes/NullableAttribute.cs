namespace TraktApiSharp.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Delegate | AttributeTargets.Event
                    | AttributeTargets.Field | AttributeTargets.Parameter
                    | AttributeTargets.Property | AttributeTargets.ReturnValue)]
    public sealed class NullableAttribute : Attribute
    {
        public NullableAttribute() : this("element might be null") { }

        public NullableAttribute(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
