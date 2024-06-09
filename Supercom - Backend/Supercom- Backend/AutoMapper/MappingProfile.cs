using AutoMapper;
using Supercom__Backend.DTOs;
using Supercom__Backend.Model;

namespace Supercom__Backend.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Ticket, TicketDTO>().ForMember(td => td.CreatedAt, opt => opt.MapFrom(t=>t.CreatedAt.ToString()+"z"));
            CreateMap<Comment, CommentDTO>();
        }
    }
}
