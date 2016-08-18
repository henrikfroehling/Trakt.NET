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
    public class TraktCollectionMovieTests
    {
        [TestMethod]
        public void TestTraktCollectionMovieDefaultConstructor()
        {
            var collectionMovie = new TraktCollectionMovie();

            collectionMovie.CollectedAt.Should().NotHaveValue();
            collectionMovie.Movie.Should().BeNull();
            collectionMovie.Metadata.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktCollectionMovieReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Collection\CollectionMovies.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var collectionMovies = JsonConvert.DeserializeObject<IEnumerable<TraktCollectionMovie>>(jsonFile);

            collectionMovies.Should().NotBeNull();

            var movies = collectionMovies.ToArray();

            movies[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            movies[0].Movie.Should().NotBeNull();
            movies[0].Movie.Title.Should().Be("TRON: Legacy");
            movies[0].Movie.Year.Should().Be(2010);
            movies[0].Movie.Ids.Should().NotBeNull();
            movies[0].Movie.Ids.Trakt.Should().Be(1U);
            movies[0].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            movies[0].Movie.Ids.Imdb.Should().Be("tt1104001");
            movies[0].Movie.Ids.Tmdb.Should().Be(20526U);
            movies[0].Metadata.Should().BeNull();

            movies[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            movies[1].Movie.Should().NotBeNull();
            movies[1].Movie.Title.Should().Be("The Dark Knight");
            movies[1].Movie.Year.Should().Be(2008);
            movies[1].Movie.Ids.Should().NotBeNull();
            movies[1].Movie.Ids.Trakt.Should().Be(6U);
            movies[1].Movie.Ids.Slug.Should().Be("the-dark-knight-2008");
            movies[1].Movie.Ids.Imdb.Should().Be("tt0468569");
            movies[1].Movie.Ids.Tmdb.Should().Be(155U);
            movies[1].Metadata.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktCollectionMovieReadFromJsonMetadata()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Collection\CollectionMoviesMetadata.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var collectionMovies = JsonConvert.DeserializeObject<IEnumerable<TraktCollectionMovie>>(jsonFile);

            collectionMovies.Should().NotBeNull();

            var movies = collectionMovies.ToArray();

            movies[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            movies[0].Movie.Should().NotBeNull();
            movies[0].Movie.Title.Should().Be("TRON: Legacy");
            movies[0].Movie.Year.Should().Be(2010);
            movies[0].Movie.Ids.Should().NotBeNull();
            movies[0].Movie.Ids.Trakt.Should().Be(1U);
            movies[0].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
            movies[0].Movie.Ids.Imdb.Should().Be("tt1104001");
            movies[0].Movie.Ids.Tmdb.Should().Be(20526U);
            movies[0].Metadata.Should().NotBeNull();
            movies[0].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
            movies[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
            movies[0].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
            movies[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
            movies[0].Metadata.ThreeDimensional.Should().BeFalse();

            movies[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            movies[1].Movie.Should().NotBeNull();
            movies[1].Movie.Title.Should().Be("The Dark Knight");
            movies[1].Movie.Year.Should().Be(2008);
            movies[1].Movie.Ids.Should().NotBeNull();
            movies[1].Movie.Ids.Trakt.Should().Be(6U);
            movies[1].Movie.Ids.Slug.Should().Be("the-dark-knight-2008");
            movies[1].Movie.Ids.Imdb.Should().Be("tt0468569");
            movies[1].Movie.Ids.Tmdb.Should().Be(155U);
            movies[1].Metadata.Should().NotBeNull();
            movies[1].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
            movies[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
            movies[1].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
            movies[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
            movies[1].Metadata.ThreeDimensional.Should().BeTrue();
        }
    }
}
