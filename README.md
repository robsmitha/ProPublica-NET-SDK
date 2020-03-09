# ProPublica-sdk


The SDK is a .NET Core library to access various congressional endpoints from the [ProPublica Congress API](https://projects.propublica.org/api-docs/congress-api/).

## Usage
```csharp
var proPublica = new ProPublica("YOUR_API_KEY");
var members = proPublica.Members.GetNewMembers();
```
[Request a free API key](https://www.propublica.org/datastore/api/propublica-congress-api) to initialize the SDK!


## Installing
Coming Soon! Working on coding more endpoints from the API into the SDK and releasing the package on nuget.

