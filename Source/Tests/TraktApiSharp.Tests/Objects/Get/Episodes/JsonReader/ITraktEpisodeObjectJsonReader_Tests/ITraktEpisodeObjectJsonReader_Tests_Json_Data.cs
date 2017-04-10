namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    public partial class ITraktEpisodeObjectJsonReader_Tests
    {
        private const string MINIMAL_JSON_COMPLETE =
            @"{
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
              }";

        private const string MINIMAL_JSON_INCOMPLETE_1 =
            @"{
                ""number"": 1,
                ""title"": ""Winter Is Coming"",
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_2 =
            @"{
                ""season"": 1,
                ""title"": ""Winter Is Coming"",
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_3 =
            @"{
                ""season"": 1,
                ""number"": 1,
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_4 =
            @"{
                ""season"": 1,
                ""number"": 1,
                ""title"": ""Winter Is Coming""
              }";

        private const string MINIMAL_JSON_INCOMPLETE_5 =
            @"{
                ""season"": 1
              }";

        private const string MINIMAL_JSON_INCOMPLETE_6 =
            @"{
                ""number"": 1
              }";

        private const string MINIMAL_JSON_INCOMPLETE_7 =
            @"{
                ""title"": ""Winter Is Coming""
              }";

        private const string MINIMAL_JSON_INCOMPLETE_8 =
            @"{
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_1 =
            @"{
                ""se"": 1,
                ""number"": 1,
                ""title"": ""Winter Is Coming"",
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_2 =
            @"{
                ""season"": 1,
                ""nu"": 1,
                ""title"": ""Winter Is Coming"",
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_3 =
            @"{
                ""season"": 1,
                ""number"": 1,
                ""ti"": ""Winter Is Coming"",
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_4 =
            @"{
                ""season"": 1,
                ""number"": 1,
                ""title"": ""Winter Is Coming"",
                ""id"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_5 =
            @"{
                ""se"": 1,
                ""nu"": 1,
                ""ti"": ""Winter Is Coming"",
                ""id"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                }
              }";

        private const string FULL_JSON_COMPLETE =
            @"{
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
                ""number_abs"": 50,
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
              }";

        private const string FULL_JSON_INCOMPLETE_1 =
            @"{
                ""number"": 1,
                ""title"": ""Winter Is Coming"",
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                },
                ""number_abs"": 50,
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
              }";

        private const string FULL_JSON_INCOMPLETE_2 =
            @"{
                ""season"": 1,
                ""title"": ""Winter Is Coming"",
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                },
                ""number_abs"": 50,
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
              }";

        private const string FULL_JSON_INCOMPLETE_3 =
            @"{
                ""season"": 1,
                ""number"": 1,
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                },
                ""number_abs"": 50,
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
              }";

        private const string FULL_JSON_INCOMPLETE_4 =
            @"{
                ""season"": 1,
                ""number"": 1,
                ""title"": ""Winter Is Coming"",
                ""number_abs"": 50,
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
              }";

        private const string FULL_JSON_INCOMPLETE_5 =
            @"{
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
              }";

        private const string FULL_JSON_INCOMPLETE_6 =
            @"{
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
                ""number_abs"": 50,
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
              }";

        private const string FULL_JSON_INCOMPLETE_7 =
            @"{
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
                ""number_abs"": 50,
                ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
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
              }";

        private const string FULL_JSON_INCOMPLETE_8 =
            @"{
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
                ""number_abs"": 50,
                ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                ""first_aired"": ""2011-04-18T01:00:00.000Z"",
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
              }";

        private const string FULL_JSON_INCOMPLETE_9 =
            @"{
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
                ""number_abs"": 50,
                ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                ""first_aired"": ""2011-04-18T01:00:00.000Z"",
                ""updated_at"": ""2014-08-29T23:16:39.000Z"",
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
              }";

        private const string FULL_JSON_INCOMPLETE_10 =
            @"{
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
                ""number_abs"": 50,
                ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                ""first_aired"": ""2011-04-18T01:00:00.000Z"",
                ""updated_at"": ""2014-08-29T23:16:39.000Z"",
                ""rating"": 9,
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
              }";

        private const string FULL_JSON_INCOMPLETE_11 =
            @"{
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
                ""number_abs"": 50,
                ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                ""first_aired"": ""2011-04-18T01:00:00.000Z"",
                ""updated_at"": ""2014-08-29T23:16:39.000Z"",
                ""rating"": 9,
                ""votes"": 111,
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
              }";

        private const string FULL_JSON_INCOMPLETE_12 =
            @"{
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
                ""number_abs"": 50,
                ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                ""first_aired"": ""2011-04-18T01:00:00.000Z"",
                ""updated_at"": ""2014-08-29T23:16:39.000Z"",
                ""rating"": 9,
                ""votes"": 111,
                ""available_translations"": [
                  ""en"",
                  ""es""
                ],
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
              }";

        private const string FULL_JSON_INCOMPLETE_13 =
            @"{
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
                ""number_abs"": 50,
                ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                ""first_aired"": ""2011-04-18T01:00:00.000Z"",
                ""updated_at"": ""2014-08-29T23:16:39.000Z"",
                ""rating"": 9,
                ""votes"": 111,
                ""available_translations"": [
                  ""en"",
                  ""es""
                ],
                ""runtime"": 55
              }";

        private const string FULL_JSON_INCOMPLETE_14 =
            @"{
                ""season"": 1
              }";

        private const string FULL_JSON_INCOMPLETE_15 =
            @"{
                ""number"": 1
              }";

        private const string FULL_JSON_INCOMPLETE_16 =
            @"{
                ""title"": ""Winter Is Coming""
              }";

        private const string FULL_JSON_INCOMPLETE_17 =
            @"{
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                }
              }";

        private const string FULL_JSON_INCOMPLETE_18 =
            @"{
                ""number_abs"": 50
              }";

        private const string FULL_JSON_INCOMPLETE_19 =
            @"{
                ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.""
              }";

        private const string FULL_JSON_INCOMPLETE_20 =
            @"{
                ""first_aired"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string FULL_JSON_INCOMPLETE_21 =
            @"{
                ""updated_at"": ""2014-08-29T23:16:39.000Z""
              }";

        private const string FULL_JSON_INCOMPLETE_22 =
            @"{
                ""rating"": 9
              }";

        private const string FULL_JSON_INCOMPLETE_23 =
            @"{
                ""votes"": 111
              }";

        private const string FULL_JSON_INCOMPLETE_24 =
            @"{
                ""available_translations"": [
                  ""en"",
                  ""es""
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_25 =
            @"{
                ""runtime"": 55
              }";

        private const string FULL_JSON_INCOMPLETE_26 =
            @"{
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
              }";

        private const string FULL_JSON_NOT_VALID_1 =
            @"{
                ""se"": 1,
                ""number"": 1,
                ""title"": ""Winter Is Coming"",
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                },
                ""number_abs"": 50,
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
              }";

        private const string FULL_JSON_NOT_VALID_2 =
            @"{
                ""season"": 1,
                ""nu"": 1,
                ""title"": ""Winter Is Coming"",
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                },
                ""number_abs"": 50,
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
              }";

        private const string FULL_JSON_NOT_VALID_3 =
            @"{
                ""season"": 1,
                ""number"": 1,
                ""ti"": ""Winter Is Coming"",
                ""ids"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                },
                ""number_abs"": 50,
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
              }";

        private const string FULL_JSON_NOT_VALID_4 =
            @"{
                ""season"": 1,
                ""number"": 1,
                ""title"": ""Winter Is Coming"",
                ""id"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                },
                ""number_abs"": 50,
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
              }";

        private const string FULL_JSON_NOT_VALID_5 =
            @"{
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
                ""nabs"": 50,
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
              }";

        private const string FULL_JSON_NOT_VALID_6 =
            @"{
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
                ""number_abs"": 50,
                ""ov"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
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
              }";

        private const string FULL_JSON_NOT_VALID_7 =
            @"{
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
                ""number_abs"": 50,
                ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                ""fa"": ""2011-04-18T01:00:00.000Z"",
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
              }";

        private const string FULL_JSON_NOT_VALID_8 =
            @"{
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
                ""number_abs"": 50,
                ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                ""first_aired"": ""2011-04-18T01:00:00.000Z"",
                ""ua"": ""2014-08-29T23:16:39.000Z"",
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
              }";

        private const string FULL_JSON_NOT_VALID_9 =
            @"{
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
                ""number_abs"": 50,
                ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                ""first_aired"": ""2011-04-18T01:00:00.000Z"",
                ""updated_at"": ""2014-08-29T23:16:39.000Z"",
                ""ra"": 9,
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
              }";

        private const string FULL_JSON_NOT_VALID_10 =
            @"{
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
                ""number_abs"": 50,
                ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                ""first_aired"": ""2011-04-18T01:00:00.000Z"",
                ""updated_at"": ""2014-08-29T23:16:39.000Z"",
                ""rating"": 9,
                ""vo"": 111,
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
              }";

        private const string FULL_JSON_NOT_VALID_11 =
            @"{
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
                ""number_abs"": 50,
                ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                ""first_aired"": ""2011-04-18T01:00:00.000Z"",
                ""updated_at"": ""2014-08-29T23:16:39.000Z"",
                ""rating"": 9,
                ""votes"": 111,
                ""avtr"": [
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
              }";

        private const string FULL_JSON_NOT_VALID_12 =
            @"{
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
                ""number_abs"": 50,
                ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                ""first_aired"": ""2011-04-18T01:00:00.000Z"",
                ""updated_at"": ""2014-08-29T23:16:39.000Z"",
                ""rating"": 9,
                ""votes"": 111,
                ""available_translations"": [
                  ""en"",
                  ""es""
                ],
                ""ru"": 55,
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
              }";

        private const string FULL_JSON_NOT_VALID_13 =
            @"{
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
                ""number_abs"": 50,
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
                ""tr"": [
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
              }";

        private const string FULL_JSON_NOT_VALID_14 =
            @"{
                ""se"": 1,
                ""nu"": 1,
                ""ti"": ""Winter Is Coming"",
                ""id"": {
                  ""trakt"": 73640,
                  ""tvdb"": 3254641,
                  ""imdb"": ""tt1480055"",
                  ""tmdb"": 63056,
                  ""tvrage"": 1065008299
                },
                ""nabs"": 50,
                ""ov"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                ""fa"": ""2011-04-18T01:00:00.000Z"",
                ""ua"": ""2014-08-29T23:16:39.000Z"",
                ""ra"": 9,
                ""vo"": 111,
                ""avtr"": [
                  ""en"",
                  ""es""
                ],
                ""ru"": 55,
                ""tr"": [
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
              }";
    }
}
