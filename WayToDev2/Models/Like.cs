using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WayToDev2.Models
{
    public class Like
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string IsLike { get; set; }
    }
}
