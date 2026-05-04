using ASPdotNETticketAPI.Dtos.Auth;
using ASPdotNETticketAPI.Dtos.Common;
using ASPdotNETticketAPI.Dtos.Tickets;
using ASPdotNETticketAPI.Services.Models;

namespace ASPdotNETticketAPI.Services.Interfaces;

public interface ITicketService
//Itt soroljuk fel a busines logic műveleteket, ezt a listát kell bővíteni új funckciók esetén, mert a használt kontroller nem tudja (nem tudhatja, nem kell hogy érdekelje) hogyan pl. történik meg az adatbázis elérése, validációja
{
    Task<PagedResultDto<TicketDto>> GetAllAsync(GetTicketsQueryDto query);
    Task<PagedResultDto<TicketDto>> GetMyCreatedAsync(int currentUserId, GetTicketsQueryDto query); //Hogy a user tudja listázni az általka létrehozott Ticketeket
    Task<PagedResultDto<TicketDto>> GetMyAssignedAsync(int currentUserId, GetTicketsQueryDto query); //Hogy a user tudja listázni a rátestált Ticketeket
    Task<ServiceResult<TicketDto>> GetByIdAsync(int id, int currentUserId, string currentUserRole);
    Task<ServiceResult<TicketDto>> CreateAsync(CreateTicketDto dto, int currentUserId);
    Task<ServiceResult<TicketDto>> UpdateAsync(int id, UpdateTicketDto dto, int currentUserId, string currentUserRole);
    Task<ServiceResult<TicketDto>> UpdateStatusAsync(int id, UpdateTicketStatusDto dto, int currentUserId, string currentUserRole);
    Task<ServiceResult<TicketDto>> AssignAsync(int id, AssignTicketDto dto, int currentUserId, string currentUserRole);
    Task<ServiceResult> DeleteAsync(int id);    //Magát a függvényt eleve csak admin tudja meghívni, itt már nem kell a user elelnőrzéséhez adatot átadni 
}