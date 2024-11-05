using MBFilmes.Api.Common.Api;
using MBFilmes.Core.Handlers;
using MBFilmes.Core.Models;
using MBFilmes.Core.Requests.Profiles;
using MBFilmes.Core.Responses;

namespace MBFilmes.Api.Endpoints.Profiles;

public class DeleteProfileEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Profiles: Delete")
            .WithSummary("Exclui o perfil de usuário")
            .WithDescription("Exclui o perfil de usuário")
            .WithOrder(3)
            .Produces<BaseResponse<Profile?>>();

    private static async Task<IResult> HandleAsync(IProfileHandler handler, long id)
    {
        var request = new DeleteProfileRequest
        {
            Id = id,
            UserId = "matheus@gmail.com"
        };
        
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess 
            ? TypedResults.NoContent() 
            : TypedResults.BadRequest(result);
    }
}