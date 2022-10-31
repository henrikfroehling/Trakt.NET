namespace TraktNet.Requests.Tests.Parameters
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Parameters;
    using Xunit;

    [TestCategory("Requests.Parameters")]
    public class TraktExtendedInfo_Tests
    {
        [Fact]
        public void Test_TraktExtendedInfo_Default_Constructor()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
            extendedInfo.GuestStars.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktExtendedInfo_SetMetadata()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.SetMetadata().Should().BeSameAs(extendedInfo);

            extendedInfo.Metadata.Should().BeTrue();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
            extendedInfo.GuestStars.Should().BeFalse();

            extendedInfo.ResetMetadata().Should().BeSameAs(extendedInfo);

            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
            extendedInfo.GuestStars.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktExtendedInfo_SetFull()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.SetFull().Should().BeSameAs(extendedInfo);

            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Full.Should().BeTrue();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
            extendedInfo.GuestStars.Should().BeFalse();

            extendedInfo.ResetFull().Should().BeSameAs(extendedInfo);

            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
            extendedInfo.GuestStars.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktExtendedInfo_SetNoSeasons()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.SetNoSeasons().Should().BeSameAs(extendedInfo);

            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeTrue();
            extendedInfo.Episodes.Should().BeFalse();
            extendedInfo.GuestStars.Should().BeFalse();

            extendedInfo.ResetNoSeasons().Should().BeSameAs(extendedInfo);

            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
            extendedInfo.GuestStars.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktExtendedInfo_SetEpisodes()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.SetEpisodes().Should().BeSameAs(extendedInfo);

            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeTrue();
            extendedInfo.GuestStars.Should().BeFalse();

            extendedInfo.ResetEpisodes().Should().BeSameAs(extendedInfo);

            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
            extendedInfo.GuestStars.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktExtendedInfo_SetGuestStars()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.SetGuestStars().Should().BeSameAs(extendedInfo);

            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
            extendedInfo.GuestStars.Should().BeTrue();

            extendedInfo.ResetGuestStars().Should().BeSameAs(extendedInfo);

            extendedInfo.Metadata.Should().BeFalse();
            extendedInfo.Full.Should().BeFalse();
            extendedInfo.NoSeasons.Should().BeFalse();
            extendedInfo.Episodes.Should().BeFalse();
            extendedInfo.GuestStars.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktExtendedInfo_HasAnySet()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.HasAnySet.Should().BeFalse();

            extendedInfo.Metadata = true;
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

            extendedInfo.Reset();
            extendedInfo.GuestStars = true;
            extendedInfo.HasAnySet.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktExtendedInfo_Resolve()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.Resolve().Should().NotBeNull().And.BeEmpty();

            extendedInfo.SetMetadata();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(1).And.Contain("metadata");

            extendedInfo.SetFull();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(2).And.Contain("metadata", "full");

            extendedInfo.SetNoSeasons();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(3).And.Contain("metadata", "full", "noseasons");

            extendedInfo.SetEpisodes();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(4).And.Contain("metadata", "full", "noseasons", "episodes");

            extendedInfo.SetGuestStars();
            extendedInfo.Resolve().Should().NotBeNull().And.HaveCount(5).And.Contain("metadata", "full", "noseasons", "episodes", "guest_stars");
        }

        [Fact]
        public void Test_TraktExtendedInfo_ToString()
        {
            var extendedInfo = new TraktExtendedInfo();

            extendedInfo.ToString().Should().NotBeNull().And.BeEmpty();

            extendedInfo.SetMetadata();
            extendedInfo.ToString().Should().NotBeNull().And.Be("metadata");

            extendedInfo.SetFull();
            extendedInfo.ToString().Should().NotBeNull().And.Be("metadata,full");

            extendedInfo.SetNoSeasons();
            extendedInfo.ToString().Should().NotBeNull().And.Be("metadata,full,noseasons");

            extendedInfo.SetEpisodes();
            extendedInfo.ToString().Should().NotBeNull().And.Be("metadata,full,noseasons,episodes");

            extendedInfo.SetGuestStars();
            extendedInfo.ToString().Should().NotBeNull().And.Be("metadata,full,noseasons,episodes,guest_stars");
        }
    }
}
