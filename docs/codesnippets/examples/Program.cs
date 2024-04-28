using Spectre.Console.Cli;
using Trakt.NET.Examples;

var app = new CommandApp();

app.Configure(config =>
{
    _ = config.AddCommand<RunAuthExampleCommand>(Constants.Commands.AuthCommand)
        .WithExample(Constants.Commands.AuthCommand, Constants.Commands.Auth.DeviceExample);

    _ = config.AddBranch(Constants.Commands.ModuleCommand,
        module =>
        {
            module.SetDescription("Run module examples.");
            
            _ = module.AddCommand<RunShowsModuleExampleCommand>(Constants.Commands.Modules.ShowsModuleCommand)
                .WithExample(Constants.Commands.ModuleCommand, Constants.Commands.Modules.ShowsModuleCommand,
                             Constants.Commands.Modules.Shows.GetSingleShow);
        });

    _ = config.AddBranch(Constants.Commands.ParametersCommand, parameters =>
    {
        parameters.SetDescription("Run parameter examples.");

        _ = parameters.AddCommand<RunParametersFilterCommand>(Constants.Commands.Parameters.FilterCommand)
            .WithExample(Constants.Commands.ParametersCommand, Constants.Commands.Parameters.FilterCommand,
                         Constants.Commands.Parameters.Filter.Calendar);

        _ = parameters.AddCommand<RunParametersPostBuilderCommand>(Constants.Commands.Parameters.PostBuilderCommand)
            .WithExample(Constants.Commands.ParametersCommand, Constants.Commands.Parameters.PostBuilderCommand,
                         Constants.Commands.Parameters.PostBuilder.Favorites);
    });

    _ = config.AddCommand<RunSerializationCommand>(Constants.Commands.SerializationCommand)
        .WithExample(Constants.Commands.SerializationCommand);
});

return app.Run(args);
