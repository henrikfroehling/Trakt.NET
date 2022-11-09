namespace Trakt.NET.Tests.Utility.Traits
{
    using System;
    using Xunit.Sdk;

    [TraitDiscoverer(TestCategoryDiscoverer.DiscovererTypeName, "TraktNet.Tests")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public sealed class TestCategoryAttribute : Attribute, ITraitAttribute
    {
        public TestCategoryAttribute(string categoryName)
        {
            Name = categoryName;
        }

        public string Name { get; }
    }
}
