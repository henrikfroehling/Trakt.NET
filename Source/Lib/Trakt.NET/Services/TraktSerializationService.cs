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
        /// <summary>Serializes a <see cref="ITraktAuthorization" /> instance to a JSON string.</summary>
        /// <param name="authorization">The <see cref="ITraktAuthorization" /> instance, which will be serialized.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the serialization should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>Returns a JSON string of the given <see cref="ITraktAuthorization" /> instance.</returns>
        public static Task<string> SerializeAsync(ITraktAuthorization authorization, CancellationToken cancellationToken = default)
        {
            if (authorization == null)
                throw new ArgumentNullException(nameof(authorization), "authorization must not be null");

            IObjectJsonWriter<ITraktAuthorization> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktAuthorization>();
            AuthorizationObjectJsonWriter authorizationObjectJsonWriter = (objectJsonWriter as AuthorizationObjectJsonWriter);
            authorizationObjectJsonWriter.CompleteSerialization = true;
            return authorizationObjectJsonWriter.WriteObjectAsync(authorization, cancellationToken);
        }

        /// <summary>Serializes a <typeparamref name="TObjectType"/> instance to a JSON string.</summary>
        /// <typeparam name="TObjectType">The type of the object, which will be serialized to a JSON string.</typeparam>
        /// <param name="obj">The object instance, which will be serialized.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the serialization should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>Returns a JSON string of the given object instance.</returns>
        public static Task<string> SerializeAsync<TObjectType>(TObjectType obj, CancellationToken cancellationToken = default)
        {
            if (EqualityComparer<TObjectType>.Default.Equals(obj, default))
                throw new ArgumentNullException(nameof(obj), "object must not be null");

            IObjectJsonWriter<TObjectType> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<TObjectType>();
            return objectJsonWriter.WriteObjectAsync(obj, cancellationToken);
        }

        /// <summary>Deserializes a JSON string to a <see cref="ITraktAuthorization" /> instance.</summary>
        /// <param name="authorizationJson">The JSON string, which will be deserialized to a <see cref="ITraktAuthorization" /> instance.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the deserialization should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A deserialized <see cref="ITraktAuthorization" /> instance from a JSON string.</returns>
        public static Task<ITraktAuthorization> DeserializeAsync(string authorizationJson, CancellationToken cancellationToken = default)
        {
            if (authorizationJson == null)
                throw new ArgumentNullException(nameof(authorizationJson), "authorization json string must not be null");

            if (authorizationJson.Length == 0)
                throw new ArgumentException("authorization json string must not be empty", nameof(authorizationJson));

            IObjectJsonReader<ITraktAuthorization> objectJsonReader = JsonFactoryContainer.CreateObjectReader<ITraktAuthorization>();
            AuthorizationObjectJsonReader authorizationObjectJsonReader = (objectJsonReader as AuthorizationObjectJsonReader);
            authorizationObjectJsonReader.CompleteDeserialization = true;
            return authorizationObjectJsonReader.ReadObjectAsync(authorizationJson, cancellationToken);
        }

        /// <summary>Deserializes a JSON string to a <typeparamref name="TObjectType"/> instance.</summary>
        /// <typeparam name="TObjectType">The type of the object, which will be deserialized from a JSON string.</typeparam>
        /// <param name="json">The JSON string, which will be deserialized to a object instance.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the deserialization should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A deserialized object instance from a JSON string.</returns>
        public static Task<TObjectType> DeserializeAsync<TObjectType>(string json, CancellationToken cancellationToken = default)
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json), "json string must not be null");

            if (json.Length == 0)
                throw new ArgumentException("json string must not be empty", nameof(json));

            IObjectJsonReader<TObjectType> objectJsonReader = JsonFactoryContainer.CreateObjectReader<TObjectType>();
            return objectJsonReader.ReadObjectAsync(json, cancellationToken);
        }

        /// <summary>Serializes a collection of <typeparamref name="TObjectType"/> instances to a JSON string.</summary>
        /// <typeparam name="TObjectType">The type of the objects, which will be serialized to a JSON string.</typeparam>
        /// <param name="objects">The objects, which will be serialized.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the serialization should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>Returns a JSON string of the given objects collection.</returns>
        public static Task<string> SerializeCollectionAsync<TObjectType>(IEnumerable<TObjectType> objects, CancellationToken cancellationToken = default)
        {
            if (objects == null)
                throw new ArgumentNullException(nameof(objects), "objects must not be null");

            IArrayJsonWriter<TObjectType> arrayJsonWriter = new ArrayJsonWriter<TObjectType>();
            return arrayJsonWriter.WriteArrayAsync(objects, cancellationToken);
        }

        /// <summary>Deserializes a JSON string to a collection of <typeparamref name="TObjectType"/> instances.</summary>
        /// <typeparam name="TObjectType">The type of the objects, which will be deserialized from a JSON string.</typeparam>
        /// <param name="json">The JSON string, which will be deserialized to a object collection.</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the deserialization should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A deserialized object collection from a JSON string.</returns>
        public static Task<IEnumerable<TObjectType>> DeserializeCollectionAsync<TObjectType>(string json, CancellationToken cancellationToken = default)
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json), "json string must not be null");

            if (json.Length == 0)
                throw new ArgumentException("json string must not be empty", nameof(json));

            IArrayJsonReader<TObjectType> arrayJsonReader = new ArrayJsonReader<TObjectType>();
            return arrayJsonReader.ReadArrayAsync(json, cancellationToken);
        }
    }
}
