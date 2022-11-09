﻿namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundPersonObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundPersonObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new PostResponseNotFoundPersonObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var postResponseNotFoundPerson = await jsonReader.ReadObjectAsync(stream);

                postResponseNotFoundPerson.Should().NotBeNull();
                postResponseNotFoundPerson.Ids.Should().NotBeNull();
                postResponseNotFoundPerson.Ids.Trakt.Should().Be(297737U);
                postResponseNotFoundPerson.Ids.Slug.Should().Be("bryan-cranston");
                postResponseNotFoundPerson.Ids.Imdb.Should().Be("nm0186505");
                postResponseNotFoundPerson.Ids.Tmdb.Should().Be(17419U);
                postResponseNotFoundPerson.Ids.TvRage.Should().Be(1797U);
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var jsonReader = new PostResponseNotFoundPersonObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var postResponseNotFoundPerson = await jsonReader.ReadObjectAsync(stream);

                postResponseNotFoundPerson.Should().NotBeNull();
                postResponseNotFoundPerson.Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new PostResponseNotFoundPersonObjectJsonReader();
            Func<Task<ITraktPostResponseNotFoundPerson>> postResponseNotFoundPerson = () => jsonReader.ReadObjectAsync(default(Stream));
            await postResponseNotFoundPerson.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundPersonObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new PostResponseNotFoundPersonObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var postResponseNotFoundPerson = await jsonReader.ReadObjectAsync(stream);
                postResponseNotFoundPerson.Should().BeNull();
            }
        }
    }
}
