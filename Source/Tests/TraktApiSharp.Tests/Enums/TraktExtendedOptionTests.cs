namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktExtendedOptionTests
    {
        [TestMethod]
        public void TestTraktExtendedOptionHasMembers()
        {
            typeof(TraktExtendedOption).GetEnumNames().Should().HaveCount(6)
                                                      .And.Contain("Unspecified", "Minimal", "Metadata", "Images", "Full", "FullAndImages");
        }

        [TestMethod]
        public void TestTraktExtendedOptionGetAsString()
        {
            TraktExtendedOption.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktExtendedOption.Minimal.AsString().Should().Be("min");
            TraktExtendedOption.Metadata.AsString().Should().Be("metadata");
            TraktExtendedOption.Images.AsString().Should().Be("images");
            TraktExtendedOption.Full.AsString().Should().Be("full");
            TraktExtendedOption.FullAndImages.AsString().Should().Be("full,images");
        }
    }
}
