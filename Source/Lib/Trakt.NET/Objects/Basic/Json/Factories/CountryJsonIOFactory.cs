namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class CountryJsonIOFactory : IJsonIOFactory<ITraktCountry>
    {
        public IObjectJsonReader<ITraktCountry> CreateObjectReader() => new CountryObjectJsonReader();

        public IArrayJsonReader<ITraktCountry> CreateArrayReader() => new CountryArrayJsonReader();

        public IObjectJsonWriter<ITraktCountry> CreateObjectWriter() => new CountryObjectJsonWriter();
    }
}
