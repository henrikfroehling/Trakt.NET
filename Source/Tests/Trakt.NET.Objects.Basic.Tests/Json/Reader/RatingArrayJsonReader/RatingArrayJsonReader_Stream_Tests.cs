namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class RatingArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(stream);
                traktRatings.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();
            IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(default(Stream));
            traktRatings.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktRating>();

            using (var stream = string.Empty.ToStream())
            {
                IEnumerable<ITraktRating> traktRatings = await jsonReader.ReadArrayAsync(stream);
                traktRatings.Should().BeNull();
            }
        }
    }
}
