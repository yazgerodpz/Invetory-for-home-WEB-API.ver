using System;
using System.Collections.Generic;

namespace Invetory_for_home_WEB_API.ver.Models;

public partial class CatTypeStock
{
    public int IdTypeStock { get; set; }

    public string TypeStockName { get; set; } = null!;

    public bool Active { get; set; }
}
