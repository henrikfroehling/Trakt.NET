namespace TraktNet.Objects.Basic.Json.Reader
{
    using Get.Users.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentObjectJsonReader : AObjectJsonReader<ITraktComment>
    {
        public override async Task<ITraktComment> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktComment traktComment = new TraktComment();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktComment.Id = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_PARENT_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktComment.ParentId = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_CREATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktComment.CreatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktComment.UpdatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_COMMENT:
                            traktComment.Comment = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SPOILER:
                            traktComment.Spoiler = (bool)await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_REVIEW:
                            traktComment.Review = (bool)await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_REPLIES:
                            traktComment.Replies = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LIKES:
                            traktComment.Likes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_USER_STATS:
                            {
                                var userStatsReader = new CommentUserStatsObjectJsonReader();
                                traktComment.UserStats = await userStatsReader.ReadObjectAsync(jsonReader, cancellationToken);
                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_USER:
                            {
                                var userReader = new UserObjectJsonReader();
                                traktComment.User = await userReader.ReadObjectAsync(jsonReader, cancellationToken);
                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktComment;
            }

            return await Task.FromResult(default(ITraktComment));
        }
    }
}
