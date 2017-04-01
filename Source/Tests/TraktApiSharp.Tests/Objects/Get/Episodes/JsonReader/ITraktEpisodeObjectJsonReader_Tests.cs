namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public class ITraktEpisodeObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktEpisodeObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktEpisode>));
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Minimal_Complete()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(MINIMAL_JSON_COMPLETE);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().NotHaveValue();
            traktEpisode.Overview.Should().BeNullOrEmpty();
            traktEpisode.Runtime.Should().NotHaveValue();
            traktEpisode.Rating.Should().NotHaveValue();
            traktEpisode.Votes.Should().NotHaveValue();
            traktEpisode.FirstAired.Should().NotHaveValue();
            traktEpisode.UpdatedAt.Should().NotHaveValue();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_1()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_1);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().NotHaveValue();
            traktEpisode.Overview.Should().BeNullOrEmpty();
            traktEpisode.Runtime.Should().NotHaveValue();
            traktEpisode.Rating.Should().NotHaveValue();
            traktEpisode.Votes.Should().NotHaveValue();
            traktEpisode.FirstAired.Should().NotHaveValue();
            traktEpisode.UpdatedAt.Should().NotHaveValue();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_2()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_2);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().NotHaveValue();
            traktEpisode.Overview.Should().BeNullOrEmpty();
            traktEpisode.Runtime.Should().NotHaveValue();
            traktEpisode.Rating.Should().NotHaveValue();
            traktEpisode.Votes.Should().NotHaveValue();
            traktEpisode.FirstAired.Should().NotHaveValue();
            traktEpisode.UpdatedAt.Should().NotHaveValue();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_3()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_3);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().NotHaveValue();
            traktEpisode.Overview.Should().BeNullOrEmpty();
            traktEpisode.Runtime.Should().NotHaveValue();
            traktEpisode.Rating.Should().NotHaveValue();
            traktEpisode.Votes.Should().NotHaveValue();
            traktEpisode.FirstAired.Should().NotHaveValue();
            traktEpisode.UpdatedAt.Should().NotHaveValue();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_4()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_4);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().NotHaveValue();
            traktEpisode.Overview.Should().BeNullOrEmpty();
            traktEpisode.Runtime.Should().NotHaveValue();
            traktEpisode.Rating.Should().NotHaveValue();
            traktEpisode.Votes.Should().NotHaveValue();
            traktEpisode.FirstAired.Should().NotHaveValue();
            traktEpisode.UpdatedAt.Should().NotHaveValue();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_5()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_5);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().NotHaveValue();
            traktEpisode.Overview.Should().BeNullOrEmpty();
            traktEpisode.Runtime.Should().NotHaveValue();
            traktEpisode.Rating.Should().NotHaveValue();
            traktEpisode.Votes.Should().NotHaveValue();
            traktEpisode.FirstAired.Should().NotHaveValue();
            traktEpisode.UpdatedAt.Should().NotHaveValue();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_6()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_6);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().NotHaveValue();
            traktEpisode.Overview.Should().BeNullOrEmpty();
            traktEpisode.Runtime.Should().NotHaveValue();
            traktEpisode.Rating.Should().NotHaveValue();
            traktEpisode.Votes.Should().NotHaveValue();
            traktEpisode.FirstAired.Should().NotHaveValue();
            traktEpisode.UpdatedAt.Should().NotHaveValue();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_7()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_7);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().NotHaveValue();
            traktEpisode.Overview.Should().BeNullOrEmpty();
            traktEpisode.Runtime.Should().NotHaveValue();
            traktEpisode.Rating.Should().NotHaveValue();
            traktEpisode.Votes.Should().NotHaveValue();
            traktEpisode.FirstAired.Should().NotHaveValue();
            traktEpisode.UpdatedAt.Should().NotHaveValue();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_8()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_8);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().NotHaveValue();
            traktEpisode.Overview.Should().BeNullOrEmpty();
            traktEpisode.Runtime.Should().NotHaveValue();
            traktEpisode.Rating.Should().NotHaveValue();
            traktEpisode.Votes.Should().NotHaveValue();
            traktEpisode.FirstAired.Should().NotHaveValue();
            traktEpisode.UpdatedAt.Should().NotHaveValue();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_1()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_1);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().NotHaveValue();
            traktEpisode.Overview.Should().BeNullOrEmpty();
            traktEpisode.Runtime.Should().NotHaveValue();
            traktEpisode.Rating.Should().NotHaveValue();
            traktEpisode.Votes.Should().NotHaveValue();
            traktEpisode.FirstAired.Should().NotHaveValue();
            traktEpisode.UpdatedAt.Should().NotHaveValue();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_2()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_2);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().NotHaveValue();
            traktEpisode.Overview.Should().BeNullOrEmpty();
            traktEpisode.Runtime.Should().NotHaveValue();
            traktEpisode.Rating.Should().NotHaveValue();
            traktEpisode.Votes.Should().NotHaveValue();
            traktEpisode.FirstAired.Should().NotHaveValue();
            traktEpisode.UpdatedAt.Should().NotHaveValue();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_3()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_3);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().NotHaveValue();
            traktEpisode.Overview.Should().BeNullOrEmpty();
            traktEpisode.Runtime.Should().NotHaveValue();
            traktEpisode.Rating.Should().NotHaveValue();
            traktEpisode.Votes.Should().NotHaveValue();
            traktEpisode.FirstAired.Should().NotHaveValue();
            traktEpisode.UpdatedAt.Should().NotHaveValue();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_4()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_4);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().NotHaveValue();
            traktEpisode.Overview.Should().BeNullOrEmpty();
            traktEpisode.Runtime.Should().NotHaveValue();
            traktEpisode.Rating.Should().NotHaveValue();
            traktEpisode.Votes.Should().NotHaveValue();
            traktEpisode.FirstAired.Should().NotHaveValue();
            traktEpisode.UpdatedAt.Should().NotHaveValue();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_5()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_5);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().NotHaveValue();
            traktEpisode.Overview.Should().BeNullOrEmpty();
            traktEpisode.Runtime.Should().NotHaveValue();
            traktEpisode.Rating.Should().NotHaveValue();
            traktEpisode.Votes.Should().NotHaveValue();
            traktEpisode.FirstAired.Should().NotHaveValue();
            traktEpisode.UpdatedAt.Should().NotHaveValue();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Complete()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_COMPLETE);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_1()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_1);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_2()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_2);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_3()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_3);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_4()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_4);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_5()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_5);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().BeNull();
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_6()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_6);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().BeNull();
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_7()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_7);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().BeNull();
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_8()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_8);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().BeNull();
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_9()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_9);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().BeNull();
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_10()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_10);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().BeNull();
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_11()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_11);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_12()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_12);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().BeNull();
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_13()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_13);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_14()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_14);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().BeNull();
            traktEpisode.Overview.Should().BeNull();
            traktEpisode.Runtime.Should().BeNull();
            traktEpisode.Rating.Should().BeNull();
            traktEpisode.Votes.Should().BeNull();
            traktEpisode.FirstAired.Should().BeNull();
            traktEpisode.UpdatedAt.Should().BeNull();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_15()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_15);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().BeNull();
            traktEpisode.Overview.Should().BeNull();
            traktEpisode.Runtime.Should().BeNull();
            traktEpisode.Rating.Should().BeNull();
            traktEpisode.Votes.Should().BeNull();
            traktEpisode.FirstAired.Should().BeNull();
            traktEpisode.UpdatedAt.Should().BeNull();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_16()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_16);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().BeNull();
            traktEpisode.Overview.Should().BeNull();
            traktEpisode.Runtime.Should().BeNull();
            traktEpisode.Rating.Should().BeNull();
            traktEpisode.Votes.Should().BeNull();
            traktEpisode.FirstAired.Should().BeNull();
            traktEpisode.UpdatedAt.Should().BeNull();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_17()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_17);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().BeNull();
            traktEpisode.Overview.Should().BeNull();
            traktEpisode.Runtime.Should().BeNull();
            traktEpisode.Rating.Should().BeNull();
            traktEpisode.Votes.Should().BeNull();
            traktEpisode.FirstAired.Should().BeNull();
            traktEpisode.UpdatedAt.Should().BeNull();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_18()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_18);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().BeNull();
            traktEpisode.Runtime.Should().BeNull();
            traktEpisode.Rating.Should().BeNull();
            traktEpisode.Votes.Should().BeNull();
            traktEpisode.FirstAired.Should().BeNull();
            traktEpisode.UpdatedAt.Should().BeNull();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_19()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_19);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().BeNull();
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().BeNull();
            traktEpisode.Rating.Should().BeNull();
            traktEpisode.Votes.Should().BeNull();
            traktEpisode.FirstAired.Should().BeNull();
            traktEpisode.UpdatedAt.Should().BeNull();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_20()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_20);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().BeNull();
            traktEpisode.Overview.Should().BeNull();
            traktEpisode.Runtime.Should().BeNull();
            traktEpisode.Rating.Should().BeNull();
            traktEpisode.Votes.Should().BeNull();
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().BeNull();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_21()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_21);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().BeNull();
            traktEpisode.Overview.Should().BeNull();
            traktEpisode.Runtime.Should().BeNull();
            traktEpisode.Rating.Should().BeNull();
            traktEpisode.Votes.Should().BeNull();
            traktEpisode.FirstAired.Should().BeNull();
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_22()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_22);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().BeNull();
            traktEpisode.Overview.Should().BeNull();
            traktEpisode.Runtime.Should().BeNull();
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().BeNull();
            traktEpisode.FirstAired.Should().BeNull();
            traktEpisode.UpdatedAt.Should().BeNull();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_23()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_23);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().BeNull();
            traktEpisode.Overview.Should().BeNull();
            traktEpisode.Runtime.Should().BeNull();
            traktEpisode.Rating.Should().BeNull();
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().BeNull();
            traktEpisode.UpdatedAt.Should().BeNull();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_24()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_24);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().BeNull();
            traktEpisode.Overview.Should().BeNull();
            traktEpisode.Runtime.Should().BeNull();
            traktEpisode.Rating.Should().BeNull();
            traktEpisode.Votes.Should().BeNull();
            traktEpisode.FirstAired.Should().BeNull();
            traktEpisode.UpdatedAt.Should().BeNull();
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_25()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_25);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().BeNull();
            traktEpisode.Overview.Should().BeNull();
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().BeNull();
            traktEpisode.Votes.Should().BeNull();
            traktEpisode.FirstAired.Should().BeNull();
            traktEpisode.UpdatedAt.Should().BeNull();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_26()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_26);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().BeNull();
            traktEpisode.Overview.Should().BeNull();
            traktEpisode.Runtime.Should().BeNull();
            traktEpisode.Rating.Should().BeNull();
            traktEpisode.Votes.Should().BeNull();
            traktEpisode.FirstAired.Should().BeNull();
            traktEpisode.UpdatedAt.Should().BeNull();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_1()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_NOT_VALID_1);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_2()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_NOT_VALID_2);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_3()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_NOT_VALID_3);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_4()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_NOT_VALID_4);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_5()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_NOT_VALID_5);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().BeNull();
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_6()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_NOT_VALID_6);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().BeNull();
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_7()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_NOT_VALID_7);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().BeNull();
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_8()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_NOT_VALID_8);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().BeNull();
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_9()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_NOT_VALID_9);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().BeNull();
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_10()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_NOT_VALID_10);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().BeNull();
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_11()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_NOT_VALID_11);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_12()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_NOT_VALID_12);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().BeNull();
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = traktEpisode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_13()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_NOT_VALID_13);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().Be(1);
            traktEpisode.Number.Should().Be(1);
            traktEpisode.Title.Should().Be("Winter Is Coming");
            traktEpisode.Ids.Should().NotBeNull();
            traktEpisode.Ids.Trakt.Should().Be(73640U);
            traktEpisode.Ids.Tvdb.Should().Be(3254641U);
            traktEpisode.Ids.Imdb.Should().Be("tt1480055");
            traktEpisode.Ids.Tmdb.Should().Be(63056U);
            traktEpisode.Ids.TvRage.Should().Be(1065008299U);
            traktEpisode.NumberAbsolute.Should().Be(50);
            traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            traktEpisode.Runtime.Should().Be(55);
            traktEpisode.Rating.Should().Be(9.0f);
            traktEpisode.Votes.Should().Be(111);
            traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_14()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(FULL_JSON_NOT_VALID_14);

            traktEpisode.Should().NotBeNull();
            traktEpisode.SeasonNumber.Should().BeNull();
            traktEpisode.Number.Should().BeNull();
            traktEpisode.Title.Should().BeNull();
            traktEpisode.Ids.Should().BeNull();
            traktEpisode.NumberAbsolute.Should().BeNull();
            traktEpisode.Overview.Should().BeNull();
            traktEpisode.Runtime.Should().BeNull();
            traktEpisode.Rating.Should().BeNull();
            traktEpisode.Votes.Should().BeNull();
            traktEpisode.FirstAired.Should().BeNull();
            traktEpisode.UpdatedAt.Should().BeNull();
            traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
            traktEpisode.Translations.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(default(string));
            traktEpisode.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(string.Empty);
            traktEpisode.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Minimal_Complete()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().NotHaveValue();
                traktEpisode.Overview.Should().BeNullOrEmpty();
                traktEpisode.Runtime.Should().NotHaveValue();
                traktEpisode.Rating.Should().NotHaveValue();
                traktEpisode.Votes.Should().NotHaveValue();
                traktEpisode.FirstAired.Should().NotHaveValue();
                traktEpisode.UpdatedAt.Should().NotHaveValue();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_1()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().NotHaveValue();
                traktEpisode.Overview.Should().BeNullOrEmpty();
                traktEpisode.Runtime.Should().NotHaveValue();
                traktEpisode.Rating.Should().NotHaveValue();
                traktEpisode.Votes.Should().NotHaveValue();
                traktEpisode.FirstAired.Should().NotHaveValue();
                traktEpisode.UpdatedAt.Should().NotHaveValue();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_2()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().NotHaveValue();
                traktEpisode.Overview.Should().BeNullOrEmpty();
                traktEpisode.Runtime.Should().NotHaveValue();
                traktEpisode.Rating.Should().NotHaveValue();
                traktEpisode.Votes.Should().NotHaveValue();
                traktEpisode.FirstAired.Should().NotHaveValue();
                traktEpisode.UpdatedAt.Should().NotHaveValue();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_3()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().NotHaveValue();
                traktEpisode.Overview.Should().BeNullOrEmpty();
                traktEpisode.Runtime.Should().NotHaveValue();
                traktEpisode.Rating.Should().NotHaveValue();
                traktEpisode.Votes.Should().NotHaveValue();
                traktEpisode.FirstAired.Should().NotHaveValue();
                traktEpisode.UpdatedAt.Should().NotHaveValue();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_4()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().NotHaveValue();
                traktEpisode.Overview.Should().BeNullOrEmpty();
                traktEpisode.Runtime.Should().NotHaveValue();
                traktEpisode.Rating.Should().NotHaveValue();
                traktEpisode.Votes.Should().NotHaveValue();
                traktEpisode.FirstAired.Should().NotHaveValue();
                traktEpisode.UpdatedAt.Should().NotHaveValue();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_5()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().NotHaveValue();
                traktEpisode.Overview.Should().BeNullOrEmpty();
                traktEpisode.Runtime.Should().NotHaveValue();
                traktEpisode.Rating.Should().NotHaveValue();
                traktEpisode.Votes.Should().NotHaveValue();
                traktEpisode.FirstAired.Should().NotHaveValue();
                traktEpisode.UpdatedAt.Should().NotHaveValue();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_6()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().NotHaveValue();
                traktEpisode.Overview.Should().BeNullOrEmpty();
                traktEpisode.Runtime.Should().NotHaveValue();
                traktEpisode.Rating.Should().NotHaveValue();
                traktEpisode.Votes.Should().NotHaveValue();
                traktEpisode.FirstAired.Should().NotHaveValue();
                traktEpisode.UpdatedAt.Should().NotHaveValue();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_7()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().NotHaveValue();
                traktEpisode.Overview.Should().BeNullOrEmpty();
                traktEpisode.Runtime.Should().NotHaveValue();
                traktEpisode.Rating.Should().NotHaveValue();
                traktEpisode.Votes.Should().NotHaveValue();
                traktEpisode.FirstAired.Should().NotHaveValue();
                traktEpisode.UpdatedAt.Should().NotHaveValue();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_8()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().NotHaveValue();
                traktEpisode.Overview.Should().BeNullOrEmpty();
                traktEpisode.Runtime.Should().NotHaveValue();
                traktEpisode.Rating.Should().NotHaveValue();
                traktEpisode.Votes.Should().NotHaveValue();
                traktEpisode.FirstAired.Should().NotHaveValue();
                traktEpisode.UpdatedAt.Should().NotHaveValue();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_1()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().NotHaveValue();
                traktEpisode.Overview.Should().BeNullOrEmpty();
                traktEpisode.Runtime.Should().NotHaveValue();
                traktEpisode.Rating.Should().NotHaveValue();
                traktEpisode.Votes.Should().NotHaveValue();
                traktEpisode.FirstAired.Should().NotHaveValue();
                traktEpisode.UpdatedAt.Should().NotHaveValue();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_2()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().NotHaveValue();
                traktEpisode.Overview.Should().BeNullOrEmpty();
                traktEpisode.Runtime.Should().NotHaveValue();
                traktEpisode.Rating.Should().NotHaveValue();
                traktEpisode.Votes.Should().NotHaveValue();
                traktEpisode.FirstAired.Should().NotHaveValue();
                traktEpisode.UpdatedAt.Should().NotHaveValue();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_3()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().NotHaveValue();
                traktEpisode.Overview.Should().BeNullOrEmpty();
                traktEpisode.Runtime.Should().NotHaveValue();
                traktEpisode.Rating.Should().NotHaveValue();
                traktEpisode.Votes.Should().NotHaveValue();
                traktEpisode.FirstAired.Should().NotHaveValue();
                traktEpisode.UpdatedAt.Should().NotHaveValue();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_4()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().NotHaveValue();
                traktEpisode.Overview.Should().BeNullOrEmpty();
                traktEpisode.Runtime.Should().NotHaveValue();
                traktEpisode.Rating.Should().NotHaveValue();
                traktEpisode.Votes.Should().NotHaveValue();
                traktEpisode.FirstAired.Should().NotHaveValue();
                traktEpisode.UpdatedAt.Should().NotHaveValue();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_5()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().NotHaveValue();
                traktEpisode.Overview.Should().BeNullOrEmpty();
                traktEpisode.Runtime.Should().NotHaveValue();
                traktEpisode.Rating.Should().NotHaveValue();
                traktEpisode.Votes.Should().NotHaveValue();
                traktEpisode.FirstAired.Should().NotHaveValue();
                traktEpisode.UpdatedAt.Should().NotHaveValue();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Complete()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_1()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_2()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_3()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_4()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_5()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().BeNull();
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_6()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().BeNull();
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_7()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().BeNull();
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_8()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().BeNull();
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_9()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().BeNull();
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_10()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().BeNull();
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_11()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_12()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().BeNull();
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_13()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_14()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().BeNull();
                traktEpisode.Overview.Should().BeNull();
                traktEpisode.Runtime.Should().BeNull();
                traktEpisode.Rating.Should().BeNull();
                traktEpisode.Votes.Should().BeNull();
                traktEpisode.FirstAired.Should().BeNull();
                traktEpisode.UpdatedAt.Should().BeNull();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_15()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_15))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().BeNull();
                traktEpisode.Overview.Should().BeNull();
                traktEpisode.Runtime.Should().BeNull();
                traktEpisode.Rating.Should().BeNull();
                traktEpisode.Votes.Should().BeNull();
                traktEpisode.FirstAired.Should().BeNull();
                traktEpisode.UpdatedAt.Should().BeNull();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_16()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_16))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().BeNull();
                traktEpisode.Overview.Should().BeNull();
                traktEpisode.Runtime.Should().BeNull();
                traktEpisode.Rating.Should().BeNull();
                traktEpisode.Votes.Should().BeNull();
                traktEpisode.FirstAired.Should().BeNull();
                traktEpisode.UpdatedAt.Should().BeNull();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_17()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_17))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().BeNull();
                traktEpisode.Overview.Should().BeNull();
                traktEpisode.Runtime.Should().BeNull();
                traktEpisode.Rating.Should().BeNull();
                traktEpisode.Votes.Should().BeNull();
                traktEpisode.FirstAired.Should().BeNull();
                traktEpisode.UpdatedAt.Should().BeNull();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_18()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_18))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().BeNull();
                traktEpisode.Runtime.Should().BeNull();
                traktEpisode.Rating.Should().BeNull();
                traktEpisode.Votes.Should().BeNull();
                traktEpisode.FirstAired.Should().BeNull();
                traktEpisode.UpdatedAt.Should().BeNull();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_19()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_19))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().BeNull();
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().BeNull();
                traktEpisode.Rating.Should().BeNull();
                traktEpisode.Votes.Should().BeNull();
                traktEpisode.FirstAired.Should().BeNull();
                traktEpisode.UpdatedAt.Should().BeNull();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_20()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_20))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().BeNull();
                traktEpisode.Overview.Should().BeNull();
                traktEpisode.Runtime.Should().BeNull();
                traktEpisode.Rating.Should().BeNull();
                traktEpisode.Votes.Should().BeNull();
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().BeNull();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_21()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_21))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().BeNull();
                traktEpisode.Overview.Should().BeNull();
                traktEpisode.Runtime.Should().BeNull();
                traktEpisode.Rating.Should().BeNull();
                traktEpisode.Votes.Should().BeNull();
                traktEpisode.FirstAired.Should().BeNull();
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_22()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_22))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().BeNull();
                traktEpisode.Overview.Should().BeNull();
                traktEpisode.Runtime.Should().BeNull();
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().BeNull();
                traktEpisode.FirstAired.Should().BeNull();
                traktEpisode.UpdatedAt.Should().BeNull();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_23()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_23))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().BeNull();
                traktEpisode.Overview.Should().BeNull();
                traktEpisode.Runtime.Should().BeNull();
                traktEpisode.Rating.Should().BeNull();
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().BeNull();
                traktEpisode.UpdatedAt.Should().BeNull();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_24()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_24))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().BeNull();
                traktEpisode.Overview.Should().BeNull();
                traktEpisode.Runtime.Should().BeNull();
                traktEpisode.Rating.Should().BeNull();
                traktEpisode.Votes.Should().BeNull();
                traktEpisode.FirstAired.Should().BeNull();
                traktEpisode.UpdatedAt.Should().BeNull();
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_25()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_25))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().BeNull();
                traktEpisode.Overview.Should().BeNull();
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().BeNull();
                traktEpisode.Votes.Should().BeNull();
                traktEpisode.FirstAired.Should().BeNull();
                traktEpisode.UpdatedAt.Should().BeNull();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_26()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_26))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().BeNull();
                traktEpisode.Overview.Should().BeNull();
                traktEpisode.Runtime.Should().BeNull();
                traktEpisode.Rating.Should().BeNull();
                traktEpisode.Votes.Should().BeNull();
                traktEpisode.FirstAired.Should().BeNull();
                traktEpisode.UpdatedAt.Should().BeNull();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_1()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_2()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_3()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_4()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_5()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().BeNull();
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_6()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().BeNull();
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_7()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().BeNull();
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_8()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().BeNull();
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_9()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().BeNull();
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_10()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().BeNull();
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_11()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_12()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().BeNull();
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().NotBeNull().And.HaveCount(2);

                var translations = traktEpisode.Translations.ToArray();

                translations[0].Should().NotBeNull();
                translations[0].Title.Should().Be("Winter Is Coming");
                translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
                translations[0].LanguageCode.Should().Be("en");

                translations[1].Should().NotBeNull();
                translations[1].Title.Should().Be("Se acerca el invierno");
                translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
                translations[1].LanguageCode.Should().Be("es");
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_13()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().Be(1);
                traktEpisode.Number.Should().Be(1);
                traktEpisode.Title.Should().Be("Winter Is Coming");
                traktEpisode.Ids.Should().NotBeNull();
                traktEpisode.Ids.Trakt.Should().Be(73640U);
                traktEpisode.Ids.Tvdb.Should().Be(3254641U);
                traktEpisode.Ids.Imdb.Should().Be("tt1480055");
                traktEpisode.Ids.Tmdb.Should().Be(63056U);
                traktEpisode.Ids.TvRage.Should().Be(1065008299U);
                traktEpisode.NumberAbsolute.Should().Be(50);
                traktEpisode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
                traktEpisode.Runtime.Should().Be(55);
                traktEpisode.Rating.Should().Be(9.0f);
                traktEpisode.Votes.Should().Be(111);
                traktEpisode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
                traktEpisode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
                traktEpisode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_14()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);

                traktEpisode.Should().NotBeNull();
                traktEpisode.SeasonNumber.Should().BeNull();
                traktEpisode.Number.Should().BeNull();
                traktEpisode.Title.Should().BeNull();
                traktEpisode.Ids.Should().BeNull();
                traktEpisode.NumberAbsolute.Should().BeNull();
                traktEpisode.Overview.Should().BeNull();
                traktEpisode.Runtime.Should().BeNull();
                traktEpisode.Rating.Should().BeNull();
                traktEpisode.Votes.Should().BeNull();
                traktEpisode.FirstAired.Should().BeNull();
                traktEpisode.UpdatedAt.Should().BeNull();
                traktEpisode.AvailableTranslationLanguageCodes.Should().BeNull();
                traktEpisode.Translations.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktEpisodeObjectJsonReader();

            var traktEpisode = jsonReader.ReadObject(default(JsonTextReader));
            traktEpisode.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktEpisodeObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisode = traktJsonReader.ReadObject(jsonReader);
                traktEpisode.Should().BeNull();
            }
        }

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
