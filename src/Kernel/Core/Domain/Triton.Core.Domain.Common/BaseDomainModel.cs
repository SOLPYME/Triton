namespace Triton.Core.Domain.Common
{
    public class BaseDomainModel
	{
        public BaseDomainModel()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}

