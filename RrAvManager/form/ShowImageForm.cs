using RrAvManager.util;
using RrAvManager.util.def;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RrAvManager
{
    public partial class ShowImageForm : Form
    {
        private Image currOrgImage = null;

        public ShowImageForm()
        {
            InitializeComponent();

            MouseWheel += ShowImageForm_MouseWheel;
            //this.Size = new Size(SystemInformation.VirtualScreen.Width - 20, SystemInformation.VirtualScreen.Height - 20);
        }

        /// <summary>
        /// 鼠滾動事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowImageForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Visible)
            {
                setSize(e.Delta > 0);
            }
        }

        public void setPosition(int x, int y)
        {
            DesktopLocation = new Point(x + EvnDef.mouseLeftSize, y + EvnDef.mouseLeftSize);
        }

        public void setImage(string imagePath)
        {
            if (!File.Exists(imagePath))
            {
                currOrgImage = null;
                picBoxShowImage.Image = null;
                return;
            }

            //設定視窗大小
            Size = new Size(EvnDef.showWidth, EvnDef.showHeight);
            //取得圖片
            currOrgImage = Image.FromFile(imagePath);
            //重設圖片大小
            picBoxShowImage.Image = CommUtil.ResizeImage(currOrgImage, EvnDef.showWidth, EvnDef.showHeight);
            //設定圖片框大小
            picBoxShowImage.Size = new Size(EvnDef.showWidth - 5, EvnDef.showHeight - 5);
            //picBoxShowImage.Location = new Point(0, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="isAddSize"></param>
        public void setSize(Boolean isAddSize)
        {
            if (currOrgImage == null)
            {
                return;
            }

            decimal newWidth = Size.Width;
            decimal newHeight = 0;

            //增減大小
            if (isAddSize)
            {
                newWidth += EvnDef.zoomInOutSize;
            }
            else
            {
                newWidth -= EvnDef.zoomInOutSize;
            }

            //避免超出桌面大小 (最大寬度=螢幕寬度-滑鼠X軸位置-邊緣寬度)
            newWidth = setInLimit(newWidth, 300, SystemInformation.VirtualScreen.Width - MousePosition.X - 20);
            //高度依據寬度比例增減(維持原比例)
            newHeight = currOrgImage.Size.Height * (newWidth / currOrgImage.Size.Width);

            int intWidth = Convert.ToInt32(newWidth);
            int intHeight = Convert.ToInt32(newHeight);

            //設定視窗大小
            Size = new Size(intWidth, intHeight);

            //重新設定圖片大小
            picBoxShowImage.Image = CommUtil.ResizeImage(currOrgImage, intWidth - 5, intHeight - 5);
            //設定圖片框大小
            picBoxShowImage.Size = new Size(intWidth - 5, intHeight - 5);

            CommUtil.SetWindowDesktopLocation(this, MousePosition.X, MousePosition.Y);
        }

        private static decimal setInLimit(decimal num, int min, int max)
        {
            if (num <= min)
            {
                return min;
            }
            if (num >= max)
            {
                return max;
            }
            return num;
        }

        private void ShowImageForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            DesktopLocation = new Point(MousePosition.X + EvnDef.mouseLeftSize, MousePosition.Y + EvnDef.mouseLeftSize);
        }
    }
}