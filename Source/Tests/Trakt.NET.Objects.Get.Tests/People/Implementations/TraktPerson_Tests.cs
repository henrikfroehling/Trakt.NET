namespace TraktNet.Objects.Get.Tests.People.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.People.Implementations")]
    public class TraktPerson_Tests
    {
        [Fact]
        public void Test_TraktPerson_Default_Constructor()
        {
            var person = new TraktPerson();

            person.Name.Should().BeNullOrEmpty();
            person.Ids.Should().BeNull();
            person.Biography.Should().BeNullOrEmpty();
            person.Birthday.Should().NotHaveValue();
            person.Death.Should().NotHaveValue();
            person.Age.Should().Be(0);
            person.Birthplace.Should().BeNullOrEmpty();
            person.Homepage.Should().BeNullOrEmpty();
            person.Gender.Should().BeNull();
            person.KnownForDepartment.Should().BeNull();
            person.SocialIds.Should().BeNull();
            person.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPerson_From_Minimal_Json()
        {
            var jsonReader = new PersonObjectJsonReader();
            var person = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktPerson;

            person.Should().NotBeNull();
            person.Name.Should().Be("Bryan Cranston");
            person.Ids.Should().NotBeNull();
            person.Ids.Trakt.Should().Be(297737U);
            person.Ids.Slug.Should().Be("bryan-cranston");
            person.Ids.Imdb.Should().Be("nm0186505");
            person.Ids.Tmdb.Should().Be(17419U);
            person.Ids.TvRage.Should().Be(1797U);
            person.Biography.Should().BeNullOrEmpty();
            person.Birthday.Should().NotHaveValue();
            person.Death.Should().NotHaveValue();
            person.Age.Should().Be(0);
            person.Birthplace.Should().BeNullOrEmpty();
            person.Homepage.Should().BeNullOrEmpty();
            person.Gender.Should().BeNull();
            person.KnownForDepartment.Should().BeNull();
            person.SocialIds.Should().BeNull();
            person.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPerson_From_Full_Json()
        {
            var jsonReader = new PersonObjectJsonReader();
            var person = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktPerson;

            person.Should().NotBeNull();
            person.Name.Should().Be("Bryan Cranston");
            person.Ids.Should().NotBeNull();
            person.Ids.Trakt.Should().Be(297737U);
            person.Ids.Slug.Should().Be("bryan-cranston");
            person.Ids.Imdb.Should().Be("nm0186505");
            person.Ids.Tmdb.Should().Be(17419U);
            person.Ids.TvRage.Should().Be(1797U);
            person.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            person.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            person.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            person.Age.Should().Be(60);
            person.Birthplace.Should().Be("San Fernando Valley, California, USA");
            person.Homepage.Should().Be("http://www.bryancranston.com/");
            person.Gender.Should().Be(TraktGender.Male);
            person.KnownForDepartment.Should().Be(TraktKnownForDepartment.Acting);
            person.SocialIds.Should().NotBeNull();
            person.SocialIds.Twitter.Should().Be("BryanCranston");
            person.SocialIds.Facebook.Should().Be("thebryancranston");
            person.SocialIds.Instagram.Should().Be("bryancranston");
            person.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            person.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T17:00:54.000Z").ToUniversalTime());
        }

        private const string MINIMAL_JSON =
            @"{
                ""name"": ""Bryan Cranston"",
                ""ids"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                }
              }";

        private const string FULL_JSON =
            @"{
                ""name"": ""Bryan Cranston"",
                ""ids"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                },
                ""biography"": ""Bryan Lee Cranston(born March 7, 1956)..."",
                ""birthday"": ""1956-03-07"",
                ""death"": ""2016-04-06"",
                ""birthplace"": ""San Fernando Valley, California, USA"",
                ""homepage"": ""http://www.bryancranston.com/"",
                ""gender"": ""male"",
                ""known_for_department"": ""acting"",
                ""social_ids"": {
                  ""twitter"": ""BryanCranston"",
                  ""facebook"": ""thebryancranston"",
                  ""instagram"": ""bryancranston"",
                  ""wikipedia"": ""Bryan_Cranston""
                },
                ""updated_at"": ""2022-11-03T17:00:54.000Z""
              }";
    }
}
