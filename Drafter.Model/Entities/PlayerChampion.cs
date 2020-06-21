using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Drafter.Model
{
    public class PlayerChampion
    {
        //[Key]
        //public int Id { get; set; }
        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int ChampionId { get; set; }

        public Champion Champion { get; set; }

        public int MasteryPoints { get; set; }

        public float WinRate { get; set; }
        
        public DateTime LastTimePlayed { get; set; }
    }
}
