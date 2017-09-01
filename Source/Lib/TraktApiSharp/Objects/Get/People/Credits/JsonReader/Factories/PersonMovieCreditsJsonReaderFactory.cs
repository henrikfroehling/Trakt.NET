namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class PersonMovieCreditsJsonReaderFactory : IJsonReaderFactory<ITraktPersonMovieCredits>
    {
        public IObjectJsonReader<ITraktPersonMovieCredits> CreateObjectReader() => new TraktPersonMovieCreditsObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCredits> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonMovieCredits)} is not supported.");
        }
    }
}
