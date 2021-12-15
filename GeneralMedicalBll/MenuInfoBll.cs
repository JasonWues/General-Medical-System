using Entity;
using Entity.DTO;
using IGeneralMedicalBll;
using IGeneralMedicalDal;
using Microsoft.EntityFrameworkCore;

namespace GeneralMedicalBll
{
    public class MenuInfoBll : BaseBll<MenuInfo>,IMenuInfoBll
    {
        public MenuInfoBll(IMenuInfoDal menuInfoDal)
        {
            _iBaseDal = menuInfoDal;
        }

        public async Task<ParentMenuInfoDto> Query()
        {
            var allMenuInfo = await _iBaseDal.GetAll().OrderBy(x => x.Sort).ToListAsync();

            //获取父级菜单
            List<ParentMenuInfoDto> parentMenuInfoDtos = allMenuInfo.Where(x => x.Type == 0).Select(x => new ParentMenuInfoDto
            {
                Id = x.Id,
                Title = x.Title,
                Icon = x.Icon,
                Type = x.Type,
                Herf = x.Herf
            }).ToList();

            foreach (var item in parentMenuInfoDtos)
            {
                var
            }
        }
    }
}
