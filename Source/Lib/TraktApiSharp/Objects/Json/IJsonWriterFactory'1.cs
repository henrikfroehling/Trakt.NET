namespace TraktApiSharp.Objects.Json
{
    internal interface IJsonWriterFactory<TObjectType>
    {
        IObjectJsonWriter<TObjectType> CreateObjectWriter();
    }
}
