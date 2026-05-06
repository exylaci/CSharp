using System.ComponentModel.DataAnnotations;

namespace ASPdotNETticketAPI.Dtos.Comments;

public class CreateCommentDto //A kommentek létrehozására való végponthoz tartozó DTO
{
    [Required(ErrorMessage = "A comment szövege kötelező!")]
    [StringLength(1000, MinimumLength = 3, ErrorMessage = "A komment hossza 3 és 1000 karakter között kell legyen!")]
    public string Content { get; set; } = string.Empty;
}