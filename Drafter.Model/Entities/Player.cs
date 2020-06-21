using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Drafter.Model
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Rank Rank { get; set; }
        public string Position { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

    }
}
