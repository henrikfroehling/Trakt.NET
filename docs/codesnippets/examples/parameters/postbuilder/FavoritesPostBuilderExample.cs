using TraktNet;
using TraktNet.Exceptions;
using TraktNet.Objects.Get.Movies;
using TraktNet.Objects.Get.Shows;
using TraktNet.Objects.Post.Syncs.Favorites;
using TraktNet.Objects.Post.Syncs.Favorites.Responses;
using TraktNet.PostBuilder;
using TraktNet.Responses;

namespace Trakt.NET.Examples.Parameters.Filter;

internal static class FavoritesPostBuilderExample
{
    internal static async Task RunAsync()
    {
        Console.WriteLine("Trakt.NET - Favorites Post Builder Example");
        Console.WriteLine();

        Console.WriteLine("Please enter your Trakt Client-ID:");
        string? clientID = Console.ReadLine();

        Console.WriteLine("Please enter your Trakt Client-Secret:");
        string? clientSecret = Console.ReadLine();

        var client = new TraktClient(clientID, clientSecret);

        // For this example we do not want to manipulate the production API
        client.Configuration.UseSandboxEnvironment = true;

        try
        {
            // Get some sample data.
            TraktPagedResponse<ITraktTrendingMovie> trendingMovies = await client.Movies.GetTrendingMoviesAsync();
            TraktPagedResponse<ITraktTrendingShow> trendingShows = await client.Shows.GetTrendingShowsAsync();

            // Create the favorites post by using its post builder.
            ITraktSyncFavoritesPost favoritesPost = TraktPost.NewSyncFavoritesPost()
                                                        .WithMovies(trendingMovies) // Add all movies.
                                                        .WithShows(trendingShows)   // Add all shows.
                                                        .Build();                   // Creates the favorites post with the added movies and shows.

            // Using the post in the request.
            // NOTE: This call needs a valid authorization, which is not set in this example.
            TraktResponse<ITraktSyncFavoritesPostResponse> response = await client.Sync.AddFavoriteItemsAsync(favoritesPost);
        }
        catch (TraktException ex)
        {
            Console.WriteLine("-------------- Trakt Exception --------------");
            Console.WriteLine($"Exception message: {ex.Message}");
            Console.WriteLine($"Status code: {ex.StatusCode}");
            Console.WriteLine($"Request URL: {ex.RequestUrl}");
            Console.WriteLine($"Request message: {ex.RequestBody}");
            Console.WriteLine($"Request response: {ex.Response}");
            Console.WriteLine($"Server Reason Phrase: {ex.ServerReasonPhrase}");
            Console.WriteLine("---------------------------------------------");
        }

        Console.WriteLine();
    }
}
