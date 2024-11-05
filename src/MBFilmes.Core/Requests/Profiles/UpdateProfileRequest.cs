using System.ComponentModel.DataAnnotations;

namespace MBFilmes.Core.Requests.Profiles;

public class UpdateProfileRequest : BaseRequest
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "Nome inválido")]
    [MaxLength(40, ErrorMessage = "O nome deve conter até 40 caracteres")]
    public string Name { get; set; } = string.Empty;
}