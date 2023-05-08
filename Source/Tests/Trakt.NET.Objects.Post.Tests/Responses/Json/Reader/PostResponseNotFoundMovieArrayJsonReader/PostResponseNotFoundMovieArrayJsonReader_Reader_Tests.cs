namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Json;
    using TraktNet.Objects.Post.Responses;
    using Xunit;

    [TestCategory("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundMovieArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundMovieArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundMovie>();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundMovies = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundMovies.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundMovie>();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundMovies = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_PostResponseNotFoundMovieArrayJsonReader_ReadArray_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundMovie>();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundMovies = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_PostResponseNotFoundMovieArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundMovie>();
            Func<Task<IList<ITraktPostResponseNotFoundMovie>>> notFoundMovies = () => traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            await notFoundMovies.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundMovieArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundMovie>();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundMovies = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundMovies.Should().BeNull();
            }
        }
    }
}
