C# Coding Style
===
- use [Allman style](https://en.wikipedia.org/wiki/Indent_style#Allman_style) braces
- four spaces of indentation (no tabs)
- `_camelCase` for internal and private fields
- use `readonly` where possible
- prefix instance fields with `_`, static fields with `s_`
- when used on static fields, `readonly` should come after `static` (i.e. `static readonly`, not `readonly static`)
- avoid `this.` unless absolutely necessary
- always specify visibility, even if it is the default (i.e. `private string _foo`, not `string _foo`)
- visibility should be the first modifier (i.e. `public abstract`, not `abstract public`)
- namespace imports should be specified at the top of the file, *inside* of `namespace` declarations and should be sorted alphabetically
- remove unused namespace imports
- avoid more than one empty line at any time; do not have two blank lines between members of a type
- avoid spurious free spaces (i.e. avoid `if (someVar == 0)...`, where the dots mark the spurious free spaces); Consider enabling "View White Space (Ctrl+E, S)" if using Visual Studio, to aid detection
- if a file happens to differ in style from these guidelines (e.g. private members are named `m_member` rather than `_member`), the existing style in that file takes precedence
- use language keywords instead of BCL types (i.e. `int, string, float` instead of `Int32, String, Single`) for both type references as well as method calls (i.e. `int.Parse()` instead of `Int32.Parse()`)
- use `UPPER_CASE` to name all constant local variables and fields,
- use `nameof(...)` instead of `"..."` whenever possible and relevant
- use `var` when it is obvious what the variable type is (i.e. `var stream = new FileStream(...)`, not `var stream = OpenStandardInput()`)
- fields should be specified at the top within type declarations
- use `PascalCase` to name classes, structs, methods and properties
- if a type is a generic type (i.e. `Pair<T, U>`) the filename should indicate the number of generic type arguments, e.g. the filename for `Pair<T, U>` should be `Pair'2.cs` and the filename for `IRequest<T>` should be `IRequest'1.cs`
- prefix interface names with `I` (i.e. `public interface IRequest` instead of `public interface Request`)
- prefix abstract class names with `A` (i.e. `public abstract ATraktRequest` instead of `public abstract TraktRequest`)
- all types which are visible publicly throug the API, should have the prefix `Trakt`, interfaces the prefix `ITrakt` (i.e. `public class TraktSomeClass` instead of `public class SomeClass` and `public interface ITraktSomeInterface` instead of `public interface ISomeInterface`)
- Use `Debug.Assert()` for checks not needed in release builds. Always include a "message" string in your assert to identify failure conditions.
- Use plain code to validate arguments at public boundaries. Do not use contracts or magic helpers.
```csharp
if (argument == null)
    throw new ArgumentNullException(nameof(argument), "optional message");
```

## **Example File**
`ATraktRequest'1.cs`

```csharp
namespace Trakt.NET.Requests.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class ATraktRequest<TContentType> : ITraktRequest<TContentType>
    {
        private const string CONSTANT_FIELD = "xxx";
        private static readonly DateTime s_staticField = DateTime.Now;
        private int _field = 5;

        public TraktRequest(TraktClient client) { }

        public async Task QueryAsync()
        {
            await Task.CompletedTask;
        }

        public TraktClient Client { get; }

        internal string Id { get; set; }

        protected virtual int Season { get; set; }

        private virtual int Episode { get; set; }

        private string BuildUrl() => string.Empty;

        protected virtual void Validate() { }

        protected virtual void SetRequestHeadersForAuthorization(HttpRequestMessage request)
        {
            if (AuthorizationHeaderRequired)
            {
                if (!Client.Authentication.IsAuthorized)
                    throw new TraktAuthorizationException("authorization is required for this request, but the current authorization parameters are invalid");

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Client.Authentication.Authorization.AccessToken);
            }

            if (AuthorizationRequirement == TraktAuthorizationRequirement.Optional && Client.Configuration.ForceAuthorization && Client.Authentication.IsAuthorized)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Client.Authentication.Authorization.AccessToken);
        }

        private void SetDefaultRequestHeaders(HttpClient httpClient)
        {
            var appJsonHeader = new MediaTypeWithQualityHeaderValue("application/json");

            if (!httpClient.DefaultRequestHeaders.Contains(TraktConstants.APIClientIdHeaderKey))
                httpClient.DefaultRequestHeaders.Add(TraktConstants.APIClientIdHeaderKey, Client.ClientId);

            if (!httpClient.DefaultRequestHeaders.Contains(TraktConstants.APIVersionHeaderKey))
                httpClient.DefaultRequestHeaders.Add(TraktConstants.APIVersionHeaderKey, $"{Client.Configuration.ApiVersion}");

            if (!httpClient.DefaultRequestHeaders.Accept.Contains(appJsonHeader))
                httpClient.DefaultRequestHeaders.Accept.Add(appJsonHeader);
        }

        private void Foo()
        {
            var value = 4;

            if (value % 2 == 0)
            {
                for (int i = 0; i < value; i++)
                    value++;
            }
        }
    }
}

```
