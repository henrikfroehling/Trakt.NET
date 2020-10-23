namespace Trakt.NET.Tests.Utility.Traits
{
    using System;
    using Xunit.Sdk;

    [TraitDiscoverer(CategoryDiscoverer.DiscovererTypeName, "TraktNet.Tests")]
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
