using Triton.Core.Domain.Common;

namespace Triton.Sample.Domain
{
    public class Director : BaseDomainModel
    {
        public Director()
        { }

        public string? Nombre { get; set; }
        public string? Apellido1 { get; set; }
        public string? Apellido2 { get; set; }

        public int VideoId { get; set; }
        public virtual Video? Video { get; set; }

    }
}
