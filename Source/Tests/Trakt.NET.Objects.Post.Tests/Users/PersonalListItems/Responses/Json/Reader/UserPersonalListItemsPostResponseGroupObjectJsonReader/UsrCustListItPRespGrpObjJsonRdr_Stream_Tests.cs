namespace TraktNet.Objects.Post.Tests.Users.PersonalListItems.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.PersonalListItems.Responses;
    using TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Users.PersonalListItems.Responses.JsonReader")]
    public partial class UserPersonalListItemsPostResponseGroupObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().BeNull();
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().BeNull();
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().BeNull();
                personalListItemsPostResponseGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().BeNull();
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().BeNull();
                personalListItemsPostResponseGroup.Shows.Should().BeNull();
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().BeNull();
                personalListItemsPostResponseGroup.Shows.Should().BeNull();
                personalListItemsPostResponseGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().BeNull();
                personalListItemsPostResponseGroup.Shows.Should().BeNull();
                personalListItemsPostResponseGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().BeNull();
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().BeNull();
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().Be(1);
                personalListItemsPostResponseGroup.Shows.Should().Be(2);
                personalListItemsPostResponseGroup.Seasons.Should().Be(3);
                personalListItemsPostResponseGroup.Episodes.Should().Be(4);
                personalListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                personalListItemsPostResponseGroup.Should().NotBeNull();
                personalListItemsPostResponseGroup.Movies.Should().BeNull();
                personalListItemsPostResponseGroup.Shows.Should().BeNull();
                personalListItemsPostResponseGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();
            Func<Task<ITraktUserPersonalListItemsPostResponseGroup>> personalListItemsPostResponseGroup = () => jsonReader.ReadObjectAsync(default(Stream));
            await personalListItemsPostResponseGroup.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var personalListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);
                personalListItemsPostResponseGroup.Should().BeNull();
            }
        }
    }
}
