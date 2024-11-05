using MBFilmes.Core.Models;
using MBFilmes.Core.Requests.Profiles;
using MBFilmes.Core.Responses;

namespace MBFilmes.Core.Handlers;

public interface IProfileHandler
{
    Task<BaseResponse<Profile?>> CreateAsync(CreateProfileRequest request);
    Task<BaseResponse<Profile?>> UpdateAsync(UpdateProfileRequest request);
    Task<BaseResponse<Profile?>> DeleteAsync(DeleteProfileRequest request);
    Task<BaseResponse<Profile?>> GetByIdAsync(GetProfileByIdRequest request);
    Task<BaseResponse<List<Profile>?>> GetAllAsync(GetAllProfilesRequest request);
}