namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Responses;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundMovieArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundMovieArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundMovie>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var notFoundMovies = await jsonReader.ReadArrayAsync(stream);
                notFoundMovies.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundMovie>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var notFoundMovies = await jsonReader.ReadArrayAsync(stream);
                notFoundMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var notFoundMovie = notFoundMovies.ToArray();

                notFoundMovie[0].Should().NotBeNull();
                notFoundMovie[0].Ids.Should().NotBeNull();
                notFoundMovie[0].Ids.Trakt.Should().Be(94024U);
                notFoundMovie[0].Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                notFoundMovie[0].Ids.Imdb.Should().Be("tt2488496");
                notFoundMovie[0].Ids.Tmdb.Should().Be(140607U);

                notFoundMovie[1].Should().NotBeNull();
                notFoundMovie[1].Ids.Should().NotBeNull();
                notFoundMovie[1].Ids.Trakt.Should().Be(172687U);
                notFoundMovie[1].Ids.Slug.Should().Be("king-arthur-legend-of-the-sword-2017");
                notFoundMovie[1].Ids.Imdb.Should().Be("tt1972591");
                notFoundMovie[1].Ids.Tmdb.Should().Be(274857U);
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieArrayJsonReader_ReadArray_From_Stream_Not_Valid()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundMovie>();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var notFoundMovies = await jsonReader.ReadArrayAsync(stream);
                notFoundMovies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var notFoundMovie = notFoundMovies.ToArray();

                notFoundMovie[0].Should().NotBeNull();
                notFoundMovie[0].Ids.Should().NotBeNull();
                notFoundMovie[0].Ids.Trakt.Should().Be(94024U);
                notFoundMovie[0].Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                notFoundMovie[0].Ids.Imdb.Should().Be("tt2488496");
                notFoundMovie[0].Ids.Tmdb.Should().Be(140607U);

                notFoundMovie[1].Should().NotBeNull();
                notFoundMovie[1].Ids.Should().BeNull();
            }
        }

        [Fact]
        public void Test_PostResponseNotFoundMovieArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundMovie>();
            Func<Task<IEnumerable<ITraktPostResponseNotFoundMovie>>> notFoundMovies = () => jsonReader.ReadArrayAsync(default(Stream));
            notFoundMovies.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundMovie>();

            using (var stream = string.Empty.ToStream())
            {
                var notFoundMovies = await jsonReader.ReadArrayAsync(stream);
                notFoundMovies.Should().BeNull();
            }
        }
    }
}
