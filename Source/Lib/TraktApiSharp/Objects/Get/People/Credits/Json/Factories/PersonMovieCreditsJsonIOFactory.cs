namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Get.People.Credits.Json.Writer;
    using Objects.Json;
    using System;

    internal class PersonMovieCreditsJsonIOFactory : IJsonIOFactory<ITraktPersonMovieCredits>
    {
        public IObjectJsonReader<ITraktPersonMovieCredits> CreateObjectReader() => new PersonMovieCreditsObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCredits> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonMovieCredits)} is not supported.");

        public IObjectJsonWriter<ITraktPersonMovieCredits> CreateObjectWriter() => new PersonMovieCreditsObjectJsonWriter();

        public IArrayJsonWriter<ITraktPersonMovieCredits> CreateArrayWriter()
            => throw new NotSupportedException($"A array json writer for {nameof(ITraktPersonMovieCredits)} is not supported.");
    }
}
