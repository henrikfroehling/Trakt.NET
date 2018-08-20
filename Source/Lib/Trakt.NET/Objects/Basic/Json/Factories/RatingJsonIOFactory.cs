namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class RatingJsonIOFactory : IJsonIOFactory<ITraktRating>
    {
        public IObjectJsonReader<ITraktRating> CreateObjectReader() => new RatingObjectJsonReader();

        public IArrayJsonReader<ITraktRating> CreateArrayReader() => new RatingArrayJsonReader();

        public IObjectJsonWriter<ITraktRating> CreateObjectWriter() => new RatingObjectJsonWriter();
    }
}
