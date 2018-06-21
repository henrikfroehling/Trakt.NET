namespace TraktNet.Objects.Get.Users.Statistics
{
    /// <summary>A collection of Trakt user statistics about an user's network.</summary>
    public class TraktUserNetworkStatistics : ITraktUserNetworkStatistics
    {
        /// <summary>Gets or sets the number of friends an user has.</summary>
        public int? Friends { get; set; }

        /// <summary>Gets or sets the number of followers an user has.</summary>
        public int? Followers { get; set; }

        /// <summary>Gets or sets the number of following users an user has.</summary>
        public int? Following { get; set; }
    }
}
