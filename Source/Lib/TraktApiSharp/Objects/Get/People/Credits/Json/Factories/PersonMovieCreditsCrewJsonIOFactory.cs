namespace TraktApiSharp.Objects.Get.People.Credits.Json.Factories
{
    using Get.People.Credits.Json.Reader;
    using Get.People.Credits.Json.Writer;
    using Objects.Json;
    using System;

    internal class PersonMovieCreditsCrewJsonIOFactory : IJsonIOFactory<ITraktPersonMovieCreditsCrew>
    {
        public IObjectJsonReader<ITraktPersonMovieCreditsCrew> CreateObjectReader() => new PersonMovieCreditsCrewObjectJsonReader();

        public IArrayJsonReader<ITraktPersonMovieCreditsCrew> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktPersonMovieCreditsCrew)} is not supported.");

        public IObjectJsonWriter<ITraktPersonMovieCreditsCrew> CreateObjectWriter() => new PersonMovieCreditsCrewObjectJsonWriter();
    }
}
