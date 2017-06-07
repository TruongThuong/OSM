using System;

namespace OSM.Model.Abstract
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }

        DateTime CreatedDate { get; set; }

        string UpdatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }

        string MetaKeyword { get; set; }

        string MetaDescription { get; set; }

        bool Status { get; set; }
    }
}