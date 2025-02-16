namespace TraktNET
{
    internal sealed class TMDBConfigurationGetRequest : TMDBRequestBase
    {
        public TMDBConfigurationGetRequest() : base(HttpMethod.Get, null) { }

        internal override void BuildUri() => RequestUri = new Uri("configuration", UriKind.Relative);
    }

    internal abstract class TMDBImagesGetRequest(string path) : TMDBRequestBase(HttpMethod.Get, null)
    {
        protected readonly string _path = path;

        internal required uint Id { get; init; }

        internal string? Language { get; set; }

        internal string? IncludeImageLanguage { get; set; }

        internal override void BuildUri()
        {
            string requestUri = $"{_path}/{Id}/images";
            List<string> queries = GetQueries();

            if (queries.Count > 0)
            {
                requestUri = requestUri + "?" + string.Join("&", queries);
            }

            RequestUri = new Uri(requestUri, UriKind.Relative);
        }

        protected List<string> GetQueries()
        {
            List<string> queries = [];

            if (!string.IsNullOrWhiteSpace(Language))
            {
                queries.Add($"language={Language}");
            }

            if (!string.IsNullOrWhiteSpace(IncludeImageLanguage))
            {
                queries.Add($"include_image_language={IncludeImageLanguage}");
            }

            return queries;
        }

        internal override void Validate()
        {
            if (Id == 0)
            {
                throw new TMDBRequestValidationException(nameof(Id), "Id must not be 0");
            }
        }
    }

    internal abstract class TMDBVideosGetRequest(string path) : TMDBRequestBase(HttpMethod.Get, null)
    {
        protected readonly string _path = path;

        internal required uint Id { get; init; }

        internal string? Language { get; set; }

        internal string? IncludeVideoLanguage { get; set; }

        internal override void BuildUri()
        {
            string requestUri = $"{_path}/{Id}/videos";
            List<string> queries = GetQueries();

            if (queries.Count > 0)
            {
                requestUri = requestUri + "?" + string.Join("&", queries);
            }

            RequestUri = new Uri(requestUri, UriKind.Relative);
        }

        protected List<string> GetQueries()
        {
            List<string> queries = [];

            if (!string.IsNullOrWhiteSpace(Language))
            {
                queries.Add($"language={Language}");
            }

            if (!string.IsNullOrWhiteSpace(IncludeVideoLanguage))
            {
                queries.Add($"include_video_language={IncludeVideoLanguage}");
            }

            return queries;
        }

        internal override void Validate()
        {
            if (Id == 0)
            {
                throw new TMDBRequestValidationException(nameof(Id), "Id must not be 0");
            }
        }
    }

    internal sealed class TMDBMovieImagesGetRequest : TMDBImagesGetRequest
    {
        public TMDBMovieImagesGetRequest() : base("movies") { }
    }

    internal class TMDBShowImagesGetRequest : TMDBImagesGetRequest
    {
        public TMDBShowImagesGetRequest() : base("shows") { }
    }

    internal class TMDBSeasonImagesGetRequest : TMDBShowImagesGetRequest
    {
        internal required uint SeasonNumber { get; init; }

        internal override void BuildUri()
        {
            string requestUri = $"{_path}/{Id}/season/{SeasonNumber}/images";
            List<string> queries = GetQueries();

            if (queries.Count > 0)
            {
                requestUri = requestUri + "?" + string.Join("&", queries);
            }

            RequestUri = new Uri(requestUri, UriKind.Relative);
        }
    }

    internal sealed class TMDBEpisodeImagesGetRequest : TMDBSeasonImagesGetRequest
    {
        internal required uint EpisodeNumber { get; init; }

        internal override void BuildUri()
        {
            string requestUri = $"{_path}/{Id}/season/{SeasonNumber}/episode/{EpisodeNumber}/images";
            List<string> queries = GetQueries();

            if (queries.Count > 0)
            {
                requestUri = requestUri + "?" + string.Join("&", queries);
            }

            RequestUri = new Uri(requestUri, UriKind.Relative);
        }
    }

    internal sealed class TMDBPersonImagesGetRequest : TMDBRequestBase
    {
        internal required uint Id { get; init; }

        public TMDBPersonImagesGetRequest() : base(HttpMethod.Get, null) { }

        internal override void BuildUri() => RequestUri = new Uri($"person/{Id}/images", UriKind.Relative);

        internal override void Validate()
        {
            if (Id == 0)
            {
                throw new TMDBRequestValidationException(nameof(Id), "Id must not be 0");
            }
        }
    }

    internal sealed class TMDBMovieVideosGetRequest : TMDBVideosGetRequest
    {
        public TMDBMovieVideosGetRequest() : base("movies") { }
    }

    internal class TMDBShowVideosGetRequest : TMDBVideosGetRequest
    {
        public TMDBShowVideosGetRequest() : base("shows") { }
    }

    internal class TMDBSeasonVideosGetRequest : TMDBShowVideosGetRequest
    {
        internal required uint SeasonNumber { get; init; }

        internal override void BuildUri()
        {
            string requestUri = $"{_path}/{Id}/season/{SeasonNumber}/videos";
            List<string> queries = GetQueries();

            if (queries.Count > 0)
            {
                requestUri = requestUri + "?" + string.Join("&", queries);
            }

            RequestUri = new Uri(requestUri, UriKind.Relative);
        }
    }

    internal sealed class TMDBEpisodeVideosGetRequest : TMDBSeasonVideosGetRequest
    {
        internal required uint EpisodeNumber { get; init; }

        internal override void BuildUri()
        {
            string requestUri = $"{_path}/{Id}/season/{SeasonNumber}/episode/{EpisodeNumber}/videos";
            List<string> queries = GetQueries();

            if (queries.Count > 0)
            {
                requestUri = requestUri + "?" + string.Join("&", queries);
            }

            RequestUri = new Uri(requestUri, UriKind.Relative);
        }
    }
}
