namespace TraktApiSharp.Tests.Requests.Params
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests.Params;

    [TestClass]
    public class TraktExtendedOptionTests
    {
        [TestMethod]
        public void TestTraktExtendedOptionDefaultConstructor()
        {
            var extendedOption = new TraktExtendedOption();

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
            extendedOption.Episodes.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendendOptionSetMinimal()
        {
            var extendedOption = new TraktExtendedOption();

            extendedOption.SetMinimal().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeTrue();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
            extendedOption.Episodes.Should().BeFalse();

            extendedOption.ResetMinimal().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
            extendedOption.Episodes.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendedOptionSetMetadata()
        {
            var extendedOption = new TraktExtendedOption();

            extendedOption.SetMetadata().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeTrue();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
            extendedOption.Episodes.Should().BeFalse();

            extendedOption.ResetMetadata().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
            extendedOption.Episodes.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendedOptionSetImages()
        {
            var extendedOption = new TraktExtendedOption();

            extendedOption.SetImages().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeTrue();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
            extendedOption.Episodes.Should().BeFalse();

            extendedOption.ResetImages().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
            extendedOption.Episodes.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendedOptionSetFull()
        {
            var extendedOption = new TraktExtendedOption();

            extendedOption.SetFull().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeTrue();
            extendedOption.NoSeasons.Should().BeFalse();
            extendedOption.Episodes.Should().BeFalse();

            extendedOption.ResetFull().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
            extendedOption.Episodes.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendedOptionSetNoSeasons()
        {
            var extendedOption = new TraktExtendedOption();

            extendedOption.SetNoSeasons().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeTrue();
            extendedOption.Episodes.Should().BeFalse();

            extendedOption.ResetNoSeasons().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
            extendedOption.Episodes.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendedOptionSetEpisodes()
        {
            var extendedOption = new TraktExtendedOption();

            extendedOption.SetEpisodes().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
            extendedOption.Episodes.Should().BeTrue();

            extendedOption.ResetEpisodes().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
            extendedOption.Episodes.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendedOptionHasAnySet()
        {
            var extendedOption = new TraktExtendedOption();

            extendedOption.HasAnySet.Should().BeFalse();

            extendedOption.Minimal = true;
            extendedOption.HasAnySet.Should().BeTrue();

            extendedOption.Reset();
            extendedOption.Metadata = true;
            extendedOption.HasAnySet.Should().BeTrue();

            extendedOption.Reset();
            extendedOption.Images = true;
            extendedOption.HasAnySet.Should().BeTrue();

            extendedOption.Reset();
            extendedOption.Full = true;
            extendedOption.HasAnySet.Should().BeTrue();

            extendedOption.Reset();
            extendedOption.NoSeasons = true;
            extendedOption.HasAnySet.Should().BeTrue();

            extendedOption.Reset();
            extendedOption.Episodes = true;
            extendedOption.HasAnySet.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktExtendedOptionResolve()
        {
            var extendedOption = new TraktExtendedOption();

            extendedOption.Resolve().Should().NotBeNull().And.BeEmpty();

            extendedOption.SetMinimal();
            extendedOption.Resolve().Should().NotBeNull().And.HaveCount(1).And.Contain("min");

            extendedOption.SetMetadata();
            extendedOption.Resolve().Should().NotBeNull().And.HaveCount(2).And.Contain("min", "metadata");

            extendedOption.SetImages();
            extendedOption.Resolve().Should().NotBeNull().And.HaveCount(3).And.Contain("min", "metadata", "images");

            extendedOption.SetFull();
            extendedOption.Resolve().Should().NotBeNull().And.HaveCount(4).And.Contain("min", "metadata", "images", "full");

            extendedOption.SetNoSeasons();
            extendedOption.Resolve().Should().NotBeNull().And.HaveCount(5).And.Contain("min", "metadata", "images", "full", "noseasons");

            extendedOption.SetEpisodes();
            extendedOption.Resolve().Should().NotBeNull().And.HaveCount(6).And.Contain("min", "metadata", "images", "full", "noseasons", "episodes");
        }

        [TestMethod]
        public void TestTraktExtendedOptionToString()
        {
            var extendedOption = new TraktExtendedOption();

            extendedOption.ToString().Should().NotBeNull().And.BeEmpty();

            extendedOption.SetMinimal();
            extendedOption.ToString().Should().NotBeNull().And.Be("min");

            extendedOption.SetMetadata();
            extendedOption.ToString().Should().NotBeNull().And.Be("min,metadata");

            extendedOption.SetImages();
            extendedOption.ToString().Should().NotBeNull().And.Be("min,metadata,images");

            extendedOption.SetFull();
            extendedOption.ToString().Should().NotBeNull().And.Be("min,metadata,images,full");

            extendedOption.SetNoSeasons();
            extendedOption.ToString().Should().NotBeNull().And.Be("min,metadata,images,full,noseasons");

            extendedOption.SetEpisodes();
            extendedOption.ToString().Should().NotBeNull().And.Be("min,metadata,images,full,noseasons,episodes");
        }
    }
}
