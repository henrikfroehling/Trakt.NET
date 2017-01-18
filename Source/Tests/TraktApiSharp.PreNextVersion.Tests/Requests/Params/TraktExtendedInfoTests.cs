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

            extendedInfo.Metadata.Should().BeTrue();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();

            extendedInfo.ResetMetadata().Should().BeSameAs(extendedInfo);

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

            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeTrue();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();

            extendedInfo.ResetImages().Should().BeSameAs(extendedInfo);

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

            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeTrue();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();

            extendedInfo.ResetFull().Should().BeSameAs(extendedInfo);

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

            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeTrue();
            extendedInfo.Episodes.Should().BeFalse();

            extendedInfo.ResetNoSeasons().Should().BeSameAs(extendedInfo);

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

            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Images.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeTrue();

            extendedInfo.ResetEpisodes().Should().BeSameAs(extendedInfo);

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

            extendedInfo.SetMetadata();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(1).And.Contain("metadata");

            extendedInfo.SetImages();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(2).And.Contain("metadata", "images");

            extendedInfo.SetFull();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(3).And.Contain("metadata", "images", "full");

            extendedInfo.SetNoSeasons();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(4).And.Contain("metadata", "images", "full", "noseasons");

            extendedInfo.SetEpisodes();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(5).And.Contain("metadata", "images", "full", "noseasons", "episodes");
        }

        [TestMethod]
        public void TestTraktExtendedInfoToString()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.ToString().Should().NotBeNull().And.BeEmpty();

            extendedInfo.SetMetadata();
            extendedInfo.ToString().Should().NotBeNull().And.Be("metadata");

            extendedInfo.SetImages();
            extendedInfo.ToString().Should().NotBeNull().And.Be("metadata,images");

            extendedInfo.SetFull();
            extendedInfo.ToString().Should().NotBeNull().And.Be("metadata,images,full");

            extendedInfo.SetNoSeasons();
            extendedInfo.ToString().Should().NotBeNull().And.Be("metadata,images,full,noseasons");

            extendedInfo.SetEpisodes();
            extendedInfo.ToString().Should().NotBeNull().And.Be("metadata,images,full,noseasons,episodes");
        }
    }
}
