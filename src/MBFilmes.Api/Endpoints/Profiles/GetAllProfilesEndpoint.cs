using MBFilmes.Api.Common.Api;
using MBFilmes.Core.Handlers;
using MBFilmes.Core.Models;
using MBFilmes.Core.Requests.Profiles;
using MBFilmes.Core.Responses;

namespace MBFilmes.Api.Endpoints.Profiles;

public class GetAllProfilesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Profiles: Get All")
            .WithSummary("Busca todos os perfis de um usuário")
            .WithDescription("Busca todos os perfis de um usuário")
            .WithOrder(5)
            .Produces<BaseResponse<List<Profile>?>>();

    private static async Task<IResult> HandleAsync(IProfileHandler handler)
    {
        var request = new GetAllProfilesRequest
        {
            UserId = "matheus@gmail.com"
        };
        
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess 
            ? TypedResults.Ok(result) 
            : TypedResults.BadRequest(result);
    }
}