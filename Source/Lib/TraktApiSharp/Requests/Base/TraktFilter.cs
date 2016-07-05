namespace TraktApiSharp.Requests.Base
{
    using System;
    using System.Collections.Generic;

    public class TraktFilter
    {
        public TraktFilter() { }

        public TraktFilter(string query, int years, string[] genres = null, string[] languages = null,
                           string[] countries = null, Range<int> runtimes = null, Range<int> ratings = null)
        {
            WithQuery(query);
            WithYears(years);
            WithGenres(null, genres);
            WithLanguages(null, languages);
            WithCountries(null, countries);
            WithRuntimes(runtimes.Begin, runtimes.End);
            WithRatings(ratings.Begin, ratings.End);
        }

        public string Query { get; protected set; }

        public int Years { get; protected set; }

        public string[] Genres { get; protected set; }

        public string[] Languages { get; protected set; }

        public string[] Countries { get; protected set; }

        public Range<int> Runtimes { get; protected set; }

        public Range<int> Ratings { get; protected set; }

        public TraktFilter WithQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("query not valid", nameof(query));

            Query = query;
            return this;
        }

        public TraktFilter WithYears(int years)
        {
            var length = years.ToString().Length;

            if (years < 0 || length > 4 || length < 4)
                throw new ArgumentException("years not valid", nameof(years));

            Years = years;
            return this;
        }

        public TraktFilter AddGenres(string genre, params string[] genres)
        {
            return AddGenres(true, genre, genres);
        }

        public TraktFilter WithGenres(string genre, params string[] genres)
        {
            return AddGenres(false, genre, genres);
        }

        public TraktFilter AddLanguages(string language, params string[] languages)
        {
            return AddLanguages(true, language, languages);
        }

        public TraktFilter WithLanguages(string language, params string[] languages)
        {
            return AddLanguages(false, language, languages);
        }

        public TraktFilter AddCountries(string country, params string[] countries)
        {
            return AddCountries(true, country, countries);
        }

        public TraktFilter WithCountries(string country, params string[] countries)
        {
            return AddCountries(false, country, countries);
        }

        public TraktFilter WithRuntimes(int begin, int end)
        {
            if (begin < 0 || end < 0 || end < begin)
                throw new ArgumentException("runtimes not valid");

            Runtimes = new Range<int>(begin, end);
            return this;
        }

        public TraktFilter WithRatings(int begin, int end)
        {
            if (begin < 0 || end < 0 || end < begin || end > 100)
                throw new ArgumentException("ratings not valid");

            Ratings = new Range<int>(begin, end);
            return this;
        }

        public virtual void Clear()
        {
            Query = null;
            Years = 0;
            Genres = null;
            Languages = null;
            Countries = null;
            Runtimes = null;
            Ratings = null;
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

        private TraktFilter AddGenres(bool keepExisting, string genre, params string[] genres)
        {
            var genresList = new List<string>();

            if (keepExisting && this.Genres != null && this.Genres.Length > 0)
                genresList.AddRange(this.Genres);

            if (!string.IsNullOrEmpty(genre))
                genresList.Add(genre);

            if (genres != null && genres.Length > 0)
                genresList.AddRange(genres);

            this.Genres = genresList.ToArray();

            return this;
        }

        private TraktFilter AddLanguages(bool keepExisting, string language, params string[] languages)
        {
            var languagesList = new List<string>();

            if (keepExisting && this.Languages != null && this.Languages.Length > 0)
                languagesList.AddRange(this.Languages);

            if (!string.IsNullOrEmpty(language))
            {
                if (language.Length > 2 || language.Length < 2)
                    throw new ArgumentException("language not valid", nameof(language));

                languagesList.Add(language);
            }

            if (languages != null && languages.Length > 0)
            {
                for (int i = 0; i < languages.Length; i++)
                {
                    if (languages[i].Length > 2 || languages[i].Length < 2)
                        throw new ArgumentException("language not valid", nameof(languages));
                }

                languagesList.AddRange(languages);
            }

            this.Languages = languagesList.ToArray();

            return this;
        }

        private TraktFilter AddCountries(bool keepExisting, string country, params string[] countries)
        {
            var countriesList = new List<string>();

            if (keepExisting && this.Countries != null && this.Countries.Length > 0)
                countriesList.AddRange(this.Countries);

            if (!string.IsNullOrEmpty(country))
            {
                if (country.Length > 2 || country.Length < 2)
                    throw new ArgumentException("country not valid", nameof(country));

                countriesList.Add(country);
            }

            if (countries != null && countries.Length > 0)
            {
                for (int i = 0; i < countries.Length; i++)
                {
                    if (countries[i].Length > 2 || countries[i].Length < 2)
                        throw new ArgumentException("country not valid", nameof(countries));
                }

                countriesList.AddRange(countries);
            }

            this.Countries = countriesList.ToArray();

            return this;
        }
    }
}
