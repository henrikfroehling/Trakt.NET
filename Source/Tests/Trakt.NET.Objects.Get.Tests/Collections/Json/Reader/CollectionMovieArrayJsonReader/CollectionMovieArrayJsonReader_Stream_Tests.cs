namespace TraktNet.Objects.Get.Tests.Collections.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Collections;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Get.Collections.JsonReader")]
    public partial class CollectionMovieArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CollectionMovieArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionMovie>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var traktCollectionMovies = await jsonReader.ReadArrayAsync(stream);
                traktCollectionMovies.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionMovie>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktCollectionMovies = await jsonReader.ReadArrayAsync(stream);
                traktCollectionMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var collectionMovies = traktCollectionMovies.ToArray();

                collectionMovies[0].Should().NotBeNull();
                collectionMovies[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                collectionMovies[0].Movie.Should().NotBeNull();
                collectionMovies[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                collectionMovies[0].Movie.Year.Should().Be(2015);
                collectionMovies[0].Movie.Ids.Should().NotBeNull();
                collectionMovies[0].Movie.Ids.Trakt.Should().Be(94024U);
                collectionMovies[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                collectionMovies[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                collectionMovies[0].Movie.Ids.Tmdb.Should().Be(140607U);

                collectionMovies[0].Metadata.Should().NotBeNull();
                collectionMovies[0].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                collectionMovies[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                collectionMovies[0].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                collectionMovies[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                collectionMovies[0].Metadata.ThreeDimensional.Should().BeFalse();

                collectionMovies[1].Should().NotBeNull();
                collectionMovies[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                collectionMovies[1].Movie.Should().NotBeNull();
                collectionMovies[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                collectionMovies[1].Movie.Year.Should().Be(2015);
                collectionMovies[1].Movie.Ids.Should().NotBeNull();
                collectionMovies[1].Movie.Ids.Trakt.Should().Be(94024U);
                collectionMovies[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                collectionMovies[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                collectionMovies[1].Movie.Ids.Tmdb.Should().Be(140607U);

                collectionMovies[1].Metadata.Should().NotBeNull();
                collectionMovies[1].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                collectionMovies[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                collectionMovies[1].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                collectionMovies[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                collectionMovies[1].Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionMovie>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktCollectionMovies = await jsonReader.ReadArrayAsync(stream);
                traktCollectionMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var collectionMovies = traktCollectionMovies.ToArray();

                collectionMovies[0].Should().NotBeNull();
                collectionMovies[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                collectionMovies[0].Movie.Should().NotBeNull();
                collectionMovies[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                collectionMovies[0].Movie.Year.Should().Be(2015);
                collectionMovies[0].Movie.Ids.Should().NotBeNull();
                collectionMovies[0].Movie.Ids.Trakt.Should().Be(94024U);
                collectionMovies[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                collectionMovies[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                collectionMovies[0].Movie.Ids.Tmdb.Should().Be(140607U);

                collectionMovies[0].Metadata.Should().NotBeNull();
                collectionMovies[0].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                collectionMovies[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                collectionMovies[0].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                collectionMovies[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                collectionMovies[0].Metadata.ThreeDimensional.Should().BeFalse();

                collectionMovies[1].Should().NotBeNull();
                collectionMovies[1].CollectedAt.Should().BeNull();

                collectionMovies[1].Movie.Should().NotBeNull();
                collectionMovies[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                collectionMovies[1].Movie.Year.Should().Be(2015);
                collectionMovies[1].Movie.Ids.Should().NotBeNull();
                collectionMovies[1].Movie.Ids.Trakt.Should().Be(94024U);
                collectionMovies[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                collectionMovies[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                collectionMovies[1].Movie.Ids.Tmdb.Should().Be(140607U);

                collectionMovies[1].Metadata.Should().NotBeNull();
                collectionMovies[1].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                collectionMovies[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                collectionMovies[1].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                collectionMovies[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                collectionMovies[1].Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionMovie>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktCollectionMovies = await jsonReader.ReadArrayAsync(stream);
                traktCollectionMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var collectionMovies = traktCollectionMovies.ToArray();

                collectionMovies[0].Should().NotBeNull();
                collectionMovies[0].CollectedAt.Should().BeNull();

                collectionMovies[0].Movie.Should().NotBeNull();
                collectionMovies[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                collectionMovies[0].Movie.Year.Should().Be(2015);
                collectionMovies[0].Movie.Ids.Should().NotBeNull();
                collectionMovies[0].Movie.Ids.Trakt.Should().Be(94024U);
                collectionMovies[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                collectionMovies[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                collectionMovies[0].Movie.Ids.Tmdb.Should().Be(140607U);

                collectionMovies[0].Metadata.Should().NotBeNull();
                collectionMovies[0].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                collectionMovies[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                collectionMovies[0].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                collectionMovies[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                collectionMovies[0].Metadata.ThreeDimensional.Should().BeFalse();

                collectionMovies[1].Should().NotBeNull();
                collectionMovies[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                collectionMovies[1].Movie.Should().NotBeNull();
                collectionMovies[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                collectionMovies[1].Movie.Year.Should().Be(2015);
                collectionMovies[1].Movie.Ids.Should().NotBeNull();
                collectionMovies[1].Movie.Ids.Trakt.Should().Be(94024U);
                collectionMovies[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                collectionMovies[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                collectionMovies[1].Movie.Ids.Tmdb.Should().Be(140607U);

                collectionMovies[1].Metadata.Should().NotBeNull();
                collectionMovies[1].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                collectionMovies[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                collectionMovies[1].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                collectionMovies[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                collectionMovies[1].Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionMovie>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktCollectionMovies = await jsonReader.ReadArrayAsync(stream);
                traktCollectionMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var collectionMovies = traktCollectionMovies.ToArray();

                collectionMovies[0].Should().NotBeNull();
                collectionMovies[0].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                collectionMovies[0].Movie.Should().NotBeNull();
                collectionMovies[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                collectionMovies[0].Movie.Year.Should().Be(2015);
                collectionMovies[0].Movie.Ids.Should().NotBeNull();
                collectionMovies[0].Movie.Ids.Trakt.Should().Be(94024U);
                collectionMovies[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                collectionMovies[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                collectionMovies[0].Movie.Ids.Tmdb.Should().Be(140607U);

                collectionMovies[0].Metadata.Should().NotBeNull();
                collectionMovies[0].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                collectionMovies[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                collectionMovies[0].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                collectionMovies[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                collectionMovies[0].Metadata.ThreeDimensional.Should().BeFalse();

                collectionMovies[1].Should().NotBeNull();
                collectionMovies[1].CollectedAt.Should().BeNull();

                collectionMovies[1].Movie.Should().NotBeNull();
                collectionMovies[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                collectionMovies[1].Movie.Year.Should().Be(2015);
                collectionMovies[1].Movie.Ids.Should().NotBeNull();
                collectionMovies[1].Movie.Ids.Trakt.Should().Be(94024U);
                collectionMovies[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                collectionMovies[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                collectionMovies[1].Movie.Ids.Tmdb.Should().Be(140607U);

                collectionMovies[1].Metadata.Should().NotBeNull();
                collectionMovies[1].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                collectionMovies[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                collectionMovies[1].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                collectionMovies[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                collectionMovies[1].Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionMovie>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktCollectionMovies = await jsonReader.ReadArrayAsync(stream);
                traktCollectionMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var collectionMovies = traktCollectionMovies.ToArray();

                collectionMovies[0].Should().NotBeNull();
                collectionMovies[0].CollectedAt.Should().BeNull();

                collectionMovies[0].Movie.Should().NotBeNull();
                collectionMovies[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                collectionMovies[0].Movie.Year.Should().Be(2015);
                collectionMovies[0].Movie.Ids.Should().NotBeNull();
                collectionMovies[0].Movie.Ids.Trakt.Should().Be(94024U);
                collectionMovies[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                collectionMovies[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                collectionMovies[0].Movie.Ids.Tmdb.Should().Be(140607U);

                collectionMovies[0].Metadata.Should().NotBeNull();
                collectionMovies[0].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                collectionMovies[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                collectionMovies[0].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                collectionMovies[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                collectionMovies[0].Metadata.ThreeDimensional.Should().BeFalse();

                collectionMovies[1].Should().NotBeNull();
                collectionMovies[1].CollectedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                collectionMovies[1].Movie.Should().NotBeNull();
                collectionMovies[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                collectionMovies[1].Movie.Year.Should().Be(2015);
                collectionMovies[1].Movie.Ids.Should().NotBeNull();
                collectionMovies[1].Movie.Ids.Trakt.Should().Be(94024U);
                collectionMovies[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                collectionMovies[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                collectionMovies[1].Movie.Ids.Tmdb.Should().Be(140607U);

                collectionMovies[1].Metadata.Should().NotBeNull();
                collectionMovies[1].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                collectionMovies[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                collectionMovies[1].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                collectionMovies[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                collectionMovies[1].Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionMovie>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktCollectionMovies = await jsonReader.ReadArrayAsync(stream);
                traktCollectionMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var collectionMovies = traktCollectionMovies.ToArray();

                collectionMovies[0].Should().NotBeNull();
                collectionMovies[0].CollectedAt.Should().BeNull();

                collectionMovies[0].Movie.Should().NotBeNull();
                collectionMovies[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                collectionMovies[0].Movie.Year.Should().Be(2015);
                collectionMovies[0].Movie.Ids.Should().NotBeNull();
                collectionMovies[0].Movie.Ids.Trakt.Should().Be(94024U);
                collectionMovies[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                collectionMovies[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                collectionMovies[0].Movie.Ids.Tmdb.Should().Be(140607U);

                collectionMovies[0].Metadata.Should().NotBeNull();
                collectionMovies[0].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                collectionMovies[0].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                collectionMovies[0].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                collectionMovies[0].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                collectionMovies[0].Metadata.ThreeDimensional.Should().BeFalse();

                collectionMovies[1].Should().NotBeNull();
                collectionMovies[1].CollectedAt.Should().BeNull();

                collectionMovies[1].Movie.Should().NotBeNull();
                collectionMovies[1].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                collectionMovies[1].Movie.Year.Should().Be(2015);
                collectionMovies[1].Movie.Ids.Should().NotBeNull();
                collectionMovies[1].Movie.Ids.Trakt.Should().Be(94024U);
                collectionMovies[1].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                collectionMovies[1].Movie.Ids.Imdb.Should().Be("tt2488496");
                collectionMovies[1].Movie.Ids.Tmdb.Should().Be(140607U);

                collectionMovies[1].Metadata.Should().NotBeNull();
                collectionMovies[1].Metadata.MediaType.Should().Be(TraktMediaType.Bluray);
                collectionMovies[1].Metadata.MediaResolution.Should().Be(TraktMediaResolution.HD_1080p);
                collectionMovies[1].Metadata.Audio.Should().Be(TraktMediaAudio.DTS);
                collectionMovies[1].Metadata.AudioChannels.Should().Be(TraktMediaAudioChannel.Channels_6_1);
                collectionMovies[1].Metadata.ThreeDimensional.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Test_CollectionMovieArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionMovie>();
            Func<Task<IList<ITraktCollectionMovie>>> traktCollectionMovies = () => jsonReader.ReadArrayAsync(default(Stream));
            await traktCollectionMovies.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CollectionMovieArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktCollectionMovie>();

            using (var stream = string.Empty.ToStream())
            {
                var traktCollectionMovies = await jsonReader.ReadArrayAsync(stream);
                traktCollectionMovies.Should().BeNull();
            }
        }
    }
}
