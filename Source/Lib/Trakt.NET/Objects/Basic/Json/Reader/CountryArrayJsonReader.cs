namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CountryArrayJsonReader : AArrayJsonReader<ITraktCountry>
    {
        public override async Task<IEnumerable<ITraktCountry>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCountry>)).ConfigureAwait(false);

            if (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var countryReader = new CountryObjectJsonReader();
                var countries = new List<ITraktCountry>();
                ITraktCountry country = await countryReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);

                while (country != null)
                {
                    countries.Add(country);
                    country = await countryReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                }

                return countries;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCountry>)).ConfigureAwait(false);
        }
    }
}
