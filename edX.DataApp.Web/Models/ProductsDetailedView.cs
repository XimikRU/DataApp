namespace edX.DataApp.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductsDetailedView")]
    public partial class ProductsDetailedView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(25)]
        public string ModelNumber { get; set; }

        [StringLength(15)]
        public string Color { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "money")]
        public decimal Cost { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "money")]
        public decimal? Profit { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string Category { get; set; }
    }
}
