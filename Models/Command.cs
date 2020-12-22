using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commander.Models
{
    public partial class Command
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("command")]
        [StringLength(100)]
        public string Command1 { get; set; }
        [Required]
        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        [Column("platform")]
        [StringLength(100)]
        public string Platform { get; set; }
    }
}
