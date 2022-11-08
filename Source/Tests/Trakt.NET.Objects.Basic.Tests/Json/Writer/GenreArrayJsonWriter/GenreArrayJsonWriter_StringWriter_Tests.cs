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

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class GenreArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_GenreArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktGenre>();
            IEnumerable<ITraktGenre> traktGenres = new List<TraktGenre>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktGenres);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_GenreArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktGenre> traktGenres = new List<TraktGenre>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktGenre>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktGenres);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_GenreArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktGenre> traktGenres = new List<ITraktGenre>
            {
                new TraktGenre
                {
                    Name = "genre name 1",
                    Slug = "genre slug 1"
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktGenre>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktGenres);
                json.Should().Be(@"[{""name"":""genre name 1"",""slug"":""genre slug 1""}]");
            }
        }

        [Fact]
        public async Task Test_GenreArrayJsonWriter_WriteArray_StringWriter_Complete()
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

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktGenre>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktGenres);
                json.Should().Be(@"[{""name"":""genre name 1"",""slug"":""genre slug 1""}," +
                                 @"{""name"":""genre name 2"",""slug"":""genre slug 2""}," +
                                 @"{""name"":""genre name 3"",""slug"":""genre slug 3""}]");
            }
        }
    }
}
