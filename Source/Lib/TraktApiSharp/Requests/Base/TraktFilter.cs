namespace TraktApiSharp.Requests.Base
{
    using System.Collections.Generic;

    public class TraktFilter
    {
        public string Query { get; set; }

        public int Years { get; set; }

        public string[] Genres { get; set; }

        public string[] Languages { get; set; }

        public string[] Countries { get; set; }

        public Range<int> Runtimes { get; set; }

        public Range<int> Ratings { get; set; }

        public TraktFilter AddGenres(string genre, params string[] genres)
        {
            var genresList = new List<string>();

            genresList.AddRange(this.Genres);
            genresList.Add(genre);
            genresList.AddRange(genres);

            this.Genres = genresList.ToArray();

            return this;
        }

        public TraktFilter WithGenres(string genre, params string[] genres)
        {
            this.Genres = new string[genres.Length + 1];

            this.Genres[0] = genre;

            for (int i = 0; i < genres.Length; i++)
                this.Genres[i + 1] = genres[i];

            return this;
        }

        public TraktFilter AddLanguages(string language, params string[] languages)
        {
            var languagesList = new List<string>();

            languagesList.AddRange(this.Languages);
            languagesList.Add(language);
            languagesList.AddRange(languages);

            this.Languages = languagesList.ToArray();

            return this;
        }

        public TraktFilter WithLanguages(string language, params string[] languages)
        {
            this.Languages = new string[languages.Length + 1];

            this.Languages[0] = language;

            for (int i = 0; i < languages.Length; i++)
                this.Languages[i + 1] = languages[i];

            return this;
        }

        public TraktFilter AddCountries(string country, params string[] countries)
        {
            var countriesList = new List<string>();

            countriesList.AddRange(this.Countries);
            countriesList.Add(country);
            countriesList.AddRange(countries);

            this.Countries = countriesList.ToArray();

            return this;
        }

        public TraktFilter WithCountries(string country, params string[] countries)
        {
            this.Countries = new string[countries.Length + 1];

            this.Countries[0] = country;

            for (int i = 0; i < countries.Length; i++)
                this.Countries[i + 1] = countries[i];

            return this;
        }

        public TraktFilter WithRuntimes(int from, int to)
        {
            Runtimes = new Range<int>(from, to);
            return this;
        }

        public TraktFilter WithRatings(int from, int to)
        {
            Ratings = new Range<int>(from, to);
            return this;
        }

        public override string ToString()
        {
            var parameters = new List<string>();

            if (!string.IsNullOrEmpty(Query))
                parameters.Add($"query={Query}");

            if (Years >= 0 && Years.ToString().Length == 4)
                parameters.Add($"years={Years.ToString()}");

            if (Genres != null && Genres.Length > 0)
                parameters.Add($"genres={string.Join(",", Genres)}");

            if (Languages != null && Languages.Length > 0)
                parameters.Add($"languages={string.Join(",", Languages)}");

            if (Countries != null && Countries.Length > 0)
                parameters.Add($"countries={string.Join(",", Countries)}");

            if (Runtimes != null && Runtimes.From >= 0 && Runtimes.To >= Runtimes.From)
                parameters.Add($"runtimes={Runtimes.From.ToString()}-{Runtimes.To.ToString()}");

            if (Ratings != null && Ratings.From >= 0 && Ratings.To >= Ratings.From && Ratings.To <= 100)
                parameters.Add($"ratings={Ratings.From.ToString()}-{Ratings.To.ToString()}");

            return string.Join("&", parameters);
        }
    }
}
