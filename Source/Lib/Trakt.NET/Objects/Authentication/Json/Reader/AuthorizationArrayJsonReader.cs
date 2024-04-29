namespace TraktNet.Objects.Authentication.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AuthorizationArrayJsonReader : ArrayJsonReader<ITraktAuthorization>
    {
        internal bool CompleteDeserialization { get; set; }

        public override async Task<IList<ITraktAuthorization>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IList<ITraktAuthorization>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var authorizationReader = new AuthorizationObjectJsonReader
                {
                    CompleteDeserialization = CompleteDeserialization
                };

                var authorizations = new List<ITraktAuthorization>();
                ITraktAuthorization authorization = await authorizationReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (authorization != null)
                {
                    authorizations.Add(authorization);
                    authorization = await authorizationReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return authorizations;
            }

            return await Task.FromResult(default(IList<ITraktAuthorization>));
        }
    }
}
