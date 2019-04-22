namespace TraktNet.Objects.Tests.Basic.Json.Writer
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
    public partial class GenreArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_GenreArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktGenre>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_GenreArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktGenre> traktGenres = new List<TraktGenre>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktGenre>();
            string json = await traktJsonWriter.WriteArrayAsync(traktGenres);
            json.Should().Be("[]");
        }

        [Fact]
        public async Task Test_GenreArrayJsonWriter_WriteArray_Array_SingleObject()
        {
            IEnumerable<ITraktGenre> traktGenres = new List<ITraktGenre>
            {
                new TraktGenre
                {
                    Name = "genre name 1",
                    Slug = "genre slug 1"
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktGenre>();
            string json = await traktJsonWriter.WriteArrayAsync(traktGenres);
            json.Should().Be(@"[{""name"":""genre name 1"",""slug"":""genre slug 1""}]");
        }

        [Fact]
        public async Task Test_GenreArrayJsonWriter_WriteArray_Array_Complete()
        {
            IEnumerable<ITraktGenre> traktGenres = new List<ITraktGenre>
            {
                new TraktGenre
                {
                    Name = "genre name 1",
                    Slug = "genre slug 1"
                },
                new TraktGenre
                {
                    Name = "genre name 2",
                    Slug = "genre slug 2"
                },
                new TraktGenre
                {
                    Name = "genre name 3",
                    Slug = "genre slug 3"
                }
            };

            var traktJsonWriter = new ArrayJsonWriter<ITraktGenre>();
            string json = await traktJsonWriter.WriteArrayAsync(traktGenres);
            json.Should().Be(@"[{""name"":""genre name 1"",""slug"":""genre slug 1""}," +
                             @"{""name"":""genre name 2"",""slug"":""genre slug 2""}," +
                             @"{""name"":""genre name 3"",""slug"":""genre slug 3""}]");
        }
    }
}
