namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.JsonReader")]
    public partial class CountryObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new CountryObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                ITraktCountry traktCountry = await traktJsonReader.ReadObjectAsync(stream);

                traktCountry.Should().NotBeNull();
                traktCountry.Name.Should().Be("Australia");
                traktCountry.Code.Should().Be("au");
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new CountryObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                ITraktCountry traktCountry = await traktJsonReader.ReadObjectAsync(stream);

                traktCountry.Should().NotBeNull();
                traktCountry.Name.Should().BeNull();
                traktCountry.Code.Should().Be("au");
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new CountryObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                ITraktCountry traktCountry = await traktJsonReader.ReadObjectAsync(stream);

                traktCountry.Should().NotBeNull();
                traktCountry.Name.Should().Be("Australia");
                traktCountry.Code.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new CountryObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                ITraktCountry traktCountry = await traktJsonReader.ReadObjectAsync(stream);

                traktCountry.Should().NotBeNull();
                traktCountry.Name.Should().BeNull();
                traktCountry.Code.Should().Be("au");
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new CountryObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                ITraktCountry traktCountry = await traktJsonReader.ReadObjectAsync(stream);

                traktCountry.Should().NotBeNull();
                traktCountry.Name.Should().Be("Australia");
                traktCountry.Code.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new CountryObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                ITraktCountry traktCountry = await traktJsonReader.ReadObjectAsync(stream);

                traktCountry.Should().NotBeNull();
                traktCountry.Name.Should().BeNull();
                traktCountry.Code.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new CountryObjectJsonReader();
            Func<Task<ITraktCountry>> traktCountry = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await traktCountry.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CountryObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new CountryObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                ITraktCountry traktCountry = await traktJsonReader.ReadObjectAsync(stream);
                traktCountry.Should().BeNull();
            }
        }
    }
}
