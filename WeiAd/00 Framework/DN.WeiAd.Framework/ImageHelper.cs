using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DN.WeiAd.Framework
{
    /// <summary>
    /// 图片帮助工具
    /// </summary>
    public class ImageHelper
    {
        #region Base64加密  
        /// <summary>  
        /// Base64加密  
        /// </summary>  
        /// <param name="text">要加密的字符串</param>  
        /// <returns></returns>  
        public static string EncodeBase64(string text)
        {
            //如果字符串为空，则返回  

            try
            {
                char[] Base64Code = new char[]{'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T',
                                            'U','V','W','X','Y','Z','a','b','c','d','e','f','g','h','i','j','k','l','m','n',
                                            'o','p','q','r','s','t','u','v','w','x','y','z','0','1','2','3','4','5','6','7',
                                            '8','9','+','/','='};
                byte empty = (byte)0;
                ArrayList byteMessage = new ArrayList(Encoding.Default.GetBytes(text));
                StringBuilder outmessage;
                int messageLen = byteMessage.Count;
                int page = messageLen / 3;
                int use = 0;
                if ((use = messageLen % 3) > 0)
                {
                    for (int i = 0; i < 3 - use; i++)
                        byteMessage.Add(empty);
                    page++;
                }
                outmessage = new System.Text.StringBuilder(page * 4);
                for (int i = 0; i < page; i++)
                {
                    byte[] instr = new byte[3];
                    instr[0] = (byte)byteMessage[i * 3];
                    instr[1] = (byte)byteMessage[i * 3 + 1];
                    instr[2] = (byte)byteMessage[i * 3 + 2];
                    int[] outstr = new int[4];
                    outstr[0] = instr[0] >> 2;
                    outstr[1] = ((instr[0] & 0x03) << 4) ^ (instr[1] >> 4);
                    if (!instr[1].Equals(empty))
                        outstr[2] = ((instr[1] & 0x0f) << 2) ^ (instr[2] >> 6);
                    else
                        outstr[2] = 64;
                    if (!instr[2].Equals(empty))
                        outstr[3] = (instr[2] & 0x3f);
                    else
                        outstr[3] = 64;
                    outmessage.Append(Base64Code[outstr[0]]);
                    outmessage.Append(Base64Code[outstr[1]]);
                    outmessage.Append(Base64Code[outstr[2]]);
                    outmessage.Append(Base64Code[outstr[3]]);
                }
                return outmessage.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Base64解密  
        /// <summary>  
        /// Base64解密  
        /// </summary>  
        /// <param name="text">要解密的字符串</param>  
        public static string DecodeBase64(string text)
        {
            //如果字符串为空，则返回  
          

            //将空格替换为加号  
            text = text.Replace(" ", "+");

            try
            {
                if ((text.Length % 4) != 0)
                {
                    return "包含不正确的BASE64编码";
                }
                if (!Regex.IsMatch(text, "^[A-Z0-9/+=]*$", RegexOptions.IgnoreCase))
                {
                    return "包含不正确的BASE64编码";
                }
                string Base64Code = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
                int page = text.Length / 4;
                ArrayList outMessage = new ArrayList(page * 3);
                char[] message = text.ToCharArray();
                for (int i = 0; i < page; i++)
                {
                    byte[] instr = new byte[4];
                    instr[0] = (byte)Base64Code.IndexOf(message[i * 4]);
                    instr[1] = (byte)Base64Code.IndexOf(message[i * 4 + 1]);
                    instr[2] = (byte)Base64Code.IndexOf(message[i * 4 + 2]);
                    instr[3] = (byte)Base64Code.IndexOf(message[i * 4 + 3]);
                    byte[] outstr = new byte[3];
                    outstr[0] = (byte)((instr[0] << 2) ^ ((instr[1] & 0x30) >> 4));
                    if (instr[2] != 64)
                    {
                        outstr[1] = (byte)((instr[1] << 4) ^ ((instr[2] & 0x3c) >> 2));
                    }
                    else
                    {
                        outstr[2] = 0;
                    }
                    if (instr[3] != 64)
                    {
                        outstr[2] = (byte)((instr[2] << 6) ^ instr[3]);
                    }
                    else
                    {
                        outstr[2] = 0;
                    }
                    outMessage.Add(outstr[0]);
                    if (outstr[1] != 0)
                        outMessage.Add(outstr[1]);
                    if (outstr[2] != 0)
                        outMessage.Add(outstr[2]);
                }
                byte[] outbyte = (byte[])outMessage.ToArray(Type.GetType("System.Byte"));
                return Encoding.Default.GetString(outbyte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        /// <summary>
        /// 字符串转base64
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string StringToBase64(string text)
        {   
            byte[] c = Convert.FromBase64String(text);
            string str = System.Text.Encoding.UTF8.GetString(c);
            return str;
        }

        /// <summary>
        /// 图片转为base64编码的字符串
        /// </summary>
        /// <param name="Imagefilename"></param>
        /// <returns></returns>
        public static string ImgToBase64String(string Imagefilename,bool isimgsrc=false)
        {
            try
            {
                string fileext = Path.GetExtension(Imagefilename);
                fileext = fileext.TrimStart('.');

                Bitmap bmp = new Bitmap(Imagefilename);
                ImageFormat format = ImageFormat.Jpeg;
                if (fileext.Equals("gif", StringComparison.OrdinalIgnoreCase))
                {
                    format = ImageFormat.Gif;
                }
                else if (fileext.Equals("png", StringComparison.OrdinalIgnoreCase))
                {
                    format = ImageFormat.Png;
                }
                else if (fileext.Equals("jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    format = ImageFormat.Jpeg;
                }
                else if (fileext.Equals("bmp", StringComparison.OrdinalIgnoreCase))
                {
                    format = ImageFormat.Bmp;
                }

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, format);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                string basesrc= Convert.ToBase64String(arr);

                if (isimgsrc)
                {
                    basesrc = string.Format("data:image/{0};base64,{1}", fileext, basesrc);
                }
                return basesrc;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// base64编码的字符串转为图片
        /// </summary>
        /// <param name="strbase64"></param>
        /// <returns></returns>
        public static Bitmap Base64StringToImage(string strbase64)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(strbase64);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);

                //bmp.Save("test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //bmp.Save("test.bmp", ImageFormat.Bmp);
                //bmp.Save("test.gif", ImageFormat.Gif);
                //bmp.Save("test.png", ImageFormat.Png);
                ms.Close();
                return bmp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary> 
        /// 将字符串使用base64算法加密 
        /// </summary> 
        /// <param name="sourcestring">待加密的字符串</param> 
        /// <param name="ens">system.text.encoding 对象，如创建中文编码集对象：system.text.encoding.getencoding(54936)</param> 
        /// <returns>加码后的文本字符串</returns> 
        public static string encodingforstring(string sourcestring, System.Text.Encoding ens)
        {
            return Convert.ToBase64String(ens.GetBytes(sourcestring));
        }

        /// <summary> 
        /// 将字符串使用base64算法加密 
        /// </summary> 
        /// <param name="sourcestring">待加密的字符串</param> 
        /// <returns>加码后的文本字符串</returns> 
        public static string encodingforstring(string sourcestring)
        {
            return encodingforstring(sourcestring, System.Text.Encoding.GetEncoding(54936));
        }

        /// <summary> 
        /// 从base64编码的字符串中还原字符串，支持中文 
        /// </summary> 
        /// <param name="base64string">base64加密后的字符串</param> 
        /// <param name="ens">system.text.encoding 对象，如创建中文编码集对象：system.text.encoding.getencoding(54936)</param> 
        /// <returns>还原后的文本字符串</returns> 
        public static string decodingforstring(string base64string, System.Text.Encoding ens)
        {
            /** 
            * *********************************************************** 
            * 
            * 从base64string中取得的字节值为字符的机内码（ansi字符编码） 
            * 一般的，用机内码转换为汉字是公式： 
            * (char)(第一字节的二进制值*256+第二字节值) 
            * 而在c#中的char或string由于采用了unicode编码，就不能按照上面的公式计算了 
            * ansi的字节编和unicode编码不兼容 
            * 故利用.net类库提供的编码类实现从ansi编码到unicode代码的转换 
            * 
            * getencoding 方法依赖于基础平台支持大部分代码页。但是，对于下列情况提供系统支持：默认编码，即在执行此方法的计算机的区域设置中指定的编码；little-endian unicode (utf-16le)；big-endian unicode (utf-16be)；windows 操作系统 (windows-1252)；utf-7；utf-8；ascii 以及 gb18030（简体中文）。 
            * 
            *指定下表中列出的其中一个名称以获取具有对应代码页的系统支持的编码。 
            * 
            * 代码页 名称 
            * 1200 “utf-16le”、“utf-16”、“ucs-2”、“unicode”或“iso-10646-ucs-2” 
            * 1201 “utf-16be”或“unicodefffe” 
            * 1252 “windows-1252” 
            * 65000 “utf-7”、“csunicode11utf7”、“unicode-1-1-utf-7”、“unicode-2-0-utf-7”、“x-unicode-1-1-utf-7”或“x-unicode-2-0-utf-7” 
            * 65001 “utf-8”、“unicode-1-1-utf-8”、“unicode-2-0-utf-8”、“x-unicode-1-1-utf-8”或“x-unicode-2-0-utf-8” 
            * 20127 “us-ascii”、“us”、“ascii”、“ansi_x3.4-1968”、“ansi_x3.4-1986”、“cp367”、“csascii”、“ibm367”、“iso-ir-6”、“iso646-us”或“iso_646.irv:1991” 
            * 54936 “gb18030” 
            * 
            * 某些平台可能不支持特定的代码页。例如，windows 98 的美国版本可能不支持日语 shift-jis 代码页（代码页 932）。这种情况下，getencoding 方法将在执行下面的 c# 代码时引发 notsupportedexception： 
            * 
            * encoding enc = encoding.getencoding("shift-jis"); 
            * 
            * **************************************************************/
            //从base64string中得到原始字符 
            return ens.GetString(Convert.FromBase64String(base64string));
        }

        /// <summary> 
        /// 从base64编码的字符串中还原字符串，支持中文 
        /// </summary> 
        /// <param name="base64string">base64加密后的字符串</param> 
        /// <returns>还原后的文本字符串</returns> 
        public static string decodingforstring(string base64string)
        {
            return decodingforstring(base64string, System.Text.Encoding.GetEncoding(54936));
        }

        //-------------------------------------------------------------------------------------- 

        /// <summary> 
        /// 对任意类型的文件进行base64加码 
        /// </summary> 
        /// <param name="filename">文件的路径和文件名</param> 
        /// <returns>对文件进行base64编码后的字符串</returns> 
        public static string encodingforfile(string filename)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(filename);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);

            /*system.byte[] b=new system.byte[fs.length]; 
            fs.read(b,0,convert.toint32(fs.length));*/

            string base64string = Convert.ToBase64String(br.ReadBytes((int)fs.Length));

            br.Close();
            fs.Close();
            return base64string;
        }

        /// <summary> 
        /// 把经过base64编码的字符串保存为文件 
        /// </summary> 
        /// <param name="base64string">经base64加码后的字符串</param> 
        /// <param name="filename">保存文件的路径和文件名</param> 
        /// <returns>保存文件是否成功</returns> 
        public static bool savedecodingtofile(string base64string, string filename)
        {
            System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Create);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
            bw.Write(Convert.FromBase64String(base64string));
            bw.Close();
            fs.Close();
            return true;
        }

        //------------------------------------------------------------------------------- 

        /// <summary> 
        /// 从网络地址一取得文件并转化为base64编码 
        /// </summary> 
        /// <param name="url">文件的url地址,一个绝对的url地址</param> 
        /// <param name="objwebclient">system.net.webclient 对象</param> 
        /// <returns></returns> 
        public static string encodingfilefromurl(string url, System.Net.WebClient objwebclient)
        {
            return Convert.ToBase64String(objwebclient.DownloadData(url));
        }

        /// <summary> 
        /// 从网络地址一取得文件并转化为base64编码 
        /// </summary> 
        /// <param name="url">文件的url地址,一个绝对的url地址</param> 
        /// <returns>将文件转化后的base64字符串</returns> 
        public static string encodingfilefromurl(string url)
        {
            //system.net.webclient mywebclient = new system.net.webclient(); 
            return encodingfilefromurl(url, new System.Net.WebClient());
        }
    }
}
