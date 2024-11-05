using MBFilmes.Api.Data;
using MBFilmes.Core.Handlers;
using MBFilmes.Core.Models;
using MBFilmes.Core.Requests.Profiles;
using MBFilmes.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace MBFilmes.Api.Handlers;

public class ProfileHandler(AppDbContext context) : IProfileHandler
{
    public async Task<BaseResponse<Profile?>> CreateAsync(CreateProfileRequest request)
    {
        try
        {
            var getAllProfilesRequest = new GetAllProfilesRequest { UserId = request.UserId };
            var profiles = await GetAllAsync(getAllProfilesRequest);

            if (profiles.Data?.Count == 4)
                return new BaseResponse<Profile?>(null, 500, "Não é possível criar mais que 4 perfis de usuário");
            
            var newProfile = new Profile
            {
                Name = request.Name,
                UserId = request.UserId
            };

            await context.Profile.AddAsync(newProfile);
            await context.SaveChangesAsync();

            return new BaseResponse<Profile?>(newProfile, 201, "Perfil criado com sucesso.");
        }
        catch
        {
            return new BaseResponse<Profile?>(null, 500, "Não foi possível criar o perfil.");
        }
    }

    public async Task<BaseResponse<Profile?>> UpdateAsync(UpdateProfileRequest request)
    {
        try
        {
            var profile = await context
                .Profile
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (profile is null)
                return new BaseResponse<Profile?>(null, 404, "Perfil não encontrado.");

            profile.Name = request.Name;

            context.Profile.Update(profile);
            await context.SaveChangesAsync();

            return new BaseResponse<Profile?>(profile, message: "Perfil atualizado com sucesso.");
        }
        catch
        {
            return new BaseResponse<Profile?>(null, 500, "Não foi possível atualizar o perfil.");
        }
    }

    public async Task<BaseResponse<Profile?>> DeleteAsync(DeleteProfileRequest request)
    {
        try
        {
            var profile = await context
                .Profile
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (profile is null)
                return new BaseResponse<Profile?>(null, 404, "Perfil não encontrado.");

            context.Profile.Remove(profile);
            await context.SaveChangesAsync();

            return new BaseResponse<Profile?>(profile, 204,"Perfil excluído com sucesso.");
        }
        catch
        {
            return new BaseResponse<Profile?>(null, 500, "Não foi possível excluir o perfil.");
        }
    }

    public async Task<BaseResponse<Profile?>> GetByIdAsync(GetProfileByIdRequest request)
    {
        try
        {
            var profile = await context
                .Profile
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
            
            return profile is null 
                ? new BaseResponse<Profile?>(null, 404, "Perfil não encontrado.") 
                : new BaseResponse<Profile?>(profile, message: "Perfil encontrado com sucesso.");
        }
        catch
        {
            return new BaseResponse<Profile?>(null, 500, "Não foi possível recuperar o perfil.");
        }
    }

    public async Task<BaseResponse<List<Profile>?>> GetAllAsync(GetAllProfilesRequest request)
    {
        try
        {
            var profiles = await context
                .Profile
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId)
                .ToListAsync();
            
            return new BaseResponse<List<Profile>?>(profiles, message: "Perfis encontrados com sucesso.");
        }
        catch
        {
            return new BaseResponse<List<Profile>?>(null, 500, "Não foi possível consultar os perfis.");
        }
    }
}