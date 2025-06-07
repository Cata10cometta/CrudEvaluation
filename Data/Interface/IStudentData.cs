using Entity.Model;

namespace Data.Interface
{
    public interface IStudentData : IBaseModelData<student>
    {
        Task<bool> ActiveAsync(int id, bool active);
        Task<bool> UpdatePartial(student customer);
    }
}
