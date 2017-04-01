namespace TraktApiSharp.Tests.Objects.Get.People.Implementations
{
    using FluentAssertions;
    using System;
    using Traits;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Objects.Get.People.Implementations;
    using TraktApiSharp.Objects.Get.People.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.Implementations")]
    public class TraktPerson_Tests
    {
        [Fact]
        public void Test_TraktPerson_Implements_ITraktPerson_Interface()
        {
            typeof(TraktPerson).GetInterfaces().Should().Contain(typeof(ITraktPerson));
        }

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
        }

        [Fact]
        public void Test_TraktPerson_From_Minimal_Json()
        {
            var jsonReader = new TraktPersonObjectJsonReader();
            var person = jsonReader.ReadObject(MINIMAL_JSON);

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
        }

        [Fact]
        public void Test_TraktPerson_From_Full_Json()
        {
            var jsonReader = new TraktPersonObjectJsonReader();
            var person = jsonReader.ReadObject(FULL_JSON);

            person.Should().NotBeNull();
            person.Name.Should().Be("Bryan Cranston");
            person.Ids.Should().NotBeNull();
            person.Ids.Trakt.Should().Be(297737U);
            person.Ids.Slug.Should().Be("bryan-cranston");
            person.Ids.Imdb.Should().Be("nm0186505");
            person.Ids.Tmdb.Should().Be(17419U);
            person.Ids.TvRage.Should().Be(1797U);
            person.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            person.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            person.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            person.Age.Should().Be(60);
            person.Birthplace.Should().Be("San Fernando Valley, California, USA");
            person.Homepage.Should().Be("http://www.bryancranston.com/");
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
                ""biography"": ""Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia."",
                ""birthday"": ""1956-03-07"",
                ""death"": ""2016-04-06"",
                ""birthplace"": ""San Fernando Valley, California, USA"",
                ""homepage"": ""http://www.bryancranston.com/""
              }";
    }
}
