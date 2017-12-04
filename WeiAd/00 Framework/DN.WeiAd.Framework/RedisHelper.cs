using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using ServiceStack.Redis.Support;

namespace DN.WeiAd.Framework
{
    public class RedisHelper
    {
        //获取Redis操作接口  
        IRedisClient Redis = RedisManager.GetClient();
        //Hash表操作  
        HashOperator operators = new HashOperator();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashid"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add<T>(string hashid,string key,T value)
        {
            try
            {
                operators.Set<T>(hashid, key, value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Add(string key,string value)
        {
            try
            {
                operators.Set(key, key, value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Add<T>(string key,T value)
        {
            try
            {
                operators.Set<T>(key, key, value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public T Get<T>(string key)
        {
            try
            {
                return operators.Get<T>(key, key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default(T);
        }
        public T Get<T>(string hashid,string key)
        {
            try
            {
                return operators.Get<T>(hashid, key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default(T);
        }

        public void Delete(string key)
        {
            try
            {
                operators.Remove(key, key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Test()
        {
            try
            {
                //获取Redis操作接口  
                IRedisClient Redis = RedisManager.GetClient();
                //Hash表操作  
                HashOperator operators = new HashOperator();

                //移除某个缓存数据  
                bool isTrue = Redis.Remove("additemtolist");

                //将字符串列表添加到redis  
                List<string> storeMembers = new List<string>() { "韩梅梅", "李雷", "露西" };
                storeMembers.ForEach(x => Redis.AddItemToList("additemtolist", x));
                //得到指定的key所对应的value集合  
                Console.WriteLine("得到指定的key所对应的value集合：");
                var members = Redis.GetAllItemsFromList("additemtolist");
                members.ForEach(s => Console.WriteLine("additemtolist :" + s));
                Console.WriteLine("");

                // 获取指定索引位置数据  
                Console.WriteLine("获取指定索引位置数据：");
                var item = Redis.GetItemFromList("additemtolist", 2);
                Console.WriteLine(item);

                Console.WriteLine("");

                //将数据存入Hash表中  
                Console.WriteLine("Hash表数据存储:");
                UserInfo userInfos = new UserInfo() { UserName = "李雷", Age = 45 };
                var ser = new ObjectSerializer();    //位于namespace ServiceStack.Redis.Support;  
                bool results = operators.Set<byte[]>("userInfosHash", "userInfos", ser.Serialize(userInfos));
                byte[] infos = operators.Get<byte[]>("userInfosHash", "userInfos");
                userInfos = ser.Deserialize(infos) as UserInfo;
                Console.WriteLine("name=" + userInfos.UserName + "   age=" + userInfos.Age);

                Console.WriteLine("");

                //object序列化方式存储  
                Console.WriteLine("object序列化方式存储:");
                UserInfo uInfo = new UserInfo() { UserName = "张三", Age = 12 };
                bool result = Redis.Set<byte[]>("uInfo", ser.Serialize(uInfo));
                UserInfo userinfo2 = ser.Deserialize(Redis.Get<byte[]>("uInfo")) as UserInfo;
                Console.WriteLine("name=" + userinfo2.UserName + "   age=" + userinfo2.Age);

                Console.WriteLine("");

                //存储值类型数据  
                Console.WriteLine("存储值类型数据:");
                Redis.Set<int>("my_age", 12);//或Redis.Set("my_age", 12);  
                int age = Redis.Get<int>("my_age");
                Console.WriteLine("age=" + age);

                Console.WriteLine("");

                //序列化列表数据  
                Console.WriteLine("列表数据:");
                List<UserInfo> userinfoList = new List<UserInfo> {
                new UserInfo{UserName="露西",Age=1,Id=1},
                new UserInfo{UserName="玛丽",Age=3,Id=2},
            };
                Redis.Set<byte[]>("userinfolist_serialize", ser.Serialize(userinfoList));
                List<UserInfo> userList = ser.Deserialize(Redis.Get<byte[]>("userinfolist_serialize")) as List<UserInfo>;
                userList.ForEach(i =>
                {
                    Console.WriteLine("name=" + i.UserName + "   age=" + i.Age);
                });
                //释放内存  
                Redis.Dispose();
                operators.Dispose();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.WriteLine("Please open the redis-server.exe ");
                Console.ReadKey();
            }
        }

        [Serializable]
        public class UserInfo
        {
            public int Id;
            public string UserName;
            public int Age;
        }
    }
}
