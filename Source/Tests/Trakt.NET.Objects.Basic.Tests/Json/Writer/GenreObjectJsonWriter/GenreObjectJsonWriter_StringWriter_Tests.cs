namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class GenreObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_GenreObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new GenreObjectJsonWriter();
            ITraktGenre traktGenre = new TraktGenre();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktGenre);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_GenreObjectJsonWriter_WriteObject_StringWriter_Only_Name_Property()
        {
            ITraktGenre traktGenre = new TraktGenre
            {
                Name = "genre name"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new GenreObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktGenre);
                json.Should().Be(@"{""name"":""genre name""}");
            }
        }

        [Fact]
        public async Task Test_GenreObjectJsonWriter_WriteObject_StringWriter_Only_Slug_Property()
        {
            ITraktGenre traktGenre = new TraktGenre
            {
                Slug = "genre slug"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new GenreObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktGenre);
                json.Should().Be(@"{""slug"":""genre slug""}");
            }
        }

        [Fact]
        public async Task Test_GenreObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktGenre traktGenre = new TraktGenre
            {
                Name = "genre name",
                Slug = "genre slug"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new GenreObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktGenre);
                json.Should().Be(@"{""name"":""genre name"",""slug"":""genre slug""}");
            }
        }
    }
}
