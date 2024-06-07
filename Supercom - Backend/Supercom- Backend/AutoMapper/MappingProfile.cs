using AutoMapper;
using Supercom__Backend.DTOs;
using Supercom__Backend.Model;

namespace Supercom__Backend.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Ticket, TicketDTO>();
            CreateMap<Comment, CommentDTO>();
        }
    }
}
