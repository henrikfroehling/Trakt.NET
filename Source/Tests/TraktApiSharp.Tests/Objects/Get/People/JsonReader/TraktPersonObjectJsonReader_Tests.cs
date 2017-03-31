namespace TraktApiSharp.Tests.Objects.Get.People.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using Traits;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.People.Implementations;
    using TraktApiSharp.Objects.Get.People.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader.Get.People")]
    public class TraktPersonObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktPersonObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktPersonObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<TraktPerson>));
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Minimal_Complete()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(MINIMAL_JSON_COMPLETE);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().BeNull();
            traktPerson.Age.Should().Be(0);
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_1()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_1);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().BeNull();
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().BeNull();
            traktPerson.Age.Should().Be(0);
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_2()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_2);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().BeNull();
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().BeNull();
            traktPerson.Age.Should().Be(0);
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_1()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_1);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().BeNull();
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().BeNull();
            traktPerson.Age.Should().Be(0);
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_2()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_2);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().BeNull();
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().BeNull();
            traktPerson.Age.Should().Be(0);
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_3()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_3);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().BeNull();
            traktPerson.Ids.Should().BeNull();
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().BeNull();
            traktPerson.Age.Should().Be(0);
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Complete()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_COMPLETE);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Age.Should().Be(60);
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_1()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_1);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().BeNull();
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Age.Should().Be(60);
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_2()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_2);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().BeNull();
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Age.Should().Be(60);
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_3()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_3);

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
            traktPerson.Age.Should().Be(60);
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_4()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_4);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Age.Should().Be(0);
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_5()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_5);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().BeNull();
            traktPerson.Age.Should().Be(traktPerson.Birthday.YearsBetween(DateTime.Now));
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_6()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_6);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Age.Should().Be(60);
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_7()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_7);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Age.Should().Be(60);
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_8()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_8);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().BeNull();
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().BeNull();
            traktPerson.Age.Should().Be(0);
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_9()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_9);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().BeNull();
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().BeNull();
            traktPerson.Age.Should().Be(0);
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_10()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_10);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().BeNull();
            traktPerson.Ids.Should().BeNull();
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().BeNull();
            traktPerson.Age.Should().Be(0);
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_11()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_11);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().BeNull();
            traktPerson.Ids.Should().BeNull();
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().BeNull();
            traktPerson.Age.Should().Be(traktPerson.Birthday.YearsBetween(DateTime.Now));
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_12()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_12);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().BeNull();
            traktPerson.Ids.Should().BeNull();
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Age.Should().Be(0);
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_13()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_13);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().BeNull();
            traktPerson.Ids.Should().BeNull();
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().BeNull();
            traktPerson.Age.Should().Be(0);
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_14()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_14);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().BeNull();
            traktPerson.Ids.Should().BeNull();
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().BeNull();
            traktPerson.Age.Should().Be(0);
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_1()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_NOT_VALID_1);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().BeNull();
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Age.Should().Be(60);
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_2()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_NOT_VALID_2);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().BeNull();
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Age.Should().Be(60);
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_3()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_NOT_VALID_3);

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
            traktPerson.Age.Should().Be(60);
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_4()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_NOT_VALID_4);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Age.Should().Be(0);
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_5()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_NOT_VALID_5);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().BeNull();
            traktPerson.Age.Should().Be(traktPerson.Birthday.YearsBetween(DateTime.Now));
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_6()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_NOT_VALID_6);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Age.Should().Be(60);
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_7()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_NOT_VALID_7);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().Be("Bryan Cranston");
            traktPerson.Ids.Should().NotBeNull();
            traktPerson.Ids.Trakt.Should().Be(297737U);
            traktPerson.Ids.Slug.Should().Be("bryan-cranston");
            traktPerson.Ids.Imdb.Should().Be("nm0186505");
            traktPerson.Ids.Tmdb.Should().Be(17419U);
            traktPerson.Ids.TvRage.Should().Be(1797U);
            traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            traktPerson.Age.Should().Be(60);
            traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
            traktPerson.Homepage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_8()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(FULL_JSON_NOT_VALID_8);

            traktPerson.Should().NotBeNull();
            traktPerson.Name.Should().BeNull();
            traktPerson.Ids.Should().BeNull();
            traktPerson.Biography.Should().BeNull();
            traktPerson.Birthday.Should().BeNull();
            traktPerson.Death.Should().BeNull();
            traktPerson.Age.Should().Be(0);
            traktPerson.Birthplace.Should().BeNull();
            traktPerson.Homepage.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(default(string));
            traktPerson.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(string.Empty);
            traktPerson.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Complete()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().BeNullOrEmpty();
                traktPerson.Birthday.Should().NotHaveValue();
                traktPerson.Death.Should().NotHaveValue();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNullOrEmpty();
                traktPerson.Homepage.Should().BeNullOrEmpty();
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_1()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNullOrEmpty();
                traktPerson.Birthday.Should().NotHaveValue();
                traktPerson.Death.Should().NotHaveValue();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNullOrEmpty();
                traktPerson.Homepage.Should().BeNullOrEmpty();
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_2()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().BeNullOrEmpty();
                traktPerson.Birthday.Should().NotHaveValue();
                traktPerson.Death.Should().NotHaveValue();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNullOrEmpty();
                traktPerson.Homepage.Should().BeNullOrEmpty();
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_1()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().BeNullOrEmpty();
                traktPerson.Birthday.Should().NotHaveValue();
                traktPerson.Death.Should().NotHaveValue();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNullOrEmpty();
                traktPerson.Homepage.Should().BeNullOrEmpty();
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_2()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNullOrEmpty();
                traktPerson.Birthday.Should().NotHaveValue();
                traktPerson.Death.Should().NotHaveValue();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNullOrEmpty();
                traktPerson.Homepage.Should().BeNullOrEmpty();
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_3()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNullOrEmpty();
                traktPerson.Birthday.Should().NotHaveValue();
                traktPerson.Death.Should().NotHaveValue();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNullOrEmpty();
                traktPerson.Homepage.Should().BeNullOrEmpty();
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Complete()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_1()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_2()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_3()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

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
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_4()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_5()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(traktPerson.Birthday.YearsBetween(DateTime.Now));
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_6()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_7()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_8()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_9()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_10()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_11()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(traktPerson.Birthday.YearsBetween(DateTime.Now));
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_12()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_13()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_14()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_1()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_2()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_3()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

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
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_4()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_5()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(traktPerson.Birthday.YearsBetween(DateTime.Now));
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_6()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().Be("http://www.bryancranston.com/");
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_7()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().Be("Bryan Cranston");
                traktPerson.Ids.Should().NotBeNull();
                traktPerson.Ids.Trakt.Should().Be(297737U);
                traktPerson.Ids.Slug.Should().Be("bryan-cranston");
                traktPerson.Ids.Imdb.Should().Be("nm0186505");
                traktPerson.Ids.Tmdb.Should().Be(17419U);
                traktPerson.Ids.TvRage.Should().Be(1797U);
                traktPerson.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
                traktPerson.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
                traktPerson.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
                traktPerson.Age.Should().Be(60);
                traktPerson.Birthplace.Should().Be("San Fernando Valley, California, USA");
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_8()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);

                traktPerson.Should().NotBeNull();
                traktPerson.Name.Should().BeNull();
                traktPerson.Ids.Should().BeNull();
                traktPerson.Biography.Should().BeNull();
                traktPerson.Birthday.Should().BeNull();
                traktPerson.Death.Should().BeNull();
                traktPerson.Age.Should().Be(0);
                traktPerson.Birthplace.Should().BeNull();
                traktPerson.Homepage.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new TraktPersonObjectJsonReader();

            var traktPerson = jsonReader.ReadObject(default(JsonTextReader));
            traktPerson.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPersonObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktPersonObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktPerson = traktJsonReader.ReadObject(jsonReader);
                traktPerson.Should().BeNull();
            }
        }

        private const string MINIMAL_JSON_COMPLETE =
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

        private const string MINIMAL_JSON_INCOMPLETE_1 =
            @"{
                ""name"": ""Bryan Cranston""
              }";

        private const string MINIMAL_JSON_INCOMPLETE_2 =
            @"{
                ""ids"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_1 =
            @"{
                ""na"": ""Bryan Cranston"",
                ""ids"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_2 =
            @"{
                ""name"": ""Bryan Cranston"",
                ""id"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_3 =
            @"{
                ""na"": ""Bryan Cranston"",
                ""id"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                }
              }";

        private const string FULL_JSON_COMPLETE =
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

        private const string FULL_JSON_INCOMPLETE_1 =
            @"{
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

        private const string FULL_JSON_INCOMPLETE_2 =
            @"{
                ""name"": ""Bryan Cranston"",
                ""biography"": ""Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia."",
                ""birthday"": ""1956-03-07"",
                ""death"": ""2016-04-06"",
                ""birthplace"": ""San Fernando Valley, California, USA"",
                ""homepage"": ""http://www.bryancranston.com/""
              }";

        private const string FULL_JSON_INCOMPLETE_3 =
            @"{
                ""name"": ""Bryan Cranston"",
                ""ids"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                },
                ""birthday"": ""1956-03-07"",
                ""death"": ""2016-04-06"",
                ""birthplace"": ""San Fernando Valley, California, USA"",
                ""homepage"": ""http://www.bryancranston.com/""
              }";

        private const string FULL_JSON_INCOMPLETE_4 =
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
                ""death"": ""2016-04-06"",
                ""birthplace"": ""San Fernando Valley, California, USA"",
                ""homepage"": ""http://www.bryancranston.com/""
              }";

        private const string FULL_JSON_INCOMPLETE_5 =
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
                ""birthplace"": ""San Fernando Valley, California, USA"",
                ""homepage"": ""http://www.bryancranston.com/""
              }";

        private const string FULL_JSON_INCOMPLETE_6 =
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
                ""homepage"": ""http://www.bryancranston.com/""
              }";

        private const string FULL_JSON_INCOMPLETE_7 =
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
                ""birthplace"": ""San Fernando Valley, California, USA""
              }";

        private const string FULL_JSON_INCOMPLETE_8 =
            @"{
                ""name"": ""Bryan Cranston""
              }";

        private const string FULL_JSON_INCOMPLETE_9 =
            @"{
                ""ids"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                }
              }";

        private const string FULL_JSON_INCOMPLETE_10 =
            @"{
                ""biography"": ""Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.""
              }";

        private const string FULL_JSON_INCOMPLETE_11 =
            @"{
                ""birthday"": ""1956-03-07""
              }";

        private const string FULL_JSON_INCOMPLETE_12 =
            @"{
                ""death"": ""2016-04-06""
              }";

        private const string FULL_JSON_INCOMPLETE_13 =
            @"{
                ""birthplace"": ""San Fernando Valley, California, USA""
              }";

        private const string FULL_JSON_INCOMPLETE_14 =
            @"{
                ""homepage"": ""http://www.bryancranston.com/""
              }";

        private const string FULL_JSON_NOT_VALID_1 =
            @"{
                ""na"": ""Bryan Cranston"",
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

        private const string FULL_JSON_NOT_VALID_2 =
            @"{
                ""name"": ""Bryan Cranston"",
                ""id"": {
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

        private const string FULL_JSON_NOT_VALID_3 =
            @"{
                ""name"": ""Bryan Cranston"",
                ""ids"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                },
                ""bio"": ""Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia."",
                ""birthday"": ""1956-03-07"",
                ""death"": ""2016-04-06"",
                ""birthplace"": ""San Fernando Valley, California, USA"",
                ""homepage"": ""http://www.bryancranston.com/""
              }";

        private const string FULL_JSON_NOT_VALID_4 =
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
                ""birth"": ""1956-03-07"",
                ""death"": ""2016-04-06"",
                ""birthplace"": ""San Fernando Valley, California, USA"",
                ""homepage"": ""http://www.bryancranston.com/""
              }";

        private const string FULL_JSON_NOT_VALID_5 =
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
                ""de"": ""2016-04-06"",
                ""birthplace"": ""San Fernando Valley, California, USA"",
                ""homepage"": ""http://www.bryancranston.com/""
              }";

        private const string FULL_JSON_NOT_VALID_6 =
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
                ""bp"": ""San Fernando Valley, California, USA"",
                ""homepage"": ""http://www.bryancranston.com/""
              }";

        private const string FULL_JSON_NOT_VALID_7 =
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
                ""hp"": ""http://www.bryancranston.com/""
              }";

        private const string FULL_JSON_NOT_VALID_8 =
            @"{
                ""na"": ""Bryan Cranston"",
                ""id"": {
                  ""trakt"": 297737,
                  ""slug"": ""bryan-cranston"",
                  ""imdb"": ""nm0186505"",
                  ""tmdb"": 17419,
                  ""tvrage"": 1797
                },
                ""bio"": ""Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia."",
                ""birth"": ""1956-03-07"",
                ""de"": ""2016-04-06"",
                ""bp"": ""San Fernando Valley, California, USA"",
                ""hp"": ""http://www.bryancranston.com/""
              }";
    }
}
