namespace TraktNet.Services
{
    using Objects.Authentication;
    using Objects.Authentication.Json.Reader;
    using Objects.Authentication.Json.Writer;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides helper methods for serializing and deserializing Trakt objects.</summary>
    public static class TraktSerializationService
    {
        public static Task<string> SerializeAsync(ITraktAuthorization authorization, CancellationToken cancellationToken = default)
        {
            if (authorization == null)
                throw new ArgumentNullException(nameof(authorization), "authorization must not be null");

            IObjectJsonWriter<ITraktAuthorization> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktAuthorization>();
            AuthorizationObjectJsonWriter authorizationObjectJsonWriter = (objectJsonWriter as AuthorizationObjectJsonWriter);
            authorizationObjectJsonWriter.CompleteSerialization = true;
            return authorizationObjectJsonWriter.WriteObjectAsync(authorization, cancellationToken);
        }

        public static Task<ITraktAuthorization> DeserializeAsync(string authorizationJson, CancellationToken cancellationToken = default)
        {
            if (authorizationJson == null)
                throw new ArgumentNullException(nameof(authorizationJson), "authorization json string must not be null");

            if (authorizationJson.Length == 0)
                throw new ArgumentException(nameof(authorizationJson), "authorization json string must not be empty");

            IObjectJsonReader<ITraktAuthorization> objectJsonReader = JsonFactoryContainer.CreateObjectReader<ITraktAuthorization>();
            AuthorizationObjectJsonReader authorizationObjectJsonReader = (objectJsonReader as AuthorizationObjectJsonReader);
            authorizationObjectJsonReader.CompleteDeserialization = true;
            return authorizationObjectJsonReader.ReadObjectAsync(authorizationJson, cancellationToken);
        }

        public static Task<string> SerializeAsync<TObjectType>(TObjectType obj, CancellationToken cancellationToken = default)
        {
            if (EqualityComparer<TObjectType>.Default.Equals(obj, default))
                throw new ArgumentNullException(nameof(obj), "object must not be null");

            IObjectJsonWriter<TObjectType> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<TObjectType>();
            return objectJsonWriter.WriteObjectAsync(obj, cancellationToken);
        }

        public static Task<TObjectType> DeserializeAsync<TObjectType>(string json, CancellationToken cancellationToken = default)
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json), "json string must not be null");

            if (json.Length == 0)
                throw new ArgumentException(nameof(json), "json string must not be empty");

            IObjectJsonReader<TObjectType> objectJsonReader = JsonFactoryContainer.CreateObjectReader<TObjectType>();
            return objectJsonReader.ReadObjectAsync(json, cancellationToken);
        }

        public static Task<string> SerializeCollectionAsync<TObjectType>(IEnumerable<TObjectType> objects, CancellationToken cancellationToken = default)
        {
            if (objects == null)
                throw new ArgumentNullException(nameof(objects), "objects must not be null");

            IArrayJsonWriter<TObjectType> arrayJsonWriter = new ArrayJsonWriter<TObjectType>();
            return arrayJsonWriter.WriteArrayAsync(objects, cancellationToken);
        }

        public static Task<IEnumerable<TObjectType>> DeserializeCollectionAsync<TObjectType>(string json, CancellationToken cancellationToken = default)
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json), "json string must not be null");

            if (json.Length == 0)
                throw new ArgumentException(nameof(json), "json string must not be empty");

            IArrayJsonReader<TObjectType> arrayJsonReader = JsonFactoryContainer.CreateArrayReader<TObjectType>();
            return arrayJsonReader.ReadArrayAsync(json, cancellationToken);
        }
    }
}
