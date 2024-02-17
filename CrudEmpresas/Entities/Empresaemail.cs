using System;
using System.Collections.Generic;

namespace CrudEmpresas.Entities;

public partial class Empresaemail
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public int? Empresaid { get; set; }

    public virtual Empresa? Empresa { get; set; }
}
