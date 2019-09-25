using System;
using System.Collections.Generic;
using System.Text;

namespace CacheFramework.Utils
{
    public interface ICacheOption
    {
        string ServerName { get; set; }
        int Port { get; set; }

    }
}
