namespace TraktApiSharp.Tests.Traits
{
    using System;
    using Xunit.Sdk;

    [TraitDiscoverer(CategoryDiscoverer.DiscovererTypeName, DiscovererUtils.AssemblyName)]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public sealed class CategoryAttribute : Attribute, ITraitAttribute
    {
        public CategoryAttribute(string categoryName)
        {
            Name = categoryName;
        }

        public string Name { get; }
    }
}
