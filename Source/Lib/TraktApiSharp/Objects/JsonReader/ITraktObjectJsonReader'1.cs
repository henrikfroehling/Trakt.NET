namespace TraktApiSharp.Objects.JsonReader
{
    internal interface ITraktObjectJsonReader<TReturnType> where TReturnType : class, new()
    {
        TReturnType ReadObject(string json);
    }
}
