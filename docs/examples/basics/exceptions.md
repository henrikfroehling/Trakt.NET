# Exception Handling

By default, the library uses exceptions.
You can find all supported exceptions in the namespace [`TraktNet.Exceptions`](xref:TraktNet.Exceptions).

The library usage would look like this:

```csharp
try
{
    var response = await client.Module.RequestAsync(Parameters...);
}
catch (TraktException ex) // Base exception type
{
    // Do something with the exception
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
