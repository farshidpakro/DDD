using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Simple_DDD.Infrastructure.Context
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(512)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(512)")]
        public string Lastname { get; set; }
        // [Required]
        // [ForeignKey("Examlistid")]
        // public virtual Examlist Examlist { get; set; }

    }
}