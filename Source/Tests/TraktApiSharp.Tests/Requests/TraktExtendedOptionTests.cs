namespace TraktApiSharp.Tests.Requests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests;

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

            extendedOption.ResetMinimal().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
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

            extendedOption.ResetMetadata().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
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

            extendedOption.ResetImages().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
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

            extendedOption.ResetFull().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
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

            extendedOption.ResetNoSeasons().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendedOptionSetAll()
        {
            var extendedOption = new TraktExtendedOption();

            extendedOption.SetAll().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeTrue();
            extendedOption.Metadata.Should().BeTrue();
            extendedOption.Images.Should().BeTrue();
            extendedOption.Full.Should().BeTrue();
            extendedOption.NoSeasons.Should().BeFalse();

            extendedOption.Reset().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktExtendedOptionSetAllAndNoSeasons()
        {
            var extendedOption = new TraktExtendedOption();

            extendedOption.SetAllAndNoSeasons().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeTrue();
            extendedOption.Metadata.Should().BeTrue();
            extendedOption.Images.Should().BeTrue();
            extendedOption.Full.Should().BeTrue();
            extendedOption.NoSeasons.Should().BeTrue();

            extendedOption.Reset().Should().BeSameAs(extendedOption);

            extendedOption.Minimal.Should().BeFalse();
            extendedOption.Metadata.Should().BeFalse();
            extendedOption.Images.Should().BeFalse();
            extendedOption.Full.Should().BeFalse();
            extendedOption.NoSeasons.Should().BeFalse();
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
        }

        [TestMethod]
        public void TestTraktExtendedOptionHasMembers()
        {
            typeof(TraktExtendedOptionOld).GetEnumNames().Should().HaveCount(12)
                                                      .And.Contain("Unspecified", "Minimal", "Metadata", "Images", "Full", "FullAndImages",
                                                                   "NoSeasons", "MinimalAndNoSeasons", "MetadataAndNoSeasons",
                                                                   "ImagesAndNoSeasons", "FullAndNoSeasons", "FullAndImagesAndNoSeasons");
        }

        [TestMethod]
        public void TestTraktExtendedOptionGetAsString()
        {
            TraktExtendedOptionOld.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktExtendedOptionOld.Minimal.AsString().Should().Be("min");
            TraktExtendedOptionOld.Metadata.AsString().Should().Be("metadata");
            TraktExtendedOptionOld.Images.AsString().Should().Be("images");
            TraktExtendedOptionOld.Full.AsString().Should().Be("full");
            TraktExtendedOptionOld.FullAndImages.AsString().Should().Be("full,images");
            TraktExtendedOptionOld.NoSeasons.AsString().Should().Be("noseasons");
            TraktExtendedOptionOld.MinimalAndNoSeasons.AsString().Should().Be("min,noseasons");
            TraktExtendedOptionOld.MetadataAndNoSeasons.AsString().Should().Be("metadata,noseasons");
            TraktExtendedOptionOld.ImagesAndNoSeasons.AsString().Should().Be("images,noseasons");
            TraktExtendedOptionOld.FullAndNoSeasons.AsString().Should().Be("full,noseasons");
            TraktExtendedOptionOld.FullAndImagesAndNoSeasons.AsString().Should().Be("full,images,noseasons");
        }
    }
}
