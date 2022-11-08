namespace TraktNet.Enums
{
    /// <summary>Determines value of the "sort-by" and "applied-sort-by" response header.</summary>
    public enum TraktSortBy
    {
        Unspecified,
        Rank,
        Added,
        Title,
        Released,
        Runtime,
        Popularity,
        Percentage,
        Votes,
        MyRating,
        Random,
        Watched,
        Collected
    }
}
