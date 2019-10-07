using System.Collections.Generic;

namespace App.Goods.Interfaces
{
    public interface IValidateService
    {
        IEnumerable<int> ValidateIds(int[] ids);
    }
}
