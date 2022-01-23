## Async

Almost every library method runs asynchronously. Every method, that runs asynchronously, has the suffix `Async`. The common syntax for calling library methods is the following:

```csharp
var result = await client.[ModuleName].[MethodName]Async([arguments]);

// or

var task = client.[ModuleName].[MethodName]Async([arguments]);
var result = await task;

// or, without result

await client.[ModuleName].[MethodName]Async([arguments]);
```
