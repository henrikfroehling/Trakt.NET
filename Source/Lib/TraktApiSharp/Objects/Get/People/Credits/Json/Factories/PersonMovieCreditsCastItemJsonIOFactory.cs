namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Objects.Json;

    internal class PersonMovieCreditsCastItemJsonIOFactory : IJsonIOFactory<ITraktPersonMovieCreditsCastItem>
    {
        public IObjectJsonReader<ITraktPersonMovieCreditsCastItem> CreateObjectReader() => new PersonMovieCreditsCastItemObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCreditsCastItem> CreateArrayReader() => new PersonMovieCreditsCastItemArrayJsonReader();

        public IObjectJsonWriter<ITraktPersonMovieCreditsCastItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktPersonMovieCreditsCastItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
