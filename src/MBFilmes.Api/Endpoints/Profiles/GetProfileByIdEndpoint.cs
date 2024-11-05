using MBFilmes.Api.Common.Api;
using MBFilmes.Core.Handlers;
using MBFilmes.Core.Models;
using MBFilmes.Core.Requests.Profiles;
using MBFilmes.Core.Responses;

namespace MBFilmes.Api.Endpoints.Profiles;

public class GetProfileByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Profiles: Get by id")
            .WithSummary("Busca um perfil de usuário")
            .WithDescription("Busca um perfil de usuário")
            .WithOrder(4)
            .Produces<BaseResponse<Profile?>>();

    private static async Task<IResult> HandleAsync(IProfileHandler handler, long id)
    {
        var request = new GetProfileByIdRequest
        {
            Id = id,
            UserId = "matheus@gmail.com"
        };
        
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess 
            ? TypedResults.Ok(result) 
            : TypedResults.BadRequest(result);
    }
}