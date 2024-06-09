using Supercom__Backend.DTOs;

namespace Supercom__Backend.Responses
{
    public class SearchTicketsResponse
    {
        public IEnumerable<TicketDTO> Tickets { get; set; }
        public int Count { get; set; }
    }
}
