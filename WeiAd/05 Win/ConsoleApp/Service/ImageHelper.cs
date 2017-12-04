using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Service
{
    /// <summary>
    /// 图片合并
    /// </summary>
    public class ImageHelper
    {
        /// <summary>
        /// 图片叠加
        /// </summary>
        /// <param name="path1">底图</param>
        /// <param name="path2">底图</param>
        /// <param name="newpath">新图地址</param>
        public static void Start(string path1,string path2,string newpath)
        {
            string path = path1;
            System.Drawing.Image imgSrc = System.Drawing.Image.FromFile(path);
            System.Drawing.Image imgWarter1 = System.Drawing.Image.FromFile(path2);
            System.Drawing.Image imgWarter = TransparentImage(imgWarter1,0.7f);
            using (Graphics g = Graphics.FromImage(imgSrc))
            {
                g.DrawImage(imgWarter, new Rectangle(0,
                                                 0,
                                                 imgSrc.Width,
                                                 imgSrc.Height),
                        0, 0, imgWarter.Width, imgWarter.Height, GraphicsUnit.Pixel);
            }

            imgSrc.Save(newpath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        /// <summary>  
        /// 处理图片透明操作  
        /// </summary>  
        /// <param name="srcImage">原始图片</param>  
        /// <param name="opacity">透明度(0.0---1.0)</param>  
        /// <returns></returns>  
         static Image TransparentImage(Image srcImage, float opacity)
        {
            float[][] nArray ={ new float[] {1, 0, 0, 0, 0},
                        new float[] {0, 1, 0, 0, 0},
                        new float[] {0, 0, 1, 0, 0},
                        new float[] {0, 0, 0, opacity, 0},
                        new float[] {0, 0, 0, 0, 1}};
            ColorMatrix matrix = new ColorMatrix(nArray);
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Bitmap resultImage = new Bitmap(srcImage.Width, srcImage.Height);
            Graphics g = Graphics.FromImage(resultImage);
            g.DrawImage(srcImage, new Rectangle(0, 0, srcImage.Width, srcImage.Height), 0, 0, srcImage.Width, srcImage.Height, GraphicsUnit.Pixel, attributes);

            return resultImage;
        }

        /// <summary>
        /// 调用此函数后使此两种图片合并，类似相册，有个
        /// 背景图，中间贴自己的目标图片
        /// </summary>
        /// <param name="sourceImg">粘贴的源图片</param>
        /// <param name="destImg">粘贴的目标图片</param>
        public static Image CombinImage(string sourceImg, string destImg)
        {
            Image imgBack = System.Drawing.Image.FromFile(sourceImg);     //相框图片  
            Image img = System.Drawing.Image.FromFile(destImg);        //照片图片


            //从指定的System.Drawing.Image创建新的System.Drawing.Graphics        
            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, 148, 124);      // g.DrawImage(imgBack, 0, 0, 相框宽, 相框高); 
            g.FillRectangle(System.Drawing.Brushes.Black, 16, 16, (int)112 + 2, ((int)73 + 2));//相片四周刷一层黑色边框

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);
            g.DrawImage(img, 17, 17, 112, 73);
            GC.Collect();
            return imgBack;
        }
    }
}
