namespace TraktNet.Tests.Services.TraktSerializationService
{
    using System;
    using TraktNet.Objects.Authentication;
    using TraktNet.Tests.TestUtils;

    public partial class TraktSerializationService_Tests
    {
        private const uint EXPIRES_IN_SECONDS = 3600;
        private static readonly DateTime s_createdAt = DateTime.UtcNow;
        private static readonly ulong s_createdAtTimestamp = TestUtility.CalculateTimestamp(s_createdAt);

        private ITraktAuthorization Authorization1 { get; }
        private ITraktAuthorization Authorization2 { get; }
        private ITraktAuthorization Authorization3 { get; }
        private ITraktAuthorization Authorization4 { get; }
        private ITraktAuthorization Authorization5 { get; }
        private ITraktAuthorization Authorization6 { get; }
        private ITraktAuthorization Authorization7 { get; }
        private ITraktAuthorization Authorization8 { get; }

        private string Authorization1Json { get; }
        private string Authorization2Json { get; }
        private string Authorization3Json { get; }
        private string Authorization4Json { get; }
        private string Authorization5Json { get; }
        private string Authorization6Json { get; }
        private string Authorization7Json { get; }
        private string Authorization8Json { get; }

        public TraktSerializationService_Tests()
        {
            Authorization1 = TraktAuthorization.CreateWith(TestConstants.MOCK_ACCESS_TOKEN);
            Authorization2 = TraktAuthorization.CreateWith(TestConstants.MOCK_ACCESS_TOKEN, TestConstants.MOCK_REFRESH_TOKEN);
            Authorization3 = TraktAuthorization.CreateWith(EXPIRES_IN_SECONDS, TestConstants.MOCK_ACCESS_TOKEN);
            Authorization4 = TraktAuthorization.CreateWith(EXPIRES_IN_SECONDS, TestConstants.MOCK_ACCESS_TOKEN, TestConstants.MOCK_REFRESH_TOKEN);
            Authorization5 = TraktAuthorization.CreateWith(s_createdAt, TestConstants.MOCK_ACCESS_TOKEN);
            Authorization6 = TraktAuthorization.CreateWith(s_createdAt, TestConstants.MOCK_ACCESS_TOKEN, TestConstants.MOCK_REFRESH_TOKEN);
            Authorization7 = TraktAuthorization.CreateWith(s_createdAt, EXPIRES_IN_SECONDS, TestConstants.MOCK_ACCESS_TOKEN);
            Authorization8 = TraktAuthorization.CreateWith(s_createdAt, EXPIRES_IN_SECONDS, TestConstants.MOCK_ACCESS_TOKEN, TestConstants.MOCK_REFRESH_TOKEN);

            Authorization1Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   "\"expires_in\":7776000," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{Authorization1.CreatedAtTimestamp}," +
                   "\"ignore_expiration\":true" +
                 "}";

            Authorization2Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   $"\"refresh_token\":\"{TestConstants.MOCK_REFRESH_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   "\"expires_in\":7776000," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{Authorization2.CreatedAtTimestamp}," +
                   "\"ignore_expiration\":true" +
                 "}";

            Authorization3Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   $"\"expires_in\":{EXPIRES_IN_SECONDS}," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{Authorization3.CreatedAtTimestamp}," +
                   "\"ignore_expiration\":false" +
                 "}";

            Authorization4Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   $"\"refresh_token\":\"{TestConstants.MOCK_REFRESH_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   $"\"expires_in\":{EXPIRES_IN_SECONDS}," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{Authorization4.CreatedAtTimestamp}," +
                   "\"ignore_expiration\":false" +
                 "}";

            Authorization5Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   "\"expires_in\":7776000," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{s_createdAtTimestamp}," +
                   "\"ignore_expiration\":true" +
                 "}";

            Authorization6Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   $"\"refresh_token\":\"{TestConstants.MOCK_REFRESH_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   "\"expires_in\":7776000," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{s_createdAtTimestamp}," +
                   "\"ignore_expiration\":true" +
                 "}";

            Authorization7Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   $"\"expires_in\":{EXPIRES_IN_SECONDS}," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{s_createdAtTimestamp}," +
                   "\"ignore_expiration\":false" +
                 "}";

            Authorization8Json =
                "{" +
                   $"\"access_token\":\"{TestConstants.MOCK_ACCESS_TOKEN}\"," +
                   $"\"refresh_token\":\"{TestConstants.MOCK_REFRESH_TOKEN}\"," +
                   "\"scope\":\"public\"," +
                   $"\"expires_in\":{EXPIRES_IN_SECONDS}," +
                   "\"token_type\":\"bearer\"," +
                   $"\"created_at\":{s_createdAtTimestamp}," +
                   "\"ignore_expiration\":false" +
                 "}";
        }
    }
}
