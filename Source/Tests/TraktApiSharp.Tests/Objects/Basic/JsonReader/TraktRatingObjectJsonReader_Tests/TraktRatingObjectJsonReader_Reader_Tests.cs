namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class TraktRatingObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktRatingObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktRatingObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRating = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRating.Should().NotBeNull();
                traktRating.Rating.Should().Be(8.32715f);
                traktRating.Votes.Should().Be(9274);
                traktRating.Distribution.Should().NotBeNull();
                traktRating.Distribution.Should().NotBeEmpty();
                traktRating.Distribution.Should().HaveCount(10);
                traktRating.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_TraktRatingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktRatingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRating = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRating.Should().NotBeNull();
                traktRating.Rating.Should().BeNull();
                traktRating.Votes.Should().Be(9274);
                traktRating.Distribution.Should().NotBeNull();
                traktRating.Distribution.Should().NotBeEmpty();
                traktRating.Distribution.Should().HaveCount(10);
                traktRating.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_TraktRatingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktRatingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRating = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRating.Should().NotBeNull();
                traktRating.Rating.Should().Be(8.32715f);
                traktRating.Votes.Should().BeNull();
                traktRating.Distribution.Should().NotBeNull();
                traktRating.Distribution.Should().NotBeEmpty();
                traktRating.Distribution.Should().HaveCount(10);
                traktRating.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_TraktRatingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TraktRatingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRating = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRating.Should().NotBeNull();
                traktRating.Rating.Should().Be(8.32715f);
                traktRating.Votes.Should().Be(9274);
                traktRating.Distribution.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktRatingObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new TraktRatingObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRating = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRating.Should().NotBeNull();
                traktRating.Rating.Should().Be(8.32715f);
                traktRating.Votes.Should().Be(9274);
                traktRating.Distribution.Should().NotBeNull();
                traktRating.Distribution.Should().NotBeEmpty();
                traktRating.Distribution.Should().HaveCount(10);
                traktRating.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 0,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 0,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_TraktRatingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktRatingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRating = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRating.Should().NotBeNull();
                traktRating.Rating.Should().BeNull();
                traktRating.Votes.Should().Be(9274);
                traktRating.Distribution.Should().NotBeNull();
                traktRating.Distribution.Should().NotBeEmpty();
                traktRating.Distribution.Should().HaveCount(10);
                traktRating.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_TraktRatingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktRatingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRating = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRating.Should().NotBeNull();
                traktRating.Rating.Should().Be(8.32715f);
                traktRating.Votes.Should().BeNull();
                traktRating.Distribution.Should().NotBeNull();
                traktRating.Distribution.Should().NotBeEmpty();
                traktRating.Distribution.Should().HaveCount(10);
                traktRating.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 55,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 545,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 1772,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_TraktRatingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktRatingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRating = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRating.Should().NotBeNull();
                traktRating.Rating.Should().Be(8.32715f);
                traktRating.Votes.Should().Be(9274);
                traktRating.Distribution.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktRatingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TraktRatingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRating = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRating.Should().NotBeNull();
                traktRating.Rating.Should().BeNull();
                traktRating.Votes.Should().BeNull();
                traktRating.Distribution.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktRatingObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new TraktRatingObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRating = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRating.Should().NotBeNull();
                traktRating.Rating.Should().Be(8.32715f);
                traktRating.Votes.Should().Be(9274);
                traktRating.Distribution.Should().NotBeNull();
                traktRating.Distribution.Should().NotBeEmpty();
                traktRating.Distribution.Should().HaveCount(10);
                traktRating.Distribution.Should().Contain(new Dictionary<string, int>
                {
                    ["1"] = 78,
                    ["2"] = 45,
                    ["3"] = 0,
                    ["4"] = 96,
                    ["5"] = 183,
                    ["6"] = 0,
                    ["7"] = 1361,
                    ["8"] = 2259,
                    ["9"] = 0,
                    ["10"] = 2863
                });
            }
        }

        [Fact]
        public async Task Test_TraktRatingObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktRatingObjectJsonReader();

            var traktRating = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktRating.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRatingObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktRatingObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRating = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktRating.Should().BeNull();
            }
        }
    }
}
