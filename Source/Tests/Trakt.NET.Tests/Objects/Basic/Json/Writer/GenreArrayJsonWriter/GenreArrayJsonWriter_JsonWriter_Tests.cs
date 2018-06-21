namespace TraktNet.Tests.Objects.Basic.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class GenreArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_GenreArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktGenre>();
            IEnumerable<ITraktGenre> traktGenres = new List<TraktGenre>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktGenres);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_GenreArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktGenre> traktGenres = new List<TraktGenre>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktGenre>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktGenres);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_GenreArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktGenre>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktGenres);
                stringWriter.ToString().Should().Be(@"[{""name"":""genre name 1"",""slug"":""genre slug 1""}]");
            }
        }

        [Fact]
        public async Task Test_GenreArrayJsonWriter_WriteArray_JsonWriter_Complete()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktGenre>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktGenres);
                stringWriter.ToString().Should().Be(@"[{""name"":""genre name 1"",""slug"":""genre slug 1""}," +
                                                    @"{""name"":""genre name 2"",""slug"":""genre slug 2""}," +
                                                    @"{""name"":""genre name 3"",""slug"":""genre slug 3""}]");
            }
        }
    }
}
