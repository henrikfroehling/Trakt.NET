namespace TraktNet.Objects.Get.Tests.Episodes.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisode>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var traktEpisodes = await traktJsonReader.ReadArrayAsync(stream);
                traktEpisodes.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_EpisodeArrayJsonReader_ReadArray_From_Stream_Minimal_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisode>();

            using (var stream = MINIMAL_JSON_COMPLETE.ToStream())
            {
                var traktEpisodes = await traktJsonReader.ReadArrayAsync(stream);
                traktEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var episodes = traktEpisodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().NotHaveValue();
                episodes[0].Overview.Should().BeNullOrEmpty();
                episodes[0].Runtime.Should().NotHaveValue();
                episodes[0].Rating.Should().NotHaveValue();
                episodes[0].Votes.Should().NotHaveValue();
                episodes[0].FirstAired.Should().NotHaveValue();
                episodes[0].UpdatedAt.Should().NotHaveValue();
                episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[0].Translations.Should().BeNull();

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(73641U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63057U);
                episodes[1].Ids.TvRage.Should().Be(1065023912U);
                episodes[1].NumberAbsolute.Should().NotHaveValue();
                episodes[1].Overview.Should().BeNullOrEmpty();
                episodes[1].Runtime.Should().NotHaveValue();
                episodes[1].Rating.Should().NotHaveValue();
                episodes[1].Votes.Should().NotHaveValue();
                episodes[1].FirstAired.Should().NotHaveValue();
                episodes[1].UpdatedAt.Should().NotHaveValue();
                episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
                episodes[1].Translations.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeArrayJsonReader_ReadArray_From_Stream_Full_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisode>();

            using (var stream = FULL_JSON_COMPLETE.ToStream())
            {
                var traktEpisodes = await traktJsonReader.ReadArrayAsync(stream);
                traktEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var episodes = traktEpisodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].SeasonNumber.Should().Be(1);
                episodes[0].Number.Should().Be(1);
                episodes[0].Title.Should().Be("Winter Is Coming");
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);
                episodes[0].NumberAbsolute.Should().Be(1);
                episodes[0].Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                episodes[0].Runtime.Should().Be(55);
                episodes[0].Rating.Should().Be(9.0f);
                episodes[0].Votes.Should().Be(111);
                episodes[0].FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                episodes[0].UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                episodes[0].AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                episodes[0].Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = episodes[0].Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");

                episodes[1].Should().NotBeNull();
                episodes[1].SeasonNumber.Should().Be(1);
                episodes[1].Number.Should().Be(2);
                episodes[1].Title.Should().Be("The Kingsroad");
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(73641U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63057U);
                episodes[1].Ids.TvRage.Should().Be(1065023912U);
                episodes[1].NumberAbsolute.Should().Be(2);
                episodes[1].Overview.Should().Be("Having agreed to become the King’s Hand, Ned leaves Winterfell with daughters Sansa and Arya, while Catelyn stays behind in Winterfell. Jon Snow heads north to join the brotherhood of the Night’s Watch. Tyrion decides to forego the trip south with his family, instead joining Jon in the entourage heading to the Wall. Viserys bides his time in hopes of winning back the throne, while Daenerys focuses her attention on learning how to please her new husband, Drogo.");
                episodes[1].Runtime.Should().Be(55);
                episodes[1].Rating.Should().Be(8.22255f);
                episodes[1].Votes.Should().Be(6183);
                episodes[1].FirstAired.Should().Be(DateTime.Parse("2011-04-25T01:00:00.000Z").ToUniversalTime());
                episodes[1].UpdatedAt.Should().Be(DateTime.Parse("2017-03-05T14:47:14.000Z").ToUniversalTime());
                episodes[1].AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                episodes[1].Translations.Should().NotBeNull().And.HaveCount(2);

                translations = episodes[1].Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("The Kingsroad");
                translations[0].Overview.Should().Be("While Bran recovers from his fall, Ned takes only his daughters to Kings Landing. Jon Snow goes with his uncle Benjen to The Wall. Tyrion joins them.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("El Camino Real");
                translations[1].Overview.Should().Be("Cuando Bran sobrevive milagrosamente a su caída de la torre, Cersei y Jaime conspiran para asegurar su silencio; Jon Snow y Tyrion se dirigen a El Muro; al convertirse en la mano derecha del rey, Ned deja Winterfell con sus hijas Sansa y Arya.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public async Task Test_EpisodeArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisode>();
            Func<Task<IEnumerable<ITraktEpisode>>> traktEpisodes = () => traktJsonReader.ReadArrayAsync(default(Stream));
            await traktEpisodes.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisode>();

            using (var stream = string.Empty.ToStream())
            {
                var traktEpisodes = await traktJsonReader.ReadArrayAsync(stream);
                traktEpisodes.Should().BeNull();
            }
        }
    }
}
