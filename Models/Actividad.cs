using System;
using System.Collections.Generic;

namespace HomeWorksBackEnd.Models
{
    public partial class Actividad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public decimal Nota { get; set; }
        public string Estado { get; set; } = null!;
        public string Materia { get; set; } = null!;
        public string FechaEntrega { get; set; } = null!;

        public virtual Materium? MateriaNavigation { get; set; } 
    }
}
