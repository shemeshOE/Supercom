using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Supercom__Backend.DTOs;
using Supercom__Backend.Enums;
using Supercom__Backend.Model;

namespace Supercom__Backend.Interfaces
{
    public interface ITicketsService
    {
        IEnumerable<Ticket> GetTickets(
            int? id, string title, string description, DateTime? createdAtFrom, DateTime? createdAtTo,
            TicketStatus? status, int pageNumber, int pageSize);
        Task<Ticket> GetTicketById(int id);
        Task CreateTicket(CreateTicketDTO ticket);
        Task UpdateTicket(UpdateTicketDTO ticket);
        Task DeleteTicket(int id);
        Task<IEnumerable<Comment>> GetComments(int ticketId);
        Task AddComment(CreateCommentDTO comment);
        Task UpdateComment(UpdateCommentDTO updateComment);
        Task DeleteComment(int id);
    }
}
