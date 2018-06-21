namespace TraktNet.Tests.Objects.Get.Episodes.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Episodes.Implementations")]
    public class TraktEpisode_Tests
    {
        [Fact]
        public void Test_TraktEpisode_Default_Constructor()
        {
            var episode = new TraktEpisode();

            episode.SeasonNumber.Should().NotHaveValue();
            episode.Number.Should().NotHaveValue();
            episode.Title.Should().BeNullOrEmpty();
            episode.Ids.Should().BeNull();
            episode.NumberAbsolute.Should().NotHaveValue();
            episode.Overview.Should().BeNullOrEmpty();
            episode.Runtime.Should().NotHaveValue();
            episode.Rating.Should().NotHaveValue();
            episode.Votes.Should().NotHaveValue();
            episode.FirstAired.Should().NotHaveValue();
            episode.UpdatedAt.Should().NotHaveValue();
            episode.AvailableTranslationLanguageCodes.Should().BeNull();
            episode.Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktEpisode_From_Minimal_Json()
        {
            var jsonReader = new EpisodeObjectJsonReader();
            var episode = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktEpisode;

            episode.Should().NotBeNull();
            episode.SeasonNumber.Should().Be(1);
            episode.Number.Should().Be(1);
            episode.Title.Should().Be("Winter Is Coming");
            episode.Ids.Should().NotBeNull();
            episode.Ids.Trakt.Should().Be(73640U);
            episode.Ids.Tvdb.Should().Be(3254641U);
            episode.Ids.Imdb.Should().Be("tt1480055");
            episode.Ids.Tmdb.Should().Be(63056U);
            episode.Ids.TvRage.Should().Be(1065008299U);
            episode.NumberAbsolute.Should().NotHaveValue();
            episode.Overview.Should().BeNullOrEmpty();
            episode.Runtime.Should().NotHaveValue();
            episode.Rating.Should().NotHaveValue();
            episode.Votes.Should().NotHaveValue();
            episode.FirstAired.Should().NotHaveValue();
            episode.UpdatedAt.Should().NotHaveValue();
            episode.AvailableTranslationLanguageCodes.Should().BeNull();
            episode.Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktEpisode_From_Full_Json()
        {
            var jsonReader = new EpisodeObjectJsonReader();
            var episode = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktEpisode;

            episode.Should().NotBeNull();
            episode.SeasonNumber.Should().Be(1);
            episode.Number.Should().Be(1);
            episode.Title.Should().Be("Winter Is Coming");
            episode.Ids.Should().NotBeNull();
            episode.Ids.Trakt.Should().Be(73640U);
            episode.Ids.Tvdb.Should().Be(3254641U);
            episode.Ids.Imdb.Should().Be("tt1480055");
            episode.Ids.Tmdb.Should().Be(63056U);
            episode.Ids.TvRage.Should().Be(1065008299U);
            episode.NumberAbsolute.Should().Be(50);
            episode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            episode.Runtime.Should().Be(55);
            episode.Rating.Should().Be(9.0f);
            episode.Votes.Should().Be(111);
            episode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            episode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            episode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            episode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = episode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        private const string MINIMAL_JSON =
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

        private const string FULL_JSON =
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
    }
}
