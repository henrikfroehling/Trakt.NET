namespace TraktApiSharp.Objects.JsonReader
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    internal interface ITraktArrayJsonReader<TReturnType>
    {
        IEnumerable<TReturnType> ReadArray(string json);

        IEnumerable<TReturnType> ReadArray(JsonTextReader jsonReader);
    }
}
