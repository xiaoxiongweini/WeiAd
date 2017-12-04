using DN.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DN.WeiAd.Business
{
    public partial class DomainInfoBLL
    {
        /// <summary>
        /// 获取城市相关信息
        /// </summary>
        /// <returns></returns>
        public List<TypeItem>  GetCitys()
        {
            List<TypeItem> list = new List<TypeItem>();

            list.Add(new TypeItem() { Id = 1, Name = "北京" });
            list.Add(new TypeItem() { Id = 2, Name = "上海" });
            list.Add(new TypeItem() { Id = 3, Name = "深圳" });
            list.Add(new TypeItem() { Id = 4, Name = "广州" });
            list.Add(new TypeItem() { Id = 5, Name = "香港" });

            return list;
        }
    }
}
