namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class UserCustomListItemsPostResponseNotFoundGroupJsonReaderFactory : IJsonReaderFactory<ITraktUserCustomListItemsPostResponseNotFoundGroup>
    {
        public IObjectJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup> CreateObjectReader() => new TraktUserCustomListItemsPostResponseNotFoundGroupObjectJsonReader();

        public IArrayJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserCustomListItemsPostResponseNotFoundGroup)} is not supported.");
        }
    }
}
