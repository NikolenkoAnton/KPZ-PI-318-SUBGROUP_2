using System.Collections.Generic;

namespace App.Goods.Services
{
    public interface IValidateService
    {
       void ValidateIds(List<int> ids);
    }
}
