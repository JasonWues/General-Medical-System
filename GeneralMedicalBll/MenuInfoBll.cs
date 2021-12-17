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

        public async Task<(List<MenuInfoDto> menuInfos,int count)> Query(int page, int limit,string? title)
        {
            var menuInfo = _iBaseDal.GetEntities;

            int count = await menuInfo.CountAsync();

            if (!string.IsNullOrEmpty(title))
            {
                menuInfo = menuInfo.Where(x => x.Title.Contains(title));
                count = await menuInfo.CountAsync();
            }

            var query = from menuinfo in menuInfo
                       join d in menuInfo
                       on menuinfo.ParentId equals d.Id into gruoing
                       from x in gruoing.DefaultIfEmpty()
                       select new MenuInfoDto
                       {
                           Id = x.Id,
                           Href = menuinfo.Href,
                           Opentype = menuinfo.Opentype == "_iframe" ? "正常打开" : "新建浏览器标签页",
                           Icon = menuinfo.Icon, 
                           Sort = menuinfo.Sort,
                           Type = menuinfo.Type == 0 ? "目录" : "菜单",
                           Title = menuinfo.Title,
                           ParentTitle = x.Title,
                       };
            
            return (await query.Skip((page-1) * limit).Take(limit).ToListAsync(),count);
        }
    }
}
