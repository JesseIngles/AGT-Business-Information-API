using System;
using System.Collections.Generic;

namespace CrudEmpresas.Entities;

public partial class Empresasectoeconomico
{
    public int Id { get; set; }

    public int? Sectoreconomicoid { get; set; }

    public int? Empresaid { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual Sectoreconomico? Sectoreconomico { get; set; }
}
