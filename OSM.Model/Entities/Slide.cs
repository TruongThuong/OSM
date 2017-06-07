using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSM.Model.Entities
{
    [Table("Slides")]
    public class Slide
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        [MaxLength(250)]
        public string Url { get; set; }

        public int? DisplayOrder { get; set; }

        public bool Status { get; set; }

        public string Content { get; set; }
    }
}