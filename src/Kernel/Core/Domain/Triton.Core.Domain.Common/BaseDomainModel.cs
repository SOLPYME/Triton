using System.ComponentModel.DataAnnotations.Schema;

namespace Triton.Core.Domain.Common
{
    public class BaseDomainModel
	{
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "VarChar(100)")]
        public string? CreatedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        [Column(TypeName = "VarChar(100)")]
        public string? LastModifiedBy { get; set; }
    }
}

