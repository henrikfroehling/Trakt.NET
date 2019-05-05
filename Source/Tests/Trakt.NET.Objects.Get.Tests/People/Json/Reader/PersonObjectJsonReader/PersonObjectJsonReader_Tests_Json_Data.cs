namespace TraktNet.Objects.Get.Tests.People.Json.Reader
{
    public partial class PersonObjectJsonReader_Tests
    {
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
