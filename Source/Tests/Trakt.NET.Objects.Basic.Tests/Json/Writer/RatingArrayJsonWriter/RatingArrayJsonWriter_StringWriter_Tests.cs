namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class RatingArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_RatingArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktRating>();
            IEnumerable<ITraktRating> traktRating = new List<TraktRating>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktRating);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RatingArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktRating> traktRating = new List<TraktRating>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktRating>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktRating);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_RatingArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktRating> traktRating = new List<ITraktRating>
            {
                new TraktRating
                {
                    Rating = 7.4561f,
                    Votes = 2453,
                    Distribution = new Dictionary<string, int>
                    {
                        ["1"] = 1,
                        ["2"] = 2,
                        ["3"] = 3,
                        ["4"] = 4,
                        ["5"] = 5,
                        ["6"] = 6,
                        ["7"] = 7,
                        ["8"] = 8,
                        ["9"] = 9,
                        ["10"] = 10
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktRating>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktRating);
                json.Should().Be(@"[{""rating"":7.4561,""votes"":2453," +
                                 @"""distribution"":{""1"":1,""2"":2,""3"":3,""4"":4,""5"":5,""6"":6,""7"":7,""8"":8,""9"":9,""10"":10}}]");
            }
        }

        [Fact]
        public async Task Test_RatingArrayJsonWriter_WriteArray_StringWriter_Complete()
        {
            IEnumerable<ITraktRating> traktRating = new List<ITraktRating>
            {
                new TraktRating
                {
                    Rating = 7.4561f,
                    Votes = 2453,
                    Distribution = new Dictionary<string, int>
                    {
                        ["1"] = 1,
                        ["2"] = 2,
                        ["3"] = 3,
                        ["4"] = 4,
                        ["5"] = 5,
                        ["6"] = 6,
                        ["7"] = 7,
                        ["8"] = 8,
                        ["9"] = 9,
                        ["10"] = 10
                    }
                },
                new TraktRating
                {
                    Rating = 7.4561f,
                    Votes = 2453,
                    Distribution = new Dictionary<string, int>
                    {
                        ["1"] = 1,
                        ["2"] = 2,
                        ["3"] = 3,
                        ["4"] = 4,
                        ["5"] = 5,
                        ["6"] = 6,
                        ["7"] = 7,
                        ["8"] = 8,
                        ["9"] = 9,
                        ["10"] = 10
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktRating>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktRating);
                json.Should().Be(@"[{""rating"":7.4561,""votes"":2453," +
                                 @"""distribution"":{""1"":1,""2"":2,""3"":3,""4"":4,""5"":5,""6"":6,""7"":7,""8"":8,""9"":9,""10"":10}}," +
                                 @"{""rating"":7.4561,""votes"":2453," +
                                 @"""distribution"":{""1"":1,""2"":2,""3"":3,""4"":4,""5"":5,""6"":6,""7"":7,""8"":8,""9"":9,""10"":10}}]");
            }
        }
    }
}
