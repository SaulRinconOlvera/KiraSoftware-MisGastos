using MisGastos.Infrastructure.EntityBase;

namespace MisGastos.Infrastructure.Entities.Identity
{
    public class RefreshToken : BaseAuditable<int>
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public User User { get; set; }
    }
}
