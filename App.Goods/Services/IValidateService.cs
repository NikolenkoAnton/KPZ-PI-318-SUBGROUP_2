using System.Collections.Generic;

namespace App.Goods.Services
{
    public interface IValidateService
    {
       void CleanIds(List<int> ids);
    }
}
