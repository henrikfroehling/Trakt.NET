namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserFollowRequestJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserFollowRequest>
    {
        public ITraktObjectJsonReader<ITraktUserFollowRequest> CreateObjectReader() => new TraktUserFollowRequestObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserFollowRequest> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserFollowRequest)} is not supported.");
        }
    }
}
