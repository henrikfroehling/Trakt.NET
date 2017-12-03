namespace TraktApiSharp.Objects.Json
{
    internal interface IJsonReaderFactory<TReturnType>
    {
        IObjectJsonReader<TReturnType> CreateObjectReader();

        IArrayJsonReader<TReturnType> CreateArrayReader();
    }
}
