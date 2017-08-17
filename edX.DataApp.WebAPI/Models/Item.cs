using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace edX.DataApp.WebAPI.Models
{
    public partial class Item
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
    }
}