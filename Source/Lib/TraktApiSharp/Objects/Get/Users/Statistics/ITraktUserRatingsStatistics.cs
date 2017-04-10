namespace TraktApiSharp.Objects.Get.Users.Statistics
{
    using System.Collections.Generic;

    public interface ITraktUserRatingsStatistics
    {
        int? Total { get; set; }

        IDictionary<string, int> Distribution { get; set; }
    }
}
