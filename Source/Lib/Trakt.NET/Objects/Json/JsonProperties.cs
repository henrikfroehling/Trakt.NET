namespace TraktNet.Objects.Json
{
    internal static class JsonProperties
    {
        // authentication
        internal const string AUTHORIZATION_PROPERTY_NAME_ACCESS_TOKEN = "access_token";
        internal const string AUTHORIZATION_PROPERTY_NAME_REFRESH_TOKEN = "refresh_token";
        internal const string AUTHORIZATION_PROPERTY_NAME_SCOPE = "scope";
        internal const string AUTHORIZATION_PROPERTY_NAME_EXPIRES_IN = "expires_in";
        internal const string AUTHORIZATION_PROPERTY_NAME_TOKEN_TYPE = "token_type";
        internal const string AUTHORIZATION_PROPERTY_NAME_CREATED_AT = "created_at";
        internal const string AUTHORIZATION_PROPERTY_NAME_IGNORE_EXPIRATION = "ignore_expiration";

        internal const string DEVICE_PROPERTY_NAME_DEVICE_CODE = "device_code";
        internal const string DEVICE_PROPERTY_NAME_USER_CODE = "user_code";
        internal const string DEVICE_PROPERTY_NAME_VERIFICATION_URL = "verification_url";
        internal const string DEVICE_PROPERTY_NAME_EXPIRES_IN = "expires_in";
        internal const string DEVICE_PROPERTY_NAME_INTERVAL = "interval";

        // basic
        internal const string CAST_AND_CREW_PROPERTY_NAME_CAST = "cast";
        internal const string CAST_AND_CREW_PROPERTY_NAME_CREW = "crew";

        internal const string CAST_MEMBER_PROPERTY_NAME_CHARACTER = "character";
        internal const string CAST_MEMBER_PROPERTY_NAME_CHARACTERS = "characters";
        internal const string CAST_MEMBER_PROPERTY_NAME_PERSON = "person";

        internal const string CERTIFICATION_PROPERTY_NAME_NAME = "name";
        internal const string CERTIFICATION_PROPERTY_NAME_SLUG = "slug";
        internal const string CERTIFICATION_PROPERTY_NAME_DESCRIPTION = "description";

        internal const string CERTIFICATIONS_PROPERTY_NAME_US = "us";

        internal const string COMMENT_PROPERTY_NAME_ID = "id";
        internal const string COMMENT_PROPERTY_NAME_PARENT_ID = "parent_id";
        internal const string COMMENT_PROPERTY_NAME_CREATED_AT = "created_at";
        internal const string COMMENT_PROPERTY_NAME_UPDATED_AT = "updated_at";
        internal const string COMMENT_PROPERTY_NAME_COMMENT = "comment";
        internal const string COMMENT_PROPERTY_NAME_SPOILER = "spoiler";
        internal const string COMMENT_PROPERTY_NAME_REVIEW = "review";
        internal const string COMMENT_PROPERTY_NAME_REPLIES = "replies";
        internal const string COMMENT_PROPERTY_NAME_LIKES = "likes";
        internal const string COMMENT_PROPERTY_NAME_USER_RATING = "user_rating";
        internal const string COMMENT_PROPERTY_NAME_USER = "user";

        internal const string COMMENT_ITEM_PROPERTY_NAME_TYPE = "type";
        internal const string COMMENT_ITEM_PROPERTY_NAME_MOVIE = "movie";
        internal const string COMMENT_ITEM_PROPERTY_NAME_SHOW = "show";
        internal const string COMMENT_ITEM_PROPERTY_NAME_SEASON = "season";
        internal const string COMMENT_ITEM_PROPERTY_NAME_EPISODE = "episode";
        internal const string COMMENT_ITEM_PROPERTY_NAME_LIST = "list";

        internal const string COMMENT_LIKE_PROPERTY_NAME_LIKED_AT = "liked_at";
        internal const string COMMENT_LIKE_PROPERTY_NAME_USER = "user";

        internal const string COUNTRY_PROPERTY_NAME_NAME = "name";
        internal const string COUNTRY_PROPERTY_NAME_CODE = "code";

        internal const string CREW_MEMBER_PROPERTY_NAME_JOB = "job";
        internal const string CREW_MEMBER_PROPERTY_NAME_JOBS = "jobs";
        internal const string CREW_MEMBER_PROPERTY_NAME_PERSON = "person";

        internal const string CREW_PROPERTY_NAME_PRODUCTION = "production";
        internal const string CREW_PROPERTY_NAME_ART = "art";
        internal const string CREW_PROPERTY_NAME_CREW = "crew";
        internal const string CREW_PROPERTY_NAME_COSTUME_AND_MAKE_UP = "costume & make-up";
        internal const string CREW_PROPERTY_NAME_DIRECTING = "directing";
        internal const string CREW_PROPERTY_NAME_WRITING = "writing";
        internal const string CREW_PROPERTY_NAME_SOUND = "sound";
        internal const string CREW_PROPERTY_NAME_CAMERA = "camera";
        internal const string CREW_PROPERTY_NAME_LIGHTING = "lighting";
        internal const string CREW_PROPERTY_NAME_VISUAL_EFFECTS = "visual effects";
        internal const string CREW_PROPERTY_NAME_EDITING = "editing";

        internal const string ERROR_PROPERTY_NAME_ERROR = "error";
        internal const string ERROR_PROPERTY_NAME_ERROR_DESCRIPTION = "error_description";

        internal const string GENRE_PROPERTY_NAME_NAME = "name";
        internal const string GENRE_PROPERTY_NAME_SLUG = "slug";

        internal const string IDS_PROPERTY_NAME_TRAKT = "trakt";
        internal const string IDS_PROPERTY_NAME_SLUG = "slug";
        internal const string IDS_PROPERTY_NAME_TVDB = "tvdb";
        internal const string IDS_PROPERTY_NAME_IMDB = "imdb";
        internal const string IDS_PROPERTY_NAME_TMDB = "tmdb";
        internal const string IDS_PROPERTY_NAME_TVRAGE = "tvrage";

        internal const string IMAGE_PROPERTY_NAME_FULL = "full";

        internal const string LANGUAGE_PROPERTY_NAME_NAME = "name";
        internal const string LANGUAGE_PROPERTY_NAME_CODE = "code";

        internal const string METADATA_PROPERTY_NAME_MEDIA_TYPE = "media_type";
        internal const string METADATA_PROPERTY_NAME_RESOLUTION = "resolution";
        internal const string METADATA_PROPERTY_NAME_AUDIO = "audio";
        internal const string METADATA_PROPERTY_NAME_AUDIO_CHANNELS = "audio_channels";
        internal const string METADATA_PROPERTY_NAME_3D = "3d";
        internal const string METADATA_PROPERTY_NAME_HDR = "hdr";

        internal const string NETWORK_PROPERTY_NAME_NAME = "name";

        internal const string RATING_PROPERTY_NAME_RATING = "rating";
        internal const string RATING_PROPERTY_NAME_VOTES = "votes";
        internal const string RATING_PROPERTY_NAME_DISTRIBUTION = "distribution";

        internal const string SEARCH_RESULT_PROPERTY_NAME_TYPE = "type";
        internal const string SEARCH_RESULT_PROPERTY_NAME_SCORE = "score";
        internal const string SEARCH_RESULT_PROPERTY_NAME_MOVIE = "movie";
        internal const string SEARCH_RESULT_PROPERTY_NAME_SHOW = "show";
        internal const string SEARCH_RESULT_PROPERTY_NAME_EPISODE = "episode";
        internal const string SEARCH_RESULT_PROPERTY_NAME_PERSON = "person";
        internal const string SEARCH_RESULT_PROPERTY_NAME_LIST = "list";

        internal const string SHARING_PROPERTY_NAME_TWITTER = "twitter";
        internal const string SHARING_PROPERTY_NAME_GOOGLE = "google";
        internal const string SHARING_PROPERTY_NAME_TUMBLR = "tumblr";
        internal const string SHARING_PROPERTY_NAME_MEDIUM = "medium";
        internal const string SHARING_PROPERTY_NAME_SLACK = "slack";

        internal const string STATISTICS_PROPERTY_NAME_WATCHERS = "watchers";
        internal const string STATISTICS_PROPERTY_NAME_PLAYS = "plays";
        internal const string STATISTICS_PROPERTY_NAME_COLLECTORS = "collectors";
        internal const string STATISTICS_PROPERTY_NAME_COLLECTED_EPISODES = "collected_episodes";
        internal const string STATISTICS_PROPERTY_NAME_COMMENTS = "comments";
        internal const string STATISTICS_PROPERTY_NAME_LISTS = "lists";
        internal const string STATISTICS_PROPERTY_NAME_VOTES = "votes";

        // calendars
        internal const string CALENDAR_MOVIE_PROPERTY_NAME_RELEASED = "released";
        internal const string CALENDAR_MOVIE_PROPERTY_NAME_MOVIE = "movie";

        internal const string CALENDAR_SHOW_PROPERTY_NAME_FIRST_AIRED = "first_aired";
        internal const string CALENDAR_SHOW_PROPERTY_NAME_SHOW = "show";
        internal const string CALENDAR_SHOW_PROPERTY_NAME_EPISODE = "episode";

        // collections
        internal const string COLLECTION_MOVIE_PROPERTY_NAME_COLLECTED_AT = "collected_at";
        internal const string COLLECTION_MOVIE_PROPERTY_NAME_UPDATED_AT = "updated_at";
        internal const string COLLECTION_MOVIE_PROPERTY_NAME_MOVIE = "movie";
        internal const string COLLECTION_MOVIE_PROPERTY_NAME_METADATA = "metadata";

        internal const string COLLECTION_SHOW_PROPERTY_NAME_LAST_COLLECTED_AT = "last_collected_at";
        internal const string COLLECTION_SHOW_PROPERTY_NAME_SHOW = "show";
        internal const string COLLECTION_SHOW_PROPERTY_NAME_SEASONS = "seasons";

        internal const string COLLECTION_SHOW_SEASON_PROPERTY_NAME_NUMBER = "number";
        internal const string COLLECTION_SHOW_SEASON_PROPERTY_NAME_EPISODES = "episodes";

        internal const string COLLECTION_SHOW_EPISODE_PROPERTY_NAME_NUMBER = "number";
        internal const string COLLECTION_SHOW_EPISODE_PROPERTY_NAME_COLLECTED_AT = "collected_at";
        internal const string COLLECTION_SHOW_EPISODE_PROPERTY_NAME_METADATA = "metadata";

        // episodes
        internal const string EPISODE_COLLECTION_PROGRESS_PROPERTY_NAME_NUMBER = "number";
        internal const string EPISODE_COLLECTION_PROGRESS_PROPERTY_NAME_COMPLETED = "completed";
        internal const string EPISODE_COLLECTION_PROGRESS_PROPERTY_NAME_COLLECTED_AT = "collected_at";

        internal const string EPISODE_IDS_PROPERTY_NAME_TRAKT = "trakt";
        internal const string EPISODE_IDS_PROPERTY_NAME_TVDB = "tvdb";
        internal const string EPISODE_IDS_PROPERTY_NAME_IMDB = "imdb";
        internal const string EPISODE_IDS_PROPERTY_NAME_TMDB = "tmdb";
        internal const string EPISODE_IDS_PROPERTY_NAME_TVRAGE = "tvrage";

        internal const string EPISODE_PROPERTY_NAME_SEASON_NUMBER = "season";
        internal const string EPISODE_PROPERTY_NAME_NUMBER = "number";
        internal const string EPISODE_PROPERTY_NAME_TITLE = "title";
        internal const string EPISODE_PROPERTY_NAME_IDS = "ids";
        internal const string EPISODE_PROPERTY_NAME_NUMBER_ABSOLUTE = "number_abs";
        internal const string EPISODE_PROPERTY_NAME_OVERVIEW = "overview";
        internal const string EPISODE_PROPERTY_NAME_RUNTIME = "runtime";
        internal const string EPISODE_PROPERTY_NAME_RATING = "rating";
        internal const string EPISODE_PROPERTY_NAME_VOTES = "votes";
        internal const string EPISODE_PROPERTY_NAME_FIRST_AIRED = "first_aired";
        internal const string EPISODE_PROPERTY_NAME_UPDATED_AT = "updated_at";
        internal const string EPISODE_PROPERTY_NAME_AVAILABLE_TRANSLATIONS = "available_translations";
        internal const string EPISODE_PROPERTY_NAME_TRANSLATIONS = "translations";
        internal const string EPISODE_PROPERTY_NAME_COMMENT_COUNT = "comment_count";

        internal const string EPISODE_TRANSLATION_PROPERTY_NAME_TITLE = "title";
        internal const string EPISODE_TRANSLATION_PROPERTY_NAME_OVERVIEW = "overview";
        internal const string EPISODE_TRANSLATION_PROPERTY_NAME_LANGUAGE_CODE = "language";

        internal const string EPISODE_WATCHED_PROGRESS_PROPERTY_NAME_NUMBER = "number";
        internal const string EPISODE_WATCHED_PROGRESS_PROPERTY_NAME_COMPLETED = "completed";
        internal const string EPISODE_WATCHED_PROGRESS_PROPERTY_NAME_LAST_WATCHED_AT = "last_watched_at";

        // history
        internal const string HISTORY_ITEM_PROPERTY_NAME_ID = "id";
        internal const string HISTORY_ITEM_PROPERTY_NAME_WATCHED_AT = "watched_at";
        internal const string HISTORY_ITEM_PROPERTY_NAME_ACTION = "action";
        internal const string HISTORY_ITEM_PROPERTY_NAME_TYPE = "type";
        internal const string HISTORY_ITEM_PROPERTY_NAME_MOVIE = "movie";
        internal const string HISTORY_ITEM_PROPERTY_NAME_SHOW = "show";
        internal const string HISTORY_ITEM_PROPERTY_NAME_SEASON = "season";
        internal const string HISTORY_ITEM_PROPERTY_NAME_EPISODE = "episode";

        // movies
        internal const string BOX_OFFICE_MOVIE_PROPERTY_NAME_REVENUE = "revenue";
        internal const string BOX_OFFICE_MOVIE_PROPERTY_NAME_MOVIE = "movie";

        internal const string MOST_ANTICIPATED_MOVIE_PROPERTY_NAME_LIST_COUNT = "list_count";
        internal const string MOST_ANTICIPATED_MOVIE_PROPERTY_NAME_MOVIE = "movie";

        internal const string MOST_PWC_MOVIE_PROPERTY_NAME_WATCHER_COUNT = "watcher_count";
        internal const string MOST_PWC_MOVIE_PROPERTY_NAME_PLAY_COUNT = "play_count";
        internal const string MOST_PWC_MOVIE_PROPERTY_NAME_COLLECTED_COUNT = "collected_count";
        internal const string MOST_PWC_MOVIE_PROPERTY_NAME_MOVIE = "movie";

        internal const string MOVIE_ALIAS_PROPERTY_NAME_TITLE = "title";
        internal const string MOVIE_ALIAS_PROPERTY_NAME_COUNTRY = "country";

        internal const string MOVIE_IDS_PROPERTY_NAME_TRAKT = "trakt";
        internal const string MOVIE_IDS_PROPERTY_NAME_SLUG = "slug";
        internal const string MOVIE_IDS_PROPERTY_NAME_IMDB = "imdb";
        internal const string MOVIE_IDS_PROPERTY_NAME_TMDB = "tmdb";

        internal const string MOVIE_PROPERTY_NAME_TITLE = "title";
        internal const string MOVIE_PROPERTY_NAME_YEAR = "year";
        internal const string MOVIE_PROPERTY_NAME_IDS = "ids";
        internal const string MOVIE_PROPERTY_NAME_TAGLINE = "tagline";
        internal const string MOVIE_PROPERTY_NAME_OVERVIEW = "overview";
        internal const string MOVIE_PROPERTY_NAME_RELEASED = "released";
        internal const string MOVIE_PROPERTY_NAME_RUNTIME = "runtime";
        internal const string MOVIE_PROPERTY_NAME_TRAILER = "trailer";
        internal const string MOVIE_PROPERTY_NAME_HOMEPAGE = "homepage";
        internal const string MOVIE_PROPERTY_NAME_RATING = "rating";
        internal const string MOVIE_PROPERTY_NAME_VOTES = "votes";
        internal const string MOVIE_PROPERTY_NAME_UPDATED_AT = "updated_at";
        internal const string MOVIE_PROPERTY_NAME_LANGUAGE = "language";
        internal const string MOVIE_PROPERTY_NAME_AVAILABLE_TRANSLATIONS = "available_translations";
        internal const string MOVIE_PROPERTY_NAME_GENRES = "genres";
        internal const string MOVIE_PROPERTY_NAME_CERTIFICATION = "certification";
        internal const string MOVIE_PROPERTY_NAME_COUNTRY = "country";
        internal const string MOVIE_PROPERTY_NAME_COMMENT_COUNT = "comment_count";

        internal const string MOVIE_RELEASE_PROPERTY_NAME_COUNTRY = "country";
        internal const string MOVIE_RELEASE_PROPERTY_NAME_CERTIFICATION = "certification";
        internal const string MOVIE_RELEASE_PROPERTY_NAME_RELEASE_DATE = "release_date";
        internal const string MOVIE_RELEASE_PROPERTY_NAME_RELEASE_TYPE = "release_type";
        internal const string MOVIE_RELEASE_PROPERTY_NAME_NOTE = "note";

        internal const string MOVIE_TRANSLATION_PROPERTY_NAME_TITLE = "title";
        internal const string MOVIE_TRANSLATION_PROPERTY_NAME_OVERVIEW = "overview";
        internal const string MOVIE_TRANSLATION_PROPERTY_NAME_LANGUAGE_CODE = "language";
        internal const string MOVIE_TRANSLATION_PROPERTY_NAME_TAGLINE = "tagline";

        internal const string RECENTLY_UPDATED_MOVIE_PROPERTY_NAME_UPDATED_AT = "updated_at";
        internal const string RECENTLY_UPDATED_MOVIE_PROPERTY_NAME_MOVIE = "movie";

        internal const string TRENDING_MOVIE_PROPERTY_NAME_WATCHERS = "watchers";
        internal const string TRENDING_MOVIE_PROPERTY_NAME_MOVIE = "movie";

        // people
        internal const string PERSON_IDS_PROPERTY_NAME_TRAKT = "trakt";
        internal const string PERSON_IDS_PROPERTY_NAME_SLUG = "slug";
        internal const string PERSON_IDS_PROPERTY_NAME_IMDB = "imdb";
        internal const string PERSON_IDS_PROPERTY_NAME_TMDB = "tmdb";
        internal const string PERSON_IDS_PROPERTY_NAME_TVRAGE = "tvrage";

        internal const string PERSON_PROPERTY_NAME_NAME = "name";
        internal const string PERSON_PROPERTY_NAME_IDS = "ids";
        internal const string PERSON_PROPERTY_NAME_BIOGRAPHY = "biography";
        internal const string PERSON_PROPERTY_NAME_BIRTHDAY = "birthday";
        internal const string PERSON_PROPERTY_NAME_DEATH = "death";
        internal const string PERSON_PROPERTY_NAME_BIRTHPLACE = "birthplace";
        internal const string PERSON_PROPERTY_NAME_HOMEPAGE = "homepage";

        // people credits
        internal const string PERSON_MOVIE_CREDITS_CAST_ITEM_PROPERTY_NAME_CHARACTER = "character";
        internal const string PERSON_MOVIE_CREDITS_CAST_ITEM_PROPERTY_NAME_CHARACTERS = "characters";
        internal const string PERSON_MOVIE_CREDITS_CAST_ITEM_PROPERTY_NAME_MOVIE = "movie";

        internal const string PERSON_MOVIE_CREDITS_CREW_ITEM_PROPERTY_NAME_JOB = "job";
        internal const string PERSON_MOVIE_CREDITS_CREW_ITEM_PROPERTY_NAME_JOBS = "jobs";
        internal const string PERSON_MOVIE_CREDITS_CREW_ITEM_PROPERTY_NAME_MOVIE = "movie";

        internal const string PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_PRODUCTION = "production";
        internal const string PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_ART = "art";
        internal const string PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_CREW = "crew";
        internal const string PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_COSTUME_AND_MAKE_UP = "costume & make-up";
        internal const string PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_DIRECTING = "directing";
        internal const string PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_WRITING = "writing";
        internal const string PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_SOUND = "sound";
        internal const string PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_CAMERA = "camera";
        internal const string PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_LIGHTING = "lighting";
        internal const string PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_VISUAL_EFFECTS = "visual effects";
        internal const string PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_EDITING = "editing";

        internal const string PERSON_MOVIE_CREDITS_PROPERTY_NAME_CAST = "cast";
        internal const string PERSON_MOVIE_CREDITS_PROPERTY_NAME_CREW = "crew";

        internal const string PERSON_SHOW_CREDITS_CAST_ITEM_PROPERTY_NAME_CHARACTER = "character";
        internal const string PERSON_SHOW_CREDITS_CAST_ITEM_PROPERTY_NAME_CHARACTERS = "characters";
        internal const string PERSON_SHOW_CREDITS_CAST_ITEM_PROPERTY_NAME_EPISODE_COUNT = "episode_count";
        internal const string PERSON_SHOW_CREDITS_CAST_ITEM_PROPERTY_NAME_SERIES_REGULAR = "series_regular";
        internal const string PERSON_SHOW_CREDITS_CAST_ITEM_PROPERTY_NAME_SHOW = "show";

        internal const string PERSON_SHOW_CREDITS_CREW_ITEM_PROPERTY_NAME_JOB = "job";
        internal const string PERSON_SHOW_CREDITS_CREW_ITEM_PROPERTY_NAME_JOBS = "jobs";
        internal const string PERSON_SHOW_CREDITS_CREW_ITEM_PROPERTY_NAME_EPISODE_COUNT = "episode_count";
        internal const string PERSON_SHOW_CREDITS_CREW_ITEM_PROPERTY_NAME_SHOW = "show";

        internal const string PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_PRODUCTION = "production";
        internal const string PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_ART = "art";
        internal const string PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_CREW = "crew";
        internal const string PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_COSTUME_AND_MAKE_UP = "costume & make-up";
        internal const string PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_DIRECTING = "directing";
        internal const string PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_WRITING = "writing";
        internal const string PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_SOUND = "sound";
        internal const string PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_CAMERA = "camera";
        internal const string PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_LIGHTING = "lighting";
        internal const string PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_VISUAL_EFFECTS = "visual effects";
        internal const string PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_EDITING = "editing";

        internal const string PERSON_SHOW_CREDITS_PROPERTY_NAME_CAST = "cast";
        internal const string PERSON_SHOW_CREDITS_PROPERTY_NAME_CREW = "crew";

        // ratings
        internal const string RATINGS_ITEM_PROPERTY_NAME_RATED_AT = "rated_at";
        internal const string RATINGS_ITEM_PROPERTY_NAME_RATING = "rating";
        internal const string RATINGS_ITEM_PROPERTY_NAME_TYPE = "type";
        internal const string RATINGS_ITEM_PROPERTY_NAME_MOVIE = "movie";
        internal const string RATINGS_ITEM_PROPERTY_NAME_SHOW = "show";
        internal const string RATINGS_ITEM_PROPERTY_NAME_SEASON = "season";
        internal const string RATINGS_ITEM_PROPERTY_NAME_EPISODE = "episode";

        // seasons
        internal const string SEASON_COLLECTION_PROGRESS_PROPERTY_NAME_NUMBER = "number";
        internal const string SEASON_COLLECTION_PROGRESS_PROPERTY_NAME_AIRED = "aired";
        internal const string SEASON_COLLECTION_PROGRESS_PROPERTY_NAME_COMPLETED = "completed";
        internal const string SEASON_COLLECTION_PROGRESS_PROPERTY_NAME_EPISODES = "episodes";

        internal const string SEASON_IDS_PROPERTY_NAME_TRAKT = "trakt";
        internal const string SEASON_IDS_PROPERTY_NAME_TVDB = "tvdb";
        internal const string SEASON_IDS_PROPERTY_NAME_TMDB = "tmdb";
        internal const string SEASON_IDS_PROPERTY_NAME_TVRAGE = "tvrage";

        internal const string SEASON_PROPERTY_NAME_NUMBER = "number";
        internal const string SEASON_PROPERTY_NAME_TITLE = "title";
        internal const string SEASON_PROPERTY_NAME_IDS = "ids";
        internal const string SEASON_PROPERTY_NAME_RATING = "rating";
        internal const string SEASON_PROPERTY_NAME_VOTES = "votes";
        internal const string SEASON_PROPERTY_NAME_EPISODE_COUNT = "episode_count";
        internal const string SEASON_PROPERTY_NAME_AIRED_EPISODES = "aired_episodes";
        internal const string SEASON_PROPERTY_NAME_OVERVIEW = "overview";
        internal const string SEASON_PROPERTY_NAME_FIRST_AIRED = "first_aired";
        internal const string SEASON_PROPERTY_NAME_NETWORK = "network";
        internal const string SEASON_PROPERTY_NAME_EPISODES = "episodes";
        internal const string SEASON_PROPERTY_NAME_COMMENT_COUNT = "comment_count";

        internal const string SEASON_WATCHED_PROGRESS_PROPERTY_NAME_NUMBER = "number";
        internal const string SEASON_WATCHED_PROGRESS_PROPERTY_NAME_AIRED = "aired";
        internal const string SEASON_WATCHED_PROGRESS_PROPERTY_NAME_COMPLETED = "completed";
        internal const string SEASON_WATCHED_PROGRESS_PROPERTY_NAME_EPISODES = "episodes";

        // shows
        internal const string MOST_ANTICIPATED_SHOW_PROPERTY_NAME_LIST_COUNT = "list_count";
        internal const string MOST_ANTICIPATED_SHOW_PROPERTY_NAME_SHOW = "show";

        internal const string MOST_PWC_SHOW_PROPERTY_NAME_WATCHER_COUNT = "watcher_count";
        internal const string MOST_PWC_SHOW_PROPERTY_NAME_PLAY_COUNT = "play_count";
        internal const string MOST_PWC_SHOW_PROPERTY_NAME_COLLECTED_COUNT = "collected_count";
        internal const string MOST_PWC_SHOW_PROPERTY_NAME_COLLECTOR_COUNT = "collector_count";
        internal const string MOST_PWC_SHOW_PROPERTY_NAME_SHOW = "show";

        internal const string RECENTLY_UPDATED_SHOW_PROPERTY_NAME_UPDATED_AT = "updated_at";
        internal const string RECENTLY_UPDATED_SHOW_PROPERTY_NAME_SHOW = "show";

        internal const string SHOW_AIRS_PROPERTY_NAME_DAY = "day";
        internal const string SHOW_AIRS_PROPERTY_NAME_TIME = "time";
        internal const string SHOW_AIRS_PROPERTY_NAME_TIMEZONE = "timezone";

        internal const string SHOW_ALIAS_PROPERTY_NAME_TITLE = "title";
        internal const string SHOW_ALIAS_PROPERTY_NAME_COUNTRY = "country";

        internal const string SHOW_COLLECTION_PROGRESS_PROPERTY_NAME_AIRED = "aired";
        internal const string SHOW_COLLECTION_PROGRESS_PROPERTY_NAME_COMPLETED = "completed";
        internal const string SHOW_COLLECTION_PROGRESS_PROPERTY_NAME_LAST_COLLECTED_AT = "last_collected_at";
        internal const string SHOW_COLLECTION_PROGRESS_PROPERTY_NAME_SEASONS = "seasons";
        internal const string SHOW_COLLECTION_PROGRESS_PROPERTY_NAME_HIDDEN_SEASONS = "hidden_seasons";
        internal const string SHOW_COLLECTION_PROGRESS_PROPERTY_NAME_NEXT_EPISODE = "next_episode";
        internal const string SHOW_COLLECTION_PROGRESS_PROPERTY_NAME_LAST_EPISODE = "last_episode";

        internal const string SHOW_IDS_PROPERTY_NAME_TRAKT = "trakt";
        internal const string SHOW_IDS_PROPERTY_NAME_SLUG = "slug";
        internal const string SHOW_IDS_PROPERTY_NAME_TVDB = "tvdb";
        internal const string SHOW_IDS_PROPERTY_NAME_IMDB = "imdb";
        internal const string SHOW_IDS_PROPERTY_NAME_TMDB = "tmdb";
        internal const string SHOW_IDS_PROPERTY_NAME_TVRAGE = "tvrage";

        internal const string SHOW_PROPERTY_NAME_TITLE = "title";
        internal const string SHOW_PROPERTY_NAME_YEAR = "year";
        internal const string SHOW_PROPERTY_NAME_IDS = "ids";
        internal const string SHOW_PROPERTY_NAME_OVERVIEW = "overview";
        internal const string SHOW_PROPERTY_NAME_FIRST_AIRED = "first_aired";
        internal const string SHOW_PROPERTY_NAME_AIRS = "airs";
        internal const string SHOW_PROPERTY_NAME_RUNTIME = "runtime";
        internal const string SHOW_PROPERTY_NAME_CERTIFICATION = "certification";
        internal const string SHOW_PROPERTY_NAME_NETWORK = "network";
        internal const string SHOW_PROPERTY_NAME_COUNTRY = "country";
        internal const string SHOW_PROPERTY_NAME_TRAILER = "trailer";
        internal const string SHOW_PROPERTY_NAME_HOMEPAGE = "homepage";
        internal const string SHOW_PROPERTY_NAME_STATUS = "status";
        internal const string SHOW_PROPERTY_NAME_RATING = "rating";
        internal const string SHOW_PROPERTY_NAME_VOTES = "votes";
        internal const string SHOW_PROPERTY_NAME_UPDATED_AT = "updated_at";
        internal const string SHOW_PROPERTY_NAME_LANGUAGE = "language";
        internal const string SHOW_PROPERTY_NAME_AVAILABLE_TRANSLATIONS = "available_translations";
        internal const string SHOW_PROPERTY_NAME_GENRES = "genres";
        internal const string SHOW_PROPERTY_NAME_AIRED_EPISODES = "aired_episodes";
        internal const string SHOW_PROPERTY_NAME_SEASONS = "seasons";
        internal const string SHOW_PROPERTY_NAME_COMMENT_COUNT = "comment_count";

        internal const string SHOW_TRANSLATION_PROPERTY_NAME_TITLE = "title";
        internal const string SHOW_TRANSLATION_PROPERTY_NAME_OVERVIEW = "overview";
        internal const string SHOW_TRANSLATION_PROPERTY_NAME_LANGUAGE_CODE = "language";

        internal const string SHOW_WATCHED_PROGRESS_PROPERTY_NAME_AIRED = "aired";
        internal const string SHOW_WATCHED_PROGRESS_PROPERTY_NAME_COMPLETED = "completed";
        internal const string SHOW_WATCHED_PROGRESS_PROPERTY_NAME_LAST_WATCHED_AT = "last_watched_at";
        internal const string SHOW_WATCHED_PROGRESS_PROPERTY_NAME_SEASONS = "seasons";
        internal const string SHOW_WATCHED_PROGRESS_PROPERTY_NAME_HIDDEN_SEASONS = "hidden_seasons";
        internal const string SHOW_WATCHED_PROGRESS_PROPERTY_NAME_NEXT_EPISODE = "next_episode";
        internal const string SHOW_WATCHED_PROGRESS_PROPERTY_NAME_LAST_EPISODE = "last_episode";
        internal const string SHOW_WATCHED_PROGRESS_PROPERTY_NAME_RESET_AT = "reset_at";

        internal const string SHOW_CAST_MEMBER_PROPERTY_NAME_EPISODE_COUNT = "episode_count";

        internal const string SHOW_CREW_MEMBER_PROPERTY_NAME_EPISODE_COUNT = "episode_count";

        internal const string TRENDING_SHOW_PROPERTY_NAME_WATCHERS = "watchers";
        internal const string TRENDING_SHOW_PROPERTY_NAME_SHOW = "show";

        // syncs activities
        internal const string SYNC_COMMENTS_LAST_ACTIVITIES_PROPERTY_NAME_LIKED_AT = "liked_at";

        internal const string SYNC_EPISODES_LAST_ACTIVITIES_PROPERTY_NAME_WATCHED_AT = "watched_at";
        internal const string SYNC_EPISODES_LAST_ACTIVITIES_PROPERTY_NAME_COLLECTED_AT = "collected_at";
        internal const string SYNC_EPISODES_LAST_ACTIVITIES_PROPERTY_NAME_RATED_AT = "rated_at";
        internal const string SYNC_EPISODES_LAST_ACTIVITIES_PROPERTY_NAME_WATCHLISTED_AT = "watchlisted_at";
        internal const string SYNC_EPISODES_LAST_ACTIVITIES_PROPERTY_NAME_COMMENTED_AT = "commented_at";
        internal const string SYNC_EPISODES_LAST_ACTIVITIES_PROPERTY_NAME_PAUSED_AT = "paused_at";

        internal const string SYNC_LAST_ACTIVITIES_PROPERTY_NAME_ALL = "all";
        internal const string SYNC_LAST_ACTIVITIES_PROPERTY_NAME_MOVIES = "movies";
        internal const string SYNC_LAST_ACTIVITIES_PROPERTY_NAME_SHOWS = "shows";
        internal const string SYNC_LAST_ACTIVITIES_PROPERTY_NAME_SEASONS = "seasons";
        internal const string SYNC_LAST_ACTIVITIES_PROPERTY_NAME_EPISODES = "episodes";
        internal const string SYNC_LAST_ACTIVITIES_PROPERTY_NAME_COMMENTS = "comments";
        internal const string SYNC_LAST_ACTIVITIES_PROPERTY_NAME_LISTS = "lists";

        internal const string SYNC_LISTS_LAST_ACTIVITIES_PROPERTY_NAME_LIKED_AT = "liked_at";
        internal const string SYNC_LISTS_LAST_ACTIVITIES_PROPERTY_NAME_UPDATED_AT = "updated_at";
        internal const string SYNC_LISTS_LAST_ACTIVITIES_PROPERTY_NAME_COMMENTED_AT = "commented_at";

        internal const string SYNC_MOVIES_LAST_ACTIVITIES_PROPERTY_NAME_WATCHED_AT = "watched_at";
        internal const string SYNC_MOVIES_LAST_ACTIVITIES_PROPERTY_NAME_COLLECTED_AT = "collected_at";
        internal const string SYNC_MOVIES_LAST_ACTIVITIES_PROPERTY_NAME_RATED_AT = "rated_at";
        internal const string SYNC_MOVIES_LAST_ACTIVITIES_PROPERTY_NAME_WATCHLISTED_AT = "watchlisted_at";
        internal const string SYNC_MOVIES_LAST_ACTIVITIES_PROPERTY_NAME_COMMENTED_AT = "commented_at";
        internal const string SYNC_MOVIES_LAST_ACTIVITIES_PROPERTY_NAME_PAUSED_AT = "paused_at";
        internal const string SYNC_MOVIES_LAST_ACTIVITIES_PROPERTY_NAME_HIDDEN_AT = "hidden_at";

        internal const string SYNC_SEASONS_LAST_ACTIVITIES_PROPERTY_NAME_RATED_AT = "rated_at";
        internal const string SYNC_SEASONS_LAST_ACTIVITIES_PROPERTY_NAME_WATCHLISTED_AT = "watchlisted_at";
        internal const string SYNC_SEASONS_LAST_ACTIVITIES_PROPERTY_NAME_COMMENTED_AT = "commented_at";
        internal const string SYNC_SEASONS_LAST_ACTIVITIES_PROPERTY_NAME_HIDDEN_AT = "hidden_at";

        internal const string SYNC_SHOWS_LAST_ACTIVITIES_PROPERTY_NAME_RATED_AT = "rated_at";
        internal const string SYNC_SHOWS_LAST_ACTIVITIES_PROPERTY_NAME_WATCHLISTED_AT = "watchlisted_at";
        internal const string SYNC_SHOWS_LAST_ACTIVITIES_PROPERTY_NAME_COMMENTED_AT = "commented_at";
        internal const string SYNC_SHOWS_LAST_ACTIVITIES_PROPERTY_NAME_HIDDEN_AT = "hidden_at";

        // syncs playback
        internal const string SYNC_PLAYBACK_PROGRESS_ITEM_PROPERTY_NAME_ID = "id";
        internal const string SYNC_PLAYBACK_PROGRESS_ITEM_PROPERTY_NAME_PROGRESS = "progress";
        internal const string SYNC_PLAYBACK_PROGRESS_ITEM_PROPERTY_NAME_PAUSED_AT = "paused_at";
        internal const string SYNC_PLAYBACK_PROGRESS_ITEM_PROPERTY_NAME_TYPE = "type";
        internal const string SYNC_PLAYBACK_PROGRESS_ITEM_PROPERTY_NAME_MOVIE = "movie";
        internal const string SYNC_PLAYBACK_PROGRESS_ITEM_PROPERTY_NAME_SHOW = "show";
        internal const string SYNC_PLAYBACK_PROGRESS_ITEM_PROPERTY_NAME_EPISODE = "episode";

        // users
        internal const string ACCOUNT_SETTINGS_PROPERTY_NAME_TIMEZONE_ID = "timezone";
        internal const string ACCOUNT_SETTINGS_PROPERTY_NAME_TIME_24HR = "time_24hr";
        internal const string ACCOUNT_SETTINGS_PROPERTY_NAME_COVER_IMAGE = "cover_image";
        internal const string ACCOUNT_SETTINGS_PROPERTY_NAME_TOKEN = "token";

        internal const string SHARING_TEXT_PROPERTY_NAME_WATCHING = "watching";
        internal const string SHARING_TEXT_PROPERTY_NAME_WATCHED = "watched";

        internal const string USER_COMMENT_PROPERTY_NAME_TYPE = "type";
        internal const string USER_COMMENT_PROPERTY_NAME_COMMENT = "comment";
        internal const string USER_COMMENT_PROPERTY_NAME_MOVIE = "movie";
        internal const string USER_COMMENT_PROPERTY_NAME_SHOW = "show";
        internal const string USER_COMMENT_PROPERTY_NAME_SEASON = "season";
        internal const string USER_COMMENT_PROPERTY_NAME_EPISODE = "episode";
        internal const string USER_COMMENT_PROPERTY_NAME_LIST = "list";

        internal const string USER_FOLLOWER_PROPERTY_NAME_FOLLOWED_AT = "followed_at";
        internal const string USER_FOLLOWER_PROPERTY_NAME_USER = "user";

        internal const string USER_FOLLOW_REQUEST_PROPERTY_NAME_ID = "id";
        internal const string USER_FOLLOW_REQUEST_PROPERTY_NAME_REQUESTED_AT = "requested_at";
        internal const string USER_FOLLOW_REQUEST_PROPERTY_NAME_USER = "user";

        internal const string USER_FRIEND_PROPERTY_NAME_FRIENDS_AT = "friends_at";
        internal const string USER_FRIEND_PROPERTY_NAME_USER = "user";

        internal const string USER_HIDDEN_ITEM_PROPERTY_NAME_HIDDEN_AT = "hidden_at";
        internal const string USER_HIDDEN_ITEM_PROPERTY_NAME_TYPE = "type";
        internal const string USER_HIDDEN_ITEM_PROPERTY_NAME_MOVIE = "movie";
        internal const string USER_HIDDEN_ITEM_PROPERTY_NAME_SHOW = "show";
        internal const string USER_HIDDEN_ITEM_PROPERTY_NAME_SEASON = "season";

        internal const string USER_IDS_PROPERTY_NAME_SLUG = "slug";

        internal const string USER_IMAGES_PROPERTY_NAME_AVATAR = "avatar";

        internal const string USER_LIKE_ITEM_PROPERTY_NAME_LIKED_AT = "liked_at";
        internal const string USER_LIKE_ITEM_PROPERTY_NAME_TYPE = "type";
        internal const string USER_LIKE_ITEM_PROPERTY_NAME_COMMENT = "comment";
        internal const string USER_LIKE_ITEM_PROPERTY_NAME_LIST = "list";

        internal const string USER_PROPERTY_NAME_USERNAME = "username";
        internal const string USER_PROPERTY_NAME_IS_PRIVATE = "private";
        internal const string USER_PROPERTY_NAME_IDS = "ids";
        internal const string USER_PROPERTY_NAME_NAME = "name";
        internal const string USER_PROPERTY_NAME_IS_VIP = "vip";
        internal const string USER_PROPERTY_NAME_IS_VIP_EP = "vip_ep";
        internal const string USER_PROPERTY_NAME_JOINED_AT = "joined_at";
        internal const string USER_PROPERTY_NAME_LOCATION = "location";
        internal const string USER_PROPERTY_NAME_ABOUT = "about";
        internal const string USER_PROPERTY_NAME_GENDER = "gender";
        internal const string USER_PROPERTY_NAME_AGE = "age";
        internal const string USER_PROPERTY_NAME_IMAGES = "images";

        internal const string USER_SETTINGS_PROPERTY_NAME_USER = "user";
        internal const string USER_SETTINGS_PROPERTY_NAME_ACCOUNT = "account";
        internal const string USER_SETTINGS_PROPERTY_NAME_CONNECTIONS = "connections";
        internal const string USER_SETTINGS_PROPERTY_NAME_SHARING_TEXT = "sharing_text";

        internal const string USER_WATCHING_ITEM_PROPERTY_NAME_STARTED_AT = "started_at";
        internal const string USER_WATCHING_ITEM_PROPERTY_NAME_EXPIRES_AT = "expires_at";
        internal const string USER_WATCHING_ITEM_PROPERTY_NAME_ACTION = "action";
        internal const string USER_WATCHING_ITEM_PROPERTY_NAME_TYPE = "type";
        internal const string USER_WATCHING_ITEM_PROPERTY_NAME_MOVIE = "movie";
        internal const string USER_WATCHING_ITEM_PROPERTY_NAME_SHOW = "show";
        internal const string USER_WATCHING_ITEM_PROPERTY_NAME_EPISODE = "episode";

        // users lists
        internal const string LIST_IDS_PROPERTY_NAME_TRAKT = "trakt";
        internal const string LIST_IDS_PROPERTY_NAME_SLUG = "slug";

        internal const string LIST_ITEM_PROPERTY_NAME_RANK = "rank";
        internal const string LIST_ITEM_PROPERTY_NAME_LISTED_AT = "listed_at";
        internal const string LIST_ITEM_PROPERTY_NAME_TYPE = "type";
        internal const string LIST_ITEM_PROPERTY_NAME_MOVIE = "movie";
        internal const string LIST_ITEM_PROPERTY_NAME_SHOW = "show";
        internal const string LIST_ITEM_PROPERTY_NAME_SEASON = "season";
        internal const string LIST_ITEM_PROPERTY_NAME_EPISODE = "episode";
        internal const string LIST_ITEM_PROPERTY_NAME_PERSON = "person";

        internal const string LIST_PROPERTY_NAME_NAME = "name";
        internal const string LIST_PROPERTY_NAME_DESCRIPTION = "description";
        internal const string LIST_PROPERTY_NAME_PRIVACY = "privacy";
        internal const string LIST_PROPERTY_NAME_DISPLAY_NUMBERS = "display_numbers";
        internal const string LIST_PROPERTY_NAME_ALLOW_COMMENTS = "allow_comments";
        internal const string LIST_PROPERTY_NAME_SORT_BY = "sort_by";
        internal const string LIST_PROPERTY_NAME_SORT_HOW = "sort_how";
        internal const string LIST_PROPERTY_NAME_CREATED_AT = "created_at";
        internal const string LIST_PROPERTY_NAME_UPDATED_AT = "updated_at";
        internal const string LIST_PROPERTY_NAME_ITEM_COUNT = "item_count";
        internal const string LIST_PROPERTY_NAME_COMMENT_COUNT = "comment_count";
        internal const string LIST_PROPERTY_NAME_LIKES = "likes";
        internal const string LIST_PROPERTY_NAME_IDS = "ids";
        internal const string LIST_PROPERTY_NAME_USER = "user";

        // users statistics
        internal const string USER_EPISODES_STATISTICS_PROPERTY_NAME_PLAYS = "plays";
        internal const string USER_EPISODES_STATISTICS_PROPERTY_NAME_WATCHED = "watched";
        internal const string USER_EPISODES_STATISTICS_PROPERTY_NAME_MINUTES = "minutes";
        internal const string USER_EPISODES_STATISTICS_PROPERTY_NAME_COLLECTED = "collected";
        internal const string USER_EPISODES_STATISTICS_PROPERTY_NAME_RATINGS = "ratings";
        internal const string USER_EPISODES_STATISTICS_PROPERTY_NAME_COMMENTS = "comments";

        internal const string USER_MOVIES_STATISTICS_PROPERTY_NAME_PLAYS = "plays";
        internal const string USER_MOVIES_STATISTICS_PROPERTY_NAME_WATCHED = "watched";
        internal const string USER_MOVIES_STATISTICS_PROPERTY_NAME_MINUTES = "minutes";
        internal const string USER_MOVIES_STATISTICS_PROPERTY_NAME_COLLECTED = "collected";
        internal const string USER_MOVIES_STATISTICS_PROPERTY_NAME_RATINGS = "ratings";
        internal const string USER_MOVIES_STATISTICS_PROPERTY_NAME_COMMENTS = "comments";

        internal const string USER_NETWORK_STATISTICS_PROPERTY_NAME_FRIENDS = "friends";
        internal const string USER_NETWORK_STATISTICS_PROPERTY_NAME_FOLLOWERS = "followers";
        internal const string USER_NETWORK_STATISTICS_PROPERTY_NAME_FOLLOWING = "following";

        internal const string USER_RATINGS_STATISTICS_PROPERTY_NAME_TOTAL = "total";
        internal const string USER_RATINGS_STATISTICS_PROPERTY_NAME_DISTRIBUTION = "distribution";

        internal const string USER_SEASONS_STATISTICS_PROPERTY_NAME_RATINGS = "ratings";
        internal const string USER_SEASONS_STATISTICS_PROPERTY_NAME_COMMENTS = "comments";

        internal const string USER_SHOWS_STATISTICS_PROPERTY_NAME_WATCHED = "watched";
        internal const string USER_SHOWS_STATISTICS_PROPERTY_NAME_COLLECTED = "collected";
        internal const string USER_SHOWS_STATISTICS_PROPERTY_NAME_RATINGS = "ratings";
        internal const string USER_SHOWS_STATISTICS_PROPERTY_NAME_COMMENTS = "comments";

        internal const string USER_STATISTICS_PROPERTY_NAME_MOVIES = "movies";
        internal const string USER_STATISTICS_PROPERTY_NAME_SHOWS = "shows";
        internal const string USER_STATISTICS_PROPERTY_NAME_SEASONS = "seasons";
        internal const string USER_STATISTICS_PROPERTY_NAME_EPISODES = "episodes";
        internal const string USER_STATISTICS_PROPERTY_NAME_NETWORK = "network";
        internal const string USER_STATISTICS_PROPERTY_NAME_RATINGS = "ratings";

        // watched
        internal const string WATCHED_MOVIE_PROPERTY_NAME_PLAYS = "plays";
        internal const string WATCHED_MOVIE_PROPERTY_NAME_LAST_WATCHED_AT = "last_watched_at";
        internal const string WATCHED_MOVIE_PROPERTY_NAME_LAST_UPDATED_AT = "last_updated_at";
        internal const string WATCHED_MOVIE_PROPERTY_NAME_MOVIE = "movie";

        internal const string WATCHED_SHOW_EPISODE_PROPERTY_NAME_NUMBER = "number";
        internal const string WATCHED_SHOW_EPISODE_PROPERTY_NAME_PLAYS = "plays";
        internal const string WATCHED_SHOW_EPISODE_PROPERTY_NAME_LAST_WATCHED_AT = "last_watched_at";

        internal const string WATCHED_SHOW_PROPERTY_NAME_PLAYS = "plays";
        internal const string WATCHED_SHOW_PROPERTY_NAME_LAST_WATCHED_AT = "last_watched_at";
        internal const string WATCHED_SHOW_PROPERTY_NAME_RESET_AT = "reset_at";
        internal const string WATCHED_SHOW_PROPERTY_NAME_SHOW = "show";
        internal const string WATCHED_SHOW_PROPERTY_NAME_SEASONS = "seasons";

        internal const string WATCHED_SHOW_SEASON_PROPERTY_NAME_NUMBER = "number";
        internal const string WATCHED_SHOW_SEASON_PROPERTY_NAME_EPISODES = "episodes";

        // watchlist
        internal const string WATCHLIST_ITEM_PROPERTY_NAME_LISTED_AT = "listed_at";
        internal const string WATCHLIST_ITEM_PROPERTY_NAME_TYPE = "type";
        internal const string WATCHLIST_ITEM_PROPERTY_NAME_MOVIE = "movie";
        internal const string WATCHLIST_ITEM_PROPERTY_NAME_SHOW = "show";
        internal const string WATCHLIST_ITEM_PROPERTY_NAME_SEASON = "season";
        internal const string WATCHLIST_ITEM_PROPERTY_NAME_EPISODE = "episode";

        // post checkins
        internal const string CHECKIN_POST_PROPERTY_NAME_SHARING = "sharing";
        internal const string CHECKIN_POST_PROPERTY_NAME_MESSAGE = "message";
        internal const string CHECKIN_POST_PROPERTY_NAME_APP_VERSION = "app_version";
        internal const string CHECKIN_POST_PROPERTY_NAME_APP_DATE = "app_date";
        internal const string CHECKIN_POST_PROPERTY_NAME_VENUE_ID = "venue_id";
        internal const string CHECKIN_POST_PROPERTY_NAME_VENUE_NAME = "venue_name";

        internal const string EPISODE_CHECKIN_POST_PROPERTY_NAME_EPISODE = "episode";
        internal const string EPISODE_CHECKIN_POST_PROPERTY_NAME_SHOW = "show";

        internal const string MOVIE_CHECKIN_POST_PROPERTY_NAME_MOVIE = "movie";

        // post checkins responses
        internal const string CHECKIN_POST_ERROR_RESPONSE_PROPERTY_NAME_EXPIRES_AT = "expires_at";

        internal const string CHECKIN_POST_RESPONSE_PROPERTY_NAME_ID = "id";
        internal const string CHECKIN_POST_RESPONSE_PROPERTY_NAME_WATCHED_AT = "watched_at";
        internal const string CHECKIN_POST_RESPONSE_PROPERTY_NAME_SHARING = "sharing";

        internal const string EPISODE_CHECKIN_POST_RESPONSE_PROPERTY_NAME_EPISODE = "episode";
        internal const string EPISODE_CHECKIN_POST_RESPONSE_PROPERTY_NAME_SHOW = "show";

        internal const string MOVIE_CHECKIN_POST_RESPONSE_PROPERTY_NAME_MOVIE = "movie";

        // post comments
        internal const string COMMENT_POST_PROPERTY_NAME_COMMENT = "comment";
        internal const string COMMENT_POST_PROPERTY_NAME_SPOILER = "spoiler";
        internal const string COMMENT_POST_PROPERTY_NAME_SHARING = "sharing";

        internal const string EPISODE_COMMENT_POST_PROPERTY_NAME_EPISODE = "episode";
        internal const string LIST_COMMENT_POST_PROPERTY_NAME_LIST = "list";
        internal const string MOVIE_COMMENT_POST_PROPERTY_NAME_MOVIE = "movie";
        internal const string SEASON_COMMENT_POST_PROPERTY_NAME_SEASON = "season";
        internal const string SHOW_COMMENT_POST_PROPERTY_NAME_SHOW = "show";

        internal const string COMMENT_UPDATE_POST_PROPERTY_NAME_COMMENT = "comment";
        internal const string COMMENT_UPDATE_POST_PROPERTY_NAME_SPOILER = "spoiler";

        // post comments responses
        internal const string COMMENT_POST_RESPONSE_PROPERTY_NAME_SHARING = "sharing";

        // post responses
        internal const string POST_RESPONSE_NOT_FOUND_EPISODE_PROPERTY_NAME_IDS = "ids";
        internal const string POST_RESPONSE_NOT_FOUND_MOVIE_PROPERTY_NAME_IDS = "ids";
        internal const string POST_RESPONSE_NOT_FOUND_PERSON_PROPERTY_NAME_IDS = "ids";
        internal const string POST_RESPONSE_NOT_FOUND_SEASON_PROPERTY_NAME_IDS = "ids";
        internal const string POST_RESPONSE_NOT_FOUND_SHOW_PROPERTY_NAME_IDS = "ids";

        // post scrobbles
        internal const string SCROBBLE_POST_PROPERTY_NAME_PROGRESS = "progress";
        internal const string SCROBBLE_POST_PROPERTY_NAME_APP_VERSION = "app_version";
        internal const string SCROBBLE_POST_PROPERTY_NAME_APP_DATE = "app_date";

        internal const string EPISODE_SCROBBLE_POST_PROPERTY_NAME_EPISODE = "episode";
        internal const string EPISODE_SCROBBLE_POST_PROPERTY_NAME_SHOW = "show";

        internal const string MOVIE_SCROBBLE_POST_PROPERTY_NAME_MOVIE = "movie";

        // post scrobbles responses
        internal const string SCROBBLE_POST_RESPONSE_PROPERTY_NAME_ID = "id";
        internal const string SCROBBLE_POST_RESPONSE_PROPERTY_NAME_ACTION = "action";
        internal const string SCROBBLE_POST_RESPONSE_PROPERTY_NAME_PROGRESS = "progress";
        internal const string SCROBBLE_POST_RESPONSE_PROPERTY_NAME_SHARING = "sharing";

        internal const string EPISODE_SCROBBLE_POST_RESPONSE_PROPERTY_NAME_EPISODE = "episode";
        internal const string EPISODE_SCROBBLE_POST_RESPONSE_PROPERTY_NAME_SHOW = "show";

        internal const string MOVIE_SCROBBLE_POST_RESPONSE_PROPERTY_NAME_MOVIE = "movie";

        // post syncs collection
        internal const string SYNC_COLLECTION_POST_PROPERTY_NAME_MOVIES = "movies";
        internal const string SYNC_COLLECTION_POST_PROPERTY_NAME_SHOWS = "shows";
        internal const string SYNC_COLLECTION_POST_PROPERTY_NAME_EPISODES = "episodes";

        internal const string SYNC_COLLECTION_POST_MOVIE_PROPERTY_NAME_COLLECTED_AT = "collected_at";
        internal const string SYNC_COLLECTION_POST_MOVIE_PROPERTY_NAME_TITLE = "title";
        internal const string SYNC_COLLECTION_POST_MOVIE_PROPERTY_NAME_YEAR = "year";
        internal const string SYNC_COLLECTION_POST_MOVIE_PROPERTY_NAME_IDS = "ids";
        internal const string SYNC_COLLECTION_POST_MOVIE_PROPERTY_NAME_METADATA = "metadata";

        internal const string SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_COLLECTED_AT = "collected_at";
        internal const string SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_TITLE = "title";
        internal const string SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_YEAR = "year";
        internal const string SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_IDS = "ids";
        internal const string SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_SEASONS = "seasons";
        internal const string SYNC_COLLECTION_POST_SHOW_PROPERTY_NAME_METADATA = "metadata";

        internal const string SYNC_COLLECTION_POST_SHOW_SEASON_PROPERTY_NAME_NUMBER = "number";
        internal const string SYNC_COLLECTION_POST_SHOW_SEASON_PROPERTY_NAME_EPISODES = "episodes";

        internal const string SYNC_COLLECTION_POST_SHOW_EPISODE_PROPERTY_NAME_NUMBER = "number";
        internal const string SYNC_COLLECTION_POST_SHOW_EPISODE_PROPERTY_NAME_COLLECTED_AT = "collected_at";

        internal const string SYNC_COLLECTION_POST_EPISODE_PROPERTY_NAME_COLLECTED_AT = "collected_at";
        internal const string SYNC_COLLECTION_POST_EPISODE_PROPERTY_NAME_IDS = "ids";
        internal const string SYNC_COLLECTION_POST_EPISODE_PROPERTY_NAME_METADATA = "metadata";

        // post syncs collection responses
        internal const string SYNC_COLLECTION_POST_RESPONSE_PROPERTY_NAME_ADDED = "added";
        internal const string SYNC_COLLECTION_POST_RESPONSE_PROPERTY_NAME_UPDATED = "updated";
        internal const string SYNC_COLLECTION_POST_RESPONSE_PROPERTY_NAME_EXISTING = "existing";
        internal const string SYNC_COLLECTION_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND = "not_found";

        internal const string SYNC_COLLECTION_REMOVE_POST_RESPONSE_PROPERTY_NAME_DELETED = "deleted";
        internal const string SYNC_COLLECTION_REMOVE_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND = "not_found";

        // post syncs history
        internal const string SYNC_HISTORY_POST_PROPERTY_NAME_MOVIES = "movies";
        internal const string SYNC_HISTORY_POST_PROPERTY_NAME_SHOWS = "shows";
        internal const string SYNC_HISTORY_POST_PROPERTY_NAME_EPISODES = "episodes";

        internal const string SYNC_HISTORY_POST_MOVIE_PROPERTY_NAME_WATCHED_AT = "watched_at";
        internal const string SYNC_HISTORY_POST_MOVIE_PROPERTY_NAME_TITLE = "title";
        internal const string SYNC_HISTORY_POST_MOVIE_PROPERTY_NAME_YEAR = "year";
        internal const string SYNC_HISTORY_POST_MOVIE_PROPERTY_NAME_IDS = "ids";

        internal const string SYNC_HISTORY_POST_SHOW_PROPERTY_NAME_WATCHED_AT = "watched_at";
        internal const string SYNC_HISTORY_POST_SHOW_PROPERTY_NAME_TITLE = "title";
        internal const string SYNC_HISTORY_POST_SHOW_PROPERTY_NAME_YEAR = "year";
        internal const string SYNC_HISTORY_POST_SHOW_PROPERTY_NAME_IDS = "ids";
        internal const string SYNC_HISTORY_POST_SHOW_PROPERTY_NAME_SEASONS = "seasons";

        internal const string SYNC_HISTORY_POST_SHOW_SEASON_PROPERTY_NAME_WATCHED_AT = "watched_at";
        internal const string SYNC_HISTORY_POST_SHOW_SEASON_PROPERTY_NAME_NUMBER = "number";
        internal const string SYNC_HISTORY_POST_SHOW_SEASON_PROPERTY_NAME_EPISODES = "episodes";

        internal const string SYNC_HISTORY_POST_SHOW_EPISODE_PROPERTY_NAME_WATCHED_AT = "watched_at";
        internal const string SYNC_HISTORY_POST_SHOW_EPISODE_PROPERTY_NAME_NUMBER = "number";

        internal const string SYNC_HISTORY_POST_EPISODE_PROPERTY_NAME_WATCHED_AT = "watched_at";
        internal const string SYNC_HISTORY_POST_EPISODE_PROPERTY_NAME_IDS = "ids";

        internal const string SYNC_HISTORY_REMOVE_POST_PROPERTY_NAME_IDS = "ids";

        // post syncs history responses
        internal const string SYNC_HISTORY_POST_RESPONSE_PROPERTY_NAME_ADDED = "added";
        internal const string SYNC_HISTORY_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND = "not_found";

        internal const string SYNC_HISTORY_REMOVE_POST_RESPONSE_GROUP_PROPERTY_NAME_IDS = "ids";

        internal const string SYNC_HISTORY_REMOVE_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_IDS = "ids";

        internal const string SYNC_HISTORY_REMOVE_POST_RESPONSE_PROPERTY_NAME_DELETED = "deleted";
        internal const string SYNC_HISTORY_REMOVE_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND = "not_found";

        // post syncs ratings
        internal const string SYNC_RATINGS_POST_PROPERTY_NAME_MOVIES = "movies";
        internal const string SYNC_RATINGS_POST_PROPERTY_NAME_SHOWS = "shows";
        internal const string SYNC_RATINGS_POST_PROPERTY_NAME_EPISODES = "episodes";

        internal const string SYNC_RATINGS_POST_MOVIE_PROPERTY_NAME_RATED_AT = "rated_at";
        internal const string SYNC_RATINGS_POST_MOVIE_PROPERTY_NAME_RATING = "rating";
        internal const string SYNC_RATINGS_POST_MOVIE_PROPERTY_NAME_TITLE = "title";
        internal const string SYNC_RATINGS_POST_MOVIE_PROPERTY_NAME_YEAR = "year";
        internal const string SYNC_RATINGS_POST_MOVIE_PROPERTY_NAME_IDS = "ids";

        internal const string SYNC_RATINGS_POST_SHOW_PROPERTY_NAME_RATED_AT = "rated_at";
        internal const string SYNC_RATINGS_POST_SHOW_PROPERTY_NAME_RATING = "rating";
        internal const string SYNC_RATINGS_POST_SHOW_PROPERTY_NAME_TITLE = "title";
        internal const string SYNC_RATINGS_POST_SHOW_PROPERTY_NAME_YEAR = "year";
        internal const string SYNC_RATINGS_POST_SHOW_PROPERTY_NAME_IDS = "ids";
        internal const string SYNC_RATINGS_POST_SHOW_PROPERTY_NAME_SEASONS = "seasons";

        internal const string SYNC_RATINGS_POST_SHOW_SEASON_PROPERTY_NAME_RATED_AT = "rated_at";
        internal const string SYNC_RATINGS_POST_SHOW_SEASON_PROPERTY_NAME_RATING = "rating";
        internal const string SYNC_RATINGS_POST_SHOW_SEASON_PROPERTY_NAME_NUMBER = "number";
        internal const string SYNC_RATINGS_POST_SHOW_SEASON_PROPERTY_NAME_EPISODES = "episodes";

        internal const string SYNC_RATINGS_POST_SHOW_EPISODE_PROPERTY_NAME_RATED_AT = "rated_at";
        internal const string SYNC_RATINGS_POST_SHOW_EPISODE_PROPERTY_NAME_RATING = "rating";
        internal const string SYNC_RATINGS_POST_SHOW_EPISODE_PROPERTY_NAME_NUMBER = "number";

        internal const string SYNC_RATINGS_POST_EPISODE_PROPERTY_NAME_RATED_AT = "rated_at";
        internal const string SYNC_RATINGS_POST_EPISODE_PROPERTY_NAME_RATING = "rating";
        internal const string SYNC_RATINGS_POST_EPISODE_PROPERTY_NAME_IDS = "ids";

        // post syncs ratings responses
        internal const string SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_EPISODE_PROPERTY_NAME_RATING = "rating";
        internal const string SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_EPISODE_PROPERTY_NAME_IDS = "ids";

        internal const string SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_MOVIES = "movies";
        internal const string SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SHOWS = "shows";
        internal const string SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SEASONS = "seasons";
        internal const string SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_EPISODES = "episodes";

        internal const string SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_MOVIE_PROPERTY_NAME_RATING = "rating";
        internal const string SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_MOVIE_PROPERTY_NAME_IDS = "ids";

        internal const string SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_SEASON_PROPERTY_NAME_RATING = "rating";
        internal const string SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_SEASON_PROPERTY_NAME_IDS = "ids";

        internal const string SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_SHOW_PROPERTY_NAME_RATING = "rating";
        internal const string SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_SHOW_PROPERTY_NAME_IDS = "ids";

        internal const string SYNC_RATINGS_POST_RESPONSE_PROPERTY_NAME_ADDED = "added";
        internal const string SYNC_RATINGS_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND = "not_found";

        internal const string SYNC_RATINGS_REMOVE_POST_RESPONSE_PROPERTY_NAME_DELETED = "deleted";
        internal const string SYNC_RATINGS_REMOVE_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND = "not_found";

        // post syncs responses
        internal const string SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_MOVIES = "movies";
        internal const string SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_SHOWS = "shows";
        internal const string SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_SEASONS = "seasons";
        internal const string SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_EPISODES = "episodes";

        internal const string SYNC_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_MOVIES = "movies";
        internal const string SYNC_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SHOWS = "shows";
        internal const string SYNC_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SEASONS = "seasons";
        internal const string SYNC_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_EPISODES = "episodes";

        // post syncs watchlist
        internal const string SYNC_WATCHLIST_POST_PROPERTY_NAME_MOVIES = "movies";
        internal const string SYNC_WATCHLIST_POST_PROPERTY_NAME_SHOWS = "shows";
        internal const string SYNC_WATCHLIST_POST_PROPERTY_NAME_EPISODES = "episodes";

        internal const string SYNC_WATCHLIST_POST_MOVIE_PROPERTY_NAME_TITLE = "title";
        internal const string SYNC_WATCHLIST_POST_MOVIE_PROPERTY_NAME_YEAR = "year";
        internal const string SYNC_WATCHLIST_POST_MOVIE_PROPERTY_NAME_IDS = "ids";

        internal const string SYNC_WATCHLIST_POST_SHOW_PROPERTY_NAME_TITLE = "title";
        internal const string SYNC_WATCHLIST_POST_SHOW_PROPERTY_NAME_YEAR = "year";
        internal const string SYNC_WATCHLIST_POST_SHOW_PROPERTY_NAME_IDS = "ids";
        internal const string SYNC_WATCHLIST_POST_SHOW_PROPERTY_NAME_SEASONS = "seasons";

        internal const string SYNC_WATCHLIST_POST_SHOW_SEASON_PROPERTY_NAME_NUMBER = "number";
        internal const string SYNC_WATCHLIST_POST_SHOW_SEASON_PROPERTY_NAME_EPISODES = "episodes";

        internal const string SYNC_WATCHLIST_POST_SHOW_EPISODE_PROPERTY_NAME_NUMBER = "number";

        internal const string SYNC_WATCHLIST_POST_EPISODE_PROPERTY_NAME_IDS = "ids";

        // post syncs watchlist responses
        internal const string SYNC_WATCHLIST_POST_RESPONSE_PROPERTY_NAME_ADDED = "added";
        internal const string SYNC_WATCHLIST_POST_RESPONSE_PROPERTY_NAME_EXISTING = "existing";
        internal const string SYNC_WATCHLIST_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND = "not_found";

        internal const string SYNC_WATCHLIST_REMOVE_POST_RESPONSE_PROPERTY_NAME_DELETED = "deleted";
        internal const string SYNC_WATCHLIST_REMOVE_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND = "not_found";

        // post users custom lists
        internal const string USER_CUSTOM_LIST_ITEMS_POST_PROPERTY_NAME_MOVIES = "movies";
        internal const string USER_CUSTOM_LIST_ITEMS_POST_PROPERTY_NAME_SHOWS = "shows";
        internal const string USER_CUSTOM_LIST_ITEMS_POST_PROPERTY_NAME_PEOPLE = "people";

        internal const string USER_CUSTOM_LIST_ITEMS_POST_MOVIE_PROPERTY_NAME_IDS = "ids";

        internal const string USER_CUSTOM_LIST_ITEMS_POST_SHOW_PROPERTY_NAME_IDS = "ids";
        internal const string USER_CUSTOM_LIST_ITEMS_POST_SHOW_PROPERTY_NAME_SEASONS = "seasons";

        internal const string USER_CUSTOM_LIST_ITEMS_POST_SHOW_EPISODE_PROPERTY_NAME_NUMBER = "number";

        internal const string USER_CUSTOM_LIST_ITEMS_POST_SHOW_SEASON_PROPERTY_NAME_NUMBER = "number";
        internal const string USER_CUSTOM_LIST_ITEMS_POST_SHOW_SEASON_PROPERTY_NAME_EPISODES = "episodes";

        // post users custom lists responses
        internal const string USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_MOVIES = "movies";
        internal const string USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_SHOWS = "shows";
        internal const string USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_SEASONS = "seasons";
        internal const string USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_EPISODES = "episodes";
        internal const string USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_PEOPLE = "people";

        internal const string USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_MOVIES = "movies";
        internal const string USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SHOWS = "shows";
        internal const string USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SEASONS = "seasons";
        internal const string USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_EPISODES = "episodes";
        internal const string USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_PEOPLE = "people";

        internal const string USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_PROPERTY_NAME_ADDED = "added";
        internal const string USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_PROPERTY_NAME_EXISTING = "existing";
        internal const string USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND = "not_found";

        internal const string USER_CUSTOM_LIST_ITEMS_REMOVE_POST_RESPONSE_PROPERTY_NAME_DELETED = "deleted";
        internal const string USER_CUSTOM_LIST_ITEMS_REMOVE_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND = "not_found";

        // post users hidden items
        internal const string USER_HIDDEN_ITEMS_POST_PROPERTY_NAME_MOVIES = "movies";
        internal const string USER_HIDDEN_ITEMS_POST_PROPERTY_NAME_SHOWS = "shows";
        internal const string USER_HIDDEN_ITEMS_POST_PROPERTY_NAME_SEASONS = "seasons";

        internal const string USER_HIDDEN_ITEMS_POST_MOVIE_PROPERTY_NAME_TITLE = "title";
        internal const string USER_HIDDEN_ITEMS_POST_MOVIE_PROPERTY_NAME_YEAR = "year";
        internal const string USER_HIDDEN_ITEMS_POST_MOVIE_PROPERTY_NAME_IDS = "ids";

        internal const string USER_HIDDEN_ITEMS_POST_SHOW_PROPERTY_NAME_TITLE = "title";
        internal const string USER_HIDDEN_ITEMS_POST_SHOW_PROPERTY_NAME_YEAR = "year";
        internal const string USER_HIDDEN_ITEMS_POST_SHOW_PROPERTY_NAME_IDS = "ids";
        internal const string USER_HIDDEN_ITEMS_POST_SHOW_PROPERTY_NAME_SEASONS = "seasons";

        internal const string USER_HIDDEN_ITEMS_POST_SHOW_SEASON_PROPERTY_NAME_NUMBER = "number";

        internal const string USER_HIDDEN_ITEMS_POST_SEASON_PROPERTY_NAME_IDS = "ids";

        // post users hidden items responses
        internal const string USER_HIDDEN_ITEMS_POST_RESPONSE_PROPERTY_NAME_ADDED = "added";
        internal const string USER_HIDDEN_ITEMS_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND = "not_found";

        internal const string USER_HIDDEN_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_MOVIES = "movies";
        internal const string USER_HIDDEN_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_SHOWS = "shows";
        internal const string USER_HIDDEN_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_SEASONS = "seasons";

        internal const string USER_HIDDEN_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_MOVIES = "movies";
        internal const string USER_HIDDEN_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SHOWS = "shows";
        internal const string USER_HIDDEN_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SEASONS = "seasons";

        internal const string USER_HIDDEN_ITEMS_REMOVE_POST_RESPONSE_PROPERTY_NAME_DELETED = "deleted";
        internal const string USER_HIDDEN_ITEMS_REMOVE_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND = "not_found";

        // post users
        internal const string USER_CUSTOM_LIST_POST_PROPERTY_NAME_NAME = "name";
        internal const string USER_CUSTOM_LIST_POST_PROPERTY_NAME_DESCRIPTION = "description";
        internal const string USER_CUSTOM_LIST_POST_PROPERTY_NAME_PRIVACY = "privacy";
        internal const string USER_CUSTOM_LIST_POST_PROPERTY_NAME_DISPLAY_NUMBERS = "display_numbers";
        internal const string USER_CUSTOM_LIST_POST_PROPERTY_NAME_ALLOW_COMMENTS = "allow_comments";
        internal const string USER_CUSTOM_LIST_POST_PROPERTY_NAME_SORT_BY = "sort_by";
        internal const string USER_CUSTOM_LIST_POST_PROPERTY_NAME_SORT_HOW = "sort_how";

        internal const string USER_CUSTOM_LISTS_REORDER_POST_PROPERTY_NAME_RANK = "rank";

        // post users responses
        internal const string USER_FOLLOW_USER_POST_RESPONSE_PROPERTY_NAME_APPROVED_AT = "approved_at";
        internal const string USER_FOLLOW_USER_POST_RESPONSE_PROPERTY_NAME_USER = "user";

        internal const string USER_CUSTOM_LISTS_REORDER_POST_RESPONSE_PROPERTY_NAME_UPDATED = "updated";
        internal const string USER_CUSTOM_LISTS_REORDER_POST_RESPONSE_PROPERTY_NAME_SKIPPED_IDS = "skipped_ids";
    }
}
