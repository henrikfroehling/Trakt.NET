namespace TraktNet.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Get.People.Credits.Json.Writer;
    using Objects.Json;

    internal class PersonMovieCreditsCastItemJsonIOFactory : IJsonIOFactory<ITraktPersonMovieCreditsCastItem>
    {
        public IObjectJsonReader<ITraktPersonMovieCreditsCastItem> CreateObjectReader() => new PersonMovieCreditsCastItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCreditsCastItem> CreateArrayReader() => new PersonMovieCreditsCastItemArrayJsonReader();

        public IObjectJsonWriter<ITraktPersonMovieCreditsCastItem> CreateObjectWriter() => new PersonMovieCreditsCastItemObjectJsonWriter();
    }
}
