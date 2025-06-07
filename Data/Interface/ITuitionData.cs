using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ITuitionData : IBaseModelData<Tuition>
    {
        Task<bool> ActiveAsync(int id, bool active);
        Task<bool> UpdatePartial(Tuition Tuition);
    }
}
