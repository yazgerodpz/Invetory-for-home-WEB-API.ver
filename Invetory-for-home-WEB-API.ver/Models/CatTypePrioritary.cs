using System;
using System.Collections.Generic;

namespace Invetory_for_home_WEB_API.ver.Models;

public partial class CatTypePrioritary
{
    public int IdTypePrioritary { get; set; }

    public string TypePrioritaryName { get; set; } = null!;

    public string _Description { get; set; } = null!;

    public bool Active { get; set; }
}
