namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktMovieTranslationJsonReaderFactory : ITraktJsonReaderFactory<ITraktMovieTranslation>
    {
        public ITraktObjectJsonReader<ITraktMovieTranslation> CreateObjectReader() => new TraktMovieTranslationObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMovieTranslation> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieTranslation)} is not supported.");
        }
    }
}
