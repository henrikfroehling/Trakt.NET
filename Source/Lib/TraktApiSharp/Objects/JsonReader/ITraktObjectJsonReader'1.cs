namespace TraktApiSharp.Objects.JsonReader
{
    using Newtonsoft.Json;

    internal interface ITraktObjectJsonReader<TReturnType>
    {
        TReturnType ReadObject(string json);

        TReturnType ReadObject(JsonTextReader jsonReader);
    }
}
