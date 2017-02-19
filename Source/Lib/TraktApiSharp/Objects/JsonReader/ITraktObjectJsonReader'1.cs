namespace TraktApiSharp.Objects.JsonReader
{
    internal interface ITraktObjectJsonReader<TReturnType>
    {
        TReturnType Read(string json);
    }
}
