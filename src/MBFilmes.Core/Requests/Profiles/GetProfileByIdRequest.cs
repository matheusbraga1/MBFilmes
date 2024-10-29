namespace MBFilmes.Core.Requests.Profiles;

public class GetProfileByIdRequest : BaseRequest
{
    public long Id { get; set; }
}