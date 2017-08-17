namespace edx.DataApp.WebDemo.Models
{
    using edX.DataApp.WebAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string ProductNumber { get; set; }

        [StringLength(15)]
        public string Color { get; set; }

        [Column(TypeName = "money")]
        public decimal StandardCost { get; set; }

        [Column(TypeName = "money")]
        public decimal ListPrice { get; set; }

        public int ProductCategoryId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ReleaseDate { get; set; }

        public bool? SafetyReviewResult { get; set; }

        public Guid ExternalId { get; set; }

        [ForeignKey("ProductCategoryId")]
        public virtual ProductCategories ProductCategories { get; set; }
    }
}
