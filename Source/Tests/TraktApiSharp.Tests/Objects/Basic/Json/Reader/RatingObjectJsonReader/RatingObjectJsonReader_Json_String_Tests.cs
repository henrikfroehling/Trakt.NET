namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class RatingObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RatingObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new RatingObjectJsonReader();

            var traktRating = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_RatingObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new RatingObjectJsonReader();

            var traktRating = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_RatingObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new RatingObjectJsonReader();

            var traktRating = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

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

        [Fact]
        public async Task Test_RatingObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new RatingObjectJsonReader();

            var traktRating = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktRating.Should().NotBeNull();
            traktRating.Rating.Should().Be(8.32715f);
            traktRating.Votes.Should().Be(9274);
            traktRating.Distribution.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new RatingObjectJsonReader();

            var traktRating = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

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

        [Fact]
        public async Task Test_RatingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new RatingObjectJsonReader();

            var traktRating = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_RatingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new RatingObjectJsonReader();

            var traktRating = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

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

        [Fact]
        public async Task Test_RatingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new RatingObjectJsonReader();

            var traktRating = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktRating.Should().NotBeNull();
            traktRating.Rating.Should().Be(8.32715f);
            traktRating.Votes.Should().Be(9274);
            traktRating.Distribution.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new RatingObjectJsonReader();

            var traktRating = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktRating.Should().NotBeNull();
            traktRating.Rating.Should().BeNull();
            traktRating.Votes.Should().BeNull();
            traktRating.Distribution.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new RatingObjectJsonReader();

            var traktRating = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

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

        [Fact]
        public async Task Test_RatingObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new RatingObjectJsonReader();

            var traktRating = await jsonReader.ReadObjectAsync(default(string));
            traktRating.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new RatingObjectJsonReader();

            var traktRating = await jsonReader.ReadObjectAsync(string.Empty);
            traktRating.Should().BeNull();
        }
    }
}
