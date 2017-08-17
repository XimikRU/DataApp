namespace edX.DataApp.WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Partner
    {
        public int PartnerId { get; set; }

        public bool IsOpen { get; set; }

        [Column(TypeName = "money")]
        public decimal AnnualRevenue { get; set; }

        [Required]
        [StringLength(100)]
        public string Photo { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        public int Priority { get; set; }

        public Guid? InternalId { get; set; }
    }
}
