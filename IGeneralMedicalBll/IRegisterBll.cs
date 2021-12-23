using Entity;
using Entity.DTO.Join;

namespace IGeneralMedicalBll
{
    public interface IRegisterBll : IBaseBll<Register>
    {
        Task<(List<Register_Doctor_Patient>, int count)> Query(int page, int limit, string? PatientId);
    }
}