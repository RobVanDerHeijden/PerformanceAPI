using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Drafter.Model
{
    public class Champion
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
