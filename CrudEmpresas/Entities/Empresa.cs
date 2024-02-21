using System;
using System.Collections.Generic;

namespace CrudEmpresas.Entities;

public partial class Empresa
{
    public int Id { get; set; }

    public string Logotipo { get; set; } = null!;

    public string Firma { get; set; } = null!;

    public string Nif { get; set; } = null!;

    public int? Atividadeeconomicaid { get; set; }

    public int? Tipoid { get; set; }

    public DateOnly Abertura { get; set; }

    public virtual Atividadeecomica? Atividadeeconomica { get; set; }

    public virtual ICollection<Empresafilial> EmpresafilialAtividadeeconomicas { get; set; } = new List<Empresafilial>();

    public virtual ICollection<Empresafilial> EmpresafilialEmpresas { get; set; } = new List<Empresafilial>();

    public virtual ICollection<Empresasectoeconomico> Empresasectoeconomicos { get; set; } = new List<Empresasectoeconomico>();

    public virtual Tipo? Tipo { get; set; }
}
