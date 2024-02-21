using System;
using System.Collections.Generic;

namespace CrudEmpresas.Entities;

public partial class Sectoreconomico
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Empresasectoeconomico> Empresasectoeconomicos { get; set; } = new List<Empresasectoeconomico>();
}
