namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SearchResultArrayJsonReader : AArrayJsonReader<ITraktSearchResult>
    {
        public override async Task<IEnumerable<ITraktSearchResult>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSearchResult>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var searchResultReader = new SearchResultObjectJsonReader();
                var searchResults = new List<ITraktSearchResult>();
                ITraktSearchResult searchResult = await searchResultReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (searchResult != null)
                {
                    searchResults.Add(searchResult);
                    searchResult = await searchResultReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return searchResults;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSearchResult>));
        }
    }
}
