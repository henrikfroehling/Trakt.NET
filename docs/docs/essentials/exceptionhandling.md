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

## Argument Exceptions

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

## Rate Limit Exception

Rate limits can be catched with the exception [`TraktRateLimitException`](xref:TraktNet.Exceptions.TraktRateLimitException).
This exception provides detailed information about the rate limit.

## Failed VIP Validation Exception

The [Trakt.tv](https://trakt.tv/) [API](http://docs.trakt.apiary.io/#) provides requests which can only be used by VIP users.
If a non [VIP](https://trakt.tv/vip) user tries to use such a request, a [`TraktFailedVIPValidationException`](xref:TraktNet.Exceptions.TraktFailedVIPValidationException) is thrown.
This exception provides a `UpgradeURL` where the user can sign up for [Trakt.tv](https://trakt.tv/) [VIP](https://trakt.tv/vip).

## User Account Limit Exception

A [`TraktUserAccountLimitException`](xref:TraktNet.Exceptions.TraktUserAccountLimitException) is thrown when a user has exceeded their account limits, such as list counts, item counts, etc.

## Locked User Account Exception

If an OAuth authorized user has a locked user account, a [`TraktLockedUserAccountException`](xref:TraktNet.Exceptions.TraktLockedUserAccountException) is thrown.

This means that the user should [contact the Trakt support](https://support.trakt.tv/).

## Request Validation Exception

Any argument, such as movie or show ids, given to a module method is validated before actually executing the request.
If for example an id is not valid (contains spaces, etc.) a [`TraktRequestValidationException`](xref:TraktNet.Exceptions.TraktRequestValidationException) is thrown.

## Post Validation Exception

For post requests where data is sent to the [Trakt.tv](https://trakt.tv/) [API](http://docs.trakt.apiary.io/#) a [`TraktPostValidationException`](xref:TraktNet.Exceptions.TraktPostValidationException) might be thrown,
if the post object contains invalid data.
E.g. a required property is null.
