using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business
{
    /// <summary>
    /// 模版帮助工具
    /// </summary>
    public class TemplateBLL
    {
        /// <summary>
        /// 非加密模版
        /// </summary>
        static ConcurrentDictionary<string, string> m_list = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// 加密模版
        /// </summary>
        static ConcurrentDictionary<string, string> m_list_encode = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// 获取模版数据
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string GetTemplate(string filepath)
        {
            string html = "";
            if(m_list.ContainsKey(filepath))
            {
                html= m_list[filepath];
            }
            else
            {
                if (System.IO.File.Exists(filepath))
                {
                    html = System.IO.File.ReadAllText(filepath);
                    m_list.TryAdd(filepath, html);
                }
            }

            return html;
        }

        /// <summary>
        /// 获取加密模版
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string GetTemplateEncode(string filepath)
        {
            string html = "";

            if (m_list_encode.ContainsKey(filepath))
            {
                html = m_list_encode[filepath];
            }
            else
            {
                if (System.IO.File.Exists(filepath))
                {
                    html = System.IO.File.ReadAllText(filepath);

                    string content = DN.Framework.Utility.HtmlHelper.NoHTML(html);

                    for (int i = 0; i < content.Length; i++)
                    {
                        string str = string.Concat(content[i]);
                        if (DN.Framework.Utility.ValidateHelper.CheckStringChinese(str))
                        {
                            html = html.Replace(str, DN.Framework.Utility.HtmlHelper.String2Unicode(str));
                        }
                    }

                    m_list_encode.TryAdd(filepath, html);
                }
            }

            return html;
        }
    }
}
