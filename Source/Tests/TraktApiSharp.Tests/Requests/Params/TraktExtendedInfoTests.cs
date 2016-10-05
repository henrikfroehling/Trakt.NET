namespace TraktApiSharp.Tests.Requests.Params
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests.Params;

    [TestClass]
    public class TraktExtendedInfoTests
    {
        [TestMethod]
        public void TestTraktExtendedInfoDefaultConstructor()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.Minimal.Should().BeFalse();
            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendedInfoSetMinimal()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.SetMinimal().Should().BeSameAs(extendedInfo);

            extendedInfo.Minimal.Should().BeTrue();
            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();

            extendedInfo.ResetMinimal().Should().BeSameAs(extendedInfo);

            extendedInfo.Minimal.Should().BeFalse();
            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendedInfoSetMetadata()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.SetMetadata().Should().BeSameAs(extendedInfo);

            extendedInfo.Minimal.Should().BeFalse();
            extendedInfo.Metadata.Should().BeTrue();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();

            extendedInfo.ResetMetadata().Should().BeSameAs(extendedInfo);

            extendedInfo.Minimal.Should().BeFalse();
            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendedInfoSetImages()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.SetImages().Should().BeSameAs(extendedInfo);

            extendedInfo.Minimal.Should().BeFalse();
            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeTrue();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();

            extendedInfo.ResetImages().Should().BeSameAs(extendedInfo);

            extendedInfo.Minimal.Should().BeFalse();
            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendedInfoSetFull()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.SetFull().Should().BeSameAs(extendedInfo);

            extendedInfo.Minimal.Should().BeFalse();
            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeTrue();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();

            extendedInfo.ResetFull().Should().BeSameAs(extendedInfo);

            extendedInfo.Minimal.Should().BeFalse();
            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendedInfoSetNoSeasons()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.SetNoSeasons().Should().BeSameAs(extendedInfo);

            extendedInfo.Minimal.Should().BeFalse();
            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeTrue();
            extendedInfo.Episodes.Should().BeFalse();

            extendedInfo.ResetNoSeasons().Should().BeSameAs(extendedInfo);

            extendedInfo.Minimal.Should().BeFalse();
            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendedInfoSetEpisodes()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.SetEpisodes().Should().BeSameAs(extendedInfo);

            extendedInfo.Minimal.Should().BeFalse();
            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeTrue();

            extendedInfo.ResetEpisodes().Should().BeSameAs(extendedInfo);

            extendedInfo.Minimal.Should().BeFalse();
            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendedInfoHasAnySet()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.HasAnySet.Should().BeFalse();

            extendedInfo.Minimal = true;
            extendedInfo.HasAnySet.Should().BeTrue();

            extendedInfo.Reset();
            extendedInfo.Metadata = true;
            extendedInfo.HasAnySet.Should().BeTrue();

            extendedInfo.Reset();
            extendedInfo.Images = true;
            extendedInfo.HasAnySet.Should().BeTrue();

            extendedInfo.Reset();
            extendedInfo.Full = true;
            extendedInfo.HasAnySet.Should().BeTrue();

            extendedInfo.Reset();
            extendedInfo.NoSeasons = true;
            extendedInfo.HasAnySet.Should().BeTrue();

            extendedInfo.Reset();
            extendedInfo.Episodes = true;
            extendedInfo.HasAnySet.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktExtendedInfoResolve()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.Resolve().Should().NotBeNull().And.BeEmpty();

            extendedInfo.SetMinimal();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(1).And.Contain("min");

            extendedInfo.SetMetadata();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(2).And.Contain("min", "metadata");

            extendedInfo.SetImages();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(3).And.Contain("min", "metadata", "images");

            extendedInfo.SetFull();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(4).And.Contain("min", "metadata", "images", "full");

            extendedInfo.SetNoSeasons();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(5).And.Contain("min", "metadata", "images", "full", "noseasons");

            extendedInfo.SetEpisodes();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(6).And.Contain("min", "metadata", "images", "full", "noseasons", "episodes");
        }

        [TestMethod]
        public void TestTraktExtendedInfoToString()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.ToString().Should().NotBeNull().And.BeEmpty();

            extendedInfo.SetMinimal();
            extendedInfo.ToString().Should().NotBeNull().And.Be("min");

            extendedInfo.SetMetadata();
            extendedInfo.ToString().Should().NotBeNull().And.Be("min,metadata");

            extendedInfo.SetImages();
            extendedInfo.ToString().Should().NotBeNull().And.Be("min,metadata,images");

            extendedInfo.SetFull();
            extendedInfo.ToString().Should().NotBeNull().And.Be("min,metadata,images,full");

            extendedInfo.SetNoSeasons();
            extendedInfo.ToString().Should().NotBeNull().And.Be("min,metadata,images,full,noseasons");

            extendedInfo.SetEpisodes();
            extendedInfo.ToString().Should().NotBeNull().And.Be("min,metadata,images,full,noseasons,episodes");
        }
    }
}
