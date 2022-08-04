using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FileToFolder
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        readonly int iMinYear = DateTime.Now.Year - 10;
        int iSelectedYear = DateTime.Now.Year;
        //readonly string sFilePath = "../../img";
        readonly string[] sMonthName = { "Jan", "Feb", "March", "April", "May", "June", "July", "Aug", "Sept", "Oct", "Nov", "Dec" };
        string sSrcPath, sDestPath;
        string sYearDirPath, sMonthDirPath, sDateDirPath;
        string sTitle = "Move File To Folder";

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Button btnCancel = new Button();
            btnCancel.Click += BtnCancel_Click;
            this.CancelButton = btnCancel;
            PopulateYear();
            prgMoveStatus.Value = 0;
            string[] arrNamePattern = { "YYYYMMDD", "YYYY-MM-DD" };

            //test
            sSrcPath = $"D:\\2_Project\\FileToFolder\\FileToFolder\\FileToFolder\\img";
            sDestPath = $"D:\\2_Project\\FileToFolder\\FileToFolder\\FileToFolder\\img";
            //string a = "D:/2_Project/FileToFolder/FileToFolder/FileToFolder/img/2021/Dec 2021";
            //MessageBox.Show(Directory.GetDirectories(a).Length.ToString());
        }

        private void PopulateYear()
        {
            for (int iYear = DateTime.Now.Year; iYear >= iMinYear; iYear--)
            {
                cboYear.Items.Add(iYear.ToString());
            }
            cboYear.SelectedIndex = 0;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void BtnMove_Click(object sender, EventArgs e)
        {
            //Create Directory For Year
            sYearDirPath = $"{sDestPath}/{iSelectedYear}";
            CreateDirectory(sYearDirPath);
            for (int iMonth = 1; iMonth <= 12; iMonth++)
            {
                //Create Directory for Month
                string sMonth = (iMonth.ToString().Length == 1) ? "0" + iMonth.ToString() : iMonth.ToString();
                sMonthDirPath = $"{sYearDirPath}/{sMonthName[int.Parse(sMonth) - 1]} {iSelectedYear}";
                CreateDirectory(sMonthDirPath);
                for (int iDate = 1; iDate <= 31; iDate++)
                {
                    string sDate = (iDate.ToString().Length == 1) ? "0" + iDate.ToString() : iDate.ToString();

                    string sName = "*" + iSelectedYear.ToString() + sMonth + sDate + "*";
                    DirectoryInfo di = new DirectoryInfo(sSrcPath);
                    if (di.Exists)
                    {
                        FileInfo[] files = di.GetFiles(sName);
                        int iFilesCount = files.Length;
                        int iCurrFileNo = 0;
                        foreach (FileInfo fi in files)
                        {
                            if (fi.Exists)
                            {
                                this.Text = $"Moving ... {sMonthName[int.Parse(sMonth) - 1]} {iSelectedYear} ... {sDate}{sMonth}{iSelectedYear} ... {fi.Name}";
                                this.Update();
                                iCurrFileNo++;
                                Decimal iPer = decimal.Floor((iCurrFileNo * 100) / iFilesCount);
                                MoveFile(sMonth, sDate, fi, iPer);
                            }
                        }
                        prgMoveStatus.Value = 0;
                    }
                }
                //Check if directory is empty then delete.
                if (!(Directory.GetDirectories(sMonthDirPath).Length > 0)) Directory.Delete(sMonthDirPath, true);
            }
            MessageBox.Show("Transfer Complete.", Application.ProductName);
            this.Text = sTitle;
            this.Update();
        }

        private void CreateDirectory(string sPath)
        {
            if (!(Directory.Exists(sPath))) Directory.CreateDirectory(sPath);
        }

        private void MoveFile(string sMonth, string sDate, FileInfo fi, decimal iPer)
        {
            sDateDirPath = $"{sMonthDirPath}/{sDate}{sMonth}{iSelectedYear}";
            CreateDirectory(sDateDirPath);
            //Directory.CreateDirectory(datePath);
            //File.Move(fi.FullName, datePath + $"/{fi.Name}");
            File.Copy(fi.FullName, sDateDirPath + $"/{fi.Name}", true);//For testing
            //prgMoveStatus.Increment(int.Parse(iPer.ToString()));
            prgMoveStatus.Value = int.Parse(iPer.ToString());
            prgMoveStatus.CreateGraphics().DrawString(iPer.ToString() + "%",
                new Font("Arial", (float)8.25, FontStyle.Regular),
                Brushes.Black,
                new PointF(prgMoveStatus.Width / 2 - 10, prgMoveStatus.Height / 2 - 7));
            prgMoveStatus.Update();
        }

        private void CboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            iSelectedYear = int.Parse(cboYear.SelectedItem.ToString());
        }

        private void BtnSrc_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                txtSrc.Text = folderBrowserDialog1.SelectedPath;
                sSrcPath = txtSrc.Text;
            }
        }

        private void BtnDest_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                txtDest.Text = folderBrowserDialog1.SelectedPath;
                sDestPath = txtDest.Text;
            }
        }
    }
}
