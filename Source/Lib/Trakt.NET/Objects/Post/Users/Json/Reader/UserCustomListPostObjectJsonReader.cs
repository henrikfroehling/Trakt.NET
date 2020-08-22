namespace TraktNet.Objects.Post.Users.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListPostObjectJsonReader : AObjectJsonReader<ITraktUserCustomListPost>
    {
        public override async Task<ITraktUserCustomListPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserCustomListPost userCustomListPost = new TraktUserCustomListPost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_NAME:
                            userCustomListPost.Name = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_DESCRIPTION:
                            userCustomListPost.Description = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PRIVACY:
                            userCustomListPost.Privacy = await JsonReaderHelper.ReadEnumerationValueAsync<TraktAccessScope>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_DISPLAY_NUMBERS:
                            userCustomListPost.DisplayNumbers = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_ALLOW_COMMENTS:
                            userCustomListPost.AllowComments = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SORT_BY:
                            userCustomListPost.SortBy = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SORT_HOW:
                            userCustomListPost.SortHow = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return userCustomListPost;
            }

            return await Task.FromResult(default(ITraktUserCustomListPost));
        }
    }
}
