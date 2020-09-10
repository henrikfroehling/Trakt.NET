namespace TraktNet.Objects.Get.Recommendations.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Enums;

    internal abstract class ARecommendationObjectJsonWriter<TRecommendationObjectType> : AObjectJsonWriter<TRecommendationObjectType> where TRecommendationObjectType : ITraktRecommendation
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TRecommendationObjectType obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await WriteRecommendationObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task WriteRecommendationObjectAsync(JsonTextWriter jsonWriter, TRecommendationObjectType obj, CancellationToken cancellationToken = default)
        {
            if (obj.Rank.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_RANK, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Rank.Value, cancellationToken).ConfigureAwait(false);
            }

            if (obj.ListedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LISTED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.ListedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Type != null && obj.Type != TraktRecommendationObjectType.Unspecified)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_TYPE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Type.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Notes))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NOTES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Notes, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
