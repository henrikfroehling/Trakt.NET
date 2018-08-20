namespace TraktNet.Objects.Authentication.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AuthorizationArrayJsonReader : AArrayJsonReader<ITraktAuthorization>
    {
        public override async Task<IEnumerable<ITraktAuthorization>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktAuthorization>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var authorizationReader = new AuthorizationObjectJsonReader();
                var authorizations = new List<ITraktAuthorization>();
                ITraktAuthorization authorization = await authorizationReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (authorization != null)
                {
                    authorizations.Add(authorization);
                    authorization = await authorizationReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return authorizations;
            }

            return await Task.FromResult(default(IEnumerable<ITraktAuthorization>));
        }
    }
}
