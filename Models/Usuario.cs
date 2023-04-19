using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace pruebaapiconviews.Models
{
    public class Usuario
    {
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } // Id - PK

        [ForeignKey("Rol")]
        public int RoleId { get; set; } // RoleId - FK

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } // Nombre

        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; } // Apellido


        [Index("IX_Cedula", IsUnique = true)]
        [MaxLength(15)]
        public string Cedula { get; set; } // Cedula - INDEX UNIQUE 01

        [Index("IX_UsuarioNombre", IsUnique = true)]
        [MaxLength(50)]
        public string Usuario_Nombre { get; set; } // Usuario_Nombre - INDEX UNIQUE 02

        [Required]
        [MaxLength(50)]
        public string Contraseña { get; set; } // Contraseña

        [Index]
        public DateTime Fecha_Nacimiento { get; set; } // Fecha_Nacimiento - INDEX

        [Required]
        [DefaultValue("DEFAULT_USER")]
        public string Usuario_Transaccion { get; set; } // Usuario_Transaccion - DEFAULT USER

        
        [DefaultValue(typeof(DateTime), "CURRENT_TIMESTAMP")]
        public DateTime Fecha_Transaccion { get; set; } // Fecha_Transaccion - DEFAULT SYSDATE
        [JsonIgnore]
        public virtual Rol Rol { get; set; } // Relación con la clase Rol
    }
}