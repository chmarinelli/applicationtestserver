using TestServer.BL.Abstract;

namespace TestServer.BL.Dtos
{
    public class PermitTypeDto : IEntityBaseDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
