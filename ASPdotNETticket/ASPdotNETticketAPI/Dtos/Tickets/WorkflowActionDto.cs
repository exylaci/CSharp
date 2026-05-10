using System.ComponentModel.DataAnnotations;

namespace ASPdotNETticketAPI.Dtos.Tickets;

public class WorkflowActionDto
{
    [StringLength(500, ErrorMessage = "Max 500 karakter hosszú lehet.")]
    public string? note { get; set; }
}