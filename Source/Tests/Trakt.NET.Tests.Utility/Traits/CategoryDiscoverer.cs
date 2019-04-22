namespace Trakt.NET.Tests.Utility.Traits
{
    using System.Collections.Generic;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    public sealed class CategoryDiscoverer : ITraitDiscoverer
    {
        internal const string DiscovererTypeName = "TraktNet.Tests" + "." + nameof(Traits) + "." + nameof(CategoryDiscoverer);

        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var categoryName = traitAttribute.GetNamedArgument<string>("Name");

            if (!string.IsNullOrWhiteSpace(categoryName))
                yield return new KeyValuePair<string, string>("Category", categoryName);
        }
    }
}
