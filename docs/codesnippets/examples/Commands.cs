using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;
using Trakt.NET.Examples.Authentication;
using Trakt.NET.Examples.Modules.Shows;
using Trakt.NET.Examples.Parameters.Filter;
using Trakt.NET.Examples.Serialization;

namespace Trakt.NET.Examples;

public sealed class ExampleSettings : CommandSettings
{
    [Description("The name of a specific example.")]
    [CommandArgument(0, "[EXAMPLE_NAME]")]
    public string ExampleName { get; set; } = string.Empty;

    public override ValidationResult Validate()
        => string.IsNullOrEmpty(ExampleName) ? ValidationResult.Error("No valid example name.") : ValidationResult.Success();
}

[Description("Run authentication examples.")]
public sealed class RunAuthExampleCommand : AsyncCommand<ExampleSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, ExampleSettings settings)
    {
        switch (settings.ExampleName)
        {
            case Constants.Commands.Auth.DeviceExample:
                await AuthenticationDeviceExample.RunAsync();
                break;
            case Constants.Commands.Auth.OAuthExample:
                await AuthenticationOAuthExample.RunAsync();
                break;
            default:
                break;
        }

        return 0;
    }
}

[Description("Run shows module examples.")]
public sealed class RunShowsModuleExampleCommand : AsyncCommand<ExampleSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, ExampleSettings settings)
    {
        switch (settings.ExampleName)
        {
            case Constants.Commands.Modules.Shows.GetSingleShow:
                await SingleShowExample.RunAsync();
                break;
            case Constants.Commands.Modules.Shows.GetSingleShowExtended:
                await SingleShowExtendedExample.RunAsync();
                break;
            case Constants.Commands.Modules.Shows.GetTrengingShows:
                await TrendingShowsExample.RunAsync();
                break;
            case Constants.Commands.Modules.Shows.GetTrendingShowsPaged:
                await TrendingShowsPagedExample.RunAsync();
                break;
            case Constants.Commands.Modules.Shows.GetMultipleShows:
                await GetShowsStreamExample.RunAsync();
                break;
            default:
                break;
        }

        return 0;
    }
}

[Description("Run filter parameter examples.")]
public sealed class RunParametersFilterCommand : AsyncCommand<ExampleSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, ExampleSettings settings)
    {
        switch (settings.ExampleName)
        {
            case Constants.Commands.Parameters.Filter.Calendar:
                await CalendarFilterExample.RunAsync();
                break;
            default:
                break;
        }

        return 0;
    }
}

[Description("Run post builder parameter examples.")]
public sealed class RunParametersPostBuilderCommand : AsyncCommand<ExampleSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, ExampleSettings settings)
    {
        switch (settings.ExampleName)
        {
            case Constants.Commands.Parameters.PostBuilder.Favorites:
                await FavoritesPostBuilderExample.RunAsync();
                break;
            default:
                break;
        }
        
        return 0;
    }
}

[Description("Run serialization examples.")]
public sealed class RunSerializationCommand : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        await SerializationExample.RunAsync();
        return 0;
    }
}
