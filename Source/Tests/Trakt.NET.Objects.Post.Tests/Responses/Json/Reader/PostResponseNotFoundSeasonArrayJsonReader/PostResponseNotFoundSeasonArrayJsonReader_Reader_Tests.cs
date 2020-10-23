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

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundSeasonArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundSeasons = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundSeasons.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundSeasons = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var notFoundSeason = notFoundSeasons.ToArray();

                notFoundSeason[0].Should().NotBeNull();
                notFoundSeason[0].Ids.Should().NotBeNull();
                notFoundSeason[0].Ids.Trakt.Should().Be(61430U);
                notFoundSeason[0].Ids.Tvdb.Should().Be(279121U);
                notFoundSeason[0].Ids.Tmdb.Should().Be(60523U);
                notFoundSeason[0].Ids.TvRage.Should().Be(36939U);

                notFoundSeason[1].Should().NotBeNull();
                notFoundSeason[1].Ids.Should().NotBeNull();
                notFoundSeason[1].Ids.Trakt.Should().Be(61431U);
                notFoundSeason[1].Ids.Tvdb.Should().Be(578373U);
                notFoundSeason[1].Ids.Tmdb.Should().Be(60524U);
                notFoundSeason[1].Ids.TvRage.Should().Be(36940U);
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundSeasons = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var notFoundSeason = notFoundSeasons.ToArray();

                notFoundSeason[0].Should().NotBeNull();
                notFoundSeason[0].Ids.Should().NotBeNull();
                notFoundSeason[0].Ids.Trakt.Should().Be(61430U);
                notFoundSeason[0].Ids.Tvdb.Should().Be(279121U);
                notFoundSeason[0].Ids.Tmdb.Should().Be(60523U);
                notFoundSeason[0].Ids.TvRage.Should().Be(36939U);

                notFoundSeason[1].Should().NotBeNull();
                notFoundSeason[1].Ids.Should().BeNull();
            }
        }

        [Fact]
        public void Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();
            Func<Task<IEnumerable<ITraktPostResponseNotFoundSeason>>> notFoundSeasons = () => traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            notFoundSeasons.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var notFoundSeasons = await traktJsonReader.ReadArrayAsync(jsonReader);
                notFoundSeasons.Should().BeNull();
            }
        }
    }
}
