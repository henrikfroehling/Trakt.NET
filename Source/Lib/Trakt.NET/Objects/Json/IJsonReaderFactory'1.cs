namespace TraktNet.Objects.Json
{
    internal interface IJsonReaderFactory<TObjectType>
    {
        IObjectJsonReader<TObjectType> CreateObjectReader();
    }
}
