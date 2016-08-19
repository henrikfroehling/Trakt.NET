namespace TraktApiSharp.Tests.Objects.People
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Get.People;
    using Utils;

    [TestClass]
    public class TraktPersonTests
    {
        [TestMethod]
        public void TestTraktPersonDefaultConstructor()
        {
            var person = new TraktPerson();

            person.Name.Should().BeNullOrEmpty();
            person.Ids.Should().BeNull();
            person.Images.Should().BeNull();
            person.Biography.Should().BeNullOrEmpty();
            person.Birthday.Should().NotHaveValue();
            person.Death.Should().NotHaveValue();
            person.Age.Should().Be(0);
            person.Birthplace.Should().BeNullOrEmpty();
            person.Homepage.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktPersonReadFromJsonMinimal()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\People\PersonMinimal.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var person = JsonConvert.DeserializeObject<TraktPerson>(jsonFile);

            person.Should().NotBeNull();
            person.Name.Should().Be("Bryan Cranston");
            person.Ids.Should().NotBeNull();
            person.Ids.Trakt.Should().Be(297737U);
            person.Ids.Slug.Should().Be("bryan-cranston");
            person.Ids.Imdb.Should().Be("nm0186505");
            person.Ids.Tmdb.Should().Be(17419U);
            person.Ids.TvRage.Should().Be(1797U);
            person.Images.Should().BeNull();
            person.Biography.Should().BeNullOrEmpty();
            person.Birthday.Should().NotHaveValue();
            person.Death.Should().NotHaveValue();
            person.Age.Should().Be(0);
            person.Birthplace.Should().BeNullOrEmpty();
            person.Homepage.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktPersonReadFromJsonImages()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\People\PersonImages.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var person = JsonConvert.DeserializeObject<TraktPerson>(jsonFile);

            person.Should().NotBeNull();
            person.Name.Should().Be("Bryan Cranston");
            person.Ids.Should().NotBeNull();
            person.Ids.Trakt.Should().Be(297737U);
            person.Ids.Slug.Should().Be("bryan-cranston");
            person.Ids.Imdb.Should().Be("nm0186505");
            person.Ids.Tmdb.Should().Be(17419U);
            person.Ids.TvRage.Should().Be(1797U);
            person.Images.Should().NotBeNull();
            person.Images.Headshot.Should().NotBeNull();
            person.Images.Headshot.Full.Should().Be("https://walter.trakt.us/images/people/000/297/737/headshots/original/47aebaace9.jpg");
            person.Images.Headshot.Medium.Should().Be("https://walter.trakt.us/images/people/000/297/737/headshots/medium/47aebaace9.jpg");
            person.Images.Headshot.Thumb.Should().Be("https://walter.trakt.us/images/people/000/297/737/headshots/thumb/47aebaace9.jpg");
            person.Images.FanArt.Should().NotBeNull();
            person.Images.FanArt.Full.Should().Be("https://walter.trakt.us/images/people/000/297/737/fanarts/original/0e436db5dd.jpg");
            person.Images.FanArt.Medium.Should().Be("https://walter.trakt.us/images/people/000/297/737/fanarts/medium/0e436db5dd.jpg");
            person.Images.FanArt.Thumb.Should().Be("https://walter.trakt.us/images/people/000/297/737/fanarts/thumb/0e436db5dd.jpg");
            person.Biography.Should().BeNullOrEmpty();
            person.Birthday.Should().NotHaveValue();
            person.Death.Should().NotHaveValue();
            person.Age.Should().Be(0);
            person.Birthplace.Should().BeNullOrEmpty();
            person.Homepage.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktPersonReadFromJsonFull()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\People\PersonFull.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var person = JsonConvert.DeserializeObject<TraktPerson>(jsonFile);

            person.Should().NotBeNull();
            person.Name.Should().Be("Bryan Cranston");
            person.Ids.Should().NotBeNull();
            person.Ids.Trakt.Should().Be(297737U);
            person.Ids.Slug.Should().Be("bryan-cranston");
            person.Ids.Imdb.Should().Be("nm0186505");
            person.Ids.Tmdb.Should().Be(17419U);
            person.Ids.TvRage.Should().Be(1797U);
            person.Images.Should().BeNull();
            person.Biography.Should().Be("Bryan Lee Cranston (born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy \"Malcolm in the Middle\", and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            person.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            person.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            person.Age.Should().Be(60);
            person.Birthplace.Should().Be("San Fernando Valley, California, USA");
            person.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [TestMethod]
        public void TestTraktPersonReadFromJsonFullAndImages()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\People\PersonFullAndImages.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var person = JsonConvert.DeserializeObject<TraktPerson>(jsonFile);

            person.Should().NotBeNull();
            person.Name.Should().Be("Bryan Cranston");
            person.Ids.Should().NotBeNull();
            person.Ids.Trakt.Should().Be(297737U);
            person.Ids.Slug.Should().Be("bryan-cranston");
            person.Ids.Imdb.Should().Be("nm0186505");
            person.Ids.Tmdb.Should().Be(17419U);
            person.Ids.TvRage.Should().Be(1797U);
            person.Images.Should().NotBeNull();
            person.Images.Headshot.Should().NotBeNull();
            person.Images.Headshot.Full.Should().Be("https://walter.trakt.us/images/people/000/297/737/headshots/original/47aebaace9.jpg");
            person.Images.Headshot.Medium.Should().Be("https://walter.trakt.us/images/people/000/297/737/headshots/medium/47aebaace9.jpg");
            person.Images.Headshot.Thumb.Should().Be("https://walter.trakt.us/images/people/000/297/737/headshots/thumb/47aebaace9.jpg");
            person.Images.FanArt.Should().NotBeNull();
            person.Images.FanArt.Full.Should().Be("https://walter.trakt.us/images/people/000/297/737/fanarts/original/0e436db5dd.jpg");
            person.Images.FanArt.Medium.Should().Be("https://walter.trakt.us/images/people/000/297/737/fanarts/medium/0e436db5dd.jpg");
            person.Images.FanArt.Thumb.Should().Be("https://walter.trakt.us/images/people/000/297/737/fanarts/thumb/0e436db5dd.jpg");
            person.Biography.Should().Be("Bryan Lee Cranston (born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy \"Malcolm in the Middle\", and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            person.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            person.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            person.Age.Should().Be(60);
            person.Birthplace.Should().Be("San Fernando Valley, California, USA");
            person.Homepage.Should().Be("http://www.bryancranston.com/");
        }
    }
}
