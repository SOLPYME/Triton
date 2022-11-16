using Triton.Core.Domain.Common;

namespace Triton.Sample.Domain
{
    public class Video : BaseDomainModel
    {
        public Video()
        {
            Actores = new HashSet<Actor>();
            Director = new Director();
        }

        public string? Nombre { get; set; }

        public int StreamerId { get; set; }
        public virtual Streamer? Streamer { get; set; }
        public virtual ICollection<Actor> Actores { get; set; }
        public virtual Director Director { get; set; }

    }
}
