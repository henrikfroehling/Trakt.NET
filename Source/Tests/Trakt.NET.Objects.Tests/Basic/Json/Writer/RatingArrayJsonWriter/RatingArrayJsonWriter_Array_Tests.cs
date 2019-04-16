﻿namespace TraktNet.Objects.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class RatingArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_RatingArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktRating>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RatingArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktRating> traktRating = new List<TraktRating>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktRating>();
            string json = await traktJsonWriter.WriteArrayAsync(traktRating);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_RatingArrayJsonWriter_WriteArray_Array_SingleObject()
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktRating>();
            string json = await traktJsonWriter.WriteArrayAsync(traktRating);
            json.Should().Be(@"[{""rating"":7.4561,""votes"":2453," +
                             @"""distribution"":{""1"":1,""2"":2,""3"":3,""4"":4,""5"":5,""6"":6,""7"":7,""8"":8,""9"":9,""10"":10}}]");
        }

        [Fact]
        public async Task Test_RatingArrayJsonWriter_WriteArray_Array_Complete()
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

            var traktJsonWriter = new ArrayJsonWriter<ITraktRating>();
            string json = await traktJsonWriter.WriteArrayAsync(traktRating);
            json.Should().Be(@"[{""rating"":7.4561,""votes"":2453," +
                                @"""distribution"":{""1"":1,""2"":2,""3"":3,""4"":4,""5"":5,""6"":6,""7"":7,""8"":8,""9"":9,""10"":10}}," +
                                @"{""rating"":7.4561,""votes"":2453," +
                                @"""distribution"":{""1"":1,""2"":2,""3"":3,""4"":4,""5"":5,""6"":6,""7"":7,""8"":8,""9"":9,""10"":10}}]");
        }
    }
}
