﻿namespace TraktNet.Objects.Tests.Basic.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [Category("Objects.Basic.JsonWriter")]
    public partial class GenreObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_GenreObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new GenreObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_GenreObjectJsonWriter_WriteObject_Object_Only_Name_Property()
        {
            ITraktGenre traktGenre = new TraktGenre
            {
                Name = "genre name"
            };

            var traktJsonWriter = new GenreObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktGenre);
            json.Should().Be(@"{""name"":""genre name""}");
        }

        [Fact]
        public async Task Test_GenreObjectJsonWriter_WriteObject_Object_Only_Slug_Property()
        {
            ITraktGenre traktGenre = new TraktGenre
            {
                Slug = "genre slug"
            };

            var traktJsonWriter = new GenreObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktGenre);
            json.Should().Be(@"{""slug"":""genre slug""}");
        }

        [Fact]
        public async Task Test_GenreObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktGenre traktGenre = new TraktGenre
            {
                Name = "genre name",
                Slug = "genre slug"
            };

            var traktJsonWriter = new GenreObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktGenre);
            json.Should().Be(@"{""name"":""genre name"",""slug"":""genre slug""}");
        }
    }
}
