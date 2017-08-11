namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserCustomListItemsPostResponseNotFoundGroupJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserCustomListItemsPostResponseNotFoundGroup>
    {
        public ITraktObjectJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup> CreateObjectReader() => new TraktUserCustomListItemsPostResponseNotFoundGroupObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPostResponseNotFoundGroup)} is not supported.");
        }
    }
}
