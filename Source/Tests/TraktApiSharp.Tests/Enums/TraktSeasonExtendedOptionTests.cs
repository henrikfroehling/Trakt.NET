namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons;

    [TestClass]
    public class TraktSeasonExtendedOptionTests
    {
        [TestMethod]
        public void TestTraktSeasonExtendedOptionHasMembers()
        {
            typeof(TraktSeasonExtendedOption).GetEnumNames().Should().HaveCount(11)
                                                      .And.Contain("Unspecified", "Minimal", "Metadata", "Images", "Full", "FullAndImages",
                                                                   "MinimalAndEpisodes", "MetadataAndEpisodes", "ImagesAndEpisodes",
                                                                   "FullAndEpisodes", "FullAndImagesAndEpisodes");
        }

        [TestMethod]
        public void TestTraktSeasonExtendedOptionGetAsString()
        {
            TraktSeasonExtendedOption.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktSeasonExtendedOption.Minimal.AsString().Should().Be("min");
            TraktSeasonExtendedOption.Metadata.AsString().Should().Be("metadata");
            TraktSeasonExtendedOption.Images.AsString().Should().Be("images");
            TraktSeasonExtendedOption.Full.AsString().Should().Be("full");
            TraktSeasonExtendedOption.FullAndImages.AsString().Should().Be("full,images");
            TraktSeasonExtendedOption.MinimalAndEpisodes.AsString().Should().Be("min,episodes");
            TraktSeasonExtendedOption.MetadataAndEpisodes.AsString().Should().Be("metadata,episodes");
            TraktSeasonExtendedOption.ImagesAndEpisodes.AsString().Should().Be("images,episodes");
            TraktSeasonExtendedOption.FullAndEpisodes.AsString().Should().Be("full,episodes");
            TraktSeasonExtendedOption.FullAndImagesAndEpisodes.AsString().Should().Be("full,images,episodes");
        }
    }
}
