namespace TraktNet.Objects.Get.Tests.People.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.People.Implementations")]
    public class TraktRecentlyUpdatedPerson_Tests
    {
        [Fact]
        public void Test_TraktRecentlyUpdatedPerson_Default_Constructor()
        {
            var recentlyUpdatedPerson = new TraktRecentlyUpdatedPerson();

            recentlyUpdatedPerson.RecentlyUpdatedAt.Should().BeNull();
            recentlyUpdatedPerson.Person.Should().BeNull();
            recentlyUpdatedPerson.Name.Should().BeNull();
            recentlyUpdatedPerson.Ids.Should().BeNull();
            recentlyUpdatedPerson.Biography.Should().BeNull();
            recentlyUpdatedPerson.Birthday.Should().BeNull();
            recentlyUpdatedPerson.Death.Should().BeNull();
            recentlyUpdatedPerson.Age.Should().Be(0);
            recentlyUpdatedPerson.Birthplace.Should().BeNull();
            recentlyUpdatedPerson.Homepage.Should().BeNull();
            recentlyUpdatedPerson.Gender.Should().BeNull();
            recentlyUpdatedPerson.KnownForDepartment.Should().BeNull();
            recentlyUpdatedPerson.SocialIds.Should().BeNull();
            recentlyUpdatedPerson.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRecentlyUpdatedPerson_From_Json()
        {
            var jsonReader = new RecentlyUpdatedPersonObjectJsonReader();
            var recentlyUpdatedPerson = await jsonReader.ReadObjectAsync(JSON) as TraktRecentlyUpdatedPerson;

            recentlyUpdatedPerson.Should().NotBeNull();
            recentlyUpdatedPerson.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2022-11-03T18:58:09.000Z").ToUniversalTime());
            recentlyUpdatedPerson.Person.Should().NotBeNull();
            recentlyUpdatedPerson.Person.Name.Should().Be("Bryan Cranston");
            recentlyUpdatedPerson.Person.Ids.Should().NotBeNull();
            recentlyUpdatedPerson.Person.Ids.Trakt.Should().Be(297737U);
            recentlyUpdatedPerson.Person.Ids.Slug.Should().Be("bryan-cranston");
            recentlyUpdatedPerson.Person.Ids.Imdb.Should().Be("nm0186505");
            recentlyUpdatedPerson.Person.Ids.Tmdb.Should().Be(17419U);
            recentlyUpdatedPerson.Person.Ids.TvRage.Should().Be(1797U);
            recentlyUpdatedPerson.Person.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            recentlyUpdatedPerson.Person.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            recentlyUpdatedPerson.Person.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            recentlyUpdatedPerson.Person.Age.Should().Be(60);
            recentlyUpdatedPerson.Person.Birthplace.Should().Be("San Fernando Valley, California, USA");
            recentlyUpdatedPerson.Person.Homepage.Should().Be("http://www.bryancranston.com/");
            recentlyUpdatedPerson.Person.Gender.Should().Be("male");
            recentlyUpdatedPerson.Person.KnownForDepartment.Should().Be("acting");
            recentlyUpdatedPerson.Person.SocialIds.Should().NotBeNull();
            recentlyUpdatedPerson.Person.SocialIds.Twitter.Should().Be("BryanCranston");
            recentlyUpdatedPerson.Person.SocialIds.Facebook.Should().Be("thebryancranston");
            recentlyUpdatedPerson.Person.SocialIds.Instagram.Should().Be("bryancranston");
            recentlyUpdatedPerson.Person.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            recentlyUpdatedPerson.Person.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T18:58:09.000Z").ToUniversalTime());

            recentlyUpdatedPerson.Name.Should().Be("Bryan Cranston");
            recentlyUpdatedPerson.Ids.Should().NotBeNull();
            recentlyUpdatedPerson.Ids.Trakt.Should().Be(297737U);
            recentlyUpdatedPerson.Ids.Slug.Should().Be("bryan-cranston");
            recentlyUpdatedPerson.Ids.Imdb.Should().Be("nm0186505");
            recentlyUpdatedPerson.Ids.Tmdb.Should().Be(17419U);
            recentlyUpdatedPerson.Ids.TvRage.Should().Be(1797U);
            recentlyUpdatedPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956)...");
            recentlyUpdatedPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            recentlyUpdatedPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            recentlyUpdatedPerson.Age.Should().Be(60);
            recentlyUpdatedPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            recentlyUpdatedPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            recentlyUpdatedPerson.Gender.Should().Be("male");
            recentlyUpdatedPerson.KnownForDepartment.Should().Be("acting");
            recentlyUpdatedPerson.SocialIds.Should().NotBeNull();
            recentlyUpdatedPerson.SocialIds.Twitter.Should().Be("BryanCranston");
            recentlyUpdatedPerson.SocialIds.Facebook.Should().Be("thebryancranston");
            recentlyUpdatedPerson.SocialIds.Instagram.Should().Be("bryancranston");
            recentlyUpdatedPerson.SocialIds.Wikipedia.Should().Be("Bryan_Cranston");
            recentlyUpdatedPerson.UpdatedAt.Should().Be(DateTime.Parse("2022-11-03T18:58:09.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""updated_at"": ""2022-11-03T18:58:09.000Z"",
                ""person"": {
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
                  ""updated_at"": ""2022-11-03T18:58:09.000Z""
                }
              }";
    }
}
