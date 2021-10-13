namespace TraktNet.Objects.Get.Tests.Calendars.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Calendars;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Calendars.JsonWriter")]
    public partial class CalendarShowArrayJsonWriter_Tests
    {
        private readonly DateTime UPDATED_AT = DateTime.UtcNow;
        private readonly DateTime FIRST_AIRED = DateTime.UtcNow;

        [Fact]
        public async Task Test_CalendarShowArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktCalendarShow>();
            IEnumerable<ITraktCalendarShow> traktCalendarShow = new List<TraktCalendarShow>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktCalendarShow);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CalendarShowArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktCalendarShow> traktCalendarShow = new List<TraktCalendarShow>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCalendarShow>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCalendarShow);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_CalendarShowArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
        {
            IEnumerable<ITraktCalendarShow> traktCalendarShow = new List<ITraktCalendarShow>
            {
                new TraktCalendarShow
                {
                    FirstAiredInCalendar = FIRST_AIRED,
                    Show = new TraktShow
                    {
                        Title = "Game of Thrones",
                        Year = 2011,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1390U,
                            Slug = "game-of-thrones",
                            Tvdb = 121361U,
                            Imdb = "tt0944947",
                            Tmdb = 1399U,
                            TvRage = 24493U
                        },
                        Overview = "Seven noble families fight for control of the mythical land of Westeros.Friction between the houses leads to full - scale war.All while a very ancient evil awakens in the farthest north.Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.",
                        FirstAired = FIRST_AIRED,
                        Airs = new TraktShowAirs
                        {
                            Day = "Sunday",
                            Time = "21:00",
                            TimeZoneId = "America/New_York"
                        },
                        Runtime = 60,
                        Certification = "TV-MA",
                        Network = "HBO",
                        CountryCode = "us",
                        Trailer = "http://youtube.com/watch?v=F9Bo89m2f6g",
                        Homepage = "http://www.hbo.com/game-of-thrones",
                        Status = TraktShowStatus.ReturningSeries,
                        Rating = 9.38327f,
                        Votes = 44773,
                        UpdatedAt = UPDATED_AT,
                        LanguageCode = "en",
                        AvailableTranslationLanguageCodes = new List<string>
                        {
                            "en",
                            "fr",
                            "it",
                            "de"
                        },
                        Genres = new List<string>
                        {
                            "drama",
                            "fantasy",
                            "science-fiction",
                            "action",
                            "adventure"
                        },
                        AiredEpisodes = 50,
                        CommentCount = 133
                    },
                    Episode = new TraktEpisode
                    {
                        SeasonNumber = 1,
                        Number = 1,
                        Title = "Winter Is Coming",
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 73640U,
                            Tvdb = 3254641U,
                            Imdb = "tt1480055",
                            Tmdb = 63056U,
                            TvRage = 1065008299U
                        },
                        NumberAbsolute = 50,
                        Overview = "Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.",
                        FirstAired = FIRST_AIRED,
                        UpdatedAt = UPDATED_AT,
                        Rating = 9.0f,
                        Votes = 111,
                        AvailableTranslationLanguageCodes = new List<string>
                        {
                            "en",
                            "es"
                        },
                        Runtime = 55,
                        Translations = new List<ITraktEpisodeTranslation>
                        {
                            new TraktEpisodeTranslation
                            {
                                Title = "Winter Is Coming",
                                Overview = "Jon Arryn, the Hand of the King, is dead.King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.",
                                LanguageCode = "en"
                            },
                            new TraktEpisodeTranslation
                            {
                                Title = "Se acerca el invierno",
                                Overview = "El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.",
                                LanguageCode = "es"
                            }
                        },
                        CommentCount = 133
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCalendarShow>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCalendarShow);
                stringWriter.ToString().Should().Be($"[{{\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    @"""show"":{""title"":""Game of Thrones"",""year"":2011,""ids"":{" +
                                                    @"""trakt"":1390,""slug"":""game-of-thrones"",""tvdb"":121361," +
                                                    @"""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}," +
                                                    @"""overview"":""Seven noble families fight for control of the mythical land of " +
                                                    @"Westeros.Friction between the houses leads to full - scale war.All while a very " +
                                                    @"ancient evil awakens in the farthest north.Amidst the war, a neglected military " +
                                                    @"order of misfits, the Night's Watch, is all that stands between the realms of men " +
                                                    @"and the icy horrors beyond.""," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    @"""airs"":{""day"":""Sunday"",""time"":""21:00"",""timezone"":""America/New_York""}," +
                                                    @"""runtime"":60,""certification"":""TV-MA"",""network"":""HBO""," +
                                                    @"""country"":""us"",""trailer"":""http://youtube.com/watch?v=F9Bo89m2f6g""," +
                                                    @"""homepage"":""http://www.hbo.com/game-of-thrones"",""status"":""returning series""," +
                                                    @"""rating"":9.38327,""votes"":44773," +
                                                    $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""language"":""en"",""available_translations"":[""en"",""fr"",""it"",""de""]," +
                                                    @"""genres"":[""drama"",""fantasy"",""science-fiction"",""action"",""adventure""]," +
                                                    @"""aired_episodes"":50,""comment_count"":133}," +
                                                    @"""episode"":{""season"":1,""number"":1,""title"":""Winter Is Coming""," +
                                                    @"""ids"":{""trakt"":73640,""tvdb"":3254641,""imdb"":""tt1480055""," +
                                                    @"""tmdb"":63056,""tvrage"":1065008299},""number_abs"":50," +
                                                    @"""overview"":""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, " +
                                                    @"has died and that King Robert is on his way north to offer Ned Arryn’s position " +
                                                    @"as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to " +
                                                    @"wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge " +
                                                    @"an alliance to take the throne."",""runtime"":55,""rating"":9.0,""votes"":111," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""available_translations"":[""en"",""es""]," +
                                                    @"""translations"":[{""title"":""Winter Is Coming""," +
                                                    @"""overview"":""Jon Arryn, the Hand of the King, is dead.King Robert Baratheon plans " +
                                                    @"to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys " +
                                                    @"Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.""," +
                                                    @"""language"":""en""},{""title"":""Se acerca el invierno""," +
                                                    @"""overview"":""El Lord Ned Stark está preocupado por los perturbantes reportes de un " +
                                                    @"desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; " +
                                                    @"el exiliado Viserys Targaryen forja una nueva y poderosa alianza."",""language"":""es""}]," +
                                                    @"""comment_count"":133}}]");
            }
        }

        [Fact]
        public async Task Test_CalendarShowArrayJsonWriter_WriteArray_JsonWriter_Complete()
        {
            IEnumerable<ITraktCalendarShow> traktCalendarShow = new List<ITraktCalendarShow>
            {
                new TraktCalendarShow
                {
                    FirstAiredInCalendar = FIRST_AIRED,
                    Show = new TraktShow
                    {
                        Title = "Game of Thrones",
                        Year = 2011,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1390U,
                            Slug = "game-of-thrones",
                            Tvdb = 121361U,
                            Imdb = "tt0944947",
                            Tmdb = 1399U,
                            TvRage = 24493U
                        },
                        Overview = "Seven noble families fight for control of the mythical land of Westeros.Friction between the houses leads to full - scale war.All while a very ancient evil awakens in the farthest north.Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.",
                        FirstAired = FIRST_AIRED,
                        Airs = new TraktShowAirs
                        {
                            Day = "Sunday",
                            Time = "21:00",
                            TimeZoneId = "America/New_York"
                        },
                        Runtime = 60,
                        Certification = "TV-MA",
                        Network = "HBO",
                        CountryCode = "us",
                        Trailer = "http://youtube.com/watch?v=F9Bo89m2f6g",
                        Homepage = "http://www.hbo.com/game-of-thrones",
                        Status = TraktShowStatus.ReturningSeries,
                        Rating = 9.38327f,
                        Votes = 44773,
                        UpdatedAt = UPDATED_AT,
                        LanguageCode = "en",
                        AvailableTranslationLanguageCodes = new List<string>
                        {
                            "en",
                            "fr",
                            "it",
                            "de"
                        },
                        Genres = new List<string>
                        {
                            "drama",
                            "fantasy",
                            "science-fiction",
                            "action",
                            "adventure"
                        },
                        AiredEpisodes = 50,
                        CommentCount = 133
                    },
                    Episode = new TraktEpisode
                    {
                        SeasonNumber = 1,
                        Number = 1,
                        Title = "Winter Is Coming",
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 73640U,
                            Tvdb = 3254641U,
                            Imdb = "tt1480055",
                            Tmdb = 63056U,
                            TvRage = 1065008299U
                        },
                        NumberAbsolute = 50,
                        Overview = "Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.",
                        FirstAired = FIRST_AIRED,
                        UpdatedAt = UPDATED_AT,
                        Rating = 9.0f,
                        Votes = 111,
                        AvailableTranslationLanguageCodes = new List<string>
                        {
                            "en",
                            "es"
                        },
                        Runtime = 55,
                        Translations = new List<ITraktEpisodeTranslation>
                        {
                            new TraktEpisodeTranslation
                            {
                                Title = "Winter Is Coming",
                                Overview = "Jon Arryn, the Hand of the King, is dead.King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.",
                                LanguageCode = "en"
                            },
                            new TraktEpisodeTranslation
                            {
                                Title = "Se acerca el invierno",
                                Overview = "El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.",
                                LanguageCode = "es"
                            }
                        },
                        CommentCount = 133
                    }
                },
                new TraktCalendarShow
                {
                    FirstAiredInCalendar = FIRST_AIRED,
                    Show = new TraktShow
                    {
                        Title = "Game of Thrones",
                        Year = 2011,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1390U,
                            Slug = "game-of-thrones",
                            Tvdb = 121361U,
                            Imdb = "tt0944947",
                            Tmdb = 1399U,
                            TvRage = 24493U
                        },
                        Overview = "Seven noble families fight for control of the mythical land of Westeros.Friction between the houses leads to full - scale war.All while a very ancient evil awakens in the farthest north.Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.",
                        FirstAired = FIRST_AIRED,
                        Airs = new TraktShowAirs
                        {
                            Day = "Sunday",
                            Time = "21:00",
                            TimeZoneId = "America/New_York"
                        },
                        Runtime = 60,
                        Certification = "TV-MA",
                        Network = "HBO",
                        CountryCode = "us",
                        Trailer = "http://youtube.com/watch?v=F9Bo89m2f6g",
                        Homepage = "http://www.hbo.com/game-of-thrones",
                        Status = TraktShowStatus.ReturningSeries,
                        Rating = 9.38327f,
                        Votes = 44773,
                        UpdatedAt = UPDATED_AT,
                        LanguageCode = "en",
                        AvailableTranslationLanguageCodes = new List<string>
                        {
                            "en",
                            "fr",
                            "it",
                            "de"
                        },
                        Genres = new List<string>
                        {
                            "drama",
                            "fantasy",
                            "science-fiction",
                            "action",
                            "adventure"
                        },
                        AiredEpisodes = 50,
                        CommentCount = 133
                    },
                    Episode = new TraktEpisode
                    {
                        SeasonNumber = 1,
                        Number = 1,
                        Title = "Winter Is Coming",
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 73640U,
                            Tvdb = 3254641U,
                            Imdb = "tt1480055",
                            Tmdb = 63056U,
                            TvRage = 1065008299U
                        },
                        NumberAbsolute = 50,
                        Overview = "Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.",
                        FirstAired = FIRST_AIRED,
                        UpdatedAt = UPDATED_AT,
                        Rating = 9.0f,
                        Votes = 111,
                        AvailableTranslationLanguageCodes = new List<string>
                        {
                            "en",
                            "es"
                        },
                        Runtime = 55,
                        Translations = new List<ITraktEpisodeTranslation>
                        {
                            new TraktEpisodeTranslation
                            {
                                Title = "Winter Is Coming",
                                Overview = "Jon Arryn, the Hand of the King, is dead.King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.",
                                LanguageCode = "en"
                            },
                            new TraktEpisodeTranslation
                            {
                                Title = "Se acerca el invierno",
                                Overview = "El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.",
                                LanguageCode = "es"
                            }
                        },
                        CommentCount = 133
                    }
                }
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktCalendarShow>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktCalendarShow);
                stringWriter.ToString().Should().Be($"[{{\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    @"""show"":{""title"":""Game of Thrones"",""year"":2011,""ids"":{" +
                                                    @"""trakt"":1390,""slug"":""game-of-thrones"",""tvdb"":121361," +
                                                    @"""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}," +
                                                    @"""overview"":""Seven noble families fight for control of the mythical land of " +
                                                    @"Westeros.Friction between the houses leads to full - scale war.All while a very " +
                                                    @"ancient evil awakens in the farthest north.Amidst the war, a neglected military " +
                                                    @"order of misfits, the Night's Watch, is all that stands between the realms of men " +
                                                    @"and the icy horrors beyond.""," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    @"""airs"":{""day"":""Sunday"",""time"":""21:00"",""timezone"":""America/New_York""}," +
                                                    @"""runtime"":60,""certification"":""TV-MA"",""network"":""HBO""," +
                                                    @"""country"":""us"",""trailer"":""http://youtube.com/watch?v=F9Bo89m2f6g""," +
                                                    @"""homepage"":""http://www.hbo.com/game-of-thrones"",""status"":""returning series""," +
                                                    @"""rating"":9.38327,""votes"":44773," +
                                                    $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""language"":""en"",""available_translations"":[""en"",""fr"",""it"",""de""]," +
                                                    @"""genres"":[""drama"",""fantasy"",""science-fiction"",""action"",""adventure""]," +
                                                    @"""aired_episodes"":50,""comment_count"":133}," +
                                                    @"""episode"":{""season"":1,""number"":1,""title"":""Winter Is Coming""," +
                                                    @"""ids"":{""trakt"":73640,""tvdb"":3254641,""imdb"":""tt1480055""," +
                                                    @"""tmdb"":63056,""tvrage"":1065008299},""number_abs"":50," +
                                                    @"""overview"":""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, " +
                                                    @"has died and that King Robert is on his way north to offer Ned Arryn’s position " +
                                                    @"as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to " +
                                                    @"wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge " +
                                                    @"an alliance to take the throne."",""runtime"":55,""rating"":9.0,""votes"":111," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""available_translations"":[""en"",""es""]," +
                                                    @"""translations"":[{""title"":""Winter Is Coming""," +
                                                    @"""overview"":""Jon Arryn, the Hand of the King, is dead.King Robert Baratheon plans " +
                                                    @"to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys " +
                                                    @"Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.""," +
                                                    @"""language"":""en""},{""title"":""Se acerca el invierno""," +
                                                    @"""overview"":""El Lord Ned Stark está preocupado por los perturbantes reportes de un " +
                                                    @"desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; " +
                                                    @"el exiliado Viserys Targaryen forja una nueva y poderosa alianza."",""language"":""es""}]," +
                                                    @"""comment_count"":133}}," +
                                                    $"{{\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    @"""show"":{""title"":""Game of Thrones"",""year"":2011,""ids"":{" +
                                                    @"""trakt"":1390,""slug"":""game-of-thrones"",""tvdb"":121361," +
                                                    @"""imdb"":""tt0944947"",""tmdb"":1399,""tvrage"":24493}," +
                                                    @"""overview"":""Seven noble families fight for control of the mythical land of " +
                                                    @"Westeros.Friction between the houses leads to full - scale war.All while a very " +
                                                    @"ancient evil awakens in the farthest north.Amidst the war, a neglected military " +
                                                    @"order of misfits, the Night's Watch, is all that stands between the realms of men " +
                                                    @"and the icy horrors beyond.""," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    @"""airs"":{""day"":""Sunday"",""time"":""21:00"",""timezone"":""America/New_York""}," +
                                                    @"""runtime"":60,""certification"":""TV-MA"",""network"":""HBO""," +
                                                    @"""country"":""us"",""trailer"":""http://youtube.com/watch?v=F9Bo89m2f6g""," +
                                                    @"""homepage"":""http://www.hbo.com/game-of-thrones"",""status"":""returning series""," +
                                                    @"""rating"":9.38327,""votes"":44773," +
                                                    $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""language"":""en"",""available_translations"":[""en"",""fr"",""it"",""de""]," +
                                                    @"""genres"":[""drama"",""fantasy"",""science-fiction"",""action"",""adventure""]," +
                                                    @"""aired_episodes"":50,""comment_count"":133}," +
                                                    @"""episode"":{""season"":1,""number"":1,""title"":""Winter Is Coming""," +
                                                    @"""ids"":{""trakt"":73640,""tvdb"":3254641,""imdb"":""tt1480055""," +
                                                    @"""tmdb"":63056,""tvrage"":1065008299},""number_abs"":50," +
                                                    @"""overview"":""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, " +
                                                    @"has died and that King Robert is on his way north to offer Ned Arryn’s position " +
                                                    @"as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to " +
                                                    @"wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge " +
                                                    @"an alliance to take the throne."",""runtime"":55,""rating"":9.0,""votes"":111," +
                                                    $"\"first_aired\":\"{FIRST_AIRED.ToTraktLongDateTimeString()}\"," +
                                                    $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                                                    @"""available_translations"":[""en"",""es""]," +
                                                    @"""translations"":[{""title"":""Winter Is Coming""," +
                                                    @"""overview"":""Jon Arryn, the Hand of the King, is dead.King Robert Baratheon plans " +
                                                    @"to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys " +
                                                    @"Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.""," +
                                                    @"""language"":""en""},{""title"":""Se acerca el invierno""," +
                                                    @"""overview"":""El Lord Ned Stark está preocupado por los perturbantes reportes de un " +
                                                    @"desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; " +
                                                    @"el exiliado Viserys Targaryen forja una nueva y poderosa alianza."",""language"":""es""}]," +
                                                    @"""comment_count"":133}}]");
            }
        }
    }
}
