using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ALAT.Core.Entities
{
    public class State
    {
        public State()
        {
            Lgas = new HashSet<Lga>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Lga> Lgas { get; set; }
    }
}
