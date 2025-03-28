using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Categoria")]
public class Categorias {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("idCategoria")]
    public int IdCategoria { get; set; }

    [Column("categoria")]
    public string? Categoria { get; set; }

    [Column("fecha_registro")]
    public DateTime? FechaRegistro { get; set; }

    [Column("fecha_actualizacion")]
    public DateTime? FechaActualizacion { get; set; }

    [Column("estatus")]
    public int Estatus { get; set; }
}