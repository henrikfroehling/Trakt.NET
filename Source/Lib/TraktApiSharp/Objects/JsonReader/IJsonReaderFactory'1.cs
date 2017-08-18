namespace TraktApiSharp.Objects.JsonReader
{
    internal interface IJsonReaderFactory<TReturnType>
    {
        ITraktObjectJsonReader<TReturnType> CreateObjectReader();

        IArrayJsonReader<TReturnType> CreateArrayReader();
    }
}
