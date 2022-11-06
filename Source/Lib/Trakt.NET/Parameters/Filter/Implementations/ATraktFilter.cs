namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Utils;

    internal abstract class ATraktFilter : ITraktFilter
    {
        public string Query { get; internal set; }

        public uint? Year { get; internal set; }

        public Range<uint>? Years { get; internal set; }

        public string[] Genres { get; internal set; }

        public string[] Languages { get; internal set; }

        public string[] Countries { get; internal set; }

        public Range<uint>? Runtimes { get; internal set; }

        public string[] Studios { get; internal set; }

        public virtual bool HasValues
            => HasQuerySet || HasYearSet || HasYearsSet() || HasGenresSet
            || HasLanguagesSet || HasCountriesSet || HasRuntimesSet() || HasStudiosSet;

        public virtual IDictionary<string, object> GetParameters()
        {
            var parameters = new Dictionary<string, object>();

            if (HasQuerySet)
                parameters.Add("query", Query);

            if (HasYearSet && !HasYearsSet())
                parameters.Add("years", $"{Year.Value}");
            else if (HasYearsSet())
            {
                uint startYear = Years.Value.Begin;
                uint endYear = Years.Value.End;

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
                Range<uint> runtimes = Runtimes.Value;
                parameters.Add("runtimes", $"{runtimes.Begin}-{runtimes.End}");
            }

            if (HasStudiosSet)
                parameters.Add("studios", string.Join(",", Studios));

            return parameters;
        }

        public override string ToString()
        {
            IDictionary<string, object> parameters = GetParameters();

            if (parameters.Count == 0)
                return string.Empty;

            var keyValues = new List<string>();

            foreach (KeyValuePair<string, object> param in parameters)
                keyValues.Add($"{param.Key}={param.Value}");

            return string.Join("&", keyValues);
        }

        protected bool HasQuerySet => !string.IsNullOrEmpty(Query);

        protected bool HasYearSet => Year.HasValue && Year.Value.ToString().Length == 4;

        protected bool HasYearsSet()
        {
            if (Years.HasValue)
            {
                Range<uint> years = Years.Value;
                uint startYear = years.Begin;
                uint endYear = years.End;
                return startYear.ToString().Length == 4 && endYear.ToString().Length == 4;
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
                Range<uint> runtimes = Runtimes.Value;
                return runtimes.Begin > 0 && runtimes.End > 0 && runtimes.End > runtimes.Begin;
            }

            return false;
        }

        protected bool HasStudiosSet => Studios != null && Studios.Length > 0;
    }
}
