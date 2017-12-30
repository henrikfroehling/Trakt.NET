namespace TraktApiSharp.Objects.Json
{
    internal interface IJsonReaderFactory<TObjectType>
    {
        IObjectJsonReader<TObjectType> CreateObjectReader();

        IArrayJsonReader<TObjectType> CreateArrayReader();
    }
}
