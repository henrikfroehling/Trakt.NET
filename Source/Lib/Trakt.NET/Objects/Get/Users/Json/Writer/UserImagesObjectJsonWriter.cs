namespace TraktNet.Objects.Get.Users.Json.Writer
{
    using Basic.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserImagesObjectJsonWriter : AObjectJsonWriter<ITraktUserImages>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserImages obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Avatar != null)
            {
                var imageObjectJsonWriter = new ImageObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_IMAGES_PROPERTY_NAME_AVATAR, cancellationToken).ConfigureAwait(false);
                await imageObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Avatar, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
