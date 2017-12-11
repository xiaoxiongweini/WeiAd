using System;

using System.Data;

using System.Configuration;

using System.Web;

using System.Web.Security;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Web.UI.WebControls.WebParts;

using System.Web.UI.HtmlControls;

using System.IO;

using System.Threading;





namespace WriteLog

{

    /// <summary>  

    /// WriteData 的摘要说明。  

    /// </summary>  

    public class WriteData

    {

        static public string m_Path = @"./Log/";

        static public string m_FilePreName = "导入bak";

        static Mutex m_WriteMutex = new Mutex();





        public WriteData()

        {

            //  

            // TODO: 在此处添加构造函数逻辑  

            //  



        }





        static public bool WriteLine(string dataText)

        {

            return WriteLine(dataText, 3);

        }





        static public bool WriteLine(string dataText, int theLevel)

        {

            FileStream fs = null;

            StreamWriter sw = null;

            bool ret = true;

            m_WriteMutex.WaitOne();

            try

            {

                string FileName = m_Path;

                //CHECK文件目录存在不  

                if (!Directory.Exists(FileName))

                {

                    Directory.CreateDirectory(FileName);

                }

                FileName += @"/" + m_FilePreName + DateTime.Now.ToString(".yyyMMdd");

                //CHECK文件存在不  

                if (!File.Exists(FileName))

                {

                    FileStream tempfs = File.Create(FileName);

                    tempfs.Close();

                }

                fs = new FileStream(

                    FileName,

                    FileMode.Append,

                    FileAccess.Write,

                    FileShare.None);



                fs.Seek(0, System.IO.SeekOrigin.End);

                sw = new StreamWriter(fs, System.Text.Encoding.UTF8);

                string LineText = DateTime.Now.ToString("yyy-MM-dd ") + DateTime.Now.ToString("T") + ", " + theLevel.ToString() + ", " + dataText;

                sw.WriteLine(LineText);

                if (sw != null)

                {

                    sw.Close();

                    sw = null;

                }

                if (fs != null)

                {

                    fs.Close();

                    fs = null;

                }





            }

            catch (Exception)

            {

                ret = false;

            }

            finally

            {

                try

                {

                    if (sw != null)

                    {

                        sw.Close();

                        sw = null;

                    }

                    if (fs != null)

                    {

                        fs.Close();

                        fs = null;

                    }

                }

                catch

                {

                }

                m_WriteMutex.ReleaseMutex();

            }

            return ret;

        }



        static public void WriteFile(string filename, byte[] dataText)

        {

            try

            {

                FileInfo finfo = new FileInfo(filename);

                FileStream fs = finfo.OpenWrite();

                fs.Write(dataText, 0, dataText.Length);

                fs.Close();

                return;

            }

            catch (Exception)

            {

                return;

            }

        }

    }



}