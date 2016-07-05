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

        public TraktFilter WithRuntimes(int begin, int end)
        {
            Runtimes = new Range<int>(begin, end);
            return this;
        }

        public TraktFilter WithRatings(int begin, int end)
        {
            Ratings = new Range<int>(begin, end);
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

            if (Runtimes != null && Runtimes.Begin >= 0 && Runtimes.End >= Runtimes.Begin)
                parameters.Add($"runtimes={Runtimes.Begin.ToString()}-{Runtimes.End.ToString()}");

            if (Ratings != null && Ratings.Begin >= 0 && Ratings.End >= Ratings.Begin && Ratings.End <= 100)
                parameters.Add($"ratings={Ratings.Begin.ToString()}-{Ratings.End.ToString()}");

            return parameters.Count > 0 ? string.Join("&", parameters) : string.Empty;
        }
    }
}
