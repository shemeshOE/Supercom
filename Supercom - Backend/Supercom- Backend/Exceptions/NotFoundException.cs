using System.Net;

namespace Supercom__Backend.Exceptions
{
    public class NotFoundException:HttpRequestException
    {
        public NotFoundException(string typeName, int id) : base($"{typeName} with id {id} was not found")
        {
        }
    }
}
