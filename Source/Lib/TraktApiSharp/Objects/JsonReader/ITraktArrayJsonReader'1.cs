namespace TraktApiSharp.Objects.JsonReader
{
    using System.Collections.Generic;

    internal interface ITraktArrayJsonReader<TReturnType> where TReturnType : class, new()
    {
        IEnumerable<TReturnType> ReadArray(string json);
    }
}
