using TraktNet.Exceptions;
using TraktNet.Objects.Get.Movies;
using TraktNet.Objects.Get.Shows;
using TraktNet.Objects.Post.Syncs.Recommendations;
using TraktNet.Objects.Post.Syncs.Recommendations.Responses;
using TraktNet.PostBuilder;
using TraktNet.Responses;

try
{
    // Get some sample data.
    TraktPagedResponse<ITraktTrendingMovie> trendingMovies = await client.Movies.GetTrendingMoviesAsync();
    TraktPagedResponse<ITraktTrendingShow> trendingShows = await client.Shows.GetTrendingShowsAsync();

    // Create the recommendations post by using its post builder.
    ITraktSyncRecommendationsPost recommendationsPost = TraktPost.NewSyncRecommendationsPost()
                                                            .WithMovies(trendingMovies) // Add all movies.
                                                            .WithShows(trendingShows)   // Add all shows.
                                                            .Build();                   // Creates the recommendations post with the added movies and shows.

    // Using the post in the request.
    // NOTE: This call needs a valid authorization, which is not set in this example.
    TraktResponse<ITraktSyncRecommendationsPostResponse> response = await client.Sync.AddPersonalRecommendationsAsync(recommendationsPost);
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