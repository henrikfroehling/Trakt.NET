namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonReader")]
    public partial class AccountSettingsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
                userAccountSettings.DateFormat.Should().NotBeNull().And.Be(TraktDateFormat.DayMonthYear);
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().BeNull();
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
                userAccountSettings.DateFormat.Should().NotBeNull().And.Be(TraktDateFormat.DayMonthYear);
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeNull();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
                userAccountSettings.DateFormat.Should().NotBeNull().And.Be(TraktDateFormat.DayMonthYear);
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().BeNull();
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
                userAccountSettings.DateFormat.Should().NotBeNull().And.Be(TraktDateFormat.DayMonthYear);
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().BeNull();
                userAccountSettings.DateFormat.Should().NotBeNull().And.Be(TraktDateFormat.DayMonthYear);
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
                userAccountSettings.DateFormat.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeNull();
                userAccountSettings.CoverImage.Should().BeNull();
                userAccountSettings.Token.Should().BeNull();
                userAccountSettings.DateFormat.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().BeNull();
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().BeNull();
                userAccountSettings.Token.Should().BeNull();
                userAccountSettings.DateFormat.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().BeNull();
                userAccountSettings.Time24Hr.Should().BeNull();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().BeNull();
                userAccountSettings.DateFormat.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().BeNull();
                userAccountSettings.Time24Hr.Should().BeNull();
                userAccountSettings.CoverImage.Should().BeNull();
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
                userAccountSettings.DateFormat.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().BeNull();
                userAccountSettings.Time24Hr.Should().BeNull();
                userAccountSettings.CoverImage.Should().BeNull();
                userAccountSettings.Token.Should().BeNull();
                userAccountSettings.DateFormat.Should().NotBeNull().And.Be(TraktDateFormat.DayMonthYear);
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().BeNull();
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
                userAccountSettings.DateFormat.Should().NotBeNull().And.Be(TraktDateFormat.DayMonthYear);
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeNull();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
                userAccountSettings.DateFormat.Should().NotBeNull().And.Be(TraktDateFormat.DayMonthYear);
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().BeNull();
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
                userAccountSettings.DateFormat.Should().NotBeNull().And.Be(TraktDateFormat.DayMonthYear);
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().BeNull();
                userAccountSettings.DateFormat.Should().NotBeNull().And.Be(TraktDateFormat.DayMonthYear);
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
                userAccountSettings.DateFormat.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().BeNull();
                userAccountSettings.Time24Hr.Should().BeNull();
                userAccountSettings.CoverImage.Should().BeNull();
                userAccountSettings.Token.Should().BeNull();
                userAccountSettings.DateFormat.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();
            Func<Task<ITraktAccountSettings>> userAccountSettings = () => jsonReader.ReadObjectAsync(default(Stream));
            await userAccountSettings.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var userAccountSettings = await jsonReader.ReadObjectAsync(stream);
                userAccountSettings.Should().BeNull();
            }
        }
    }
}
