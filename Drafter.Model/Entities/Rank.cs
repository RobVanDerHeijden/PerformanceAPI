using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Drafter.Model
{
    public class Rank
    {
        [Key]
        public int Id { get; set; }
        public string Division { get; set; }
        public string Tier { get; set; }
    }
}
