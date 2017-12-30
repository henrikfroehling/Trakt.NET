namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Objects.Json;
    using System;

    internal class PersonMovieCreditsCrewJsonReaderFactory : IJsonIOFactory<ITraktPersonMovieCreditsCrew>
    {
        public IObjectJsonReader<ITraktPersonMovieCreditsCrew> CreateObjectReader() => new PersonMovieCreditsCrewObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCreditsCrew> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonMovieCreditsCrew)} is not supported.");
        }

        public IObjectJsonReader<ITraktPersonMovieCreditsCrew> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktPersonMovieCreditsCrew> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
