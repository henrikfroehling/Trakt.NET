namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Utils;

    public interface ITraktFilter
    {
        /// <summary>Optional search titles and descriptions.</summary>
        string Query { get; }

        /// <summary>Optional 4 digit year.</summary>
        uint? Year { get; }

        /// <summary>Optional range of 4 digit years.</summary>
        Range<uint>? Years { get; }

        /// <summary>Optional genre slugs.</summary>
        string[] Genres { get; }

        /// <summary>Optional 2 character language codes.</summary>
        string[] Languages { get; }

        /// <summary>Optional 2 character country codes.</summary>
        string[] Countries { get; }

        /// <summary>Optional runtime range in minutes.</summary>
        Range<uint>? Runtimes { get; }

        /// <summary>Optional studio slugs.</summary>
        string[] Studios { get; }

        /// <summary>Returns whether the filter has any values set.</summary>
        bool HasValues { get; }

        /// <summary>Returns a list of key value pairs of set filter values.</summary>
        /// <returns>A list of key value pairs of set filter values.</returns>
        IDictionary<string, object> GetParameters();

        /// <summary>Returns a string representation of set filter values.</summary>
        /// <returns>A string representation of set filter values.</returns>
        string ToString();
    }
}
