﻿namespace TraktNet.Objects.Tests.Post.Users.CustomListItems.Responses.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Users.CustomListItems.Responses.JsonReader")]
    public partial class UserCustomListItemsPostResponseGroupObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().Be(1);
            customListItemsPostResponseGroup.Shows.Should().Be(2);
            customListItemsPostResponseGroup.Seasons.Should().Be(3);
            customListItemsPostResponseGroup.Episodes.Should().Be(4);
            customListItemsPostResponseGroup.People.Should().Be(5);
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().BeNull();
            customListItemsPostResponseGroup.Shows.Should().Be(2);
            customListItemsPostResponseGroup.Seasons.Should().Be(3);
            customListItemsPostResponseGroup.Episodes.Should().Be(4);
            customListItemsPostResponseGroup.People.Should().Be(5);
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().Be(1);
            customListItemsPostResponseGroup.Shows.Should().BeNull();
            customListItemsPostResponseGroup.Seasons.Should().Be(3);
            customListItemsPostResponseGroup.Episodes.Should().Be(4);
            customListItemsPostResponseGroup.People.Should().Be(5);
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().Be(1);
            customListItemsPostResponseGroup.Shows.Should().Be(2);
            customListItemsPostResponseGroup.Seasons.Should().BeNull();
            customListItemsPostResponseGroup.Episodes.Should().Be(4);
            customListItemsPostResponseGroup.People.Should().Be(5);
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().Be(1);
            customListItemsPostResponseGroup.Shows.Should().Be(2);
            customListItemsPostResponseGroup.Seasons.Should().Be(3);
            customListItemsPostResponseGroup.Episodes.Should().BeNull();
            customListItemsPostResponseGroup.People.Should().Be(5);
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().Be(1);
            customListItemsPostResponseGroup.Shows.Should().Be(2);
            customListItemsPostResponseGroup.Seasons.Should().Be(3);
            customListItemsPostResponseGroup.Episodes.Should().Be(4);
            customListItemsPostResponseGroup.People.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().Be(1);
            customListItemsPostResponseGroup.Shows.Should().BeNull();
            customListItemsPostResponseGroup.Seasons.Should().BeNull();
            customListItemsPostResponseGroup.Episodes.Should().BeNull();
            customListItemsPostResponseGroup.People.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().BeNull();
            customListItemsPostResponseGroup.Shows.Should().Be(2);
            customListItemsPostResponseGroup.Seasons.Should().BeNull();
            customListItemsPostResponseGroup.Episodes.Should().BeNull();
            customListItemsPostResponseGroup.People.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().BeNull();
            customListItemsPostResponseGroup.Shows.Should().BeNull();
            customListItemsPostResponseGroup.Seasons.Should().Be(3);
            customListItemsPostResponseGroup.Episodes.Should().BeNull();
            customListItemsPostResponseGroup.People.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().BeNull();
            customListItemsPostResponseGroup.Shows.Should().BeNull();
            customListItemsPostResponseGroup.Seasons.Should().BeNull();
            customListItemsPostResponseGroup.Episodes.Should().Be(4);
            customListItemsPostResponseGroup.People.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().BeNull();
            customListItemsPostResponseGroup.Shows.Should().BeNull();
            customListItemsPostResponseGroup.Seasons.Should().BeNull();
            customListItemsPostResponseGroup.Episodes.Should().BeNull();
            customListItemsPostResponseGroup.People.Should().Be(5);
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().BeNull();
            customListItemsPostResponseGroup.Shows.Should().Be(2);
            customListItemsPostResponseGroup.Seasons.Should().Be(3);
            customListItemsPostResponseGroup.Episodes.Should().Be(4);
            customListItemsPostResponseGroup.People.Should().Be(5);
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().Be(1);
            customListItemsPostResponseGroup.Shows.Should().BeNull();
            customListItemsPostResponseGroup.Seasons.Should().Be(3);
            customListItemsPostResponseGroup.Episodes.Should().Be(4);
            customListItemsPostResponseGroup.People.Should().Be(5);
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().Be(1);
            customListItemsPostResponseGroup.Shows.Should().Be(2);
            customListItemsPostResponseGroup.Seasons.Should().BeNull();
            customListItemsPostResponseGroup.Episodes.Should().Be(4);
            customListItemsPostResponseGroup.People.Should().Be(5);
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().Be(1);
            customListItemsPostResponseGroup.Shows.Should().Be(2);
            customListItemsPostResponseGroup.Seasons.Should().Be(3);
            customListItemsPostResponseGroup.Episodes.Should().BeNull();
            customListItemsPostResponseGroup.People.Should().Be(5);
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().Be(1);
            customListItemsPostResponseGroup.Shows.Should().Be(2);
            customListItemsPostResponseGroup.Seasons.Should().Be(3);
            customListItemsPostResponseGroup.Episodes.Should().Be(4);
            customListItemsPostResponseGroup.People.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            customListItemsPostResponseGroup.Should().NotBeNull();
            customListItemsPostResponseGroup.Movies.Should().BeNull();
            customListItemsPostResponseGroup.Shows.Should().BeNull();
            customListItemsPostResponseGroup.Seasons.Should().BeNull();
            customListItemsPostResponseGroup.Episodes.Should().BeNull();
            customListItemsPostResponseGroup.People.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(default(string));
            customListItemsPostResponseGroup.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(string.Empty);
            customListItemsPostResponseGroup.Should().BeNull();
        }
    }
}
