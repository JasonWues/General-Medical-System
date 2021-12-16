using Entity;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;

namespace GeneralMedicalBll
{
    public class DrugstorageBll : BaseBll<Drugstorage>, IDrugstorageBll
    {
        public DrugstorageBll(IDrugstorageDal drugstorageDal)
        {
            _iBaseDal = drugstorageDal;
        }

        public async Task<(List<Drugstorage> drugstorages,int count)> Query(int page,int limit, string? applicanId)
        {
            var drugstorage = _iBaseDal.GetEntities;

            int count = await drugstorage.CountAsync();

            if(!string.IsNullOrEmpty(applicanId))
            {
                drugstorage = drugstorage.Where(x => x.ApplicantId.Contains(applicanId));
                count = await drugstorage.CountAsync();
            }

            return (await drugstorage.OrderBy(x=> x.DrugId).Skip((page - 1) * limit).Take(limit).ToListAsync(),count);
        }
    }
}