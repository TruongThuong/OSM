using OSM.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSM.Model.Entities
{
    [Table("Tags")]
    public class Tag : Auditable
    {
        [Key]
        [MaxLength(50)]
        public string ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
    }
}