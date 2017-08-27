namespace TraktApiSharp.Objects.Basic.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SearchResultArrayJsonReader : IArrayJsonReader<ITraktSearchResult>
    {
        public Task<IEnumerable<ITraktSearchResult>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktSearchResult>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktSearchResult>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktSearchResult>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktSearchResult>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSearchResult>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var searchResultReader = new TraktSearchResultObjectJsonReader();
                //var searchResultReadingTasks = new List<Task<ITraktSearchResult>>();
                var searchResults = new List<ITraktSearchResult>();

                //searchResultReadingTasks.Add(searchResultReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSearchResult searchResult = await searchResultReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (searchResult != null)
                {
                    searchResults.Add(searchResult);
                    //searchResultReadingTasks.Add(searchResultReader.ReadObjectAsync(jsonReader, cancellationToken));
                    searchResult = await searchResultReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSearchResults = await Task.WhenAll(searchResultReadingTasks);
                //return (IEnumerable<ITraktSearchResult>)readSearchResults.GetEnumerator();
                return searchResults;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSearchResult>));
        }
    }
}
