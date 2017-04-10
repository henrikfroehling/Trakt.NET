namespace TraktApiSharp.Objects.Get.Users.Statistics
{
    public interface ITraktUserNetworkStatistics
    {
        int? Friends { get; set; }

        int? Followers { get; set; }

        int? Following { get; set; }
    }
}
