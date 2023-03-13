using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint.Crm.Client;

public static class ExtMethods
{
    public static bool IsNotEmptyId(this string id)
        => !string.IsNullOrEmpty(id) && id != "0";
}

