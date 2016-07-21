namespace TraktApiSharp.Objects.Post
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public sealed class PostRatingsSeasons : IEnumerable<PostRatingsSeason>
    {
        private readonly List<PostRatingsSeason> _seasons;

        public PostRatingsSeasons()
        {
            _seasons = new List<PostRatingsSeason>();
        }

        public void Add(int number) => _seasons.Add(new PostRatingsSeason(number));

        public void Add(int number, int rating, DateTime? ratedAt = null) => _seasons.Add(new PostRatingsSeason(number, rating, ratedAt));

        public void Add(int number, int rating, DateTime ratedAt, PostRatingsEpisodes episodes) => _seasons.Add(new PostRatingsSeason(number, rating, ratedAt, episodes));

        public void Add(int number, PostRatingsEpisodes episodes) => _seasons.Add(new PostRatingsSeason(number, null, null, episodes));

        public void Add(int number, int rating, PostRatingsEpisodes episodes) => _seasons.Add(new PostRatingsSeason(number, rating, null, episodes));

        public IEnumerator<PostRatingsSeason> GetEnumerator() => _seasons.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class PostRatingsSeason
    {
        public PostRatingsSeason() : this(-1) { }

        public PostRatingsSeason(int number) : this(number, null) { }

        public PostRatingsSeason(int number, int? rating) : this(number, rating, null) { }

        public PostRatingsSeason(int number, int? rating, DateTime? ratedAt) : this(number, rating, ratedAt, new PostRatingsEpisodes()) { }

        public PostRatingsSeason(int number, int? rating, DateTime? ratedAt, PostRatingsEpisodes episodes)
        {
            Number = number;
            Rating = rating;
            RatedAt = ratedAt;
            Episodes = episodes;
        }

        public int Number { get; set; }

        public int? Rating { get; set; }

        public DateTime? RatedAt { get; set; }

        public PostRatingsEpisodes Episodes { get; set; }
    }

    public sealed class PostRatingsEpisodes : IEnumerable<PostRatingsEpisode>
    {
        private readonly List<PostRatingsEpisode> _episodes;

        public PostRatingsEpisodes()
        {
            _episodes = new List<PostRatingsEpisode>();
        }

        public void Add(int episode) => _episodes.Add(new PostRatingsEpisode(episode));

        public void Add(int episode, int rating, DateTime? ratedAt = null) => _episodes.Add(new PostRatingsEpisode(episode, rating, ratedAt));

        public void Add(PostRatingsEpisode episode, params PostRatingsEpisode[] episodes)
        {
            _episodes.Add(episode);

            if (episodes != null && episodes.Length > 0)
                _episodes.AddRange(episodes);
        }

        public IEnumerator<PostRatingsEpisode> GetEnumerator() => _episodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class PostRatingsEpisode
    {
        public PostRatingsEpisode() : this(-1) { }

        public PostRatingsEpisode(int number) : this(number, null) { }

        public PostRatingsEpisode(int number, int? rating) : this(number, rating, null) { }

        public PostRatingsEpisode(int number, int? rating, DateTime? ratedAt)
        {
            Number = number;
            Rating = rating;
            RatedAt = ratedAt;
        }

        public int Number { get; set; }

        public int? Rating { get; set; }

        public DateTime? RatedAt { get; set; }
    }
}
