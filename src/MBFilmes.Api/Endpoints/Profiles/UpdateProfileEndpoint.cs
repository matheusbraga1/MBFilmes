using MBFilmes.Api.Common.Api;
using MBFilmes.Core.Handlers;
using MBFilmes.Core.Models;
using MBFilmes.Core.Requests.Profiles;
using MBFilmes.Core.Responses;

namespace MBFilmes.Api.Endpoints.Profiles;

public class UpdateProfileEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
            .WithName("Profiles: Update")
            .WithSummary("Atualiza o perfil de usuário")
            .WithDescription("Atualiza o perfil de usuário")
            .WithOrder(2)
            .Produces<BaseResponse<Profile?>>();

    private static async Task<IResult> HandleAsync(IProfileHandler handler, UpdateProfileRequest request, long id)
    {
        request.Id = id;
        request.UserId = "matheus@gmail.com";
        
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess 
            ? TypedResults.Ok(result) 
            : TypedResults.BadRequest(result);
    }
}