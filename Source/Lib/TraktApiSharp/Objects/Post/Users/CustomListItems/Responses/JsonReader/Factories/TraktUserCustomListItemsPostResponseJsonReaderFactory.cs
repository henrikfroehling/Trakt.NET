namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserCustomListItemsPostResponseJsonReaderFactory : IJsonReaderFactory<ITraktUserCustomListItemsPostResponse>
    {
        public ITraktObjectJsonReader<ITraktUserCustomListItemsPostResponse> CreateObjectReader() => new TraktUserCustomListItemsPostResponseObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserCustomListItemsPostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPostResponse)} is not supported.");
        }
    }
}
