using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Entities.HojadeVida
{
    public class Sociales
    {
        public int id { get; set; }
        [Required]
        public int IdEstudiante { get; set; }
        public string FaceBook { get; set; }
        public string Twitter { get; set; }
        public string Google { get; set; }

    }
}
