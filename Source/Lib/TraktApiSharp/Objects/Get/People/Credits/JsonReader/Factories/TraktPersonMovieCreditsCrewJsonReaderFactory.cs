namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktPersonMovieCreditsCrewJsonReaderFactory : IJsonReaderFactory<ITraktPersonMovieCreditsCrew>
    {
        public ITraktObjectJsonReader<ITraktPersonMovieCreditsCrew> CreateObjectReader() => new TraktPersonMovieCreditsCrewObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCreditsCrew> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonMovieCreditsCrew)} is not supported.");
        }
    }
}
