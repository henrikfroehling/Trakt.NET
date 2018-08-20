namespace TraktNet.Objects.Post.Comments.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentUpdatePostObjectJsonReader : AObjectJsonReader<ITraktCommentUpdatePost>
    {
        public override async Task<ITraktCommentUpdatePost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktCommentUpdatePost));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktCommentUpdatePost commentUpdatePost = new TraktCommentUpdatePost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.COMMENT_UPDATE_POST_PROPERTY_NAME_COMMENT:
                            commentUpdatePost.Comment = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.COMMENT_UPDATE_POST_PROPERTY_NAME_SPOILER:
                            {
                                bool? value = await jsonReader.ReadAsBooleanAsync(cancellationToken);

                                if (value.HasValue)
                                    commentUpdatePost.Spoiler = value.Value;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return commentUpdatePost;
            }

            return await Task.FromResult(default(ITraktCommentUpdatePost));
        }
    }
}
