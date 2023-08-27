# Filter Builder

Many requests provide the possibility to filter the results. **Trakt.NET** makes this easy by providing some helper classes which are used to create such filters.

Filters are created with builder methods provided by [`TraktFilter`](xref:TraktNet.Parameters.TraktFilter).

Filters are only creatable through their builder methods.
Each filter instance is immutable.
If you want to change one, just create a new instance.

## Example

In this example a filter is used to get a filtered response of trending movies.

```csharp
using TraktNet;
using TraktNet.Objects.Get.Movies;
using TraktNet.Parameters;
using TraktNet.Responses;

// Create a filter.
ITraktMovieFilter movieFilter = TraktFilter.NewMovieFilter()
                                    .WithYears(2020, 2022)           // Only look for movies released in the years 2020, 2021 and 2022.
                                    .WithGenres("action", "fantasy") // Only look for action and fantasy movies.
                                    .WithRuntimes(90, 120)           // Each movie should have a runtime between 90 and 120 minutes.
                                    .WithRatings(80, 95)             // Each movie should have a rating between 80 and 95.
                                    .Build();                        // Create the filter with the given parameters.

// Get trending movies with the specified filter.
TraktPagedResponse<ITraktTrendingMovie> trendingMoviesResponse = await client.Movies.GetTrendingMoviesAsync(filter: movieFilter);
```

An overview of all filters can be found in the [references section](../references/requestparameters.md#filters).
