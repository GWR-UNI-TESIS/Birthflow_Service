using System;
using System.Collections.Generic;

namespace BirthflowMicroServices.Domain.Models;

public partial class Partograma
{
    public string PartogramaId { get; set; } = null!;

    public Guid? UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Expediente { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public bool IsDelete { get; set; }

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<DilatacionesCervicale> DilatacionesCervicales { get; set; } = new List<DilatacionesCervicale>();

    public virtual ICollection<FrecuenciaCardiacaFetal> FrecuenciaCardiacaFetals { get; set; } = new List<FrecuenciaCardiacaFetal>();

    public virtual ICollection<FrecuenciaContracione> FrecuenciaContraciones { get; set; } = new List<FrecuenciaContracione>();

    public virtual NotaParto? NotaParto { get; set; }

    public virtual PartogramaEstado? PartogramaEstado { get; set; }

    public virtual ICollection<PartogramaPermiso> PartogramaPermisos { get; set; } = new List<PartogramaPermiso>();

    public virtual TiempoTrabajo? TiempoTrabajo { get; set; }

    public virtual Usuario? Usuario { get; set; }

    public virtual ICollection<VigilanciaMedica> VigilanciaMedicas { get; set; } = new List<VigilanciaMedica>();

    public virtual ICollection<Vpp> Vpps { get; set; } = new List<Vpp>();
}
