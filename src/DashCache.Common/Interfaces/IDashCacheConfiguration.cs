using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashCache.Common.Interfaces
{
    public interface IDashCacheConfiguration
    {
        IDashCacheConfiguration Convert(string key);

        int ToAInt();

        bool ToABool();

        string ToAString();
    }
}
