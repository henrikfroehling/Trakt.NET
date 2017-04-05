namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    public partial class ITraktEpisodeArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string MINIMAL_JSON_COMPLETE =
            @"[
                {
                  ""season"": 1,
                  ""number"": 1,
                  ""title"": ""Winter Is Coming"",
                  ""ids"": {
                    ""trakt"": 73640,
                    ""tvdb"": 3254641,
                    ""imdb"": ""tt1480055"",
                    ""tmdb"": 63056,
                    ""tvrage"": 1065008299
                  }
                },
                {
                  ""season"": 1,
                  ""number"": 2,
                  ""title"": ""The Kingsroad"",
                  ""ids"": {
                    ""trakt"": 73641,
                    ""tvdb"": 3436411,
                    ""imdb"": ""tt1668746"",
                    ""tmdb"": 63057,
                    ""tvrage"": 1065023912
                  }
                }
              ]";

        private const string FULL_JSON_COMPLETE =
            @"[
                {
                  ""season"": 1,
                  ""number"": 1,
                  ""title"": ""Winter Is Coming"",
                  ""ids"": {
                    ""trakt"": 73640,
                    ""tvdb"": 3254641,
                    ""imdb"": ""tt1480055"",
                    ""tmdb"": 63056,
                    ""tvrage"": 1065008299
                  },
                  ""number_abs"": 1,
                  ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                  ""first_aired"": ""2011-04-18T01:00:00.000Z"",
                  ""updated_at"": ""2014-08-29T23:16:39.000Z"",
                  ""rating"": 9,
                  ""votes"": 111,
                  ""available_translations"": [
                    ""en"",
                    ""es""
                  ],
                  ""runtime"": 55,
                  ""translations"": [
                    {
                      ""title"": ""Winter Is Coming"",
                      ""overview"": ""Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army."",
                      ""language"": ""en""
                    },
                    {
                      ""title"": ""Se acerca el invierno"",
                      ""overview"": ""El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza."",
                      ""language"": ""es""
                    }
                  ]
                },
                {
                  ""season"": 1,
                  ""number"": 2,
                  ""title"": ""The Kingsroad"",
                  ""ids"": {
                    ""trakt"": 73641,
                    ""tvdb"": 3436411,
                    ""imdb"": ""tt1668746"",
                    ""tmdb"": 63057,
                    ""tvrage"": 1065023912
                  },
                  ""number_abs"": 2,
                  ""overview"": ""Having agreed to become the King’s Hand, Ned leaves Winterfell with daughters Sansa and Arya, while Catelyn stays behind in Winterfell. Jon Snow heads north to join the brotherhood of the Night’s Watch. Tyrion decides to forego the trip south with his family, instead joining Jon in the entourage heading to the Wall. Viserys bides his time in hopes of winning back the throne, while Daenerys focuses her attention on learning how to please her new husband, Drogo."",
                  ""first_aired"": ""2011-04-25T01:00:00.000Z"",
                  ""updated_at"": ""2017-03-05T14:47:14.000Z"",
                  ""rating"": 8.22255,
                  ""votes"": 6183,
                  ""available_translations"": [
                    ""en"",
                    ""es""
                  ],
                  ""runtime"": 55,
                  ""translations"": [
                    {
                      ""title"": ""The Kingsroad"",
                      ""overview"": ""While Bran recovers from his fall, Ned takes only his daughters to Kings Landing. Jon Snow goes with his uncle Benjen to The Wall. Tyrion joins them."",
                      ""language"": ""en""
                    },
                    {
                      ""title"": ""El Camino Real"",
                      ""overview"": ""Cuando Bran sobrevive milagrosamente a su caída de la torre, Cersei y Jaime conspiran para asegurar su silencio; Jon Snow y Tyrion se dirigen a El Muro; al convertirse en la mano derecha del rey, Ned deja Winterfell con sus hijas Sansa y Arya."",
                      ""language"": ""es""
                    }
                  ]
                }
              ]";
    }
}
