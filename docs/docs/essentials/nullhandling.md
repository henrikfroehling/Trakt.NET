# Null Handling

The Trakt API might not return all data, especially not when you are using the [extended info](../references/requestparameters.md#extended-info). Therefore, you should check object properties, if they are null or not.

```csharp
using TraktNet.Objects.Get.Shows;
using TraktNet.Parameters;
using TraktNet.Responses;

TraktResponse<ITraktShow> showResponse = await client.Shows.GetShowAsync("game-of-thrones");
string showOverview = showResponse.Value.Overview;  // will be null

// with extended info

TraktResponse<ITraktShow> showResponse = await client.Shows.GetShowAsync("game-of-thrones", new TraktExtendedInfo { Full = true });
string showOverView = showResponse.Value.Overview; // could be null
```
