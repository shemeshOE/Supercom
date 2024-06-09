using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Supercom__Backend.DTOs;
using Supercom__Backend.Enums;
using Supercom__Backend.Interfaces;
using Supercom__Backend.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Supercom__Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService _ticketsService;
        private readonly IMapper _mapper;

        public TicketsController(ITicketsService ticketsService, IMapper mapper)
        {
            _ticketsService = ticketsService;
            _mapper = mapper;
        }

        [HttpGet("search")]
        public SearchTicketsResponse Search(
            int? id, string title, string description, DateTime? createdAtFrom, DateTime? createdAtTo,
            TicketStatus? status, [BindRequired] int pageNumber, [BindRequired] int pageSize)
        {
            return 
                _ticketsService.GetTickets(id, title, createdAtFrom, createdAtTo, status, pageNumber, pageSize, _mapper);
        }

        [HttpGet("{id}")]
        public async Task<TicketDTO> GetTicket(int id)
        {
            return _mapper.Map<TicketDTO>(await _ticketsService.GetTicketById(id));
        }

        [HttpPost("createTicket")]
        public async Task<TicketDTO> CreateTicket([FromBody] CreateTicketDTO createTicketDTO)
        {
            return _mapper.Map<TicketDTO>(await _ticketsService.CreateTicket(createTicketDTO));
        }

        [HttpPut("updateTicket")]
        public async Task UpdateTicket([FromBody] UpdateTicketDTO updateTicketDTO)
        {
            await _ticketsService.UpdateTicket(updateTicketDTO);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTicket(int id)
        {
            await _ticketsService.DeleteTicket(id);
        }

        [HttpGet("{id}/comments")]
        public async Task<IEnumerable<CommentDTO>> GetComments(int id)
        {
            return _mapper.ProjectTo<CommentDTO>(
                (await _ticketsService.GetComments(id))
                .AsQueryable());
        }

        [HttpPost("addComment")]
        public async Task AddComment([FromBody] CreateCommentDTO createCommentDTO)
        {
            await _ticketsService.AddComment(createCommentDTO);
        }

        [HttpPut("updateComment")]
        public async Task UpdateComment([FromBody] UpdateCommentDTO updateCommentDTO)
        {
            await _ticketsService.UpdateComment(updateCommentDTO);
        }

        [HttpDelete("{id}/comment")]
        public async Task DeleteComment(int id)
        {
            await _ticketsService.DeleteComment(id);
        }
    }
}
