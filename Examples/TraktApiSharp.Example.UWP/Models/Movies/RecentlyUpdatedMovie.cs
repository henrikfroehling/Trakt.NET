namespace TraktApiSharp.Example.UWP.Models.Movies
{
    using Objects.Get.Movies;
    using System;

    public class RecentlyUpdatedMovie : TraktMovie
    {
        public DateTime? MovieUpdatedAt { get; set; }
    }
}
