# idunno.AtProto

A .NET 8 class library for the [atproto protocol](https://docs.bsky.app/docs/api/at-protocol-xrpc-api) and APIs for the Bluesky social network.

## Getting Started

Add the `idunno.AtProto`` package to your project and

```c#
BlueskyAgent agent = new ();
HttpResult<bool> loginResult = await agent.Login(username, password);
if (loginResult.Succeeded && agent.Session is not null)
{
    HttpResult<CreateRecordResponse> response = await agent.CreatePost("Hello World");
    if (response.Succeeded)
    {
    }
}
```

Please see the [documentation](docs/readme.md) much more useful documentation and samples.

The [API status page](docs/endpointStatus.md) shows what is currently implemented and what is planned.

## Current Build Status

[![Build Status](https://github.com/blowdart/idunno.atproto/actions/workflows/ci-build.yml/badge.svg)](https://github.com/blowdart/idunno.atproto/actions/workflows/ci-build.yml)

[![Test Results](https://camo.githubusercontent.com/9f508f166f15790248d7986f09e96076b994a0eddb0293c810ed3bbcccdb3ac0/68747470733a2f2f7376672e746573742d73756d6d6172792e636f6d2f64617368626f6172642e7376673f703d31313826663d3026733d30)](https://github.com/blowdart/idunno.atproto/actions/workflows/ci-build.yml)

## License

idunno.AtProto is available under the MIT license, see the [LICENSE](LICENSE) file for more information.

## External dependencies

* [System.IdentityModel.Tokens](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet) - used to parse the JWT tokens issued by Bluesky.

## External libraries and utilities used during builds

* [NerdBank.GitVersioning](https://github.com/dotnet/Nerdbank.GitVersioning) - used for version stamping assemblies and packages.
* [DotNet.ReproducibleBuilds](https://github.com/dotnet/reproducible-builds) - used to easily set .NET reproducible build settings.
* [xunit](https://github.com/xunit/xunit) - used for unit tests.
* [ReportGenerator](https://github.com/danielpalme/ReportGenerator) - used to produce code coverage reports.
* [JunitXml.TestLogger](https://github.com/spekt/junit.testlogger) - used in CI builds to produce test results in a format understood by the [test-summary](https://github.com/test-summary/action) GitHub action.

## Other .NET Bluesky libraries

* [FishyFlip](https://github.com/drasticactions/FishyFlip)
* [atprotosharp](https://github.com/taranasus/atprotosharp)
