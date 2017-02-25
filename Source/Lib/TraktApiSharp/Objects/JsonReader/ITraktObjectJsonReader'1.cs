namespace TraktApiSharp.Objects.JsonReader
{
    using Newtonsoft.Json;

    internal interface ITraktObjectJsonReader<TReturnType> where TReturnType : class, new()
    {
        TReturnType ReadObject(string json);

        TReturnType ReadObject(JsonTextReader jsonReader);
    }
}
