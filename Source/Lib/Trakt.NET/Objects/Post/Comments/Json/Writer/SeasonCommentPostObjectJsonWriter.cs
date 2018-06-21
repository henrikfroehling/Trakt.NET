namespace TraktNet.Objects.Post.Comments.Json.Writer
{
    using Get.Seasons.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonCommentPostObjectJsonWriter : ACommentPostObjectJsonWriter<ITraktSeasonCommentPost>
    {
        protected override async Task WriteCommentObjectAsync(JsonTextWriter jsonWriter, ITraktSeasonCommentPost obj, CancellationToken cancellationToken = default)
        {
            if (obj.Season != null)
            {
                var seasonObjectJsonWriter = new SeasonObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SEASON_COMMENT_POST_PROPERTY_NAME_SEASON, cancellationToken).ConfigureAwait(false);
                await seasonObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Season, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
