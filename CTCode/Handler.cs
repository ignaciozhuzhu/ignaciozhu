using System;
using System.Drawing;
using System.Web;

namespace CTCode
{
    public class Handler : IHttpHandler
    {
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此处理程序 
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // 如果无法为其他请求重用托管处理程序，则返回 false。
            // 如果按请求保留某些状态信息，则通常这将为 false。
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //在此处写入您的处理程序实现。
        }

        /// <summary>
        /// 生成二维码至指定路径
        /// </summary>
        /// <param name="request"></param>
        public void getqrcode()
        {
            try
            {
                string productbarcode = HttpContext.Current.Request["productbarcode"].ToString();
                string FrameBarcode4 = HttpContext.Current.Request["FrameBarcode4"].ToString();
                string code = productbarcode + '-' + FrameBarcode4;
                HttpContext.Current.Response.ContentType = "image/*";
                QRCode QRCode = new QRCode();
                QRCode.Create_CodeImages(code);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                //image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ContentType = "image/Gif";
                HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            }
            catch { }
        }

        /// <summary>
        /// 生成条形码
        /// </summary>
        /// <param name="request"></param>
        public void getbarcode()
        {
            try
            {
                string productbarcode = HttpContext.Current.Request["productbarcode"].ToString();
                string FrameBarcode4 = HttpContext.Current.Request["FrameBarcode4"].ToString();
                string code = productbarcode + '-' + FrameBarcode4;
                HttpContext.Current.Response.ContentType = "image/*";
                BarCode _Code128 = new BarCode();
                _Code128.Height = 45;
                _Code128.Magnify = 1;
                _Code128.ValueFont = new Font("宋体", 10);
                Bitmap image = _Code128.GetCodeImage(code,BarCode.Encode.BarCodeA);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ContentType = "image/Gif";
                HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            }
            catch { }
        }

        #endregion
    }
}
