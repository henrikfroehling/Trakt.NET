## Exception Handling

Trakt.NET uses exceptions extensively. Every exception in the library inherits by [`TraktException`](xref:TraktNet.Exceptions.TraktException). That means you don't need to catch every single exception thrown by the library, only [`TraktException`](xref:TraktNet.Exceptions.TraktException):

```csharp
using TraktNet.Exceptions;

try
{
    var result = await client.[ModuleName].[MethodName]Async([arguments]);
}
catch (TraktException ex)
{
    Console.WriteLine($"Exception message: {ex.Message}");
    Console.WriteLine($"Status code: {ex.StatusCode}");
    Console.WriteLine($"Request URL: {ex.RequestUrl}");                     // could be null
    Console.WriteLine($"Request message: {ex.RequestBody}");                // could be null
    Console.WriteLine($"Request response: {ex.Response}");                  // could be null
    Console.WriteLine($"Server Reason Phrase: {ex.ServerReasonPhrase}");    // could be null
}
```

Other exceptions, you need to be aware of, are [`ArgumentNullException`](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception?view=net-7.0), [`ArgumentException`](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception?view=net-7.0) and occasionally [`ArgumentOutOfRangeException`](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception?view=net-7.0). As the names suggest, they are only thrown, if you pass invalid arguments to the library methods.

_**Note: Trakt.NET checks all input parameters before any actual Trakt API request is made.**_

This means, that you will get one of the `Argument...` exceptions before a [`TraktException`](xref:TraktNet.Exceptions.TraktException).

For every possible Trakt media object (show, movie, person, etc.), there is also an exception, if the object was not found, e.g. a call to

```csharp
using TraktNet.Objects.Get.Shows;
using TraktNet.Responses;

TraktResponse<ITraktShow> show = client.Shows.GetShowAsync("unknown-slug");
```

could throw a [`TraktShowNotFoundException`](xref:TraktNet.Exceptions.TraktShowNotFoundException).
Each
- [`TraktCommentNotFoundException`](xref:TraktNet.Exceptions.TraktCommentNotFoundException)
- [`TraktEpisodeNotFoundException`](xref:TraktNet.Exceptions.TraktEpisodeNotFoundException)
- [`TraktListNotFoundException`](xref:TraktNet.Exceptions.TraktListNotFoundException)
- [`TraktMovieNotFoundException`](xref:TraktNet.Exceptions.TraktMovieNotFoundException)
- [`TraktPersonNotFoundException`](xref:TraktNet.Exceptions.TraktPersonNotFoundException)
- [`TraktSeasonNotFoundException`](xref:TraktNet.Exceptions.TraktSeasonNotFoundException)
- [`TraktShowNotFoundException`](xref:TraktNet.Exceptions.TraktShowNotFoundException)
has a property [`ObjectId`](xref:TraktNet.Exceptions.TraktObjectNotFoundException.ObjectId), that tells you the id, which was not found.

If no exception was thrown, you can consider, that the method call was successful. But you should always check the return value if it is [not null](nullhandling.md).

For more information on responses see the [Responses Section](responses.md).
