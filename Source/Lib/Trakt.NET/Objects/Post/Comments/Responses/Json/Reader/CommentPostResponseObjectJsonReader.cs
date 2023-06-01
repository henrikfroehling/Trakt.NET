namespace TraktNet.Objects.Post.Comments.Responses.Json.Reader
{
    using Get.Users.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentPostResponseObjectJsonReader : AObjectJsonReader<ITraktCommentPostResponse>
    {
        public override async Task<ITraktCommentPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktCommentPostResponse traktCommentPostResponse = new TraktCommentPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCommentPostResponse.Id = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_PARENT_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCommentPostResponse.ParentId = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_CREATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCommentPostResponse.CreatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCommentPostResponse.UpdatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_COMMENT:
                            traktCommentPostResponse.Comment = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SPOILER:
                            traktCommentPostResponse.Spoiler = (bool)await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_REVIEW:
                            traktCommentPostResponse.Review = (bool)await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_REPLIES:
                            traktCommentPostResponse.Replies = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LIKES:
                            traktCommentPostResponse.Likes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_USER_STATS:
                            {
                                var userStatsReader = new CommentUserStatsObjectJsonReader();
                                traktCommentPostResponse.UserStats = await userStatsReader.ReadObjectAsync(jsonReader, cancellationToken);
                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_USER:
                            {
                                var userReader = new UserObjectJsonReader();
                                traktCommentPostResponse.User = await userReader.ReadObjectAsync(jsonReader, cancellationToken);
                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_SHARING:
                            {
                                var sharingReader = new ConnectionsObjectJsonReader();
                                traktCommentPostResponse.Sharing = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);
                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktCommentPostResponse;
            }

            return await Task.FromResult(default(ITraktCommentPostResponse));
        }
    }
}
