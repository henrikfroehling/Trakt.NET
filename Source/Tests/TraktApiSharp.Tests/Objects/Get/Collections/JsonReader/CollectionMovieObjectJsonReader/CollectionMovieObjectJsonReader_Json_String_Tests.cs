namespace TraktApiSharp.Tests.Objects.Get.Collections.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Collections.JsonReader;
    using Xunit;

    [Category("Objects.Get.Collections.JsonReader")]
    public partial class CollectionMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new CollectionMovieObjectJsonReader();

            var traktCollectionMovie = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktCollectionMovie.Should().NotBeNull();
            traktCollectionMovie.CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktCollectionMovie.Movie.Should().NotBeNull();
            traktCollectionMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCollectionMovie.Movie.Year.Should().Be(2015);
            traktCollectionMovie.Movie.Ids.Should().NotBeNull();
            traktCollectionMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktCollectionMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCollectionMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCollectionMovie.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCollectionMovie.Metadata.Should().NotBeNull();
            traktCollectionMovie.Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
            traktCollectionMovie.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
            traktCollectionMovie.Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
            traktCollectionMovie.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
            traktCollectionMovie.Metadata.ThreeDimensional.Should().BeFalse();
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new CollectionMovieObjectJsonReader();

            var traktCollectionMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktCollectionMovie.Should().NotBeNull();
            traktCollectionMovie.CollectedAt.Should().BeNull();

            traktCollectionMovie.Movie.Should().NotBeNull();
            traktCollectionMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCollectionMovie.Movie.Year.Should().Be(2015);
            traktCollectionMovie.Movie.Ids.Should().NotBeNull();
            traktCollectionMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktCollectionMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCollectionMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCollectionMovie.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCollectionMovie.Metadata.Should().NotBeNull();
            traktCollectionMovie.Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
            traktCollectionMovie.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
            traktCollectionMovie.Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
            traktCollectionMovie.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
            traktCollectionMovie.Metadata.ThreeDimensional.Should().BeFalse();
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new CollectionMovieObjectJsonReader();

            var traktCollectionMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktCollectionMovie.Should().NotBeNull();
            traktCollectionMovie.CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktCollectionMovie.Movie.Should().BeNull();

            traktCollectionMovie.Metadata.Should().NotBeNull();
            traktCollectionMovie.Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
            traktCollectionMovie.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
            traktCollectionMovie.Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
            traktCollectionMovie.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
            traktCollectionMovie.Metadata.ThreeDimensional.Should().BeFalse();
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new CollectionMovieObjectJsonReader();

            var traktCollectionMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktCollectionMovie.Should().NotBeNull();
            traktCollectionMovie.CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktCollectionMovie.Movie.Should().NotBeNull();
            traktCollectionMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCollectionMovie.Movie.Year.Should().Be(2015);
            traktCollectionMovie.Movie.Ids.Should().NotBeNull();
            traktCollectionMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktCollectionMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCollectionMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCollectionMovie.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCollectionMovie.Metadata.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new CollectionMovieObjectJsonReader();

            var traktCollectionMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktCollectionMovie.Should().NotBeNull();
            traktCollectionMovie.CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktCollectionMovie.Movie.Should().BeNull();
            traktCollectionMovie.Metadata.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new CollectionMovieObjectJsonReader();

            var traktCollectionMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktCollectionMovie.Should().NotBeNull();
            traktCollectionMovie.CollectedAt.Should().BeNull();

            traktCollectionMovie.Movie.Should().NotBeNull();
            traktCollectionMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCollectionMovie.Movie.Year.Should().Be(2015);
            traktCollectionMovie.Movie.Ids.Should().NotBeNull();
            traktCollectionMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktCollectionMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCollectionMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCollectionMovie.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCollectionMovie.Metadata.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new CollectionMovieObjectJsonReader();

            var traktCollectionMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktCollectionMovie.Should().NotBeNull();
            traktCollectionMovie.CollectedAt.Should().BeNull();
            traktCollectionMovie.Movie.Should().BeNull();

            traktCollectionMovie.Metadata.Should().NotBeNull();
            traktCollectionMovie.Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
            traktCollectionMovie.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
            traktCollectionMovie.Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
            traktCollectionMovie.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
            traktCollectionMovie.Metadata.ThreeDimensional.Should().BeFalse();
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new CollectionMovieObjectJsonReader();

            var traktCollectionMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktCollectionMovie.Should().NotBeNull();
            traktCollectionMovie.CollectedAt.Should().BeNull();

            traktCollectionMovie.Movie.Should().NotBeNull();
            traktCollectionMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCollectionMovie.Movie.Year.Should().Be(2015);
            traktCollectionMovie.Movie.Ids.Should().NotBeNull();
            traktCollectionMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktCollectionMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCollectionMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCollectionMovie.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCollectionMovie.Metadata.Should().NotBeNull();
            traktCollectionMovie.Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
            traktCollectionMovie.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
            traktCollectionMovie.Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
            traktCollectionMovie.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
            traktCollectionMovie.Metadata.ThreeDimensional.Should().BeFalse();
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new CollectionMovieObjectJsonReader();

            var traktCollectionMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktCollectionMovie.Should().NotBeNull();
            traktCollectionMovie.CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktCollectionMovie.Movie.Should().BeNull();

            traktCollectionMovie.Metadata.Should().NotBeNull();
            traktCollectionMovie.Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
            traktCollectionMovie.Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
            traktCollectionMovie.Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
            traktCollectionMovie.Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
            traktCollectionMovie.Metadata.ThreeDimensional.Should().BeFalse();
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new CollectionMovieObjectJsonReader();

            var traktCollectionMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktCollectionMovie.Should().NotBeNull();
            traktCollectionMovie.CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            traktCollectionMovie.Movie.Should().NotBeNull();
            traktCollectionMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktCollectionMovie.Movie.Year.Should().Be(2015);
            traktCollectionMovie.Movie.Ids.Should().NotBeNull();
            traktCollectionMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktCollectionMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktCollectionMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktCollectionMovie.Movie.Ids.Tmdb.Should().Be(140607U);

            traktCollectionMovie.Metadata.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new CollectionMovieObjectJsonReader();

            var traktCollectionMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktCollectionMovie.Should().NotBeNull();
            traktCollectionMovie.CollectedAt.Should().BeNull();
            traktCollectionMovie.Movie.Should().BeNull();
            traktCollectionMovie.Metadata.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new CollectionMovieObjectJsonReader();

            var traktCollectionMovie = await jsonReader.ReadObjectAsync(default(string));
            traktCollectionMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_CollectionMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new CollectionMovieObjectJsonReader();

            var traktCollectionMovie = await jsonReader.ReadObjectAsync(string.Empty);
            traktCollectionMovie.Should().BeNull();
        }
    }
}
