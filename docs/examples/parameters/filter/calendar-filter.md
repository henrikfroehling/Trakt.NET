# Calendar Filter

In this example we create a calendar filter to filter all new calendar shows.

Since we do not need authentication or authorization for this example, only the Client-ID is required.

[!code-csharp[](../../../codesnippets/examples/ClientSetup.cs)]

The following lines create a new calendar filter, which filters the request for specific genres, runtimes and year.

[!code-csharp[](../../../codesnippets/examples/parameters/filter/CalendarFilter.cs#L6-L18)]

Get all new calendar shows filtered with the above created filter.

[!code-csharp[](../../../codesnippets/examples/parameters/filter/CalendarFilter.cs#L22-L32)]
