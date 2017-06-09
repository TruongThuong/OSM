using System;
using System.ComponentModel.DataAnnotations;

namespace OSM.Model.Abstract
{
    public class Auditable : IAuditable
    {
        [MaxLength(250)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [MaxLength(250)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [MaxLength(250)]
        public string MetaKeyword { get; set; }

        [MaxLength(250)]
        public string MetaDescription { get; set; }

        public bool Status { get; set; }
    }
}