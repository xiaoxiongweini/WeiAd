using DN.WeiAd.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DN.WeiAd.Api.Controllers
{
    public class ContactController : ApiController
    {
        List<Contact> m_list = new List<Contact>();

        private void InitDb()
        {
            if (m_list.Count == 0)
            {
                m_list.Add(new Contact() { ID = 1, Age = 23, Birthday = Convert.ToDateTime("1977-05-30"), Name = "情缘", Sex = "男" });
                m_list.Add(new Contact() { ID = 2, Age = 55, Birthday = Convert.ToDateTime("1937-05-30"), Name = "令狐冲", Sex = "男" });
                m_list.Add(new Contact() { ID = 3, Age = 12, Birthday = Convert.ToDateTime("1987-05-30"), Name = "郭靖", Sex = "男" });
                m_list.Add(new Contact() { ID = 4, Age = 18, Birthday = Convert.ToDateTime("1997-05-30"), Name = "黄蓉", Sex = "女" });
            }
        }

        // GET: api/Contact
        public IEnumerable<Contact> Get()
        {
            InitDb();

            return m_list;

        }

        // GET: api/Contact/5
        public Contact GetContactById(int id)
        {

            InitDb();

            var info = m_list.SingleOrDefault(p => p.ID == id);

            return info;
        }

        // POST: api/Contact
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contact/5
        public void Delete(int id)
        {
        }
    }
}
