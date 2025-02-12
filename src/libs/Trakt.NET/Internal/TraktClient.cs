#if NET6_0_OR_GREATER
using TraktNET.Utilities.Json;
#endif

namespace TraktNET
{
    public sealed partial class TraktClient
    {
        private readonly TraktContext _context;

        internal HttpClientProvider HttpClientProvider
        {
            get => _context.HttpClientProvider;
            set => _context.HttpClientProvider = value;
        }

        internal TraktClient(TraktContext context)
        {
            ArgumentValidator.ThrowIfNull(context);
            _context = context;
        }

#if NET6_0_OR_GREATER
        static TraktClient()
            => JsonSerializerContextFactoryRegistry.RegisterFactory(Constants.Json.FactoryKey, new JsonSerializerContextFactory());
#endif
    }
}
