namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class RatingArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_RatingArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new RatingArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktRating> traktRatings = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktRatings.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_RatingArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new RatingArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktRating> traktRatings = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktRatings.Should().NotBeNull();
                ITraktRating[] ratings = traktRatings.ToArray();

                ratings[0].Should().NotBeNull();
                ratings[0].Rating.Should().Be(8.32715f);
                ratings[0].Votes.Should().Be(9274);
                ratings[0].Distribution.Should().NotBeNull();
                ratings[0].Distribution.Should().NotBeEmpty();
                ratings[0].Distribution.Should().HaveCount(10);
                ratings[0].Distribution.Should().Contain(new Dictionary<string, int>
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

                ratings[1].Should().NotBeNull();
                ratings[1].Rating.Should().Be(8.32715f);
                ratings[1].Votes.Should().Be(9274);
                ratings[1].Distribution.Should().NotBeNull();
                ratings[1].Distribution.Should().NotBeEmpty();
                ratings[1].Distribution.Should().HaveCount(10);
                ratings[1].Distribution.Should().Contain(new Dictionary<string, int>
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
        public async Task Test_RatingArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new RatingArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktRating> traktRatings = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktRatings.Should().NotBeNull();
                ITraktRating[] ratings = traktRatings.ToArray();

                ratings[0].Should().NotBeNull();
                ratings[0].Rating.Should().Be(8.32715f);
                ratings[0].Votes.Should().Be(9274);
                ratings[0].Distribution.Should().NotBeNull();
                ratings[0].Distribution.Should().NotBeEmpty();
                ratings[0].Distribution.Should().HaveCount(10);
                ratings[0].Distribution.Should().Contain(new Dictionary<string, int>
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

                ratings[1].Should().NotBeNull();
                ratings[1].Rating.Should().BeNull();
                ratings[1].Votes.Should().Be(9274);
                ratings[1].Distribution.Should().NotBeNull();
                ratings[1].Distribution.Should().NotBeEmpty();
                ratings[1].Distribution.Should().HaveCount(10);
                ratings[1].Distribution.Should().Contain(new Dictionary<string, int>
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
        public async Task Test_RatingArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new RatingArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktRating> traktRatings = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktRatings.Should().NotBeNull();
                ITraktRating[] ratings = traktRatings.ToArray();

                ratings[0].Should().NotBeNull();
                ratings[0].Rating.Should().BeNull();
                ratings[0].Votes.Should().Be(9274);
                ratings[0].Distribution.Should().NotBeNull();
                ratings[0].Distribution.Should().NotBeEmpty();
                ratings[0].Distribution.Should().HaveCount(10);
                ratings[0].Distribution.Should().Contain(new Dictionary<string, int>
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

                ratings[1].Should().NotBeNull();
                ratings[1].Rating.Should().Be(8.32715f);
                ratings[1].Votes.Should().Be(9274);
                ratings[1].Distribution.Should().NotBeNull();
                ratings[1].Distribution.Should().NotBeEmpty();
                ratings[1].Distribution.Should().HaveCount(10);
                ratings[1].Distribution.Should().Contain(new Dictionary<string, int>
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
        public async Task Test_RatingArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new RatingArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktRating> traktRatings = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktRatings.Should().NotBeNull();
                ITraktRating[] ratings = traktRatings.ToArray();

                ratings[0].Should().NotBeNull();
                ratings[0].Rating.Should().BeNull();
                ratings[0].Votes.Should().Be(9274);
                ratings[0].Distribution.Should().NotBeNull();
                ratings[0].Distribution.Should().NotBeEmpty();
                ratings[0].Distribution.Should().HaveCount(10);
                ratings[0].Distribution.Should().Contain(new Dictionary<string, int>
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

                ratings[1].Should().NotBeNull();
                ratings[1].Rating.Should().Be(8.32715f);
                ratings[1].Votes.Should().Be(9274);
                ratings[1].Distribution.Should().NotBeNull();
                ratings[1].Distribution.Should().NotBeEmpty();
                ratings[1].Distribution.Should().HaveCount(10);
                ratings[1].Distribution.Should().Contain(new Dictionary<string, int>
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
        public async Task Test_RatingArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new RatingArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktRating> traktRatings = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktRatings.Should().NotBeNull();
                ITraktRating[] ratings = traktRatings.ToArray();

                ratings[0].Should().NotBeNull();
                ratings[0].Rating.Should().Be(8.32715f);
                ratings[0].Votes.Should().Be(9274);
                ratings[0].Distribution.Should().NotBeNull();
                ratings[0].Distribution.Should().NotBeEmpty();
                ratings[0].Distribution.Should().HaveCount(10);
                ratings[0].Distribution.Should().Contain(new Dictionary<string, int>
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

                ratings[1].Should().NotBeNull();
                ratings[1].Rating.Should().BeNull();
                ratings[1].Votes.Should().Be(9274);
                ratings[1].Distribution.Should().NotBeNull();
                ratings[1].Distribution.Should().NotBeEmpty();
                ratings[1].Distribution.Should().HaveCount(10);
                ratings[1].Distribution.Should().Contain(new Dictionary<string, int>
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
        public async Task Test_RatingArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new RatingArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktRating> traktRatings = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktRatings.Should().NotBeNull();
                ITraktRating[] ratings = traktRatings.ToArray();

                ratings[0].Should().NotBeNull();
                ratings[0].Rating.Should().BeNull();
                ratings[0].Votes.Should().Be(9274);
                ratings[0].Distribution.Should().NotBeNull();
                ratings[0].Distribution.Should().NotBeEmpty();
                ratings[0].Distribution.Should().HaveCount(10);
                ratings[0].Distribution.Should().Contain(new Dictionary<string, int>
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

                ratings[1].Should().NotBeNull();
                ratings[1].Rating.Should().BeNull();
                ratings[1].Votes.Should().Be(9274);
                ratings[1].Distribution.Should().NotBeNull();
                ratings[1].Distribution.Should().NotBeEmpty();
                ratings[1].Distribution.Should().HaveCount(10);
                ratings[1].Distribution.Should().Contain(new Dictionary<string, int>
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
        public async Task Test_RatingArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new RatingArrayJsonReader();
            IEnumerable<ITraktRating> traktRatings = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktRatings.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new RatingArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktRating> traktRatings = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktRatings.Should().BeNull();
            }
        }
    }
}
