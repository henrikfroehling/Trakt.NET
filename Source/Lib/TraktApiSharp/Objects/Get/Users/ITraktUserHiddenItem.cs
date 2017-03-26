namespace TraktApiSharp.Objects.Get.Users
{
    using Enums;
    using Movies;
    using Seasons;
    using Shows;
    using System;

    public interface ITraktUserHiddenItem
    {
        DateTime? HiddenAt { get; set; }

        TraktHiddenItemType Type { get; set; }

        ITraktMovie Movie { get; set; }

        ITraktShow Show { get; set; }

        ITraktSeason Season { get; set; }
    }
}
