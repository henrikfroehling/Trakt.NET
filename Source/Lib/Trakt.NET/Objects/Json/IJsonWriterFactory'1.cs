namespace TraktNet.Objects.Json
{
    internal interface IJsonWriterFactory<TObjectType>
    {
        IObjectJsonWriter<TObjectType> CreateObjectWriter();
    }
}
