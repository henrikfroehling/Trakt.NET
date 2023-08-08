# Exception Handling

**Trakt.NET** uses exceptions extensively. Every exception in the library inherits by [`TraktException`](xref:TraktNet.Exceptions.TraktException). That means you don't need to catch every single exception thrown by the library, only [`TraktException`](xref:TraktNet.Exceptions.TraktException):

## Usage

The library usage would look like this:

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

If you want to catch a specific exception, the usage would look like this:

```csharp
try
{
    var response = await client.Module.RequestAsync(Parameters...);
}
catch (TraktMovieNotFoundException ex) // Specific exception, which is thrown when a movie is not found
{
    // Do something with the exception
} 
catch (TraktException ex) // Base exception type
{
    // Do something with the exception
}
```

## Disabling Exceptions

If you do not want to use exceptions, you can disable this behaviour with the following setting:

```csharp
client.Configuration.ThrowResponseExceptions = false;
```

You then need to check whether a response is valid like this:

```csharp
var response = await client.Module.RequestAsync(Parameters...);

if (response) // Or response.IsSuccess
{
    // Do something with the response.
}
else
{
    // Get a possible thrown exception
    var exception = response.Exception;
}
```

## Exception Types

Other exceptions, you need to be aware of, are [`ArgumentNullException`](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception?view=net-7.0), [`ArgumentException`](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception?view=net-7.0) and occasionally [`ArgumentOutOfRangeException`](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception?view=net-7.0). As the names suggest, they are only thrown, if you pass invalid arguments to the library methods.

> [!NOTE]
> Trakt.NET checks all input parameters before any actual Trakt API request is made.

> [!NOTE]
> `Argument...` exceptions are not affected by the setting `client.Configuration.ThrowResponseExceptions`.

This means, that you will get one of the `Argument...` exceptions before a [`TraktException`](xref:TraktNet.Exceptions.TraktException).

## Not Found Exceptions

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

For more information on responses see the [Responses Section](responses.md).
