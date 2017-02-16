namespace TraktApiSharp.Objects.JsonReader
{
    internal interface ITraktJsonReader<TReturnType>
    {
        TReturnType Read(string json);
    }
}
