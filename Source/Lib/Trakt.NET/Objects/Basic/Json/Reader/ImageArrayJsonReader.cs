namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ImageArrayJsonReader : ArrayJsonReader<ITraktImage>
    {
        public override async Task<IEnumerable<ITraktImage>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktImage>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var imageReader = new ImageObjectJsonReader();
                var images = new List<ITraktImage>();
                ITraktImage image = await imageReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (image != null)
                {
                    images.Add(image);
                    image = await imageReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return images;
            }

            return await Task.FromResult(default(IEnumerable<ITraktImage>));
        }
    }
}
