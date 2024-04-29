﻿namespace TraktNet.Objects.Json
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ArrayJsonReader<TReturnType> : IArrayJsonReader<TReturnType>
    {
        public virtual Task<IList<TReturnType>> ReadArrayAsync(string json, CancellationToken cancellationToken = default)
        {
            CheckJson(json);

            if (json == string.Empty)
                return Task.FromResult(default(IList<TReturnType>));

            using var reader = new StringReader(json);
            using var jsonReader = new JsonTextReader(reader);
            return ReadArrayAsync(jsonReader, cancellationToken);
        }

        public virtual Task<IList<TReturnType>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            CheckStream(stream);
            using var streamReader = new StreamReader(stream);
            using var jsonReader = new JsonTextReader(streamReader);
            return ReadArrayAsync(jsonReader, cancellationToken);
        }

        public virtual async Task<IList<TReturnType>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var objectReader = JsonFactoryContainer.CreateObjectReader<TReturnType>();
                var objects = new List<TReturnType>();
                TReturnType obj = await objectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (obj != null)
                {
                    objects.Add(obj);
                    obj = await objectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return objects;
            }

            return await Task.FromResult(default(IList<TReturnType>));
        }

        protected void CheckJson(string json)
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json));
        }

        protected void CheckStream(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
        }

        protected void CheckJsonTextReader(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                throw new ArgumentNullException(nameof(jsonReader));
        }
    }
}
