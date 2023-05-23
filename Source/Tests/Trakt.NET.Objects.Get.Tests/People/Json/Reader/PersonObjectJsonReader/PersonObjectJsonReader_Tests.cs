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
    public partial class PersonObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Complete()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Incomplete_1()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().BeNull();
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Incomplete_2()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().BeNull();
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Incomplete_3()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Incomplete_4()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Incomplete_5()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().BeNull();
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Incomplete_6()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Incomplete_7()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_7);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().BeNull();
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Incomplete_8()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_8);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().BeNull();
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Incomplete_9()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_9);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().BeNull();
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Incomplete_10()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_10);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().BeNull();
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Incomplete_11()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_11);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Not_Valid_1()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().BeNull();
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Not_Valid_2()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().BeNull();
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Not_Valid_3()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Not_Valid_4()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Not_Valid_5()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().BeNull();
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Not_Valid_6()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Not_Valid_7()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_7);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().BeNull();
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Not_Valid_8()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_8);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().BeNull();
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Not_Valid_9()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_9);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().BeNull();
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Not_Valid_10()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_10);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().BeNull();
            traktPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Not_Valid_11()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_11);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            traktPerson.Gender.Should().Be(TraktGender.Male);
            traktPerson.KnownForDepartment.Should().Be("acting");
            traktPerson.SocialIds.Should().NotBeNull();
            traktPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            traktPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            traktPerson.SocialIds.Instagram.Should().Be("bryancranston");
            traktPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            traktPerson.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_Not_Valid_12()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_12);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().BeNull();
            traktPerson.Ids.Should().BeNull();
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().BeNull();
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().BeNull();
            traktPerson.Gender.Should().BeNull();
            traktPerson.KnownForDepartment.Should().BeNull();
            traktPerson.SocialIds.Should().BeNull();
            traktPerson.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PersonObjectJsonReader();
            Func<Task<ITraktPerson>> traktPerson = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktPerson.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PersonObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktPerson = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktPerson.Should().BeNull();
        }
    }
}
