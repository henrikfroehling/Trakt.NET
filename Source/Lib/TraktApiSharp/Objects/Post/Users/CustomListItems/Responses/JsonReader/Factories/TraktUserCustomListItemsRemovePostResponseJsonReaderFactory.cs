namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserCustomListItemsRemovePostResponseJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserCustomListItemsRemovePostResponse>
    {
        public ITraktObjectJsonReader<ITraktUserCustomListItemsRemovePostResponse> CreateObjectReader() => new TraktUserCustomListItemsRemovePostResponseObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserCustomListItemsRemovePostResponse> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsRemovePostResponse)} is not supported.");
        }
    }
}
