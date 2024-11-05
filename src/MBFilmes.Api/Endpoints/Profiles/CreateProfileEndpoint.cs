using MBFilmes.Api.Common.Api;
using MBFilmes.Core.Handlers;
using MBFilmes.Core.Models;
using MBFilmes.Core.Requests.Profiles;
using MBFilmes.Core.Responses;

namespace MBFilmes.Api.Endpoints.Profiles;

public class CreateProfileEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Profiles: Create")
            .WithSummary("Cria um novo perfil de usuário")
            .WithDescription("Cria um novo perfil de usuario")
            .WithOrder(1)
            .Produces<BaseResponse<Profile?>>();

    private static async Task<IResult> HandleAsync(IProfileHandler handler, CreateProfileRequest request)
    {
        request.UserId = "matheus@gmail.com";
        var result = await handler.CreateAsync(request);
        return result.IsSuccess 
            ? TypedResults.Created($"/{result.Data?.Id}", result) 
            : TypedResults.BadRequest(result);
    }
}