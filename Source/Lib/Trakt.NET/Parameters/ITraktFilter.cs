namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Utils;

    public interface ITraktFilter
    {
        string Query { get; set; }

        int? Year { get; set; }

        Range<int>? Years { get; set; }

        string[] Genres { get; set; }

        string[] Languages { get; set; }

        string[] Countries { get; set; }

        Range<int>? Runtimes { get; set; }

        string[] Studios { get; set; }

        bool HasValues { get; }

        IDictionary<string, object> GetParameters();

        string ToString();
    }
}
