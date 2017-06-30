namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktMovieReleaseJsonReaderFactory : ITraktJsonReaderFactory<ITraktMovieRelease>
    {
        public ITraktObjectJsonReader<ITraktMovieRelease> CreateObjectReader() => new TraktMovieReleaseObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMovieRelease> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieRelease)} is not supported.");
        }
    }
}
