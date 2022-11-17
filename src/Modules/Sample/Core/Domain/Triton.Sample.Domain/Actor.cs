using Triton.Core.Domain.Common;

namespace Triton.Sample.Domain
{
    public class Actor : BaseDomainModel
    {
        public Actor()
        {
            Videos = new HashSet<Video>();
        }

        public string? Nombre { get; set; }
        public string? Apellido1 { get; set; }
        public string? Apellido2 { get; set; }

        public virtual ICollection<Video> Videos { get; set; }

    }
}
