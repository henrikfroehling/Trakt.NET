namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ErrorArrayJsonReader : AArrayJsonReader<ITraktError>
    {
        public override async Task<IEnumerable<ITraktError>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktError>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var errorReader = new ErrorObjectJsonReader();
                var errors = new List<ITraktError>();
                ITraktError error = await errorReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (error != null)
                {
                    errors.Add(error);
                    error = await errorReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return errors;
            }

            return await Task.FromResult(default(IEnumerable<ITraktError>));
        }
    }
}
