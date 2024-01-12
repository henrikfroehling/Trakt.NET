# Calendar Filter

In this example we create a calendar filter to filter all new calendar shows.

Since we do not need authentication or authorization for this example, only the Client-ID is required.

[!code-csharp[](../../../codesnippets/examples/parameters/filter/CalendarFilter.cs#L7-L10)]

The following lines create a new calendar filter, which filters the request for specific genres, runtimes and year.

[!code-csharp[](../../../codesnippets/examples/parameters/filter/CalendarFilter.cs#L12-L24)]

Get all new calendar shows filtered with the above created filter.

[!code-csharp[](../../../codesnippets/examples/parameters/filter/CalendarFilter.cs#L27-L37)]

__The complete code for this example can be found at: [Trakt.NET/docs/codesnippets/examples/parameters/filter/CalendarFilter.cs](https://github.com/henrikfroehling/Trakt.NET/tree/release-1.4.0/docs/codesnippets/examples/parameters/filter/CalendarFilter.cs)__
