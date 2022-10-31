namespace TraktNet.Objects.Post.Tests.Users.PersonalListItems.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.PersonalListItems.Responses;
    using TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Users.PersonalListItems.Responses.JsonReader")]
    public partial class UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var movies = personalListItemsPostResponseNotFoundGroup.Movies.ToArray();

                movies[0].Should().NotBeNull();
                movies[0].Ids.Should().NotBeNull();
                movies[0].Ids.Trakt.Should().Be(94024U);
                movies[0].Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movies[0].Ids.Imdb.Should().Be("tt2488496");
                movies[0].Ids.Tmdb.Should().Be(140607U);

                movies[1].Should().NotBeNull();
                movies[1].Ids.Should().NotBeNull();
                movies[1].Ids.Trakt.Should().Be(172687U);
                movies[1].Ids.Slug.Should().Be("king-arthur-legend-of-the-sword-2017");
                movies[1].Ids.Imdb.Should().Be("tt1972591");
                movies[1].Ids.Tmdb.Should().Be(274857U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Shows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var shows = personalListItemsPostResponseNotFoundGroup.Shows.ToArray();

                shows[0].Should().NotBeNull();
                shows[0].Ids.Should().NotBeNull();
                shows[0].Ids.Trakt.Should().Be(1390U);
                shows[0].Ids.Slug.Should().Be("game-of-thrones");
                shows[0].Ids.Tvdb.Should().Be(121361U);
                shows[0].Ids.Imdb.Should().Be("tt0944947");
                shows[0].Ids.Tmdb.Should().Be(1399U);
                shows[0].Ids.TvRage.Should().Be(24493U);

                shows[1].Should().NotBeNull();
                shows[1].Ids.Should().NotBeNull();
                shows[1].Ids.Trakt.Should().Be(60300U);
                shows[1].Ids.Slug.Should().Be("the-flash-2014");
                shows[1].Ids.Tvdb.Should().Be(279121U);
                shows[1].Ids.Imdb.Should().Be("tt3107288");
                shows[1].Ids.Tmdb.Should().Be(60735U);
                shows[1].Ids.TvRage.Should().Be(36939U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = personalListItemsPostResponseNotFoundGroup.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);

                seasons[1].Should().NotBeNull();
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(61431U);
                seasons[1].Ids.Tvdb.Should().Be(578373U);
                seasons[1].Ids.Tmdb.Should().Be(60524U);
                seasons[1].Ids.TvRage.Should().Be(36940U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var episodes = personalListItemsPostResponseNotFoundGroup.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);

                episodes[1].Should().NotBeNull();
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(73641U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63057U);
                episodes[1].Ids.TvRage.Should().Be(1065023912U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.People.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var people = personalListItemsPostResponseNotFoundGroup.People.ToArray();

                people[0].Should().NotBeNull();
                people[0].Ids.Should().NotBeNull();
                people[0].Ids.Trakt.Should().Be(297737U);
                people[0].Ids.Slug.Should().Be("bryan-cranston");
                people[0].Ids.Imdb.Should().Be("nm0186505");
                people[0].Ids.Tmdb.Should().Be(17419U);
                people[0].Ids.TvRage.Should().Be(1797U);

                people[1].Should().NotBeNull();
                people[1].Ids.Should().NotBeNull();
                people[1].Ids.Trakt.Should().Be(9486U);
                people[1].Ids.Slug.Should().Be("samuel-l-jackson");
                people[1].Ids.Imdb.Should().Be("nm0000168");
                people[1].Ids.Tmdb.Should().Be(2231U);
                people[1].Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().BeNull();

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Shows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var shows = personalListItemsPostResponseNotFoundGroup.Shows.ToArray();

                shows[0].Should().NotBeNull();
                shows[0].Ids.Should().NotBeNull();
                shows[0].Ids.Trakt.Should().Be(1390U);
                shows[0].Ids.Slug.Should().Be("game-of-thrones");
                shows[0].Ids.Tvdb.Should().Be(121361U);
                shows[0].Ids.Imdb.Should().Be("tt0944947");
                shows[0].Ids.Tmdb.Should().Be(1399U);
                shows[0].Ids.TvRage.Should().Be(24493U);

                shows[1].Should().NotBeNull();
                shows[1].Ids.Should().NotBeNull();
                shows[1].Ids.Trakt.Should().Be(60300U);
                shows[1].Ids.Slug.Should().Be("the-flash-2014");
                shows[1].Ids.Tvdb.Should().Be(279121U);
                shows[1].Ids.Imdb.Should().Be("tt3107288");
                shows[1].Ids.Tmdb.Should().Be(60735U);
                shows[1].Ids.TvRage.Should().Be(36939U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = personalListItemsPostResponseNotFoundGroup.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);

                seasons[1].Should().NotBeNull();
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(61431U);
                seasons[1].Ids.Tvdb.Should().Be(578373U);
                seasons[1].Ids.Tmdb.Should().Be(60524U);
                seasons[1].Ids.TvRage.Should().Be(36940U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var episodes = personalListItemsPostResponseNotFoundGroup.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);

                episodes[1].Should().NotBeNull();
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(73641U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63057U);
                episodes[1].Ids.TvRage.Should().Be(1065023912U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.People.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var people = personalListItemsPostResponseNotFoundGroup.People.ToArray();

                people[0].Should().NotBeNull();
                people[0].Ids.Should().NotBeNull();
                people[0].Ids.Trakt.Should().Be(297737U);
                people[0].Ids.Slug.Should().Be("bryan-cranston");
                people[0].Ids.Imdb.Should().Be("nm0186505");
                people[0].Ids.Tmdb.Should().Be(17419U);
                people[0].Ids.TvRage.Should().Be(1797U);

                people[1].Should().NotBeNull();
                people[1].Ids.Should().NotBeNull();
                people[1].Ids.Trakt.Should().Be(9486U);
                people[1].Ids.Slug.Should().Be("samuel-l-jackson");
                people[1].Ids.Imdb.Should().Be("nm0000168");
                people[1].Ids.Tmdb.Should().Be(2231U);
                people[1].Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var movies = personalListItemsPostResponseNotFoundGroup.Movies.ToArray();

                movies[0].Should().NotBeNull();
                movies[0].Ids.Should().NotBeNull();
                movies[0].Ids.Trakt.Should().Be(94024U);
                movies[0].Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movies[0].Ids.Imdb.Should().Be("tt2488496");
                movies[0].Ids.Tmdb.Should().Be(140607U);

                movies[1].Should().NotBeNull();
                movies[1].Ids.Should().NotBeNull();
                movies[1].Ids.Trakt.Should().Be(172687U);
                movies[1].Ids.Slug.Should().Be("king-arthur-legend-of-the-sword-2017");
                movies[1].Ids.Imdb.Should().Be("tt1972591");
                movies[1].Ids.Tmdb.Should().Be(274857U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Shows.Should().BeNull();

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = personalListItemsPostResponseNotFoundGroup.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);

                seasons[1].Should().NotBeNull();
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(61431U);
                seasons[1].Ids.Tvdb.Should().Be(578373U);
                seasons[1].Ids.Tmdb.Should().Be(60524U);
                seasons[1].Ids.TvRage.Should().Be(36940U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var episodes = personalListItemsPostResponseNotFoundGroup.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);

                episodes[1].Should().NotBeNull();
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(73641U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63057U);
                episodes[1].Ids.TvRage.Should().Be(1065023912U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.People.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var people = personalListItemsPostResponseNotFoundGroup.People.ToArray();

                people[0].Should().NotBeNull();
                people[0].Ids.Should().NotBeNull();
                people[0].Ids.Trakt.Should().Be(297737U);
                people[0].Ids.Slug.Should().Be("bryan-cranston");
                people[0].Ids.Imdb.Should().Be("nm0186505");
                people[0].Ids.Tmdb.Should().Be(17419U);
                people[0].Ids.TvRage.Should().Be(1797U);

                people[1].Should().NotBeNull();
                people[1].Ids.Should().NotBeNull();
                people[1].Ids.Trakt.Should().Be(9486U);
                people[1].Ids.Slug.Should().Be("samuel-l-jackson");
                people[1].Ids.Imdb.Should().Be("nm0000168");
                people[1].Ids.Tmdb.Should().Be(2231U);
                people[1].Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var movies = personalListItemsPostResponseNotFoundGroup.Movies.ToArray();

                movies[0].Should().NotBeNull();
                movies[0].Ids.Should().NotBeNull();
                movies[0].Ids.Trakt.Should().Be(94024U);
                movies[0].Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movies[0].Ids.Imdb.Should().Be("tt2488496");
                movies[0].Ids.Tmdb.Should().Be(140607U);

                movies[1].Should().NotBeNull();
                movies[1].Ids.Should().NotBeNull();
                movies[1].Ids.Trakt.Should().Be(172687U);
                movies[1].Ids.Slug.Should().Be("king-arthur-legend-of-the-sword-2017");
                movies[1].Ids.Imdb.Should().Be("tt1972591");
                movies[1].Ids.Tmdb.Should().Be(274857U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Shows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var shows = personalListItemsPostResponseNotFoundGroup.Shows.ToArray();

                shows[0].Should().NotBeNull();
                shows[0].Ids.Should().NotBeNull();
                shows[0].Ids.Trakt.Should().Be(1390U);
                shows[0].Ids.Slug.Should().Be("game-of-thrones");
                shows[0].Ids.Tvdb.Should().Be(121361U);
                shows[0].Ids.Imdb.Should().Be("tt0944947");
                shows[0].Ids.Tmdb.Should().Be(1399U);
                shows[0].Ids.TvRage.Should().Be(24493U);

                shows[1].Should().NotBeNull();
                shows[1].Ids.Should().NotBeNull();
                shows[1].Ids.Trakt.Should().Be(60300U);
                shows[1].Ids.Slug.Should().Be("the-flash-2014");
                shows[1].Ids.Tvdb.Should().Be(279121U);
                shows[1].Ids.Imdb.Should().Be("tt3107288");
                shows[1].Ids.Tmdb.Should().Be(60735U);
                shows[1].Ids.TvRage.Should().Be(36939U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Seasons.Should().BeNull();

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var episodes = personalListItemsPostResponseNotFoundGroup.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);

                episodes[1].Should().NotBeNull();
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(73641U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63057U);
                episodes[1].Ids.TvRage.Should().Be(1065023912U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.People.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var people = personalListItemsPostResponseNotFoundGroup.People.ToArray();

                people[0].Should().NotBeNull();
                people[0].Ids.Should().NotBeNull();
                people[0].Ids.Trakt.Should().Be(297737U);
                people[0].Ids.Slug.Should().Be("bryan-cranston");
                people[0].Ids.Imdb.Should().Be("nm0186505");
                people[0].Ids.Tmdb.Should().Be(17419U);
                people[0].Ids.TvRage.Should().Be(1797U);

                people[1].Should().NotBeNull();
                people[1].Ids.Should().NotBeNull();
                people[1].Ids.Trakt.Should().Be(9486U);
                people[1].Ids.Slug.Should().Be("samuel-l-jackson");
                people[1].Ids.Imdb.Should().Be("nm0000168");
                people[1].Ids.Tmdb.Should().Be(2231U);
                people[1].Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var movies = personalListItemsPostResponseNotFoundGroup.Movies.ToArray();

                movies[0].Should().NotBeNull();
                movies[0].Ids.Should().NotBeNull();
                movies[0].Ids.Trakt.Should().Be(94024U);
                movies[0].Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movies[0].Ids.Imdb.Should().Be("tt2488496");
                movies[0].Ids.Tmdb.Should().Be(140607U);

                movies[1].Should().NotBeNull();
                movies[1].Ids.Should().NotBeNull();
                movies[1].Ids.Trakt.Should().Be(172687U);
                movies[1].Ids.Slug.Should().Be("king-arthur-legend-of-the-sword-2017");
                movies[1].Ids.Imdb.Should().Be("tt1972591");
                movies[1].Ids.Tmdb.Should().Be(274857U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Shows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var shows = personalListItemsPostResponseNotFoundGroup.Shows.ToArray();

                shows[0].Should().NotBeNull();
                shows[0].Ids.Should().NotBeNull();
                shows[0].Ids.Trakt.Should().Be(1390U);
                shows[0].Ids.Slug.Should().Be("game-of-thrones");
                shows[0].Ids.Tvdb.Should().Be(121361U);
                shows[0].Ids.Imdb.Should().Be("tt0944947");
                shows[0].Ids.Tmdb.Should().Be(1399U);
                shows[0].Ids.TvRage.Should().Be(24493U);

                shows[1].Should().NotBeNull();
                shows[1].Ids.Should().NotBeNull();
                shows[1].Ids.Trakt.Should().Be(60300U);
                shows[1].Ids.Slug.Should().Be("the-flash-2014");
                shows[1].Ids.Tvdb.Should().Be(279121U);
                shows[1].Ids.Imdb.Should().Be("tt3107288");
                shows[1].Ids.Tmdb.Should().Be(60735U);
                shows[1].Ids.TvRage.Should().Be(36939U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = personalListItemsPostResponseNotFoundGroup.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);

                seasons[1].Should().NotBeNull();
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(61431U);
                seasons[1].Ids.Tvdb.Should().Be(578373U);
                seasons[1].Ids.Tmdb.Should().Be(60524U);
                seasons[1].Ids.TvRage.Should().Be(36940U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Episodes.Should().BeNull();

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.People.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var people = personalListItemsPostResponseNotFoundGroup.People.ToArray();

                people[0].Should().NotBeNull();
                people[0].Ids.Should().NotBeNull();
                people[0].Ids.Trakt.Should().Be(297737U);
                people[0].Ids.Slug.Should().Be("bryan-cranston");
                people[0].Ids.Imdb.Should().Be("nm0186505");
                people[0].Ids.Tmdb.Should().Be(17419U);
                people[0].Ids.TvRage.Should().Be(1797U);

                people[1].Should().NotBeNull();
                people[1].Ids.Should().NotBeNull();
                people[1].Ids.Trakt.Should().Be(9486U);
                people[1].Ids.Slug.Should().Be("samuel-l-jackson");
                people[1].Ids.Imdb.Should().Be("nm0000168");
                people[1].Ids.Tmdb.Should().Be(2231U);
                people[1].Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var movies = personalListItemsPostResponseNotFoundGroup.Movies.ToArray();

                movies[0].Should().NotBeNull();
                movies[0].Ids.Should().NotBeNull();
                movies[0].Ids.Trakt.Should().Be(94024U);
                movies[0].Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movies[0].Ids.Imdb.Should().Be("tt2488496");
                movies[0].Ids.Tmdb.Should().Be(140607U);

                movies[1].Should().NotBeNull();
                movies[1].Ids.Should().NotBeNull();
                movies[1].Ids.Trakt.Should().Be(172687U);
                movies[1].Ids.Slug.Should().Be("king-arthur-legend-of-the-sword-2017");
                movies[1].Ids.Imdb.Should().Be("tt1972591");
                movies[1].Ids.Tmdb.Should().Be(274857U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Shows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var shows = personalListItemsPostResponseNotFoundGroup.Shows.ToArray();

                shows[0].Should().NotBeNull();
                shows[0].Ids.Should().NotBeNull();
                shows[0].Ids.Trakt.Should().Be(1390U);
                shows[0].Ids.Slug.Should().Be("game-of-thrones");
                shows[0].Ids.Tvdb.Should().Be(121361U);
                shows[0].Ids.Imdb.Should().Be("tt0944947");
                shows[0].Ids.Tmdb.Should().Be(1399U);
                shows[0].Ids.TvRage.Should().Be(24493U);

                shows[1].Should().NotBeNull();
                shows[1].Ids.Should().NotBeNull();
                shows[1].Ids.Trakt.Should().Be(60300U);
                shows[1].Ids.Slug.Should().Be("the-flash-2014");
                shows[1].Ids.Tvdb.Should().Be(279121U);
                shows[1].Ids.Imdb.Should().Be("tt3107288");
                shows[1].Ids.Tmdb.Should().Be(60735U);
                shows[1].Ids.TvRage.Should().Be(36939U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = personalListItemsPostResponseNotFoundGroup.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);

                seasons[1].Should().NotBeNull();
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(61431U);
                seasons[1].Ids.Tvdb.Should().Be(578373U);
                seasons[1].Ids.Tmdb.Should().Be(60524U);
                seasons[1].Ids.TvRage.Should().Be(36940U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var episodes = personalListItemsPostResponseNotFoundGroup.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);

                episodes[1].Should().NotBeNull();
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(73641U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63057U);
                episodes[1].Ids.TvRage.Should().Be(1065023912U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var movies = personalListItemsPostResponseNotFoundGroup.Movies.ToArray();

                movies[0].Should().NotBeNull();
                movies[0].Ids.Should().NotBeNull();
                movies[0].Ids.Trakt.Should().Be(94024U);
                movies[0].Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movies[0].Ids.Imdb.Should().Be("tt2488496");
                movies[0].Ids.Tmdb.Should().Be(140607U);

                movies[1].Should().NotBeNull();
                movies[1].Ids.Should().NotBeNull();
                movies[1].Ids.Trakt.Should().Be(172687U);
                movies[1].Ids.Slug.Should().Be("king-arthur-legend-of-the-sword-2017");
                movies[1].Ids.Imdb.Should().Be("tt1972591");
                movies[1].Ids.Tmdb.Should().Be(274857U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Shows.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().BeNull();

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Shows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var shows = personalListItemsPostResponseNotFoundGroup.Shows.ToArray();

                shows[0].Should().NotBeNull();
                shows[0].Ids.Should().NotBeNull();
                shows[0].Ids.Trakt.Should().Be(1390U);
                shows[0].Ids.Slug.Should().Be("game-of-thrones");
                shows[0].Ids.Tvdb.Should().Be(121361U);
                shows[0].Ids.Imdb.Should().Be("tt0944947");
                shows[0].Ids.Tmdb.Should().Be(1399U);
                shows[0].Ids.TvRage.Should().Be(24493U);

                shows[1].Should().NotBeNull();
                shows[1].Ids.Should().NotBeNull();
                shows[1].Ids.Trakt.Should().Be(60300U);
                shows[1].Ids.Slug.Should().Be("the-flash-2014");
                shows[1].Ids.Tvdb.Should().Be(279121U);
                shows[1].Ids.Imdb.Should().Be("tt3107288");
                shows[1].Ids.Tmdb.Should().Be(60735U);
                shows[1].Ids.TvRage.Should().Be(36939U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.Shows.Should().BeNull();

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = personalListItemsPostResponseNotFoundGroup.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);

                seasons[1].Should().NotBeNull();
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(61431U);
                seasons[1].Ids.Tvdb.Should().Be(578373U);
                seasons[1].Ids.Tmdb.Should().Be(60524U);
                seasons[1].Ids.TvRage.Should().Be(36940U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.Shows.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.Seasons.Should().BeNull();

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var episodes = personalListItemsPostResponseNotFoundGroup.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);

                episodes[1].Should().NotBeNull();
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(73641U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63057U);
                episodes[1].Ids.TvRage.Should().Be(1065023912U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.Shows.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.Episodes.Should().BeNull();

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.People.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var people = personalListItemsPostResponseNotFoundGroup.People.ToArray();

                people[0].Should().NotBeNull();
                people[0].Ids.Should().NotBeNull();
                people[0].Ids.Trakt.Should().Be(297737U);
                people[0].Ids.Slug.Should().Be("bryan-cranston");
                people[0].Ids.Imdb.Should().Be("nm0186505");
                people[0].Ids.Tmdb.Should().Be(17419U);
                people[0].Ids.TvRage.Should().Be(1797U);

                people[1].Should().NotBeNull();
                people[1].Ids.Should().NotBeNull();
                people[1].Ids.Trakt.Should().Be(9486U);
                people[1].Ids.Slug.Should().Be("samuel-l-jackson");
                people[1].Ids.Imdb.Should().Be("nm0000168");
                people[1].Ids.Tmdb.Should().Be(2231U);
                people[1].Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().BeNull();

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Shows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var shows = personalListItemsPostResponseNotFoundGroup.Shows.ToArray();

                shows[0].Should().NotBeNull();
                shows[0].Ids.Should().NotBeNull();
                shows[0].Ids.Trakt.Should().Be(1390U);
                shows[0].Ids.Slug.Should().Be("game-of-thrones");
                shows[0].Ids.Tvdb.Should().Be(121361U);
                shows[0].Ids.Imdb.Should().Be("tt0944947");
                shows[0].Ids.Tmdb.Should().Be(1399U);
                shows[0].Ids.TvRage.Should().Be(24493U);

                shows[1].Should().NotBeNull();
                shows[1].Ids.Should().NotBeNull();
                shows[1].Ids.Trakt.Should().Be(60300U);
                shows[1].Ids.Slug.Should().Be("the-flash-2014");
                shows[1].Ids.Tvdb.Should().Be(279121U);
                shows[1].Ids.Imdb.Should().Be("tt3107288");
                shows[1].Ids.Tmdb.Should().Be(60735U);
                shows[1].Ids.TvRage.Should().Be(36939U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = personalListItemsPostResponseNotFoundGroup.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);

                seasons[1].Should().NotBeNull();
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(61431U);
                seasons[1].Ids.Tvdb.Should().Be(578373U);
                seasons[1].Ids.Tmdb.Should().Be(60524U);
                seasons[1].Ids.TvRage.Should().Be(36940U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var episodes = personalListItemsPostResponseNotFoundGroup.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);

                episodes[1].Should().NotBeNull();
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(73641U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63057U);
                episodes[1].Ids.TvRage.Should().Be(1065023912U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.People.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var people = personalListItemsPostResponseNotFoundGroup.People.ToArray();

                people[0].Should().NotBeNull();
                people[0].Ids.Should().NotBeNull();
                people[0].Ids.Trakt.Should().Be(297737U);
                people[0].Ids.Slug.Should().Be("bryan-cranston");
                people[0].Ids.Imdb.Should().Be("nm0186505");
                people[0].Ids.Tmdb.Should().Be(17419U);
                people[0].Ids.TvRage.Should().Be(1797U);

                people[1].Should().NotBeNull();
                people[1].Ids.Should().NotBeNull();
                people[1].Ids.Trakt.Should().Be(9486U);
                people[1].Ids.Slug.Should().Be("samuel-l-jackson");
                people[1].Ids.Imdb.Should().Be("nm0000168");
                people[1].Ids.Tmdb.Should().Be(2231U);
                people[1].Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var movies = personalListItemsPostResponseNotFoundGroup.Movies.ToArray();

                movies[0].Should().NotBeNull();
                movies[0].Ids.Should().NotBeNull();
                movies[0].Ids.Trakt.Should().Be(94024U);
                movies[0].Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movies[0].Ids.Imdb.Should().Be("tt2488496");
                movies[0].Ids.Tmdb.Should().Be(140607U);

                movies[1].Should().NotBeNull();
                movies[1].Ids.Should().NotBeNull();
                movies[1].Ids.Trakt.Should().Be(172687U);
                movies[1].Ids.Slug.Should().Be("king-arthur-legend-of-the-sword-2017");
                movies[1].Ids.Imdb.Should().Be("tt1972591");
                movies[1].Ids.Tmdb.Should().Be(274857U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Shows.Should().BeNull();

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = personalListItemsPostResponseNotFoundGroup.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);

                seasons[1].Should().NotBeNull();
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(61431U);
                seasons[1].Ids.Tvdb.Should().Be(578373U);
                seasons[1].Ids.Tmdb.Should().Be(60524U);
                seasons[1].Ids.TvRage.Should().Be(36940U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var episodes = personalListItemsPostResponseNotFoundGroup.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);

                episodes[1].Should().NotBeNull();
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(73641U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63057U);
                episodes[1].Ids.TvRage.Should().Be(1065023912U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.People.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var people = personalListItemsPostResponseNotFoundGroup.People.ToArray();

                people[0].Should().NotBeNull();
                people[0].Ids.Should().NotBeNull();
                people[0].Ids.Trakt.Should().Be(297737U);
                people[0].Ids.Slug.Should().Be("bryan-cranston");
                people[0].Ids.Imdb.Should().Be("nm0186505");
                people[0].Ids.Tmdb.Should().Be(17419U);
                people[0].Ids.TvRage.Should().Be(1797U);

                people[1].Should().NotBeNull();
                people[1].Ids.Should().NotBeNull();
                people[1].Ids.Trakt.Should().Be(9486U);
                people[1].Ids.Slug.Should().Be("samuel-l-jackson");
                people[1].Ids.Imdb.Should().Be("nm0000168");
                people[1].Ids.Tmdb.Should().Be(2231U);
                people[1].Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var movies = personalListItemsPostResponseNotFoundGroup.Movies.ToArray();

                movies[0].Should().NotBeNull();
                movies[0].Ids.Should().NotBeNull();
                movies[0].Ids.Trakt.Should().Be(94024U);
                movies[0].Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movies[0].Ids.Imdb.Should().Be("tt2488496");
                movies[0].Ids.Tmdb.Should().Be(140607U);

                movies[1].Should().NotBeNull();
                movies[1].Ids.Should().NotBeNull();
                movies[1].Ids.Trakt.Should().Be(172687U);
                movies[1].Ids.Slug.Should().Be("king-arthur-legend-of-the-sword-2017");
                movies[1].Ids.Imdb.Should().Be("tt1972591");
                movies[1].Ids.Tmdb.Should().Be(274857U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Shows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var shows = personalListItemsPostResponseNotFoundGroup.Shows.ToArray();

                shows[0].Should().NotBeNull();
                shows[0].Ids.Should().NotBeNull();
                shows[0].Ids.Trakt.Should().Be(1390U);
                shows[0].Ids.Slug.Should().Be("game-of-thrones");
                shows[0].Ids.Tvdb.Should().Be(121361U);
                shows[0].Ids.Imdb.Should().Be("tt0944947");
                shows[0].Ids.Tmdb.Should().Be(1399U);
                shows[0].Ids.TvRage.Should().Be(24493U);

                shows[1].Should().NotBeNull();
                shows[1].Ids.Should().NotBeNull();
                shows[1].Ids.Trakt.Should().Be(60300U);
                shows[1].Ids.Slug.Should().Be("the-flash-2014");
                shows[1].Ids.Tvdb.Should().Be(279121U);
                shows[1].Ids.Imdb.Should().Be("tt3107288");
                shows[1].Ids.Tmdb.Should().Be(60735U);
                shows[1].Ids.TvRage.Should().Be(36939U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Seasons.Should().BeNull();

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var episodes = personalListItemsPostResponseNotFoundGroup.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);

                episodes[1].Should().NotBeNull();
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(73641U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63057U);
                episodes[1].Ids.TvRage.Should().Be(1065023912U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.People.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var people = personalListItemsPostResponseNotFoundGroup.People.ToArray();

                people[0].Should().NotBeNull();
                people[0].Ids.Should().NotBeNull();
                people[0].Ids.Trakt.Should().Be(297737U);
                people[0].Ids.Slug.Should().Be("bryan-cranston");
                people[0].Ids.Imdb.Should().Be("nm0186505");
                people[0].Ids.Tmdb.Should().Be(17419U);
                people[0].Ids.TvRage.Should().Be(1797U);

                people[1].Should().NotBeNull();
                people[1].Ids.Should().NotBeNull();
                people[1].Ids.Trakt.Should().Be(9486U);
                people[1].Ids.Slug.Should().Be("samuel-l-jackson");
                people[1].Ids.Imdb.Should().Be("nm0000168");
                people[1].Ids.Tmdb.Should().Be(2231U);
                people[1].Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var movies = personalListItemsPostResponseNotFoundGroup.Movies.ToArray();

                movies[0].Should().NotBeNull();
                movies[0].Ids.Should().NotBeNull();
                movies[0].Ids.Trakt.Should().Be(94024U);
                movies[0].Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movies[0].Ids.Imdb.Should().Be("tt2488496");
                movies[0].Ids.Tmdb.Should().Be(140607U);

                movies[1].Should().NotBeNull();
                movies[1].Ids.Should().NotBeNull();
                movies[1].Ids.Trakt.Should().Be(172687U);
                movies[1].Ids.Slug.Should().Be("king-arthur-legend-of-the-sword-2017");
                movies[1].Ids.Imdb.Should().Be("tt1972591");
                movies[1].Ids.Tmdb.Should().Be(274857U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Shows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var shows = personalListItemsPostResponseNotFoundGroup.Shows.ToArray();

                shows[0].Should().NotBeNull();
                shows[0].Ids.Should().NotBeNull();
                shows[0].Ids.Trakt.Should().Be(1390U);
                shows[0].Ids.Slug.Should().Be("game-of-thrones");
                shows[0].Ids.Tvdb.Should().Be(121361U);
                shows[0].Ids.Imdb.Should().Be("tt0944947");
                shows[0].Ids.Tmdb.Should().Be(1399U);
                shows[0].Ids.TvRage.Should().Be(24493U);

                shows[1].Should().NotBeNull();
                shows[1].Ids.Should().NotBeNull();
                shows[1].Ids.Trakt.Should().Be(60300U);
                shows[1].Ids.Slug.Should().Be("the-flash-2014");
                shows[1].Ids.Tvdb.Should().Be(279121U);
                shows[1].Ids.Imdb.Should().Be("tt3107288");
                shows[1].Ids.Tmdb.Should().Be(60735U);
                shows[1].Ids.TvRage.Should().Be(36939U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = personalListItemsPostResponseNotFoundGroup.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);

                seasons[1].Should().NotBeNull();
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(61431U);
                seasons[1].Ids.Tvdb.Should().Be(578373U);
                seasons[1].Ids.Tmdb.Should().Be(60524U);
                seasons[1].Ids.TvRage.Should().Be(36940U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Episodes.Should().BeNull();

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.People.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var people = personalListItemsPostResponseNotFoundGroup.People.ToArray();

                people[0].Should().NotBeNull();
                people[0].Ids.Should().NotBeNull();
                people[0].Ids.Trakt.Should().Be(297737U);
                people[0].Ids.Slug.Should().Be("bryan-cranston");
                people[0].Ids.Imdb.Should().Be("nm0186505");
                people[0].Ids.Tmdb.Should().Be(17419U);
                people[0].Ids.TvRage.Should().Be(1797U);

                people[1].Should().NotBeNull();
                people[1].Ids.Should().NotBeNull();
                people[1].Ids.Trakt.Should().Be(9486U);
                people[1].Ids.Slug.Should().Be("samuel-l-jackson");
                people[1].Ids.Imdb.Should().Be("nm0000168");
                people[1].Ids.Tmdb.Should().Be(2231U);
                people[1].Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var movies = personalListItemsPostResponseNotFoundGroup.Movies.ToArray();

                movies[0].Should().NotBeNull();
                movies[0].Ids.Should().NotBeNull();
                movies[0].Ids.Trakt.Should().Be(94024U);
                movies[0].Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movies[0].Ids.Imdb.Should().Be("tt2488496");
                movies[0].Ids.Tmdb.Should().Be(140607U);

                movies[1].Should().NotBeNull();
                movies[1].Ids.Should().NotBeNull();
                movies[1].Ids.Trakt.Should().Be(172687U);
                movies[1].Ids.Slug.Should().Be("king-arthur-legend-of-the-sword-2017");
                movies[1].Ids.Imdb.Should().Be("tt1972591");
                movies[1].Ids.Tmdb.Should().Be(274857U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Shows.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var shows = personalListItemsPostResponseNotFoundGroup.Shows.ToArray();

                shows[0].Should().NotBeNull();
                shows[0].Ids.Should().NotBeNull();
                shows[0].Ids.Trakt.Should().Be(1390U);
                shows[0].Ids.Slug.Should().Be("game-of-thrones");
                shows[0].Ids.Tvdb.Should().Be(121361U);
                shows[0].Ids.Imdb.Should().Be("tt0944947");
                shows[0].Ids.Tmdb.Should().Be(1399U);
                shows[0].Ids.TvRage.Should().Be(24493U);

                shows[1].Should().NotBeNull();
                shows[1].Ids.Should().NotBeNull();
                shows[1].Ids.Trakt.Should().Be(60300U);
                shows[1].Ids.Slug.Should().Be("the-flash-2014");
                shows[1].Ids.Tvdb.Should().Be(279121U);
                shows[1].Ids.Imdb.Should().Be("tt3107288");
                shows[1].Ids.Tmdb.Should().Be(60735U);
                shows[1].Ids.TvRage.Should().Be(36939U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Seasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var seasons = personalListItemsPostResponseNotFoundGroup.Seasons.ToArray();

                seasons[0].Should().NotBeNull();
                seasons[0].Ids.Should().NotBeNull();
                seasons[0].Ids.Trakt.Should().Be(61430U);
                seasons[0].Ids.Tvdb.Should().Be(279121U);
                seasons[0].Ids.Tmdb.Should().Be(60523U);
                seasons[0].Ids.TvRage.Should().Be(36939U);

                seasons[1].Should().NotBeNull();
                seasons[1].Ids.Should().NotBeNull();
                seasons[1].Ids.Trakt.Should().Be(61431U);
                seasons[1].Ids.Tvdb.Should().Be(578373U);
                seasons[1].Ids.Tmdb.Should().Be(60524U);
                seasons[1].Ids.TvRage.Should().Be(36940U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var episodes = personalListItemsPostResponseNotFoundGroup.Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Ids.Should().NotBeNull();
                episodes[0].Ids.Trakt.Should().Be(73640U);
                episodes[0].Ids.Tvdb.Should().Be(3254641U);
                episodes[0].Ids.Imdb.Should().Be("tt1480055");
                episodes[0].Ids.Tmdb.Should().Be(63056U);
                episodes[0].Ids.TvRage.Should().Be(1065008299U);

                episodes[1].Should().NotBeNull();
                episodes[1].Ids.Should().NotBeNull();
                episodes[1].Ids.Trakt.Should().Be(73641U);
                episodes[1].Ids.Tvdb.Should().Be(3436411U);
                episodes[1].Ids.Imdb.Should().Be("tt1668746");
                episodes[1].Ids.Tmdb.Should().Be(63057U);
                episodes[1].Ids.TvRage.Should().Be(1065023912U);

                // --------------------------------------------------

                personalListItemsPostResponseNotFoundGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

                personalListItemsPostResponseNotFoundGroup.Should().NotBeNull();
                personalListItemsPostResponseNotFoundGroup.Movies.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.Shows.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.Seasons.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.Episodes.Should().BeNull();
                personalListItemsPostResponseNotFoundGroup.People.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();
            Func<Task<ITraktUserPersonalListItemsPostResponseNotFoundGroup>> personalListItemsPostResponseNotFoundGroup = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await personalListItemsPostResponseNotFoundGroup.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var personalListItemsPostResponseNotFoundGroup = await traktJsonReader.ReadObjectAsync(jsonReader);
                personalListItemsPostResponseNotFoundGroup.Should().BeNull();
            }
        }
    }
}
