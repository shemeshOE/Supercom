using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Supercom__Backend.DTOs;
using Supercom__Backend.Enums;
using Supercom__Backend.Model;
using Supercom__Backend.Responses;

namespace Supercom__Backend.Interfaces
{
    public interface ITicketsService
    {
        SearchTicketsResponse GetTickets(
            int? id, string title, DateTime? createdAtFrom, DateTime? createdAtTo,
            TicketStatus? status, int pageNumber, int pageSize, IMapper mapper);
        Task<Ticket> GetTicketById(int id);
        Task<Ticket> CreateTicket(CreateTicketDTO ticket);
        Task UpdateTicket(UpdateTicketDTO ticket);
        Task DeleteTicket(int id);
        Task<IEnumerable<Comment>> GetComments(int ticketId);
        Task AddComment(CreateCommentDTO comment);
        Task UpdateComment(UpdateCommentDTO updateComment);
        Task DeleteComment(int id);
    }
}
