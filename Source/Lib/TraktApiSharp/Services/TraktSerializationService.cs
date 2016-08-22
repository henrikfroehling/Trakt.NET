namespace TraktApiSharp.Services
{
    using Authentication;
    using System;

    /// <summary>Provides helper methods for serializing and deserializing Trakt objects.</summary>
    public static class TraktSerializationService
    {
        public static string Serialize(TraktAuthorization authorization)
        {
            if (authorization == null)
                throw new ArgumentNullException(nameof(authorization), "authorization must not be null");

            return string.Empty;
        }

        public static TraktAuthorization Deserialize(string authorization)
        {
            return null;
        }
    }
}
