using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace pruebaapiconviews.Models
{
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } // Id - PK

        [Index("IX_Nombre", IsUnique = true)]
        [MaxLength(50)]
        public string Nombre { get; set; } // Nombre - INDEX UNIQUE

        [Required]
        [DefaultValue("DEFAULT_USER")]
        public string Usuario_Transaccion { get; set; } // Usuario_Transaccion - DEFAULT USER

        [Required]
        [DefaultValue(typeof(DateTime), "CURRENT_TIMESTAMP")]

        public DateTime Fecha_Transaccion { get; set; } // Fecha_Transaccion - DEFAULT SYSDATE
        [JsonIgnore]
        public virtual ICollection<Usuario> Usuarios { get; set; } // Relación con la clase Usuario
    }
}