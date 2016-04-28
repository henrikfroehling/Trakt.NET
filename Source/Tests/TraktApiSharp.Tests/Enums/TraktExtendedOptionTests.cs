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
            typeof(TraktExtendedOption).GetEnumNames().Should().HaveCount(12)
                                                      .And.Contain("Unspecified", "Minimal", "Metadata", "Images", "Full", "FullAndImages",
                                                                   "NoSeasons", "MinimalAndNoSeasons", "MetadataAndNoSeasons",
                                                                   "ImagesAndNoSeasons", "FullAndNoSeasons", "FullAndImagesAndNoSeasons");
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
            TraktExtendedOption.NoSeasons.AsString().Should().Be("noseasons");
            TraktExtendedOption.MinimalAndNoSeasons.AsString().Should().Be("min,noseasons");
            TraktExtendedOption.MetadataAndNoSeasons.AsString().Should().Be("metadata,noseasons");
            TraktExtendedOption.ImagesAndNoSeasons.AsString().Should().Be("images,noseasons");
            TraktExtendedOption.FullAndNoSeasons.AsString().Should().Be("full,noseasons");
            TraktExtendedOption.FullAndImagesAndNoSeasons.AsString().Should().Be("full,images,noseasons");
        }
    }
}
