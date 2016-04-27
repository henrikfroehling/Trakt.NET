namespace TraktApiSharp.Tests.Objects.Get.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.Collections;
    using Utils;

    [TestClass]
    public class TraktUserCollectionTests
    {
        [TestMethod]
        public void TestTraktUserCollectionReadFromJsonMovies()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserCollectionMovies.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userCollectionMovies = JsonConvert.DeserializeObject<IEnumerable<TraktUserCollectionMovieItem>>(jsonFile);

            userCollectionMovies.Should().NotBeNull();
            userCollectionMovies.Should().HaveCount(2);

            var collectionMovies = userCollectionMovies.ToArray();

            collectionMovies[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            collectionMovies[0].Movie.Should().NotBeNull();
            collectionMovies[0].Movie.Title.Should().Be("TRON: Legacy");
            collectionMovies[0].Movie.Year.Should().Be(2010);
            collectionMovies[0].Movie.Ids.Should().NotBeNull();
            collectionMovies[0].Movie.Ids.Trakt.Should().Be(1);
            collectionMovies[0].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            collectionMovies[0].Movie.Ids.Imdb.Should().Be("tt1104001");
            collectionMovies[0].Movie.Ids.Tmdb.Should().Be(20526);
            collectionMovies[0].Metadata.Should().NotBeNull();
            collectionMovies[0].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
            collectionMovies[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
            collectionMovies[0].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
            collectionMovies[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
            collectionMovies[0].Metadata.ThreeDimensional.Should().BeFalse();

            collectionMovies[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            collectionMovies[1].Movie.Should().NotBeNull();
            collectionMovies[1].Movie.Title.Should().Be("The Dark Knight");
            collectionMovies[1].Movie.Year.Should().Be(2008);
            collectionMovies[1].Movie.Ids.Should().NotBeNull();
            collectionMovies[1].Movie.Ids.Trakt.Should().Be(6);
            collectionMovies[1].Movie.Ids.Slug.Should().Be("the-dark-knight-2008");
            collectionMovies[1].Movie.Ids.Imdb.Should().Be("tt0468569");
            collectionMovies[1].Movie.Ids.Tmdb.Should().Be(155);
            collectionMovies[1].Metadata.Should().NotBeNull();
            collectionMovies[1].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
            collectionMovies[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
            collectionMovies[1].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
            collectionMovies[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
            collectionMovies[1].Metadata.ThreeDimensional.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktUserCollectionReadFromJsonShows()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserCollectionShows.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userCollectionShows = JsonConvert.DeserializeObject<IEnumerable<TraktUserCollectionShowItem>>(jsonFile);

            userCollectionShows.Should().NotBeNull();
            userCollectionShows.Should().HaveCount(2);

            var collectionShows = userCollectionShows.ToArray();

            collectionShows[0].LastCollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            collectionShows[0].Show.Should().NotBeNull();
            collectionShows[0].Show.Title.Should().Be("Breaking Bad");
            collectionShows[0].Show.Year.Should().Be(2008);
            collectionShows[0].Show.Ids.Should().NotBeNull();
            collectionShows[0].Show.Ids.Trakt.Should().Be(1);
            collectionShows[0].Show.Ids.Slug.Should().Be("breaking-bad");
            collectionShows[0].Show.Ids.Tvdb.Should().Be(81189);
            collectionShows[0].Show.Ids.Imdb.Should().Be("tt0903747");
            collectionShows[0].Show.Ids.Tmdb.Should().Be(1396);
            collectionShows[0].Show.Ids.TvRage.Should().Be(18164);
            collectionShows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            var show0Seasons = collectionShows[0].Seasons.ToArray();

            show0Seasons[0].Number.Should().Be(1);
            show0Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var show0Season0Episodes = show0Seasons[0].Episodes.ToArray();

            show0Season0Episodes[0].Number.Should().Be(1);
            show0Season0Episodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            show0Season0Episodes[0].Metadata.Should().NotBeNull();
            show0Season0Episodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            show0Season0Episodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            show0Season0Episodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            show0Season0Episodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            show0Season0Episodes[0].Metadata.ThreeDimensional.Should().BeFalse();

            show0Season0Episodes[1].Number.Should().Be(2);
            show0Season0Episodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            show0Season0Episodes[1].Metadata.Should().NotBeNull();
            show0Season0Episodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            show0Season0Episodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            show0Season0Episodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            show0Season0Episodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            show0Season0Episodes[1].Metadata.ThreeDimensional.Should().BeFalse();

            // ---------------------------------------------------------------------

            show0Seasons[1].Number.Should().Be(2);
            show0Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            var show0Season1Episodes = show0Seasons[1].Episodes.ToArray();

            show0Season1Episodes[0].Number.Should().Be(1);
            show0Season1Episodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            show0Season1Episodes[0].Metadata.Should().NotBeNull();
            show0Season1Episodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            show0Season1Episodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            show0Season1Episodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            show0Season1Episodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            show0Season1Episodes[0].Metadata.ThreeDimensional.Should().BeFalse();

            show0Season1Episodes[1].Number.Should().Be(2);
            show0Season1Episodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            show0Season1Episodes[1].Metadata.Should().NotBeNull();
            show0Season1Episodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            show0Season1Episodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            show0Season1Episodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            show0Season1Episodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            show0Season1Episodes[1].Metadata.ThreeDimensional.Should().BeFalse();

            // ---------------------------------------------------------------------
            // ---------------------------------------------------------------------

            collectionShows[1].LastCollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            collectionShows[1].Show.Should().NotBeNull();
            collectionShows[1].Show.Title.Should().Be("The Walking Dead");
            collectionShows[1].Show.Year.Should().Be(2010);
            collectionShows[1].Show.Ids.Should().NotBeNull();
            collectionShows[1].Show.Ids.Trakt.Should().Be(2);
            collectionShows[1].Show.Ids.Slug.Should().Be("the-walking-dead");
            collectionShows[1].Show.Ids.Tvdb.Should().Be(153021);
            collectionShows[1].Show.Ids.Imdb.Should().Be("tt1520211");
            collectionShows[1].Show.Ids.Tmdb.Should().Be(1402);
            collectionShows[1].Show.Ids.TvRage.Should().NotHaveValue();
            collectionShows[1].Seasons.Should().NotBeNull().And.HaveCount(2);

            var show1Seasons = collectionShows[1].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var show1Season0Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season0Episodes[0].Number.Should().Be(1);
            show1Season0Episodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            show1Season0Episodes[0].Metadata.Should().NotBeNull();
            show1Season0Episodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            show1Season0Episodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            show1Season0Episodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            show1Season0Episodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            show1Season0Episodes[0].Metadata.ThreeDimensional.Should().BeFalse();

            show1Season0Episodes[1].Number.Should().Be(2);
            show1Season0Episodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            show1Season0Episodes[1].Metadata.Should().NotBeNull();
            show1Season0Episodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            show1Season0Episodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            show1Season0Episodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            show1Season0Episodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            show1Season0Episodes[1].Metadata.ThreeDimensional.Should().BeFalse();

            // ---------------------------------------------------------------------

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            var show1Season1Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            show1Season1Episodes[0].Metadata.Should().NotBeNull();
            show1Season1Episodes[0].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            show1Season1Episodes[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            show1Season1Episodes[0].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            show1Season1Episodes[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            show1Season1Episodes[0].Metadata.ThreeDimensional.Should().BeFalse();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            show1Season1Episodes[1].Metadata.Should().NotBeNull();
            show1Season1Episodes[1].Metadata.MediaType.Should().Be(TraktMediaType.Digital);
            show1Season1Episodes[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_720p);
            show1Season1Episodes[1].Metadata.Audio.Should().Be(TraktMediaAudio.AAC);
            show1Season1Episodes[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_5_1);
            show1Season1Episodes[1].Metadata.ThreeDimensional.Should().BeFalse();
        }
    }
}
