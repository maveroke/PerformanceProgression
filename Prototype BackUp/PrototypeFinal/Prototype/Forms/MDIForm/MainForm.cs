using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Prototype;
using Prototype.Forms;
using System.Collections.Generic;
using Prototype.Forms.ProgramForms;
using Prototype.Forms.Authors;
using CoolPrintPreview;
using Prototype.Forms.Information;
using ProductProtection;
namespace mdisample
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class MainFormSample : Form
    {
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem miLayout;
        private System.Windows.Forms.MenuItem miHoriz;
        private System.Windows.Forms.MenuItem miVert;
        private System.Windows.Forms.MenuItem miFile;
        private System.Windows.Forms.MenuItem miNew;
        private System.Windows.Forms.MenuItem miClose;
        private System.Windows.Forms.MenuItem miWindow;
        private System.Windows.Forms.MenuItem miMax;
        private System.Windows.Forms.MenuItem miMin;
        private System.Windows.Forms.OpenFileDialog oFileDlg;
        private System.Windows.Forms.MenuItem miCloseAll;
        private MenuItem miOpen;
        private MenuItem miDelete;
        private MenuItem miHelp;
        private MenuItem menuItemAbout;
        private MenuItem menuItemAuthors;
        private Timer timer1;
        private MenuItem menuItemData;
        private IContainer components;
        private MenuItem menuItemHowToUse;
        private MenuItem menuItem2;
        private MenuItem menuItem1;
        private Contents contentsMain;
        private ProductProtection.ProductProtection PP;

        public MainFormSample()
        {
            //
            // Required for Windows Form Designer support
            //

            InitializeComponent();
            contentsMain = new Contents();
            contentsMain.MdiParent = this;
            contentsMain.CNButtonClicked += new EventHandler(CN_contents_ButtonClicked);
            contentsMain.OPButtonClicked += new EventHandler(OP_contents_ButtonClicked);
            contentsMain.Show();

            mainProgramDisable();
            PP = new ProductProtection.ProductProtection();
            PP.continueButtonClicked += new EventHandler(continueButtonClicked_ButtonClicked);
            PP.Show();
            
        }

        private void mainProgramDisable()
        {
            this.Enabled = false;
            this.miClose.Enabled = false;
            this.miFile.Enabled = false;
            this.miWindow.Enabled = false;
            this.miLayout.Enabled = false;
            this.miHelp.Enabled = false;
        }
        private void mainProgramEnable()
        {
            this.Enabled = true;
            this.miClose.Enabled = true;
            this.miFile.Enabled = true;
            this.miWindow.Enabled = true;
            this.miLayout.Enabled = true;
            this.miHelp.Enabled = true;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.miFile = new System.Windows.Forms.MenuItem();
            this.miNew = new System.Windows.Forms.MenuItem();
            this.miOpen = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.miDelete = new System.Windows.Forms.MenuItem();
            this.miClose = new System.Windows.Forms.MenuItem();
            this.miCloseAll = new System.Windows.Forms.MenuItem();
            this.miWindow = new System.Windows.Forms.MenuItem();
            this.miLayout = new System.Windows.Forms.MenuItem();
            this.miHoriz = new System.Windows.Forms.MenuItem();
            this.miVert = new System.Windows.Forms.MenuItem();
            this.miMax = new System.Windows.Forms.MenuItem();
            this.miMin = new System.Windows.Forms.MenuItem();
            this.miHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.menuItemAuthors = new System.Windows.Forms.MenuItem();
            this.menuItemData = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemHowToUse = new System.Windows.Forms.MenuItem();
            this.oFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miFile,
            this.miWindow,
            this.miLayout,
            this.miHelp});
            // 
            // miFile
            // 
            this.miFile.Index = 0;
            this.miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miNew,
            this.miOpen,
            this.menuItem2,
            this.miDelete,
            this.miClose,
            this.miCloseAll});
            this.miFile.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.miFile.Text = "&File";
            // 
            // miNew
            // 
            this.miNew.Index = 0;
            this.miNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.miNew.Text = "&New";
            this.miNew.Click += new System.EventHandler(this.menuItemNew_Click);
            // 
            // miOpen
            // 
            this.miOpen.Index = 1;
            this.miOpen.MergeOrder = 1;
            this.miOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.miOpen.Text = "&Open";
            this.miOpen.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.MergeOrder = 3;
            this.menuItem2.Text = "-";
            // 
            // miDelete
            // 
            this.miDelete.Index = 3;
            this.miDelete.MergeOrder = 4;
            this.miDelete.Text = "&Delete";
            this.miDelete.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // miClose
            // 
            this.miClose.Index = 4;
            this.miClose.MergeOrder = 5;
            this.miClose.Text = "&Close";
            this.miClose.Click += new System.EventHandler(this.menuItemClose_Click);
            // 
            // miCloseAll
            // 
            this.miCloseAll.Index = 5;
            this.miCloseAll.MergeOrder = 6;
            this.miCloseAll.Text = "&Close All";
            this.miCloseAll.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // miWindow
            // 
            this.miWindow.Index = 1;
            this.miWindow.MdiList = true;
            this.miWindow.Text = "&Window";
            // 
            // miLayout
            // 
            this.miLayout.Index = 2;
            this.miLayout.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miHoriz,
            this.miVert,
            this.miMax,
            this.miMin});
            this.miLayout.Text = "&Layout";
            // 
            // miHoriz
            // 
            this.miHoriz.Index = 0;
            this.miHoriz.Text = "Arrange &Horizontal";
            this.miHoriz.Click += new System.EventHandler(this.menuItemHoriz_Click);
            // 
            // miVert
            // 
            this.miVert.Index = 1;
            this.miVert.Text = "Arrange &Vertical";
            this.miVert.Click += new System.EventHandler(this.menuItemVert_Click);
            // 
            // miMax
            // 
            this.miMax.Index = 2;
            this.miMax.Text = "Ma&ximize all";
            this.miMax.Click += new System.EventHandler(this.menuItemMax_Click);
            // 
            // miMin
            // 
            this.miMin.Index = 3;
            this.miMin.Text = "Mi&nimize all";
            this.miMin.Click += new System.EventHandler(this.menuItemMin_Click);
            // 
            // miHelp
            // 
            this.miHelp.Index = 3;
            this.miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemAbout,
            this.menuItemAuthors,
            this.menuItemData,
            this.menuItem1,
            this.menuItemHowToUse});
            this.miHelp.Text = "Help";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 0;
            this.menuItemAbout.Text = "About this Software";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItemAuthors
            // 
            this.menuItemAuthors.Index = 1;
            this.menuItemAuthors.Text = "Authors";
            this.menuItemAuthors.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItemData
            // 
            this.menuItemData.Index = 2;
            this.menuItemData.Text = "Data";
            this.menuItemData.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // menuItemHowToUse
            // 
            this.menuItemHowToUse.Index = 4;
            this.menuItemHowToUse.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
            this.menuItemHowToUse.Text = "How To Use / Help";
            this.menuItemHowToUse.Click += new System.EventHandler(this.menuItemHowToUse_Click);
            // 
            // oFileDlg
            // 
            this.oFileDlg.AddExtension = false;
            this.oFileDlg.Title = "MDI Sample";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            // 
            // MainFormSample
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(528, 380);
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu1;
            this.Name = "MainFormSample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Performance Progression";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormSample_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormSample_FormClosed);
            this.ResumeLayout(false);

        }
        #endregion

        private void checkContentsOpen()
        {
            Contents dDog = null;
            if ((dDog = (Contents)IsFormAlreadyOpen(typeof(Contents))) != null)
            {
                dDog.Close();
            }
        }
        private void menuItemNew_Click(object sender, System.EventArgs e)
        {
            checkContentsOpen();
            CreateNewMethod();
        }
        private void CreateNewMethod()
        {
            CreateNew cn = new CreateNew();
            cn.FormClosed += new FormClosedEventHandler(Form2_FormClosed);
            cn.ShowDialog(this);
            if (cn.okButton())
            {
                try
                {
                    if (!cn.fileAlreadyExists)
                    {
                        //Create a new instance of the MDI child template form
                        Form2 chForm = new Form2();
                        //set parent form for the child window
                        chForm.MdiParent = this;
                        //set the title of the child window.
                        chForm.Text = cn.getName();
                        chForm.Male_Female = cn.getmale_Female();
                        chForm.chartName = cn.getChartName();
                        chForm.fileloc = cn.getLocation();
                        chForm.DoB = cn.getDoB();
                        chForm.newopen = true;
                        chForm.eventName = cn.getEventName();
                        chForm.FormClosed += new FormClosedEventHandler(Form2_FormClosed);
                        //display the child window
                        chForm.Show();
                    }
                }
                catch
                {
                    MessageBox.Show("Error opening image", "MDI Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void menuItemClose_Click(object sender, System.EventArgs e)
        {
            //Gets the currently active MDI child window.
            Form a = this.ActiveMdiChild;
            //Close the MDI child window
            if (a.Name.CompareTo("Contents") != 0)
            {
                a.Close();
            }
        }

        private void menuItemAI_Click(object sender, System.EventArgs e)
        {
            //Arrange MDI child icons within the client region of the MDI parent form.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
            contentsMain.WindowState = FormWindowState.Normal;
        }

        private void menuItemCas_Click(object sender, System.EventArgs e)
        {
            //Cascade all child forms.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
            contentsMain.WindowState = FormWindowState.Normal;
        }

        private void menuItemHoriz_Click(object sender, System.EventArgs e)
        {
            //Tile all child forms horizontally.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void menuItemVert_Click(object sender, System.EventArgs e)
        {
            //Tile all child forms vertically.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void menuItemMax_Click(object sender, System.EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            Form[] charr = this.MdiChildren;

            //for each child form set the window state to Maximized
            foreach (Form chform in charr)
            {
                if (chform.Name != "Contents")
                {
                    chform.WindowState = FormWindowState.Maximized;
                }
            }
        }

        private void menuItemMin_Click(object sender, System.EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            Form[] charr = this.MdiChildren;

            //for each child form set the window state to Minimized
            foreach (Form chform in charr)
            {
                if (chform.Name != "Contents")
                {
                    chform.WindowState = FormWindowState.Minimized;
                }
            }
        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            //MessageBox.Show(":)");
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            Form[] charr = this.MdiChildren;

            //for each child form set the window state to Minimized
            foreach (Form chform in charr)
            {
                if (chform.Name.CompareTo("Contents") != 0)
                {
                    chform.Close();
                }
            }
        }
        private void menuItem2_Click(object sender, EventArgs e)
        {
            checkContentsOpen();
            OpenMethod();
        }

        private void OpenMethod()
        {
            OpenDisplay asds = new OpenDisplay();
            asds.FormClosed += new FormClosedEventHandler(Form2_FormClosed);
            asds.ShowDialog(this);
            checkContentsOpen();
            if (asds.openButton())
            {
                try
                {
                    Form[] charr = this.MdiChildren;
                    List<string> temp = asds.sItemsR();
                    foreach (string s in asds.sItemsR())
                    {
                        bool open = true;
                        //for each child form set the window state to Maximized
                        foreach (Form chform in charr)
                        {
                            string[] individ = s.Split(',');
                            string re = individ[0] + "_" + individ[2] + individ[3];
                            if (re.CompareTo(chform.Text) == 0)
                            {
                                MessageBox.Show("The file: " + re + " is already open");
                                open = false;
                            }
                        }
                        if (open)
                        {
                            string itemName, itemFormName, itemDoB, itemSex, itemEvent, itemLocation;
                            string[] individ = s.Split(',');
                            itemName = individ[0];
                            itemFormName = individ[0] + "_" + individ[2] + individ[3];
                            itemDoB = individ[1];
                            itemSex = individ[2];
                            itemEvent = individ[3];
                            itemLocation = individ[4];
                            //Create a new instance of the MDI child template form
                            Form2 chForm = new Form2();
                            //set parent form for the child window
                            chForm.MdiParent = this;
                            //set the title of the child window.
                            chForm.Text = individ[0] + "_" + individ[2] + individ[3];
                            if (individ[2].CompareTo("M") == 0) { chForm.Male_Female = true; }
                            else { chForm.Male_Female = true; }
                            chForm.chartName = itemEvent.Substring(1) + " Performance Progression for  " + itemName;
                            chForm.fileloc = itemLocation;
                            chForm.DoB = itemDoB;
                            chForm.newopen = false;
                            chForm.eventName = individ[2] + itemEvent;
                            chForm.FormClosed += new FormClosedEventHandler(Form2_FormClosed);
 



                            //display the child window
                            chForm.Show();
                        }
                    }

                }
                catch
                {
                    MessageBox.Show("Error opening image", "MDI Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (asds.createNewButton())
            {
                CreateNewMethod();
            }
        }


        private void menuItem3_Click(object sender, EventArgs e)
        {
            DeleteDisplay dDog = null;
            if ((dDog = (DeleteDisplay)IsFormAlreadyOpen(typeof(DeleteDisplay))) == null)
            {
                dDog = new DeleteDisplay();
                dDog.Show();
            }
            else
            {
                dDog.Select(); // may be UForm.Select();
            }
        }


        private void menuItem4_Click(object sender, EventArgs e)
        {
            DataUsed dDog = null;
            if ((dDog = (DataUsed)IsFormAlreadyOpen(typeof(DataUsed))) == null)
            {
                dDog = new DataUsed();
                dDog.Show();
            }
            else
            {
                dDog.Select(); // may be UForm.Select();
            }
        }
        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }
        /// <summary>
        /// About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem7_Click(object sender, EventArgs e)
        {
            AboutForm dDog = null;
            if ((dDog = (AboutForm)IsFormAlreadyOpen(typeof(AboutForm))) == null)
            {
                dDog = new AboutForm();
                dDog.FormClosed += new FormClosedEventHandler(Form2_FormClosed);
                dDog.Show();
            }
            else
            {
                dDog.Select(); // may be UForm.Select();
            }
        }
        /// <summary>
        /// Authors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem8_Click(object sender, EventArgs e)
        {

            Authors dDog = null;
            if ((dDog = (Authors)IsFormAlreadyOpen(typeof(Authors))) == null)
            {
                dDog = new Authors();
                dDog.FormClosed += new FormClosedEventHandler(Form2_FormClosed);
                dDog.Show();
            }
            else
            {
                dDog.Select(); // may be UForm.Select();
            }
        }

        /// <summary>
        /// Authors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem9_Click(object sender, EventArgs e)
        {
            DataUsed dDog = null;
            if ((dDog = (DataUsed)IsFormAlreadyOpen(typeof(DataUsed))) == null)
            {
                dDog = new DataUsed();
                dDog.FormClosed += new FormClosedEventHandler(Form2_FormClosed);
                dDog.Show();
            }
            else
            {
                dDog.Select(); // may be UForm.Select();
            }
        }

        #region closeMethods

        private void MainFormSample_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("MF: 1");
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr)
            {
                chform.Close();
            }
        }

        private void MainFormSample_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBox.Show("MF: 2");
            Environment.Exit(0);
        }
        
        #endregion

        void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form[] charr = this.MdiChildren;
            int count = 0;
            //bool temp = false;
            foreach (Form chform in charr)
            {
                count++;
            }
            //MessageBox.Show(count+"");
            if (count <= 1)
            {
                contentsMain = null;
                if ((contentsMain = (Contents)IsFormAlreadyOpen(typeof(Contents))) == null)
                {
                    contentsMain = new Contents();
                    contentsMain.MdiParent = this;
                    contentsMain.CNButtonClicked += new EventHandler(CN_contents_ButtonClicked);
                    contentsMain.OPButtonClicked += new EventHandler(OP_contents_ButtonClicked);
                    contentsMain.Show();
                    contentsMain.WindowState = FormWindowState.Normal;
                }
                else
                {
                    contentsMain.Select(); // may be UForm.Select();
                }
                
            }
        }
        void CN_contents_ButtonClicked(object sender, EventArgs e)
        {
            //MessageBox.Show("CN Clicked!!! OMG BBQ!!!");

            try
            {
                if (!contentsMain.CN_fileAlreadyExists)
                {
                    //Create a new instance of the MDI child template form
                    Form2 chForm = new Form2();
                    //set parent form for the child window
                    chForm.MdiParent = this;
                    //set the title of the child window.
                    chForm.Text = contentsMain.CN_getName();
                    chForm.Male_Female = contentsMain.CN_getmale_Female();
                    chForm.chartName = contentsMain.CN_getChartName();
                    chForm.fileloc = contentsMain.CN_getLocation();
                    chForm.DoB = contentsMain.CN_getDoB();
                    chForm.newopen = true;
                    chForm.eventName = contentsMain.CN_getEventName();
                    chForm.FormClosed += new FormClosedEventHandler(Form2_FormClosed);
                    //display the child window
                    chForm.Show();
                }
            }
            catch
            {
                MessageBox.Show("Error opening image", "MDI Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            contentsMain.Close();
        }
        void continueButtonClicked_ButtonClicked(object sender, EventArgs e)
        {
            PP.Close();
            mainProgramEnable();
        }

        void OP_contents_ButtonClicked(object sender, EventArgs e)
        {
            //MessageBox.Show("OP Clicked!!! ROFL!!!");

            try
            {
                Form[] charr = this.MdiChildren;
                List<string> temp = contentsMain.OP_sItemsR();
                foreach (string s in contentsMain.OP_sItemsR())
                {
                    bool open = true;
                    //for each child form set the window state to Maximized
                    foreach (Form chform in charr)
                    {
                        string[] individ = s.Split(',');
                        string re = individ[0] + "_" + individ[2] + individ[3];
                        if (re.CompareTo(chform.Text) == 0)
                        {
                            MessageBox.Show("The file: " + re + " is already open");
                            open = false;
                        }
                    }
                    if (open)
                    {
                        string itemName, itemFormName, itemDoB, itemSex, itemEvent, itemLocation;
                        string[] individ = s.Split(',');
                        itemName = individ[0];
                        itemFormName = individ[0] + "_" + individ[2] + individ[3];
                        itemDoB = individ[1];
                        itemSex = individ[2];
                        itemEvent = individ[3];
                        itemLocation = individ[4];
                        //Create a new instance of the MDI child template form
                        Form2 chForm = new Form2();
                        //set parent form for the child window
                        chForm.MdiParent = this;
                        //set the title of the child window.
                        chForm.Text = individ[0] + "_" + individ[2] + individ[3];
                        if (individ[2].CompareTo("M") == 0) { chForm.Male_Female = true; }
                        else { chForm.Male_Female = true; }
                        chForm.chartName = itemEvent.Substring(1) + " Performance Progression for  " + itemName;
                        chForm.fileloc = itemLocation;
                        chForm.DoB = itemDoB;
                        chForm.newopen = false;
                        chForm.eventName = individ[2] + itemEvent;
                        chForm.FormClosed += new FormClosedEventHandler(Form2_FormClosed);




                        //display the child window
                        chForm.Show();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Error opening image", "MDI Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            contentsMain.Close();
        }

        private void menuItemHowToUse_Click(object sender, EventArgs e)
        {
            HelpHTU dDog = null;
            if ((dDog = (HelpHTU)IsFormAlreadyOpen(typeof(HelpHTU))) == null)
            {
                dDog = new HelpHTU();
                dDog.FormClosed += new FormClosedEventHandler(Form2_FormClosed);
                dDog.Show();
            }
            else
            {
                dDog.Select(); // may be UForm.Select();
            }
        }
    }
}
