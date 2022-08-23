using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using Newtonsoft.Json;

namespace FileToFolder
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private int iMinYear = DateTime.Now.Year;//- 10;
        private int iSelectedYear = DateTime.Now.Year;
        private readonly string[] sMonthName = { "Jan", "Feb", "March", "April", "May", "June", "July", "Aug", "Sept", "Oct", "Nov", "Dec" };
        private string sSrcPath, sDestPath;
        private string sYearDirPath, sMonthDirPath, sDateDirPath;
        private readonly string sTitle = "Move File To Folder";
        private string[] arrNamePattern;//{ "YYYYMMDD", "YYYY-MM-DD" };//Pattern for filename matching, add in array if file found with new pattern.
        public enum MsgType
        {
            Info = 1,
            Error = 2,
            Warning = 3
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Button btnCancel = new Button();
            btnCancel.Click += BtnCancel_Click;
            CancelButton = btnCancel;
            LoadConfigAndControls();
            prgMoveStatus.Value = 0;
            this.Cursor = DefaultCursor;
        }

        private void LoadConfigAndControls()
        {
            iMinYear -= int.Parse(ConfigurationManager.AppSettings["MinYear"]);
            arrNamePattern = ConfigurationManager.AppSettings["NamePattern"].Split(',');
            sSrcPath = ConfigurationManager.AppSettings["SrcPath"];
            sDestPath = ConfigurationManager.AppSettings["DestPath"];

            PopulateControls();
        }

        private void PopulateControls()
        {
            for (int iYear = DateTime.Now.Year; iYear >= iMinYear; iYear--)
            {
                cboYear.Items.Add(iYear.ToString());
            }
            cboYear.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(sSrcPath))
            { txtSrc.Text = sSrcPath; }
            if (!string.IsNullOrEmpty(sDestPath))
            { txtDest.Text = sDestPath; }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void BtnMove_Click(object sender, EventArgs e)
        {
            //string _testPath = "C:\\Users\\hari1\\Downloads\\Test\\Img\\FB_IMG_1457091083345.jpg.json";
            //FILEPROP p = new FILEPROP();
            //StreamReader _r = new StreamReader(_testPath);
            //p = JsonConvert.DeserializeObject<FILEPROP>(_r.ReadToEnd());
            //return;

            MoveFBFiles();
            return;
            if (ValidateForm())
                return;
            this.Cursor = Cursors.WaitCursor;
            //Create Directory For Year
            sYearDirPath = $"{sDestPath}/{iSelectedYear}";
            CreateDirectory(sYearDirPath);

            List<string> arrayList = new List<string>();
            for (int iMonth = 1; iMonth <= 12; iMonth++)
            {
                //Create Directory for Month
                string sMonth = (iMonth.ToString().Length == 1) ? "0" + iMonth.ToString() : iMonth.ToString();
                sMonthDirPath = $"{sYearDirPath}/{sMonthName[int.Parse(sMonth) - 1]} {iSelectedYear}";
                CreateDirectory(sMonthDirPath);
                for (int iDate = 1; iDate <= 31; iDate++)
                {
                    string sDate = (iDate.ToString().Length == 1) ? "0" + iDate.ToString() : iDate.ToString();
                    int iCurrFileNo = 0;
                    foreach (var item in arrNamePattern)
                    {
                        var sNameSearch = "*" + item.Replace("YYYY", iSelectedYear.ToString()).Replace("MM", sMonth).Replace("DD", sDate) + "*";
                        string[] arrFileName = Directory.GetFiles(sSrcPath, sNameSearch);
                        arrayList.AddRange(arrFileName);
                    }

                    int iFilesCount = arrayList.Count;

                    foreach (string _name in arrayList)
                    {
                        FileInfo fi = new FileInfo(_name);
                        if (fi.Exists)
                        {
                            Text = $"Moving ... {sMonthName[int.Parse(sMonth) - 1]} {iSelectedYear} ... {sDate}{sMonth}{iSelectedYear} ... {fi.Name}";
                            Update();
                            iCurrFileNo++;
                            Decimal iPer = decimal.Floor((iCurrFileNo * 100) / iFilesCount);
                            MoveFile(sMonth, sDate, fi, iPer);
                        }
                    }
                    prgMoveStatus.Value = 0;
                }
                if (Directory.GetDirectories(sMonthDirPath).Length == 0)
                {
                    Directory.Delete(sMonthDirPath, true);
                }
            }


            DisplayMessage("Transfer Complete.", MsgType.Info);
            sSrcPath = sDestPath = "";
            Text = sTitle;
            Update();
            this.Cursor = DefaultCursor;
        }

        private void MoveFBFiles()
        {
            //File to be placed in photoTakenTime.formatted
            //FB_IMG_1457091083345.jpg.json
            List<string> fbFilesList = new List<string>(Directory.EnumerateFiles(sSrcPath, "FB*.json"));
            foreach (var item in fbFilesList)
            {
                FILEPROP fileProp = new FILEPROP();
                fileProp = JsonConvert.DeserializeObject<FILEPROP>(new StreamReader(item).ReadToEnd());
                DateTime dt = Convert.ToDateTime(fileProp.photoTakenTime.formatted.Substring(0, fileProp.photoTakenTime.formatted.Length - 4));//Remove UTC word the datetime
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(sSrcPath))
            {
                DisplayMessage("Source Path Cannot Be Empty.", MsgType.Error);
                return true;
            }
            if (string.IsNullOrEmpty(sDestPath))
            {
                DisplayMessage("Destination Path Cannot Be Empty.", MsgType.Error);
                return true;
            }
            return false;
        }

        private void DisplayMessage(string _msg, MsgType _msgType)
        {
            MessageBoxIcon icon = MessageBoxIcon.None;
            switch (_msgType)
            {
                case MsgType.Info:
                    icon = MessageBoxIcon.Information;
                    break;
                case MsgType.Error:
                    icon = MessageBoxIcon.Error;
                    break;
                case MsgType.Warning:
                    icon = MessageBoxIcon.Warning;
                    break;
            }
            MessageBox.Show(_msg, "File To Folder", MessageBoxButtons.OK, icon);
        }

        private void CreateDirectory(string sPath)
        {
            if (!Directory.Exists(sPath))
            {
                _ = Directory.CreateDirectory(sPath);
            }
        }

        private void MoveFile(string sMonth, string sDate, FileInfo fi, decimal iPer)
        {
            sDateDirPath = $"{sMonthDirPath}/{sDate}{sMonth}{iSelectedYear}";
            CreateDirectory(sDateDirPath);
            File.Move(fi.FullName, sDateDirPath + $"/{fi.Name}");
            prgMoveStatus.Value = int.Parse(iPer.ToString());
            prgMoveStatus.CreateGraphics().DrawString(iPer.ToString() + "%",
                new Font("Arial", (float)8.25, FontStyle.Regular),
                Brushes.Black,
                new PointF((prgMoveStatus.Width / 2) - 10, (prgMoveStatus.Height / 2) - 7));
            prgMoveStatus.Update();
        }

        private void CboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            iSelectedYear = int.Parse(cboYear.SelectedItem.ToString());
        }

        private void BtnSrc_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtSrc.Text;
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                txtSrc.Text = folderBrowserDialog1.SelectedPath;
                sSrcPath = txtSrc.Text;
            }
        }

        private void BtnDest_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtDest.Text;
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                txtDest.Text = folderBrowserDialog1.SelectedPath;
                sDestPath = txtDest.Text;
            }
        }
    }
}
