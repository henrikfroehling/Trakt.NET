namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class StudioObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_StudioObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new StudioObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStudio = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStudio.Should().NotBeNull();
                traktStudio.Name.Should().Be("20th Century Fox");
                traktStudio.CountryCode.Should().Be("us");
                traktStudio.Ids.Should().NotBeNull();
                traktStudio.Ids.Trakt.Should().Be(20U);
                traktStudio.Ids.Slug.Should().Be("20th-century-fox");
                traktStudio.Ids.Tmdb.Should().Be(25U);
            }
        }

        [Fact]
        public async Task Test_StudioObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new StudioObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStudio = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStudio.Should().NotBeNull();
                traktStudio.Name.Should().BeNull();
                traktStudio.CountryCode.Should().Be("us");
                traktStudio.Ids.Should().NotBeNull();
                traktStudio.Ids.Trakt.Should().Be(20U);
                traktStudio.Ids.Slug.Should().Be("20th-century-fox");
                traktStudio.Ids.Tmdb.Should().Be(25U);
            }
        }

        [Fact]
        public async Task Test_StudioObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new StudioObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStudio = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStudio.Should().NotBeNull();
                traktStudio.Name.Should().Be("20th Century Fox");
                traktStudio.CountryCode.Should().BeNull();
                traktStudio.Ids.Should().NotBeNull();
                traktStudio.Ids.Trakt.Should().Be(20U);
                traktStudio.Ids.Slug.Should().Be("20th-century-fox");
                traktStudio.Ids.Tmdb.Should().Be(25U);
            }
        }

        [Fact]
        public async Task Test_StudioObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new StudioObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStudio = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStudio.Should().NotBeNull();
                traktStudio.Name.Should().Be("20th Century Fox");
                traktStudio.CountryCode.Should().Be("us");
                traktStudio.Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_StudioObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new StudioObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStudio = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStudio.Should().NotBeNull();
                traktStudio.Name.Should().BeNull();
                traktStudio.CountryCode.Should().Be("us");
                traktStudio.Ids.Should().NotBeNull();
                traktStudio.Ids.Trakt.Should().Be(20U);
                traktStudio.Ids.Slug.Should().Be("20th-century-fox");
                traktStudio.Ids.Tmdb.Should().Be(25U);
            }
        }

        [Fact]
        public async Task Test_StudioObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new StudioObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStudio = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStudio.Should().NotBeNull();
                traktStudio.Name.Should().Be("20th Century Fox");
                traktStudio.CountryCode.Should().BeNull();
                traktStudio.Ids.Should().NotBeNull();
                traktStudio.Ids.Trakt.Should().Be(20U);
                traktStudio.Ids.Slug.Should().Be("20th-century-fox");
                traktStudio.Ids.Tmdb.Should().Be(25U);
            }
        }

        [Fact]
        public async Task Test_StudioObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new StudioObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStudio = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStudio.Should().NotBeNull();
                traktStudio.Name.Should().Be("20th Century Fox");
                traktStudio.CountryCode.Should().Be("us");
                traktStudio.Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_StudioObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new StudioObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktStudio = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktStudio.Should().NotBeNull();
                traktStudio.Name.Should().BeNull();
                traktStudio.CountryCode.Should().BeNull();
                traktStudio.Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_StudioObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new StudioObjectJsonReader();
            Func<Task<ITraktStudio>> traktStudio = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktStudio.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_StudioObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new StudioObjectJsonReader();
            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktStudio = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktStudio.Should().BeNull();
        }
    }
}
