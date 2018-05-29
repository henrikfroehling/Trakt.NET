namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktRating_Tests
    {
        [Fact]
        public void Test_TraktRating_Default_Constructor()
        {
            var traktRating = new TraktRating();

            traktRating.Rating.Should().BeNull();
            traktRating.Votes.Should().BeNull();
            traktRating.Distribution.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRating_From_Json()
        {
            var jsonReader = new RatingObjectJsonReader();
            var traktRating = await jsonReader.ReadObjectAsync(JSON) as TraktRating;

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

        private const string JSON =
            @"{
                ""rating"": 8.32715,
                ""votes"": 9274,
                ""distribution"": {
                  ""1"": 78,
                  ""2"": 45,
                  ""3"": 55,
                  ""4"": 96,
                  ""5"": 183,
                  ""6"": 545,
                  ""7"": 1361,
                  ""8"": 2259,
                  ""9"": 1772,
                  ""10"": 2863
                }
              }";
    }
}
