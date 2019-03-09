namespace TraktNet.Requests.Parameters.Filter
{
    using System.Collections.Generic;
    using Utils;

    public abstract class ATraktFilter : ITraktFilter
    {
        public string Query { get; internal set; }

        public int? Year { get; internal set; }

        public Range<int>? Years { get; internal set; }

        public string[] Genres { get; internal set; }

        public string[] Languages { get; internal set; }

        public string[] Countries { get; internal set; }

        public Range<int>? Runtimes { get; internal set; }

        public Range<int>? Ratings { get; internal set; }

        public virtual bool HasValues => HasQuerySet || HasYearSet || HasYearsSet() || HasGenresSet || HasLanguagesSet || HasCountriesSet || HasRuntimesSet() || HasRatingsSet();

        public virtual IDictionary<string, object> GetParameters()
        {
            var parameters = new Dictionary<string, object>();

            if (HasQuerySet)
                parameters.Add("query", Query);

            if (HasYearSet && !HasYearsSet())
                parameters.Add("years", $"{Year.Value}");
            else if (!HasYearSet && HasYearsSet())
            {
                int startYear = Years.Value.Begin;
                int endYear = Years.Value.End;

                if (startYear <= endYear)
                    parameters.Add("years", $"{startYear}-{endYear}");
                else
                    parameters.Add("years", $"{endYear}-{startYear}");
            }

            if (HasGenresSet)
                parameters.Add("genres", string.Join(",", Genres));

            if (HasLanguagesSet)
                parameters.Add("languages", string.Join(",", Languages));

            if (HasCountriesSet)
                parameters.Add("countries", string.Join(",", Countries));

            if (HasRuntimesSet())
            {
                var runtimes = Runtimes.Value;
                parameters.Add("runtimes", $"{runtimes.Begin}-{runtimes.End}");
            }

            if (HasRatingsSet())
            {
                var ratings = Ratings.Value;
                parameters.Add("ratings", $"{ratings.Begin}-{ratings.End}");
            }

            return parameters;
        }

        public override string ToString()
        {
            var parameters = GetParameters();

            if (parameters.Count <= 0)
                return string.Empty;

            var keyValues = new List<string>();

            foreach (var param in parameters)
                keyValues.Add($"{param.Key}={param.Value}");

            return string.Join("&", keyValues);
        }

        protected bool HasQuerySet => !string.IsNullOrEmpty(Query);

        protected bool HasYearSet => Year.HasValue && Year.Value.ToString().Length == 4;

        protected bool HasYearsSet()
        {
            if (Years.HasValue)
            {
                Range<int> years = Years.Value;
                int startYear = years.Begin;
                int endYear = years.End;
                return startYear <= endYear && startYear.ToString().Length == 4 && endYear.ToString().Length == 4;
            }

            return false;
        }

        protected bool HasGenresSet => Genres != null && Genres.Length > 0;

        protected bool HasLanguagesSet => Languages != null && Languages.Length > 0;

        protected bool HasCountriesSet => Countries != null && Countries.Length > 0;

        protected bool HasRuntimesSet()
        {
            if (Runtimes.HasValue)
            {
                Range<int> runtimes = Runtimes.Value;
                return runtimes.Begin > 0 && runtimes.End > 0 && runtimes.End > runtimes.Begin;
            }

            return false;
        }

        protected bool HasRatingsSet()
        {
            if (Ratings.HasValue)
            {
                Range<int> ratings = Ratings.Value;
                return ratings.Begin > 0 && ratings.End > 0 && ratings.End > ratings.Begin && ratings.End <= 100;
            }

            return false;
        }
    }
}
