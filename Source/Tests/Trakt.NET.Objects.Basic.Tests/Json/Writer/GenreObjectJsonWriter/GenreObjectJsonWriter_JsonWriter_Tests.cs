namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class GenreObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_GenreObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new GenreObjectJsonWriter();
            ITraktGenre traktGenre = new TraktGenre();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktGenre);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_GenreObjectJsonWriter_WriteObject_JsonWriter_Only_Name_Property()
        {
            ITraktGenre traktGenre = new TraktGenre
            {
                Name = "genre name"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new GenreObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktGenre);
                stringWriter.ToString().Should().Be(@"{""name"":""genre name""}");
            }
        }

        [Fact]
        public async Task Test_GenreObjectJsonWriter_WriteObject_JsonWriter_Only_Slug_Property()
        {
            ITraktGenre traktGenre = new TraktGenre
            {
                Slug = "genre slug"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new GenreObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktGenre);
                stringWriter.ToString().Should().Be(@"{""slug"":""genre slug""}");
            }
        }

        [Fact]
        public async Task Test_GenreObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktGenre traktGenre = new TraktGenre
            {
                Name = "genre name",
                Slug = "genre slug"
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new GenreObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktGenre);
                stringWriter.ToString().Should().Be(@"{""name"":""genre name"",""slug"":""genre slug""}");
            }
        }
    }
}
