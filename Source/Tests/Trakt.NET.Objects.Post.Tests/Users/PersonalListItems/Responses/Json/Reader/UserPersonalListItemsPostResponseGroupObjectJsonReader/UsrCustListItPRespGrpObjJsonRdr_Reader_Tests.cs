namespace TraktNet.Objects.Post.Tests.Users.PersonalListItems.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.PersonalListItems.Responses;
    using TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Users.PersonalListItems.Responses.JsonReader")]
    public partial class UserPersonalListItemsPostResponseGroupObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().BeNull();
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().BeNull();
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().BeNull();
                personalListItemsPostResponseGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().BeNull();
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().BeNull();
                personalListItemsPostResponseGroup.Shows.Should().BeNull();
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().BeNull();
                personalListItemsPostResponseGroup.Shows.Should().BeNull();
                personalListItemsPostResponseGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().BeNull();
                personalListItemsPostResponseGroup.Shows.Should().BeNull();
                personalListItemsPostResponseGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().BeNull();
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().BeNull();
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().BeNull();
                personalListItemsPostResponseGroup.Shows.Should().BeNull();
                personalListItemsPostResponseGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();
            Func<Task<ITraktUserPersonalListItemsPostResponseGroup>> personalListItemsPostResponseGroup = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await personalListItemsPostResponseGroup.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);
                personalListItemsPostResponseGroup.Should().BeNull();
            }
        }
    }
}
