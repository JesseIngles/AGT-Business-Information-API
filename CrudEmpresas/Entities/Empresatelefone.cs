using System;
using System.Collections.Generic;

namespace CrudEmpresas.Entities;

public partial class Empresatelefone
{
    public int Id { get; set; }

    public string Telefone { get; set; } = null!;

    public int? Empresaid { get; set; }

    public virtual Empresa? Empresa { get; set; }
}
