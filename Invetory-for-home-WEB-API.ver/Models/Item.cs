using System;
using System.Collections.Generic;

namespace Invetory_for_home_WEB_API.ver.Models;

public partial class Item
{
    public int IdItem { get; set; }

    public string ItemName { get; set; } = null!;

    public int Stock { get; set; }

    public int IdTypePrioritary { get; set; }

    public int IdTypeStock { get; set; }

    public DateTime PurchesDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public bool Active { get; set; }
}
