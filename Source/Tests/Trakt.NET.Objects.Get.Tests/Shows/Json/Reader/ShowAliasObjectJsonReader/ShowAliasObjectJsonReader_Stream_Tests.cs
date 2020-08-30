namespace TraktNet.Objects.Get.Tests.Shows.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ShowAliasObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowAliasObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new ShowAliasObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktShowAlias = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAlias.Should().NotBeNull();
                traktShowAlias.Title.Should().Be("Game of Thrones- Das Lied von Eis und Feuer");
                traktShowAlias.CountryCode.Should().Be("de");
            }
        }

        [Fact]
        public async Task Test_ShowAliasObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new ShowAliasObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktShowAlias = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAlias.Should().NotBeNull();
                traktShowAlias.Title.Should().Be("Game of Thrones- Das Lied von Eis und Feuer");
                traktShowAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowAliasObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new ShowAliasObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktShowAlias = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAlias.Should().NotBeNull();
                traktShowAlias.Title.Should().BeNull();
                traktShowAlias.CountryCode.Should().Be("de");
            }
        }

        [Fact]
        public async Task Test_ShowAliasObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new ShowAliasObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktShowAlias = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAlias.Should().NotBeNull();
                traktShowAlias.Title.Should().BeNull();
                traktShowAlias.CountryCode.Should().Be("de");
            }
        }

        [Fact]
        public async Task Test_ShowAliasObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new ShowAliasObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktShowAlias = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAlias.Should().NotBeNull();
                traktShowAlias.Title.Should().Be("Game of Thrones- Das Lied von Eis und Feuer");
                traktShowAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowAliasObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new ShowAliasObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktShowAlias = await traktJsonReader.ReadObjectAsync(stream);

                traktShowAlias.Should().NotBeNull();
                traktShowAlias.Title.Should().BeNull();
                traktShowAlias.CountryCode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ShowAliasObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new ShowAliasObjectJsonReader();
            Func<Task<ITraktShowAlias>> traktShowAlias = () => traktJsonReader.ReadObjectAsync(default(Stream));
            traktShowAlias.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ShowAliasObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new ShowAliasObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktShowAlias = await traktJsonReader.ReadObjectAsync(stream);
                traktShowAlias.Should().BeNull();
            }
        }
    }
}
