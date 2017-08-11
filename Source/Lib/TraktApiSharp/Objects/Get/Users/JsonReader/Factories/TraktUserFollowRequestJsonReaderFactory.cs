namespace TraktApiSharp.Objects.Get.Users.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktUserFollowRequestJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserFollowRequest>
    {
        public ITraktObjectJsonReader<ITraktUserFollowRequest> CreateObjectReader() => new TraktUserFollowRequestObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserFollowRequest> CreateArrayReader() => new TraktUserFollowRequestArrayJsonReader();
    }
}
