namespace TraktApiSharp.Tests.Objects.Get.Collection
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Collection;
    using Utils;

    [TestClass]
    public class TraktCollectionShowTests
    {
        [TestMethod]
        public void TestTraktCollectionShowDefaultConstructor()
        {
            var collectionShow = new TraktCollectionShow();

            collectionShow.LastCollectedAt.Should().NotHaveValue();
            collectionShow.Show.Should().BeNull();
            collectionShow.Seasons.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktCollectionShowReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Collection\CollectionShows.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var collectionShows = JsonConvert.DeserializeObject<IEnumerable<TraktCollectionShow>>(jsonFile);

            collectionShows.Should().NotBeNull();

            var shows = collectionShows.ToArray();

            // Show 1
            shows[0].LastCollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            shows[0].Show.Should().NotBeNull();
            shows[0].Show.Title.Should().Be("Breaking Bad");
            shows[0].Show.Year.Should().Be(2008);
            shows[0].Show.Ids.Should().NotBeNull();
            shows[0].Show.Ids.Trakt.Should().Be(1U);
            shows[0].Show.Ids.Slug.Should().Be("breaking-bad");
            shows[0].Show.Ids.Tvdb.Should().Be(81189U);
            shows[0].Show.Ids.Imdb.Should().Be("tt0903747");
            shows[0].Show.Ids.Tmdb.Should().Be(1396U);
            shows[0].Show.Ids.TvRage.Should().Be(18164U);
            shows[0].Seasons.Should().NotBeNull();
            shows[0].Seasons.Should().HaveCount(2);

            var seasons0 = shows[0].Seasons.ToArray();

            // Season 1 of Show 1
            seasons0[0].Number.Should().Be(1);
            seasons0[0].Episodes.Should().NotBeNull();
            seasons0[0].Episodes.Should().HaveCount(2);

            // Episodes of Season 1 of Show 1
            var episodes00 = seasons0[0].Episodes.ToArray();

            episodes00[0].Number.Should().Be(1);
            episodes00[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes00[0].Metadata.Should().BeNull();

            episodes00[1].Number.Should().Be(2);
            episodes00[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes00[1].Metadata.Should().BeNull();

            // Season 2 of Show 1
            seasons0[1].Number.Should().Be(2);
            seasons0[1].Episodes.Should().NotBeNull();
            seasons0[1].Episodes.Should().HaveCount(2);

            // Episodes of Season 2 of Show 1
            var episodes01 = seasons0[1].Episodes.ToArray();

            episodes01[0].Number.Should().Be(1);
            episodes01[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes01[0].Metadata.Should().BeNull();

            episodes01[1].Number.Should().Be(2);
            episodes01[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes01[1].Metadata.Should().BeNull();

            // -----------------------------------

            // Show 2
            shows[1].LastCollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            shows[1].Show.Should().NotBeNull();
            shows[1].Show.Title.Should().Be("The Walking Dead");
            shows[1].Show.Year.Should().Be(2010);
            shows[1].Show.Ids.Should().NotBeNull();
            shows[1].Show.Ids.Trakt.Should().Be(2U);
            shows[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            shows[1].Show.Ids.Tvdb.Should().Be(153021U);
            shows[1].Show.Ids.Imdb.Should().Be("tt1520211");
            shows[1].Show.Ids.Tmdb.Should().Be(1402U);
            shows[1].Show.Ids.TvRage.Should().BeNull();
            shows[1].Seasons.Should().NotBeNull();
            shows[1].Seasons.Should().HaveCount(2);

            var seasons1 = shows[1].Seasons.ToArray();

            // Season 1 of Show 2
            seasons1[0].Number.Should().Be(1);
            seasons1[0].Episodes.Should().NotBeNull();
            seasons1[0].Episodes.Should().HaveCount(2);

            // Episodes of Season 1 of Show 2
            var episodes10 = seasons1[0].Episodes.ToArray();

            episodes10[0].Number.Should().Be(1);
            episodes10[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes10[0].Metadata.Should().BeNull();

            episodes10[1].Number.Should().Be(2);
            episodes10[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes10[1].Metadata.Should().BeNull();

            // Season 2 of Show 2
            seasons1[1].Number.Should().Be(2);
            seasons1[1].Episodes.Should().NotBeNull();
            seasons1[1].Episodes.Should().HaveCount(2);

            // Episodes of Season 2 of Show 2
            var episodes11 = seasons1[1].Episodes.ToArray();

            episodes11[0].Number.Should().Be(1);
            episodes11[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes11[0].Metadata.Should().BeNull();

            episodes11[1].Number.Should().Be(2);
            episodes11[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes11[1].Metadata.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktCollectionShowReadFromJsonMetadata()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Collection\CollectionShowsMetadata.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var collectionShows = JsonConvert.DeserializeObject<IEnumerable<TraktCollectionShow>>(jsonFile);

            collectionShows.Should().NotBeNull();

            var shows = collectionShows.ToArray();

            // Show 1
            shows[0].LastCollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            shows[0].Show.Should().NotBeNull();
            shows[0].Show.Title.Should().Be("Breaking Bad");
            shows[0].Show.Year.Should().Be(2008);
            shows[0].Show.Ids.Should().NotBeNull();
            shows[0].Show.Ids.Trakt.Should().Be(1U);
            shows[0].Show.Ids.Slug.Should().Be("breaking-bad");
            shows[0].Show.Ids.Tvdb.Should().Be(81189U);
            shows[0].Show.Ids.Imdb.Should().Be("tt0903747");
            shows[0].Show.Ids.Tmdb.Should().Be(1396U);
            shows[0].Show.Ids.TvRage.Should().Be(18164U);
            shows[0].Seasons.Should().NotBeNull();
            shows[0].Seasons.Should().HaveCount(2);

            var seasons0 = shows[0].Seasons.ToArray();

            // Season 1 of Show 1
            seasons0[0].Number.Should().Be(1);
            seasons0[0].Episodes.Should().NotBeNull();
            seasons0[0].Episodes.Should().HaveCount(2);

            // Episodes of Season 1 of Show 1
            var episodes00 = seasons0[0].Episodes.ToArray();

            episodes00[0].Number.Should().Be(1);
            episodes00[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes00[0].Metadata.Should().NotBeNull();
            episodes00[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodes00[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodes00[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodes00[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodes00[0].Metadata.ThreeDimensional.Should().BeFalse();

            episodes00[1].Number.Should().Be(2);
            episodes00[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes00[1].Metadata.Should().NotBeNull();
            episodes00[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodes00[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodes00[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodes00[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodes00[1].Metadata.ThreeDimensional.Should().BeFalse();

            // Season 2 of Show 1
            seasons0[1].Number.Should().Be(2);
            seasons0[1].Episodes.Should().NotBeNull();
            seasons0[1].Episodes.Should().HaveCount(2);

            // Episodes of Season 2 of Show 1
            var episodes01 = seasons0[1].Episodes.ToArray();

            episodes01[0].Number.Should().Be(1);
            episodes01[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes01[0].Metadata.Should().NotBeNull();
            episodes01[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodes01[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodes01[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodes01[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodes01[0].Metadata.ThreeDimensional.Should().BeFalse();

            episodes01[1].Number.Should().Be(2);
            episodes01[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes01[1].Metadata.Should().NotBeNull();
            episodes01[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodes01[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodes01[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodes01[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodes01[1].Metadata.ThreeDimensional.Should().BeFalse();

            // -----------------------------------

            // Show 2
            shows[1].LastCollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            shows[1].Show.Should().NotBeNull();
            shows[1].Show.Title.Should().Be("The Walking Dead");
            shows[1].Show.Year.Should().Be(2010);
            shows[1].Show.Ids.Should().NotBeNull();
            shows[1].Show.Ids.Trakt.Should().Be(2U);
            shows[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            shows[1].Show.Ids.Tvdb.Should().Be(153021U);
            shows[1].Show.Ids.Imdb.Should().Be("tt1520211");
            shows[1].Show.Ids.Tmdb.Should().Be(1402U);
            shows[1].Show.Ids.TvRage.Should().BeNull();
            shows[1].Seasons.Should().NotBeNull();
            shows[1].Seasons.Should().HaveCount(2);

            var seasons1 = shows[1].Seasons.ToArray();

            // Season 1 of Show 2
            seasons1[0].Number.Should().Be(1);
            seasons1[0].Episodes.Should().NotBeNull();
            seasons1[0].Episodes.Should().HaveCount(2);

            // Episodes of Season 1 of Show 2
            var episodes10 = seasons1[0].Episodes.ToArray();

            episodes10[0].Number.Should().Be(1);
            episodes10[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes10[0].Metadata.Should().NotBeNull();
            episodes10[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodes10[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodes10[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodes10[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodes10[0].Metadata.ThreeDimensional.Should().BeFalse();

            episodes10[1].Number.Should().Be(2);
            episodes10[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes10[1].Metadata.Should().NotBeNull();
            episodes10[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodes10[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodes10[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodes10[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodes10[1].Metadata.ThreeDimensional.Should().BeFalse();

            // Season 2 of Show 2
            seasons1[1].Number.Should().Be(2);
            seasons1[1].Episodes.Should().NotBeNull();
            seasons1[1].Episodes.Should().HaveCount(2);

            // Episodes of Season 2 of Show 2
            var episodes11 = seasons1[1].Episodes.ToArray();

            episodes11[0].Number.Should().Be(1);
            episodes11[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes11[0].Metadata.Should().NotBeNull();
            episodes11[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodes11[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodes11[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodes11[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodes11[0].Metadata.ThreeDimensional.Should().BeFalse();

            episodes11[1].Number.Should().Be(2);
            episodes11[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            episodes11[1].Metadata.Should().NotBeNull();
            episodes11[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            episodes11[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            episodes11[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            episodes11[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            episodes11[1].Metadata.ThreeDimensional.Should().BeFalse();
        }
    }
}
