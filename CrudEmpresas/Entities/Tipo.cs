using System;
using System.Collections.Generic;

namespace CrudEmpresas.Entities;

public partial class Tipo
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
}
