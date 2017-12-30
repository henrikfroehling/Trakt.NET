namespace TraktApiSharp.Objects.Json
{
    internal interface IJsonWriterFactory<TObjectType>
    {
        IObjectJsonReader<TObjectType> CreateObjectWriter();

        IArrayJsonReader<TObjectType> CreateArrayWriter();
    }
}
