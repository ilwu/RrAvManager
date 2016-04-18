using rbt.util;
using rbt.util.exception;
using RrAvManager.parser;
using RrAvManager.Properties;
using RrAvManager.sublogic;
using RrAvManager.util;
using RrAvManager.util.db;
using RrAvManager.util.def;
using RrAvManager.util.exception;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RrAvManager
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 主列表資料容器
        /// </summary>
        private DataTable mainListDatatable;

        private readonly RavmDBUtil ravmDBUtil = new RavmDBUtil("RrAvManager.db");

        public MainForm()
        {
            InitializeComponent();

            //調整欄之後就會自動變化，故於初始化時設定
            gvMainLsit.AutoGenerateColumns = false;
            //設定初始畫面置中
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //目錄瀏覽器初始化
            treeViewFolderExploerInit();
        }

        #region 按鈕事件

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileScan_Click(object sender, EventArgs e)
        {
            CommUtil commUtil = new CommUtil();
            try
            {
                if (treeViewFolderExploer.SelectedNode == null)
                {
                    MessageBox.Show("請選擇目錄!");
                    return;
                }

                treeViewFolderExploer.SelectedNode.BackColor = Color.Aqua;

                //========================================
                //前置
                //========================================
                //當前路徑
                labScanDir.Text = treeViewFolderExploer.SelectedNode.Tag.ToString().Trim();

                //處理按鈕鎖定
                commUtil.ProcessBtnLockStart(this, (Button)sender);

                //切回檔案列表
                tabControl1.SelectTab(tabPageFileManager);

                //清除檔案清單
                litBoxFileList.Items.Clear();

                //========================================
                //掃瞄目錄下所有影片檔案
                //========================================
                mainListDatatable = SubLogicFileManager.ScanFolder(
                    labScanDir.Text,
                    litBoxFileList);
                //========================================
                //更新畫面列表
                //========================================
                gvMainLsit.DataSource = mainListDatatable;
            }
            catch (Exception ex)
            {
                ShowException(ex, "查詢失敗！");
            }
            finally
            {
                //處理完成，還原按鈕狀態
                commUtil.ProcessBtnLockEnd(this);
            }
        }

        // <summary>
        // 事件：品番查詢
        // </summary>
        private void btnSearchSNO_Click(object sender, EventArgs e)
        {
            //=================================================
            //檢核搜尋品番
            //=================================================
            txtSearchID.Text = StringUtil.SafeTrim(txtSearchID.Text);
            if (txtSearchID.Text == "")
            {
                txtSearchID.Focus();
                MessageBox.Show("搜尋品番不可為空白！");
                return;
            }

            //=================================================
            //開始查詢資料
            //=================================================

            VideoInfo videoInfo = null;
            CommUtil commUtil = new CommUtil();

            try
            {
                //========================================
                //處理按鈕鎖定
                //========================================
                commUtil.ProcessBtnLockStart(this, (Button)sender);

                //========================================
                //由網站解析資料
                //========================================
                videoInfo = new JavlibraryParser().parseJavlibrary(txtSearchID.Text);
            }
            catch (HtmlPathErrorException ex)
            {
                ShowException(ex, Resources.MSG_WEB_CONTENT_CHANGE);
                return;
            }
            catch (MessageException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                ShowException(ex, "查詢失敗！");
                return;
            }
            finally
            {
                //處理完成，還原按鈕狀態
                commUtil.ProcessBtnLockEnd(this);
            }

            //=================================================
            //開始查詢資料
            //=================================================
            if (videoInfo != null)
            {
                //封面
                picVdoInfoVdoCover.Image = videoInfo.COVER;
                //片名
                txtVdoInfoVdoName.Text = videoInfo.NAME;
                //演員
                txtVdoInfoActor.Text = videoInfo.ACTOR;
                //製作商
                txtVdoInfoMaker.Text = videoInfo.MAKER;
                //發行商
                txtVdoInfoIssuer.Text = videoInfo.ISSUER;
                //發售日
                txtVdoInfoReleaseDate.Text = videoInfo.RELEASE_DATE;
                //品番
                txtVdoInfoSno.Text = videoInfo.SNO;
                //片長
                txtVdoInfoLength.Text = videoInfo.LENGTH;
                //簡介
                txtVdoInfoIntro.Text = videoInfo.INTRO;
            }
        }

        #endregion 按鈕事件

        #region 目錄瀏覽器

        /// <summary>
        /// 目錄瀏覽器初始化
        /// </summary>
        private void treeViewFolderExploerInit()
        {
            //清除所有節點
            treeViewFolderExploer.Nodes.Clear();
            foreach (var logicalDrive in Environment.GetLogicalDrives())
            {
                TreeNode mRootNode = new TreeNode
                {
                    Text = logicalDrive,
                    Tag = logicalDrive,
                    Name = logicalDrive.ToLower()
                };
                mRootNode.Nodes.Add("*DUMMY*");
                treeViewFolderExploer.Nodes.Add(mRootNode);
            }
        }

        /// <summary>
        ///折疊節點前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewFolderExploer_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            // clear the node that is being collapsed
            e.Node.Nodes.Clear();
            // add a dummy TreeNode to the node being collapsed so it is expandable
            e.Node.Nodes.Add("*DUMMY*");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewFolderExploer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // clear the argNode so we can re-populate, or else we end up with duplicate nodes
            {
                e.Node.Nodes.Clear();
                // get the directory representing this node
                DirectoryInfo mNodeDirectory = default(DirectoryInfo);
                mNodeDirectory = new DirectoryInfo(e.Node.Tag.ToString());
                // add each directory from the file system that is a child of the argNode that was passed in

                try
                {
                    foreach (DirectoryInfo mDirectory in mNodeDirectory.GetDirectories())
                    {
                        // declare a TreeNode for this directory
                        TreeNode mDirectoryNode = new TreeNode
                        {
                            Tag = mDirectory.FullName,
                            Text = mDirectory.Name,
                            Name = mDirectory.FullName.ToLower()
                        };
                        // store the full path to this directory in the directory TreeNode's Tag property
                        // set the directory TreeNodes's display text
                        // TODO: NEW .Name property set
                        // add a dummy TreeNode to the directory node so that it is expandable
                        mDirectoryNode.Nodes.Add("*DUMMY*");
                        // add this directory treenode to the treenode that is being populated
                        e.Node.Nodes.Add(mDirectoryNode);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void treeViewFolderExploer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //labScanDir.Text = StringUtil.SafeTrim(e.Node.Tag);
        }

        #endregion 目錄瀏覽器

        #region 檔案列表滑鼠移動事件

        //====================================================================
        //滑鼠移動秀大圖事件
        //====================================================================
        /// <summary>
        ///
        /// </summary>
        private ShowImageForm mainListShowImageForm;

        private int mainListShowImageCurrRow = -1;

        /// <summary>
        /// 事件：滑鼠進入CELL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvMainLsit_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //========================================
            //滑鼠移動秀大圖事件
            //========================================
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                var formattedValue = gvMainLsit.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue;

                if (formattedValue is Bitmap)
                {
                    //不存在時建立新視窗
                    if (mainListShowImageForm == null)
                    {
                        mainListShowImageForm = new ShowImageForm();
                    }

                    //列數不一樣時(不同筆，重新取圖
                    if (mainListShowImageCurrRow != e.RowIndex)
                    {
                        //取得資料 index 值
                        int index =
                            short.Parse(
                                StringUtil.SafeTrim(gvMainLsit.Rows[e.RowIndex].Cells[ColDef.INDEX].FormattedValue));

                        //組圖片檔路徑
                        string filepath = StringUtil.SafeTrim(mainListDatatable.Rows[index][ColDef.DIRECTORY_PATH]) +
                                          StringUtil.SafeTrim(mainListDatatable.Rows[index][ColDef.COVER_FILE_NAME]);

                        //交付路徑給新視窗
                        mainListShowImageForm.setImage(filepath);

                        mainListShowImageCurrRow = e.RowIndex;
                    }
                    //else
                    //{
                    //    mainListShowImageForm.Visible = true;
                    //    return;
                    //}

                    //顯示

                    mainListShowImageForm.Show();
                }
            }
        }

        /// <summary>
        ///事件：滑鼠離開 CELL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvMainLsit_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            //========================================
            //滑鼠移動秀大圖事件
            //========================================
            //移出時關閉
            if (e.ColumnIndex == 0)
            {
                mainListShowImageForm?.Hide();
            }

            //========================================
            //字型變化
            //========================================
            //dynamic normalFont = new Font(gvMainLsit.DefaultCellStyle.Font, FontStyle.Regular);
            //if ((e.ColumnIndex > -1))
            //{
            //    if (e.RowIndex > -1)
            //    {
            //        var formattedValue = gvMainLsit.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue;
            //        if (formattedValue != null && formattedValue.ToString().Trim().Length > 0)
            //        {
            //            gvMainLsit.Rows[e.RowIndex].DefaultCellStyle.Font = normalFont;
            //        }
            //        else
            //        {
            //            gvMainLsit.Rows[e.RowIndex].DefaultCellStyle.Font = normalFont;
            //        }
            //    }
            //}
        }

        /// <summary>
        ///事件：滑鼠移動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvMainLsit_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            //========================================
            //滑鼠移動秀大圖事件
            //========================================
            //圖形隨滑鼠移動
            if (e.ColumnIndex == 0 && mainListShowImageForm != null)
            {
                CommUtil.SetWindowDesktopLocation(mainListShowImageForm, MousePosition.X, MousePosition.Y);
            }

            //string xy = e.RowIndex + "_" + e.ColumnIndex;

            //if (showImageFormDic.ContainsKey(xy))
            //{
            //    ShowImageForm showImageForm = showImageFormDic[xy];
            //    showImageForm.setPosition(MousePosition.X, MousePosition.Y);
            //}
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvMainLsit_MouseMove(object sender, MouseEventArgs e)
        {
            //========================================
            //字型變化
            //========================================
            //dynamic normalFont = new Font(gvMainLsit.DefaultCellStyle.Font, FontStyle.Regular);
            //DataGridView.HitTestInfo hit = gvMainLsit.HitTest(e.X, e.Y);
            //if (hit.Type == DataGridViewHitTestType.Cell)
            //{
            //    var formattedValue = gvMainLsit.Rows[hit.RowIndex].Cells[hit.ColumnIndex].FormattedValue;
            //    if (formattedValue != null && formattedValue.ToString().Trim().Length > 0)
            //    {
            //        gvMainLsit.Rows[hit.RowIndex].DefaultCellStyle.Font = new Font(gvMainLsit.DefaultCellStyle.Font, FontStyle.Underline);
            //    }
            //    else
            //    {
            //        gvMainLsit.Rows[hit.RowIndex].DefaultCellStyle.Font = normalFont;
            //    }
            //}
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvMainLsit_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            //========================================
            //將點選的資料放到搜尋欄
            //========================================
            //取得影像檔名
            string sno = StringUtil.SafeTrim(gvMainLsit.Rows[e.RowIndex].Cells[ColDef.VIDEO_FILE_NAME].FormattedValue);
            //去附檔名
            sno = Path.GetFileNameWithoutExtension(sno);
            //放到搜尋欄
            txtSearchID.Text = sno;
        }

        private void gvMainLsit_MouseLeave(object sender, EventArgs e)
        {
            //========================================
            //離開主列表時刪除顯示窗
            //========================================
            if (mainListShowImageForm != null)
            {
                mainListShowImageForm.Close();
                mainListShowImageForm.Dispose();
                mainListShowImageForm = null;
            }
        }

        /// <summary>
        ///顯示 exceptioon
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        private void ShowException(Exception ex, string message = "")
        {
            txtDebug.Text = ex.Message + "\r\n\r\n" + ex.StackTrace;
            tabPageDebug.Visible = true;
            tabControl1.SelectTab(tabPageDebug);
            MessageBox.Show(message);
        }

        #endregion 檔案列表滑鼠移動事件
    }
}