using Microsoft.EntityFrameworkCore;
using Supercom__Backend.DTOs;
using Supercom__Backend.Enums;
using Supercom__Backend.Interfaces;
using Supercom__Backend.Model;
using Supercom__Backend.Exceptions;
using Supercom__Backend.Responses;
using AutoMapper;
using System.Linq.Expressions;

namespace Supercom__Backend.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly SupercomDbContext _dbContext;

        public TicketsService(SupercomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Ticket> CreateTicket(CreateTicketDTO ticket)
        {
            var addedTicket = await _dbContext.AddAsync(new Ticket
            {
                Title = ticket.Title,
                Description = ticket.Description
            });
            await _dbContext.SaveChangesAsync();
            return addedTicket.Entity;
        }

        public async Task DeleteTicket(int id)
        {
            var ticket = await GetTicketById(id);
            ticket.Status=TicketStatus.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            var ticket = await _dbContext.FindAsync<Ticket>(id);

            if (ticket != null)
            {
                return ticket;
            }
            throw new NotFoundException(typeof(Ticket).Name, id);
        }

        public SearchTicketsResponse GetTickets(
            int? id, string title, DateTime? createdAtFrom, DateTime? createdAtTo,
            TicketStatus? status, int pageNumber, int pageSize, IMapper mapper)
        {
            Expression<Func<Ticket, bool>> predicate = t => (id == null || id == t.Id) &&
                     (status == null || status == t.Status) &&
                     (title == null || t.Title.Contains(title)) &&
                     (createdAtFrom == null || createdAtFrom <= t.CreatedAt) &&
                     (createdAtTo == null || createdAtTo >= t.CreatedAt);
            return new SearchTicketsResponse()
            {
                Tickets = mapper.ProjectTo<TicketDTO>(_dbContext.Tickets.Where(predicate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)),
                Count= _dbContext.Tickets.Count(predicate)
            };
        }

        public async Task UpdateTicket(UpdateTicketDTO updateTicket)
        {
            var ticket=await GetTicketById(updateTicket.Id);

            if (updateTicket.Status != null)
            {
                ticket.Status = updateTicket.Status.Value;
            }

            if (updateTicket.Title != null)
            {
                ticket.Title = updateTicket.Title;
            }

            if (updateTicket.Description != null)
            {
                ticket.Description = updateTicket.Description;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetComments(int ticketId)
        {
            var ticket = await _dbContext.Tickets.Include(t => t.Comments).FirstOrDefaultAsync(t => t.Id == ticketId);
            
            if(ticket != null)
            {
                return ticket.Comments;
            }

            throw new NotFoundException(typeof(Ticket).Name, ticketId);
        }

        public async Task AddComment(CreateCommentDTO comment)
        {
            var ticket = await GetTicketById(comment.TicketId);

            await _dbContext.AddAsync(new Comment
            {
                Text = comment.Text,
                TicketId = comment.TicketId
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateComment(UpdateCommentDTO updateComment)
        {
            var comment = await GetCommentById(updateComment.Id);

            comment.Text=updateComment.Text;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteComment(int id)
        {
            var comment = await GetCommentById(id);

            _dbContext.Remove(comment);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<Comment> GetCommentById(int id)
        {
            var comment = await _dbContext.FindAsync<Comment>(id);

            if (comment != null)
            {
                return comment;
            }

            throw new NotFoundException(typeof(Comment).Name, id);
        }
    }
}
