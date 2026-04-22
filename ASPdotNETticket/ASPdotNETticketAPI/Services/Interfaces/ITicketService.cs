using ASPdotNETticketAPI.Dtos.Common;
using ASPdotNETticketAPI.Dtos.Tickets;
using ASPdotNETticketAPI.Services.Models;

namespace ASPdotNETticketAPI.Services.Interfaces;

public interface ITicketService
//Itt soroljuk fel a busines logic műveleteket, ezt a listát kell bővíteni új funckciók esetén, mert a használt kontroller nem tudja (nem tudhatja, nem kell hogy érdekelje) hogyan pl. történik meg az adatbázis elérése, validációja
{
    Task<PagedResultDto<TicketDto>> GetAllAsync(GetTicketsQueryDto query);
    Task<ServiceResult<TicketDto>> GetByIdAsync(int id);
    Task<ServiceResult<TicketDto>> CreateAsync(CreateTicketDto dto);
    Task<ServiceResult<TicketDto>> UpdateAsync(int id, UpdateTicketDto dto);
    Task<ServiceResult<TicketDto>> UpdateStatusAsync(int id, UpdateTicketStatusDto dto);
    Task<ServiceResult> DeleteAsync(int id);
}