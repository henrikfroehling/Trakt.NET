namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktPersonMovieCreditsJsonReaderFactory : IJsonReaderFactory<ITraktPersonMovieCredits>
    {
        public ITraktObjectJsonReader<ITraktPersonMovieCredits> CreateObjectReader() => new TraktPersonMovieCreditsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktPersonMovieCredits> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonMovieCredits)} is not supported.");
        }
    }
}
