# Post Builder

The [Trakt.tv](https://trakt.tv/) [API](http://docs.trakt.apiary.io/#) has many requests which require the user to send data.
These post objects can be filled manually with data like if you are creating a new object.

But **Trakt.NET** also provides some helper classes for creating these post objects.

## Usage

First, get some data which is used to add to the user's favorites.

```csharp
using TraktNet.Objects.Get.Movies;
using TraktNet.Objects.Get.Shows;
using TraktNet.Responses;

// Get some sample data.
TraktPagedResponse<ITraktTrendingMovie> trendingMovies = await client.Movies.GetTrendingMoviesAsync();
TraktPagedResponse<ITraktTrendingShow> trendingShows = await client.Shows.GetTrendingShowsAsync();
```

Here is the approach for creating a new instance of a post object.

```csharp
using TraktNet.Objects.Post.Syncs.Favorites;

ITraktSyncFavoritesPost favoritesPost = new TraktSyncFavoritesPost
{
    Movies = trendingMovies.Select(movie => new TraktSyncFavoritesPostMovie
    {
        Ids = movie.Ids,
        Title = movie.Title,
        Year = movie.Year,
        Notes = "A new favorite movie!"
    })
    .ToList<ITraktSyncFavoritesPostMovie>(),
    
    Shows = trendingShows.Select(show => new TraktSyncFavoritesPostShow
    {
        Ids = show.Ids,
        Title = show.Title,
        Year = show.Year,
        Notes = "A new favorite show!"
    })
    .ToList<ITraktSyncFavoritesPostShow>()
};
```

And now the same with the help of the post builder provided by the library.

```csharp
using TraktNet.PostBuilder;

// Create the favorites post by using its post builder.
ITraktSyncFavoritesPost favoritesPost = TraktPost.NewSyncFavoritesPost()
    // Add all movies.
    .WithMoviesWithNotes(trendingMovies.Select(movie => new MovieWithNotes(movie, "A new favorite movie!")))
    // Add all shows.
    .WithShowsWithNotes(trendingShows.Select(show => new ShowWithNotes(show, "A new favorite show!")))
    // Creates the favorites post with the added movies and shows.
    .Build();
```

And now actually posting the data to [Trakt.tv](https://trakt.tv/).

```csharp
using TraktNet.Objects.Post.Syncs.Favorites.Responses;

// Using the post in the request.
// NOTE: This call needs a valid authorization, which is not set in this example.
TraktResponse<ITraktSyncFavoritesPostResponse> response = await client.Sync.AddFavoriteItemsAsync(favoritesPost);
```
