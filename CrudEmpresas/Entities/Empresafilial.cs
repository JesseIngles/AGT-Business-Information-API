using System;
using System.Collections.Generic;

namespace CrudEmpresas.Entities;

public partial class Empresafilial
{
    public int Id { get; set; }

    public string Logotipo { get; set; } = null!;

    public string Firma { get; set; } = null!;

    public string Nif { get; set; } = null!;

    public int? Atividadeeconomicaid { get; set; }

    public int? Empresaid { get; set; }

    public virtual Empresa? Atividadeeconomica { get; set; }

    public virtual Empresa? Empresa { get; set; }
}
