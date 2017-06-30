namespace TraktApiSharp.Objects.JsonReader
{
    internal interface ITraktJsonReaderFactory<TReturnType>
    {
        ITraktObjectJsonReader<TReturnType> CreateObjectReader();

        ITraktArrayJsonReader<TReturnType> CreateArrayReader();
    }
}
