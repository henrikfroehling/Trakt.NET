namespace TraktNet.Objects.Get.Users.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Enums;

    internal class UserSavedFilterObjectJsonWriter : AObjectJsonWriter<ITraktUserSavedFilter>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserSavedFilter obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_ID, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Id, cancellationToken).ConfigureAwait(false);

            if (obj.Rank.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_RANK, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Rank.Value, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Section != null && obj.Section != TraktFilterSection.Unspecified)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SECTION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Section.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Name))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NAME, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Name, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Path))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_PATH, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Path, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Query))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_QUERY, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Query, cancellationToken).ConfigureAwait(false);
            }

            if (obj.UpdatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_UPDATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.UpdatedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
