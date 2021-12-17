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

        public void RecursionMenu(List<ParentMenuInfoDto> parentMenuDtoInfos,List<MenuInfo> menus)
        {
            foreach (var item in parentMenuDtoInfos)
            {
                var childMenus = menus.Where(x => x.ParentId == item.Id).Select(x => new ParentMenuInfoDto
                {
                    Id = x.Id,
                    Href = x.Href,
                    Icon = x.Icon,
                    Title = x.Title,
                    Type = x.Type,
                    Opentype = x.Opentype,
                }).ToList();

                item.Children = childMenus;

                RecursionMenu(childMenus, menus);
            }
        }


        public async Task<List<ParentMenuInfoDto>> GetMenuJson()
        {
            var allMenuInfo = await _iBaseDal.GetAll().OrderBy(x => x.Sort).ToListAsync();

            //获取父级菜单
            List<ParentMenuInfoDto> parentMenuInfoDtos = allMenuInfo.Where(x => x.Type == 0).Select(x => new ParentMenuInfoDto
            {
                Id = x.Id,
                Title = x.Title,
                Icon = x.Icon,
                Type = x.Type,
                Href = x.Href,

            }).ToList();

            foreach (var parentMenuInfoDto in parentMenuInfoDtos)
            {
                var childMenus = allMenuInfo.Where(x => x.ParentId == parentMenuInfoDto.Id).Select(x => new ParentMenuInfoDto
                {
                    Id = x.Id,
                    Href = x.Href,
                    Icon = x.Icon,
                    Title = x.Title,
                    Type = x.Type,
                    Opentype = x.Opentype 
                }).ToList();
                parentMenuInfoDto.Children = childMenus;
                RecursionMenu(parentMenuInfoDto.Children, allMenuInfo);
            }

            return parentMenuInfoDtos;
        }

        public async Task<(List<MenuInfo> menuInfos,int count)> Query(int page, int limit,string? title)
        {
            var menuInfo = _iBaseDal.GetEntities;

            menuInfo = from menuinfo in menuInfo
                       join menuInfo2 in menuInfo
                       on menuinfo.ParentId equals menuInfo2.Id into gruoing
                       from x in gruoing
                       select new MenuInfo
                       {
                           Id = x.Id,
                           Href = x.Href,
                           Opentype = x.Opentype,
                           Icon = x.Icon, 
                           Sort = x.Sort,
                           Type = x.Type,
                           Title = x.Title,
                           ParentId = x.Title,
                       };

            int count = await menuInfo.CountAsync();

            if (!string.IsNullOrEmpty(title))
            {
                menuInfo = menuInfo.Where(x => x.Title.Contains(title));
                count = await menuInfo.CountAsync();
            }
            
            return (await menuInfo.Skip((page-1) * limit).Take(limit).ToListAsync(),count);
        }
    }
}
