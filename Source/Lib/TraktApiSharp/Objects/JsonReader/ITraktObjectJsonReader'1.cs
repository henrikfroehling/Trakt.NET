namespace TraktApiSharp.Objects.JsonReader
{
    internal interface ITraktObjectJsonReader<TReturnType>
    {
        TReturnType ReadObject(string json);
    }
}
