using System;
using System.Collections.Generic;

namespace HomeWorksBackEnd.Models
{
    public partial class Materium
    {
        public Materium()
        {
            Actividads = new HashSet<Actividad>();
        }

        public string NombreMateria { get; set; } = null!;

        public virtual ICollection<Actividad> Actividads { get; set; }
    }
}
