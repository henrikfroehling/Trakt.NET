namespace TraktNet.Objects.Post.Responses.Json.Writer
{
    using Get.Seasons.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundSeasonObjectJsonWriter : AObjectJsonWriter<ITraktPostResponseNotFoundSeason>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktPostResponseNotFoundSeason obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Ids != null)
            {
                var seasonIdsObjectJsonWriter = new SeasonIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.POST_RESPONSE_NOT_FOUND_EPISODE_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await seasonIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
