using MBFilmes.Api.Common.Api;
using MBFilmes.Api.Endpoints.Profiles;

namespace MBFilmes.Api.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("v1/profiles")
            .WithTags("Profiles")
            // .RequireAuthorization()
            .MapEndpoint<CreateProfileEndpoint>()
            .MapEndpoint<UpdateProfileEndpoint>()
            .MapEndpoint<DeleteProfileEndpoint>()
            .MapEndpoint<GetProfileByIdEndpoint>()
            .MapEndpoint<GetAllProfilesEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}