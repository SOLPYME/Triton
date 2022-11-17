using Triton.Core.Domain.Common;

namespace Triton.Sample.Domain
{
    public class VideoActor : BaseDomainModel
    {
        public int VideoId { get; set; }
        public int ActorId { get; set; }

    }
}
