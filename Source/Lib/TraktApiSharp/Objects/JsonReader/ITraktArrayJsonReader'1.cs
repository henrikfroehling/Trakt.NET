namespace TraktApiSharp.Objects.JsonReader
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    internal interface ITraktArrayJsonReader<TReturnType> where TReturnType : class, new()
    {
        IEnumerable<TReturnType> ReadArray(string json);

        IEnumerable<TReturnType> ReadArray(JsonTextReader jsonReader);
    }
}
