namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Objects.Json;
    using System;

    internal class PersonMovieCreditsJsonIOFactory : IJsonIOFactory<ITraktPersonMovieCredits>
    {
        public IObjectJsonReader<ITraktPersonMovieCredits> CreateObjectReader() => new PersonMovieCreditsObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCredits> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonMovieCredits)} is not supported.");
        }

        public IObjectJsonWriter<ITraktPersonMovieCredits> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktPersonMovieCredits> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
