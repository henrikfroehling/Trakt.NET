namespace TraktApiSharp.Tests.Objects.Post.Users.CustomListItems.Responses.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Users.CustomListItems.Responses.JsonReader")]
    public partial class TraktUserCustomListItemsPostResponseGroupObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().BeNull();
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().BeNull();
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().BeNull();
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().BeNull();
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().BeNull();
                customListItemsPostResponseGroup.Seasons.Should().BeNull();
                customListItemsPostResponseGroup.Episodes.Should().BeNull();
                customListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().BeNull();
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().BeNull();
                customListItemsPostResponseGroup.Episodes.Should().BeNull();
                customListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().BeNull();
                customListItemsPostResponseGroup.Shows.Should().BeNull();
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().BeNull();
                customListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().BeNull();
                customListItemsPostResponseGroup.Shows.Should().BeNull();
                customListItemsPostResponseGroup.Seasons.Should().BeNull();
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().BeNull();
                customListItemsPostResponseGroup.Shows.Should().BeNull();
                customListItemsPostResponseGroup.Seasons.Should().BeNull();
                customListItemsPostResponseGroup.Episodes.Should().BeNull();
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().BeNull();
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().BeNull();
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().BeNull();
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().BeNull();
                customListItemsPostResponseGroup.People.Should().Be(5);
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().Be(1);
                customListItemsPostResponseGroup.Shows.Should().Be(2);
                customListItemsPostResponseGroup.Seasons.Should().Be(3);
                customListItemsPostResponseGroup.Episodes.Should().Be(4);
                customListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);

                customListItemsPostResponseGroup.Should().NotBeNull();
                customListItemsPostResponseGroup.Movies.Should().BeNull();
                customListItemsPostResponseGroup.Shows.Should().BeNull();
                customListItemsPostResponseGroup.Seasons.Should().BeNull();
                customListItemsPostResponseGroup.Episodes.Should().BeNull();
                customListItemsPostResponseGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(default(Stream));
            customListItemsPostResponseGroup.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserCustomListItemsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktUserCustomListItemsPostResponseGroupObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var customListItemsPostResponseGroup = await jsonReader.ReadObjectAsync(stream);
                customListItemsPostResponseGroup.Should().BeNull();
            }
        }
    }
}
