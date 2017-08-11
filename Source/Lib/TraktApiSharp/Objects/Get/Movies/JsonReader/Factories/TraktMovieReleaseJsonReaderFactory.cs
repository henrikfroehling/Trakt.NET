namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktMovieReleaseJsonReaderFactory : ITraktJsonReaderFactory<ITraktMovieRelease>
    {
        public ITraktObjectJsonReader<ITraktMovieRelease> CreateObjectReader() => new TraktMovieReleaseObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMovieRelease> CreateArrayReader() => new TraktMovieReleaseArrayJsonReader();
    }
}
