using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;

namespace DN.WeiAd.Business
{
    public partial class AdTypeInfoBLL
    {
        List<AdTypeInfoVO> m_list = new List<AdTypeInfoVO>();

        public string GetNameById(object id)
        {
            AdTypeInfoVO info = null;

            info = m_list.SingleOrDefault(p => p.Id == int.Parse(id.ToString()));

            if (info == null)
            {
                info = GetSingle(new AdTypeInfoPara() { Id = int.Parse(id.ToString()) });
                if (info != null)
                {
                    m_list.Add(info);
                    return info.Name;
                }
            }
            else
            {
                return info.Name;
            }

            return id.ToString();
        }
    }
}
