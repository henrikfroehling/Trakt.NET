namespace TraktNet.Objects.Post.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListsReorderPostObjectJsonReader : AObjectJsonReader<ITraktUserCustomListsReorderPost>
    {
        public override async Task<ITraktUserCustomListsReorderPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserCustomListsReorderPost)).ConfigureAwait(false);

            if (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserCustomListsReorderPost customListsReorderPost = new TraktUserCustomListsReorderPost();

                while (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.USER_CUSTOM_LISTS_REORDER_POST_PROPERTY_NAME_RANK:
                            customListsReorderPost.Rank = await JsonReaderHelper.ReadUnsignedIntegerArrayAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                    }
                }

                return customListsReorderPost;
            }

            return await Task.FromResult(default(ITraktUserCustomListsReorderPost)).ConfigureAwait(false);
        }
    }
}
