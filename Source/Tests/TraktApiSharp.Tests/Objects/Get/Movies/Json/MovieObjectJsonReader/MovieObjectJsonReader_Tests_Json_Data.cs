namespace TraktApiSharp.Tests.Objects.Get.Movies.Json
{
    public partial class MovieObjectJsonReader_Tests
    {
        private const string MINIMAL_JSON_COMPLETE =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_1 =
            @"{
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_2 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_3 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015
              }";

        private const string MINIMAL_JSON_INCOMPLETE_4 =
            @"{
                ""title"": ""Star Wars: The Force Awakens""
              }";

        private const string MINIMAL_JSON_INCOMPLETE_5 =
            @"{
                ""year"": 2015
              }";

        private const string MINIMAL_JSON_INCOMPLETE_6 =
            @"{
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""ye"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_3 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""id"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_4 =
            @"{
                ""ti"": ""Star Wars: The Force Awakens"",
                ""ye"": 2015,
                ""id"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string FULL_JSON_COMPLETE =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_1 =
            @"{
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_2 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_3 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_4 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_5 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_6 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_7 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_8 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_9 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_10 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_11 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_12 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_13 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_14 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_15 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_16 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_17 =
            @"{
                ""title"": ""Star Wars: The Force Awakens""
              }";

        private const string FULL_JSON_INCOMPLETE_18 =
            @"{
                ""year"": 2015
              }";

        private const string FULL_JSON_INCOMPLETE_19 =
            @"{
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string FULL_JSON_INCOMPLETE_20 =
            @"{
                ""tagline"": ""Every generation has a story.""
              }";

        private const string FULL_JSON_INCOMPLETE_21 =
            @"{
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.""
              }";

        private const string FULL_JSON_INCOMPLETE_22 =
            @"{
                ""released"": ""2015-12-18""
              }";

        private const string FULL_JSON_INCOMPLETE_23 =
            @"{
                ""runtime"": 136
              }";

        private const string FULL_JSON_INCOMPLETE_24 =
            @"{
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U""
              }";

        private const string FULL_JSON_INCOMPLETE_25 =
            @"{
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii""
              }";

        private const string FULL_JSON_INCOMPLETE_26 =
            @"{
                ""rating"": 8.31988
              }";

        private const string FULL_JSON_INCOMPLETE_27 =
            @"{
                ""votes"": 9338
              }";

        private const string FULL_JSON_INCOMPLETE_28 =
            @"{
                ""updated_at"": ""2016-03-31T09:01:59Z""
              }";

        private const string FULL_JSON_INCOMPLETE_29 =
            @"{
                ""language"": ""en""
              }";

        private const string FULL_JSON_INCOMPLETE_30 =
            @"{
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_31 =
            @"{
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_32 =
            @"{
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""ye"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_3 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""id"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_4 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tl"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_5 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""ov"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_6 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""re"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_7 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""ru"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_8 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""tr"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_9 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""hp"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_10 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""ra"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_11 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""vo"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_12 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""ua"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_13 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""la"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_14 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""availtr"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_15 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""ge"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_16 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""cert"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_17 =
            @"{
                ""ti"": ""Star Wars: The Force Awakens"",
                ""ye"": 2015,
                ""id"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tl"": ""Every generation has a story."",
                ""ov"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""re"": ""2015-12-18"",
                ""ru"": 136,
                ""tr"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""hp"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""ra"": 8.31988,
                ""vo"": 9338,
                ""ua"": ""2016-03-31T09:01:59Z"",
                ""la"": ""en"",
                ""availtr"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""ge"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""cert"": ""PG-13""
              }";
    }
}
