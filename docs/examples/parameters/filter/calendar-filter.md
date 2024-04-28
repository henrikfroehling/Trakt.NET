# Calendar Filter

In this example we create a calendar filter to filter all new calendar shows.

Since we do not need authentication or authorization for this example, only the Client-ID is required.

[!code-csharp[](../../../codesnippets/examples/parameters/filter/CalendarFilterExample.cs#L16-L19)]

The following lines create a new calendar filter, which filters the request for specific genres, runtimes and year.

[!code-csharp[](../../../codesnippets/examples/parameters/filter/CalendarFilterExample.cs#L21-L33)]

Get all new calendar shows filtered with the above created filter.

[!code-csharp[](../../../codesnippets/examples/parameters/filter/CalendarFilterExample.cs#L37-L47)]

__The complete code for this example can be found at: [Trakt.NET/docs/codesnippets/examples/parameters/filter/CalendarFilterExample.cs](https://github.com/henrikfroehling/Trakt.NET/tree/v1.4.0/docs/codesnippets/examples/parameters/filter/CalendarFilterExample.cs)__
