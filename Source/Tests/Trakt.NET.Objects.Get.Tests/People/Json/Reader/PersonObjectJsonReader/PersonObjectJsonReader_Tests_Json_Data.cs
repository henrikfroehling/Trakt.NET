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

        private const string MINIMAL_JSON_NOT_VALID =
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
                ""homepage"": ""http://www.bryancranston.com/"",
                ""gender"": ""male"",
                ""known_for_department"": ""acting"",
                ""social_ids"": {
                  ""twitter"": ""BryanCranston"",
                  ""facebook"": ""thebryancranston"",
                  ""instagram"": ""bryancranston"",
                  ""wikipedia"": ""Bryan_Cranston""
                }
              }";

        private const string FULL_JSON_NOT_VALID =
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
                ""dea"": ""2016-04-06"",
                ""bir"": ""San Fernando Valley, California, USA"",
                ""hp"": ""http://www.bryancranston.com/"",
                ""g"": ""male"",
                ""kfd"": ""acting"",
                ""social"": {
                  ""twitter"": ""BryanCranston"",
                  ""facebook"": ""thebryancranston"",
                  ""instagram"": ""bryancranston"",
                  ""wikipedia"": ""Bryan_Cranston""
                }
              }";
    }
}
