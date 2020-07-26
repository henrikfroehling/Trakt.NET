namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class RatingArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();
            IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktRatings.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();
            IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();
            IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();
            IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

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

        [Fact]
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();
            IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();
            IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

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

        [Fact]
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();
            IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

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

        [Fact]
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();
            IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(default(string));
            traktRatings.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();
            IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(string.Empty);
            traktRatings.Should().BeNull();
        }
    }
}
