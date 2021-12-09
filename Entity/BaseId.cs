using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class BaseId
    {
        [Key]
        [Column(TypeName = "varchar(36)")]
        public string Id { get; set; }
    }
}