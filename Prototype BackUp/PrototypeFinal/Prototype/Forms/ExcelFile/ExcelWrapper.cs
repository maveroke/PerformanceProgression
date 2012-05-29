using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;


namespace EmbeddedExcel
{
    public partial class ExcelWrapper : UserControl
    {

        [DllImport("ole32.dll")]
        static extern int GetRunningObjectTable(uint reserved, out IRunningObjectTable pprot);
        [DllImport("ole32.dll")]
        static extern int CreateBindCtx(uint reserved, out IBindCtx pctx);

        #region Fields
        private readonly Missing MISS = Missing.Value;
        /// <summary>Contains a reference to the hosting application.</summary>
        public Microsoft.Office.Interop.Excel.Application m_XlApplication = null;
        /// <summary>Contains a reference to the active workbook.</summary>
        private Workbook m_Workbook = null;
        private bool m_ToolBarVisible = false;
        private Office.CommandBar m_StandardCommandBar = null;
        /// <summary>Contains the path to the workbook file.</summary>
        private string m_ExcelFileName = string.Empty;
        #endregion Fields

        #region Construction
        public ExcelWrapper()
        {
            InitializeComponent();
        }
        #endregion Construction

        #region Properties
        [Browsable(false)]
        public Workbook Workbook
        {
            get { return m_Workbook; }
        }

        [Browsable(true), Category("Appearance")]
        public bool ToolBarVisible
        {
            get { return m_ToolBarVisible; }
            set
            {
                if (m_ToolBarVisible == value) return;
                m_ToolBarVisible = value;
                if (m_XlApplication != null) OnToolBarVisibleChanged();
            }
        }
        #endregion Properties

        #region Events
        private void OnToolBarVisibleChanged()
        {
            try
            {
                m_StandardCommandBar.Visible = m_ToolBarVisible;
            }
            catch { }
        }

        private void OnWebBrowserExcelNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            AttachApplication();
        }

        //private void OnOpenClick(Office.CommandBarButton Ctrl,ref bool Cancel) {
        //    if(this.OpenExcelFileDialog.ShowDialog()==DialogResult.OK) {
        //        OpenFile(OpenExcelFileDialog.FileName);
        //    }
        //}

        //void OnNewClick(Office.CommandBarButton Ctrl,ref bool Cancel) {
        //    throw new Exception("The method or operation is not implemented.");
        //}
        #endregion Events

        #region Methods
        public void OpenFile(string filename)
        {
            // Check the file exists
            if (!System.IO.File.Exists(filename)) throw new Exception();
            m_ExcelFileName = filename;
            // Load the workbook in the WebBrowser control
            this.WebBrowserExcel.Navigate(filename, false);
        }
        public void redirect()
        {
           // this.WebBrowserExcel..Navigate("www.google.com");
        }
        public Workbook GetActiveWorkbook(string xlfile)
        {
            IRunningObjectTable prot = null;
            IEnumMoniker pmonkenum = null;
            string ret = "";
            try
            {
                IntPtr pfetched = IntPtr.Zero;
                // Query the running object table (ROT)
                if (GetRunningObjectTable(0, out prot) != 0 || prot == null) return null;
                prot.EnumRunning(out pmonkenum);
                pmonkenum.Reset();
                IMoniker[] monikers = new IMoniker[1];
                while (pmonkenum.Next(1, monikers, pfetched) == 0)
                {
                    IBindCtx pctx; string filepathname;
                    CreateBindCtx(0, out pctx);
                    // Get the name of the file
                    monikers[0].GetDisplayName(pctx, null, out filepathname);
                    // Clean up
                    Marshal.ReleaseComObject(pctx);
                    // Search for the workbook
                    ret = filepathname.ToString();
                    //if (ret.Replace('\\','/').ToUpper().CompareTo(xlfile.Replace('\\', '/').ToUpper()) == 0)
                    if (ret.Replace('\\', '/').ToUpper().Contains(xlfile.Replace('\\', '/').ToUpper()))
                    {
                        //MessageBox.Show(xlfile.Replace('\\', '/').ToUpper() + "\r\n" + ret.Replace('\\', '/').ToUpper());
                        object roval;
                        // Get a handle on the workbook
                        prot.GetObject(monikers[0], out roval);
                        return roval as Workbook;
                    }
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                // Clean up
                
                if (prot != null) Marshal.ReleaseComObject(prot);
                if (pmonkenum != null) Marshal.ReleaseComObject(pmonkenum);
            }
            return null;
        }
        public string namesTest(string nameOfFile)
        {
            int count = 0; string temp = "";
            foreach (Workbook f in m_XlApplication.Workbooks)
            {
                if (f.Name.CompareTo(nameOfFile) == 0)
                {
                    f.Worksheets[1].Activate();
                }
                count++;
                temp += count + " : " + f.Name + "\r\n";
            }
            return temp;
        }
        public void AttachApplication()
        {
            try
            {
                if (m_ExcelFileName == null || m_ExcelFileName.Length == 0) return;
                // Creation of the workbook object
                if ((m_Workbook = GetActiveWorkbook(m_ExcelFileName)) == null) return;
                // Create the Excel.Application object
                m_XlApplication = (Microsoft.Office.Interop.Excel.Application)m_Workbook.Application;
            }
            catch
            {
                MessageBox.Show("Impossible de charger le fichier Excel");
                return;
            }
        }

        public Worksheet FindExcelWorksheet(string sheetname)
        {
            if (m_Workbook.Sheets == null) return null;
            Worksheet sheet = null;
            // Step through the worksheet collection and see if the sheet is available. If found return true;
            for (int isheet = 1; isheet <= m_Workbook.Sheets.Count; isheet++)
            {
                sheet = (Worksheet)m_Workbook.Sheets.get_Item((object)isheet);
                if (sheet.Name.Equals(sheetname)) { sheet.Activate(); return sheet; }
            }
            return null;
        }
        #endregion Methods
        public void tryThisOnFOrSize()
        {
            ((Microsoft.Office.Interop.Excel._Workbook)m_Workbook).Activate();
        }

        public void Close(bool save)
        {
            try
            {
                // Quit Excel and clean up.
                if (m_Workbook != null)
                {
                    m_Workbook.Close(save, Missing.Value, Missing.Value);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject
                                            (m_Workbook);
                    m_Workbook = null;
                }
                if (m_XlApplication != null)
                {
                    m_XlApplication.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject
                                        (m_XlApplication);
                    m_XlApplication = null;
                    System.GC.Collect();
                }
            }
            catch
            {
                MessageBox.Show("Failed to close the application");
            }
        }
    }
}

