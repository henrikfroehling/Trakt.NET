namespace TraktNet.Objects.Post.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListItemUpdatePostObjectJsonReader : AObjectJsonReader<ITraktListItemUpdatePost>
    {
        public override async Task<ITraktListItemUpdatePost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktListItemUpdatePost listItemUpdatePost = new TraktListItemUpdatePost();

                while (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_NOTES:
                            listItemUpdatePost.Notes = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                    }
                }

                return listItemUpdatePost;
            }

            return await Task.FromResult(default(ITraktListItemUpdatePost)).ConfigureAwait(false);
        }
    }
}
