using System.Collections.Generic;

namespace App.Goods.Services
{
    public interface INormalizeService
    {
       void CleanIds(List<int> ids);
    }
}
