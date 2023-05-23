namespace TraktNet.Objects.Get.Tests.People.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.People.JsonReader")]
    public partial class RecentlyUpdatedPersonObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecentlyUpdatedPersonObjectJsonReader_ReadObject_Complete()
        {
            var traktJsonReader = new RecentlyUpdatedPersonObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktUpdatedPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktUpdatedPerson.Should().NotBeNull();
            traktUpdatedPerson.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2022-11-03T18:58:09.000Z").ToUniversalTime());
            traktUpdatedPerson.Person.Should().NotBeNull();
            traktUpdatedPerson.Person.Name.Should().Be("Bryan Cranston");
            traktUpdatedPerson.Person.Ids.Should().NotBeNull();
            traktUpdatedPerson.Person.Ids.Trakt.Should().Be(297737U);
            traktUpdatedPerson.Person.Ids.Slug.Should().Be("bryan-cranston");
            traktUpdatedPerson.Person.Ids.Imdb.Should().Be("nm0186505");
            traktUpdatedPerson.Person.Ids.Tmdb.Should().Be(17419U);
            traktUpdatedPerson.Person.Ids.TvRage.Should().Be(1797U);
            traktUpdatedPerson.Person.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktUpdatedPerson.Person.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktUpdatedPerson.Person.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktUpdatedPerson.Person.Age.Should().Be(60);
            traktUpdatedPerson.Person.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktUpdatedPerson.Person.Homepage.Should().Be("http://www.bryancranston.com/");
            traktUpdatedPerson.Person.Gender.Should().Be(TraktGender.Male);
            traktUpdatedPerson.Person.KnownForDepartment.Should().Be("acting");
            traktUpdatedPerson.Person.SocialIds.Should().NotBeNull();
            traktUpdatedPerson.Person.SocialIds.Twitter.Should().Be("BryanCranston");
            traktUpdatedPerson.Person.SocialIds.Facebook.Should().Be("thebryancranston");
            traktUpdatedPerson.Person.SocialIds.Instagram.Should().Be("bryancranston");
            traktUpdatedPerson.Person.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktUpdatedPerson.Person.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T18:58:09.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_RecentlyUpdatedPersonObjectJsonReader_ReadObject_Incomplete_1()
        {
            var traktJsonReader = new RecentlyUpdatedPersonObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktUpdatedPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktUpdatedPerson.Should().NotBeNull();
            traktUpdatedPerson.RecentlyUpdatedAt.Should().BeNull();
            traktUpdatedPerson.Person.Should().NotBeNull();
            traktUpdatedPerson.Person.Name.Should().Be("Bryan Cranston");
            traktUpdatedPerson.Person.Ids.Should().NotBeNull();
            traktUpdatedPerson.Person.Ids.Trakt.Should().Be(297737U);
            traktUpdatedPerson.Person.Ids.Slug.Should().Be("bryan-cranston");
            traktUpdatedPerson.Person.Ids.Imdb.Should().Be("nm0186505");
            traktUpdatedPerson.Person.Ids.Tmdb.Should().Be(17419U);
            traktUpdatedPerson.Person.Ids.TvRage.Should().Be(1797U);
            traktUpdatedPerson.Person.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktUpdatedPerson.Person.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktUpdatedPerson.Person.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktUpdatedPerson.Person.Age.Should().Be(60);
            traktUpdatedPerson.Person.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktUpdatedPerson.Person.Homepage.Should().Be("http://www.bryancranston.com/");
            traktUpdatedPerson.Person.Gender.Should().Be(TraktGender.Male);
            traktUpdatedPerson.Person.KnownForDepartment.Should().Be("acting");
            traktUpdatedPerson.Person.SocialIds.Should().NotBeNull();
            traktUpdatedPerson.Person.SocialIds.Twitter.Should().Be("BryanCranston");
            traktUpdatedPerson.Person.SocialIds.Facebook.Should().Be("thebryancranston");
            traktUpdatedPerson.Person.SocialIds.Instagram.Should().Be("bryancranston");
            traktUpdatedPerson.Person.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktUpdatedPerson.Person.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T18:58:09.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_RecentlyUpdatedPersonObjectJsonReader_ReadObject_Incomplete_2()
        {
            var traktJsonReader = new RecentlyUpdatedPersonObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktUpdatedPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktUpdatedPerson.Should().NotBeNull();
            traktUpdatedPerson.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2022-11-03T18:58:09.000Z").ToUniversalTime());
            traktUpdatedPerson.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecentlyUpdatedPersonObjectJsonReader_ReadObject_Not_Valid_1()
        {
            var traktJsonReader = new RecentlyUpdatedPersonObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktUpdatedPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktUpdatedPerson.Should().NotBeNull();
            traktUpdatedPerson.RecentlyUpdatedAt.Should().BeNull();
            traktUpdatedPerson.Person.Should().NotBeNull();
            traktUpdatedPerson.Person.Name.Should().Be("Bryan Cranston");
            traktUpdatedPerson.Person.Ids.Should().NotBeNull();
            traktUpdatedPerson.Person.Ids.Trakt.Should().Be(297737U);
            traktUpdatedPerson.Person.Ids.Slug.Should().Be("bryan-cranston");
            traktUpdatedPerson.Person.Ids.Imdb.Should().Be("nm0186505");
            traktUpdatedPerson.Person.Ids.Tmdb.Should().Be(17419U);
            traktUpdatedPerson.Person.Ids.TvRage.Should().Be(1797U);
            traktUpdatedPerson.Person.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktUpdatedPerson.Person.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktUpdatedPerson.Person.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktUpdatedPerson.Person.Age.Should().Be(60);
            traktUpdatedPerson.Person.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktUpdatedPerson.Person.Homepage.Should().Be("http://www.bryancranston.com/");
            traktUpdatedPerson.Person.Gender.Should().Be(TraktGender.Male);
            traktUpdatedPerson.Person.KnownForDepartment.Should().Be("acting");
            traktUpdatedPerson.Person.SocialIds.Should().NotBeNull();
            traktUpdatedPerson.Person.SocialIds.Twitter.Should().Be("BryanCranston");
            traktUpdatedPerson.Person.SocialIds.Facebook.Should().Be("thebryancranston");
            traktUpdatedPerson.Person.SocialIds.Instagram.Should().Be("bryancranston");
            traktUpdatedPerson.Person.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktUpdatedPerson.Person.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T18:58:09.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_RecentlyUpdatedPersonObjectJsonReader_ReadObject_Not_Valid_2()
        {
            var traktJsonReader = new RecentlyUpdatedPersonObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktUpdatedPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktUpdatedPerson.Should().NotBeNull();
            traktUpdatedPerson.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2022-11-03T18:58:09.000Z").ToUniversalTime());
            traktUpdatedPerson.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecentlyUpdatedPersonObjectJsonReader_ReadObject_Not_Valid_3()
        {
            var traktJsonReader = new RecentlyUpdatedPersonObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktUpdatedPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktUpdatedPerson.Should().NotBeNull();
            traktUpdatedPerson.RecentlyUpdatedAt.Should().BeNull();
            traktUpdatedPerson.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecentlyUpdatedPersonObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new RecentlyUpdatedPersonObjectJsonReader();
            Func<Task<ITraktRecentlyUpdatedPerson>> traktUpdatedPerson = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktUpdatedPerson.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecentlyUpdatedPersonObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new RecentlyUpdatedPersonObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktUpdatedPerson = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktUpdatedPerson.Should().BeNull();
        }
    }
}
