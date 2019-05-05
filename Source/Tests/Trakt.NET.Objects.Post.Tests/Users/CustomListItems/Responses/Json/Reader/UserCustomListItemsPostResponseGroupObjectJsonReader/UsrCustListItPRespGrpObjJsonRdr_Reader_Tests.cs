namespace TraktNet.Objects.Post.Tests.Users.CustomListItems.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Users.CustomListItems.Responses.JsonReader")]
    public partial class UserCustomListItemsPostResponseGroupObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().BeNull();
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().BeNull();
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().BeNull();
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().BeNull();
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().BeNull();
                customListItemsPostResponseGroup.Seasons.Should().BeNull();
                customListItemsPostResponseGroup.Episodes.Should().BeNull();
                customListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().BeNull();
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().BeNull();
                customListItemsPostResponseGroup.Episodes.Should().BeNull();
                customListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().BeNull();
                customListItemsPostResponseGroup.Shows.Should().BeNull();
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().BeNull();
                customListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().BeNull();
                customListItemsPostResponseGroup.Shows.Should().BeNull();
                customListItemsPostResponseGroup.Seasons.Should().BeNull();
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().BeNull();
                customListItemsPostResponseGroup.Shows.Should().BeNull();
                customListItemsPostResponseGroup.Seasons.Should().BeNull();
                customListItemsPostResponseGroup.Episodes.Should().BeNull();
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().BeNull();
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().BeNull();
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().BeNull();
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().BeNull();
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().BeNull();
                customListItemsPostResponseGroup.Shows.Should().BeNull();
                customListItemsPostResponseGroup.Seasons.Should().BeNull();
                customListItemsPostResponseGroup.Episodes.Should().BeNull();
                customListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            customListItemsPostResponseGroup.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var customListItemsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);
                customListItemsPostResponseGroup.Should().BeNull();
            }
        }
    }
}
