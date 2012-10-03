using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb; 
using utilities; 

namespace leesexcel
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmReadWriteExcelDemo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel pnlCell;
		private System.Windows.Forms.Label lblCellOperatorIs;
		private System.Windows.Forms.Label lblGetValueData;
		private System.Windows.Forms.TextBox textBox1;

		private DataTable _dt;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtRange;
		private System.Windows.Forms.TextBox txtPK;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnSetPK;
		private System.Windows.Forms.Label lblCurrentPK;
		private System.Windows.Forms.Button btnOpenFileDlg;
		
		#region variables
		private string _strExcelFilename = "";
		private System.Windows.Forms.Button btnGetData;
		private ExcelReader _exr=null;
		private System.Windows.Forms.Button btnSaveData;
		private System.Windows.Forms.Button btnChangeVal;
		private System.Windows.Forms.Label lblFilename;
		private System.Windows.Forms.Label lblSheet;
		private System.Windows.Forms.ComboBox cboSheetnames;
		private System.Windows.Forms.TextBox txtCell;
		private System.Windows.Forms.Label label1;
		private int _intPKCol=-1;
		#endregion

		#region CTOR
		public frmReadWriteExcelDemo()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
#endregion
		#region DTOR
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnGetData = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.btnSaveData = new System.Windows.Forms.Button();
			this.pnlCell = new System.Windows.Forms.Panel();
			this.btnChangeVal = new System.Windows.Forms.Button();
			this.lblCellOperatorIs = new System.Windows.Forms.Label();
			this.lblGetValueData = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.lblFilename = new System.Windows.Forms.Label();
			this.btnOpenFileDlg = new System.Windows.Forms.Button();
			this.lblSheet = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtRange = new System.Windows.Forms.TextBox();
			this.txtPK = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnSetPK = new System.Windows.Forms.Button();
			this.lblCurrentPK = new System.Windows.Forms.Label();
			this.cboSheetnames = new System.Windows.Forms.ComboBox();
			this.txtCell = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.pnlCell.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnGetData
			// 
			this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGetData.Location = new System.Drawing.Point(560, 367);
			this.btnGetData.Name = "btnGetData";
			this.btnGetData.Size = new System.Drawing.Size(88, 28);
			this.btnGetData.TabIndex = 0;
			this.btnGetData.Text = "Get Data";
			this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 72);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(624, 280);
			this.dataGrid1.TabIndex = 1;
			// 
			// btnSaveData
			// 
			this.btnSaveData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveData.Location = new System.Drawing.Point(488, 367);
			this.btnSaveData.Name = "btnSaveData";
			this.btnSaveData.Size = new System.Drawing.Size(72, 28);
			this.btnSaveData.TabIndex = 5;
			this.btnSaveData.Text = "SaveData";
			this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
			// 
			// pnlCell
			// 
			this.pnlCell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pnlCell.Controls.Add(this.label1);
			this.pnlCell.Controls.Add(this.btnChangeVal);
			this.pnlCell.Controls.Add(this.lblCellOperatorIs);
			this.pnlCell.Controls.Add(this.lblGetValueData);
			this.pnlCell.Controls.Add(this.txtCell);
			this.pnlCell.Location = new System.Drawing.Point(24, 364);
			this.pnlCell.Name = "pnlCell";
			this.pnlCell.Size = new System.Drawing.Size(440, 32);
			this.pnlCell.TabIndex = 6;
			this.pnlCell.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCell_Paint);
			// 
			// btnChangeVal
			// 
			this.btnChangeVal.Location = new System.Drawing.Point(312, 8);
			this.btnChangeVal.Name = "btnChangeVal";
			this.btnChangeVal.Size = new System.Drawing.Size(120, 24);
			this.btnChangeVal.TabIndex = 8;
			this.btnChangeVal.Text = "Change value";
			this.btnChangeVal.Click += new System.EventHandler(this.btnChangeVal_Click);
			// 
			// lblCellOperatorIs
			// 
			this.lblCellOperatorIs.Location = new System.Drawing.Point(144, 8);
			this.lblCellOperatorIs.Name = "lblCellOperatorIs";
			this.lblCellOperatorIs.Size = new System.Drawing.Size(8, 12);
			this.lblCellOperatorIs.TabIndex = 7;
			this.lblCellOperatorIs.Text = "=";
			// 
			// lblGetValueData
			// 
			this.lblGetValueData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblGetValueData.Location = new System.Drawing.Point(160, 8);
			this.lblGetValueData.Name = "lblGetValueData";
			this.lblGetValueData.Size = new System.Drawing.Size(144, 16);
			this.lblGetValueData.TabIndex = 5;
			// 
			// textBox1
			// 
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(79, 10);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(489, 20);
			this.textBox1.TabIndex = 7;
			this.textBox1.Text = "";
			// 
			// lblFilename
			// 
			this.lblFilename.Location = new System.Drawing.Point(16, 12);
			this.lblFilename.Name = "lblFilename";
			this.lblFilename.Size = new System.Drawing.Size(56, 16);
			this.lblFilename.TabIndex = 8;
			this.lblFilename.Text = "Filename";
			// 
			// btnOpenFileDlg
			// 
			this.btnOpenFileDlg.Location = new System.Drawing.Point(576, 9);
			this.btnOpenFileDlg.Name = "btnOpenFileDlg";
			this.btnOpenFileDlg.Size = new System.Drawing.Size(56, 24);
			this.btnOpenFileDlg.TabIndex = 9;
			this.btnOpenFileDlg.Text = "...";
			this.btnOpenFileDlg.Click += new System.EventHandler(this.btnOpenFileDlg_Click);
			// 
			// lblSheet
			// 
			this.lblSheet.Location = new System.Drawing.Point(16, 40);
			this.lblSheet.Name = "lblSheet";
			this.lblSheet.Size = new System.Drawing.Size(40, 23);
			this.lblSheet.TabIndex = 11;
			this.lblSheet.Text = "Sheet";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(207, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 21);
			this.label3.TabIndex = 12;
			this.label3.Text = "Range";
			// 
			// txtRange
			// 
			this.txtRange.Location = new System.Drawing.Point(255, 40);
			this.txtRange.MaxLength = 20;
			this.txtRange.Name = "txtRange";
			this.txtRange.Size = new System.Drawing.Size(72, 20);
			this.txtRange.TabIndex = 13;
			this.txtRange.Text = "A1:C5";
			// 
			// txtPK
			// 
			this.txtPK.Location = new System.Drawing.Point(420, 40);
			this.txtPK.MaxLength = 3;
			this.txtPK.Name = "txtPK";
			this.txtPK.Size = new System.Drawing.Size(47, 20);
			this.txtPK.TabIndex = 14;
			this.txtPK.Text = "0";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(338, 43);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 15);
			this.label4.TabIndex = 15;
			this.label4.Text = "Prim. Key Col";
			// 
			// btnSetPK
			// 
			this.btnSetPK.Location = new System.Drawing.Point(476, 40);
			this.btnSetPK.Name = "btnSetPK";
			this.btnSetPK.Size = new System.Drawing.Size(76, 24);
			this.btnSetPK.TabIndex = 16;
			this.btnSetPK.Text = "Set PK";
			this.btnSetPK.Click += new System.EventHandler(this.btnSetPK_Click);
			// 
			// lblCurrentPK
			// 
			this.lblCurrentPK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblCurrentPK.Location = new System.Drawing.Point(560, 40);
			this.lblCurrentPK.Name = "lblCurrentPK";
			this.lblCurrentPK.Size = new System.Drawing.Size(72, 24);
			this.lblCurrentPK.TabIndex = 17;
			// 
			// cboSheetnames
			// 
			this.cboSheetnames.Location = new System.Drawing.Point(80, 40);
			this.cboSheetnames.Name = "cboSheetnames";
			this.cboSheetnames.Size = new System.Drawing.Size(121, 21);
			this.cboSheetnames.TabIndex = 18;
			// 
			// txtCell
			// 
			this.txtCell.Location = new System.Drawing.Point(77, 6);
			this.txtCell.MaxLength = 4;
			this.txtCell.Name = "txtCell";
			this.txtCell.Size = new System.Drawing.Size(48, 20);
			this.txtCell.TabIndex = 19;
			this.txtCell.Text = "A2";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 20;
			this.label1.Text = "Cell";
			// 
			// frmReadWriteExcelDemo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(656, 406);
			this.Controls.Add(this.cboSheetnames);
			this.Controls.Add(this.lblCurrentPK);
			this.Controls.Add(this.btnSetPK);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtPK);
			this.Controls.Add(this.txtRange);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblSheet);
			this.Controls.Add(this.btnOpenFileDlg);
			this.Controls.Add(this.lblFilename);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.pnlCell);
			this.Controls.Add(this.btnSaveData);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.btnGetData);
			this.Name = "frmReadWriteExcelDemo";
			this.Text = "Read and Write Excel";
			this.Load += new System.EventHandler(this.frmReadWriteExcelDemo_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.pnlCell.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmReadWriteExcelDemo());
		}

		private void InitExcel(ref ExcelReader exr)
		{
			//Excel must be open
			if (exr == null)
			{
				exr = new ExcelReader();
				exr.ExcelFilename = _strExcelFilename;
				exr.Headers =false;
				exr.MixedData =true;
			}
			if  (_dt==null) _dt = new DataTable("par");			
			exr.KeepConnectionOpen =true;
			
			//Check excel sheetname is selected
			if (this.cboSheetnames.SelectedIndex>-1) 
				exr.SheetName = this.cboSheetnames.Text; 
			else
				throw new Exception("Select a sheet first!"); 

			//Set excel sheet range
			exr.SheetRange = this.txtRange.Text; 
			
		
		}
	
		

		private void frmReadWriteExcelDemo_Load(object sender, System.EventArgs e)
		{
			this.textBox1.Text = Application.StartupPath  + @"\Map1.xls"; 
			_strExcelFilename=this.textBox1.Text;
			if (System.IO.File.Exists(this.textBox1.Text))
				RetrieveSheetnames();
		}

		private void RetrieveSheetnames()
		{
			try
			{
				this.cboSheetnames.Items.Clear();
			
				if (_exr !=null)
				{
					_exr.Dispose();
					_exr=null;
				}
				
				_exr = new ExcelReader();
				_exr.ExcelFilename = _strExcelFilename;
				_exr.Headers =false;
				_exr.MixedData =true;
				string[] sheetnames = this._exr.GetExcelSheetNames();
				this.cboSheetnames.Items.AddRange(sheetnames); 
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);    				
			}
		}


		

		private bool IsInt(string strNr)
		{
			try
			{
				int intNr= int.Parse(strNr);
				return true;

			}
			catch
			{
				return false;
			}
		}

		private void SetPK()
		{
			Cursor = Cursors.WaitCursor; 
			_intPKCol=-1;
			try
			{
				if (txtPK.Text.Length >0) 
				{
					if (IsInt(txtPK.Text)) 
						_intPKCol=Convert.ToInt32(txtPK.Text) ;
					else
					{
						if (_dt.Columns.Contains(txtPK.Text))
						{
							_intPKCol = _dt.Columns[txtPK.Text].Ordinal; 
						}
						else
						{
							throw new Exception("Columnname is not present in the table.!");
						
						}
					}
					if (_dt.Columns.Count<=_intPKCol)
					{
						_intPKCol=-1;
						Cursor = Cursors.Default;
						throw new Exception("Column does not exists!");
					}
				}
				Cursor = Cursors.Default;
			}
			
			catch (Exception ex)
			{
				Cursor = Cursors.Default;
				MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);    
			}
		}

		private void btnSetPK_Click(object sender, System.EventArgs e)
		{
			SetPK();
		}

		private void btnOpenFileDlg_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog f = new OpenFileDialog(); 
			f.Filter ="Excel files | *.xls";
			f.InitialDirectory = Application.ExecutablePath;   
			
			if (f.ShowDialog()==DialogResult.OK)
				if (f.FileName != null && f.CheckFileExists==true )
				{
					this._strExcelFilename =f.FileName;
					this.textBox1.Text = f.FileName;
					RetrieveSheetnames();
					if (this.cboSheetnames.Items.Count >0) 
						cboSheetnames.SelectedIndex =0;
				}
			
 		
		}

		private void btnGetData_Click(object sender, System.EventArgs e)
		{
			try
			{
				Cursor = Cursors.WaitCursor; 
				InitExcel(ref _exr);
				_dt = _exr.GetTable();
				this.lblGetValueData.Text =  _exr.GetValue(txtCell.Text).ToString() ;
				this.dataGrid1.DataSource=_dt;
				
				_exr.Close();
				_exr.Dispose();
				_exr=null;
				Cursor = Cursors.Default;
				if (_dt !=null && this.txtPK.Text.Length >0) SetPK();
			}		
			catch (Exception ex)
			{
				Cursor = Cursors.Default;
				MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);    
			}
		}

		private void btnSaveData_Click(object sender, System.EventArgs e)
		{
			try
			{
				Cursor = Cursors.WaitCursor; 
				InitExcel(ref _exr);
				if (this._intPKCol>-1)
				{
					int[] intPKCols = new int[]  { _intPKCol};
					_exr.PKCols = intPKCols;
				}
				_exr.SetTable(_dt); 
				Cursor = Cursors.Default;
			}
			catch (Exception ex)
			{
				Cursor = Cursors.Default;
				MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);    
			}
		}

		private void btnChangeVal_Click(object sender, System.EventArgs e)
		{
			try
			{
				Cursor = Cursors.WaitCursor;
				InitExcel(ref _exr);			
				if (this._intPKCol>-1)
				{
					int[] intPKCols = new int[]  { _intPKCol};
					_exr.PKCols = intPKCols;
				}
				this.lblGetValueData.Text =  _exr.GetValue(txtCell.Text).ToString() ;
				int intNewValue;
				try
				{
					intNewValue = Convert.ToInt32(lblGetValueData.Text);
				}
				catch (Exception)
				{
					intNewValue=0;
				}
				intNewValue++;
				_exr.SetValue(txtCell.Text,intNewValue.ToString());    
				this.lblGetValueData.Text += "->" + _exr.GetValue(txtCell.Text).ToString() ;
				_exr.Close();
				_exr.Dispose();
				_exr=null;
				Cursor = Cursors.Default;
			}
			catch (Exception ex)
			{
				Cursor = Cursors.Default;
				MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);    
			}
		}

		private void pnlCell_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		

		

		

		
	}
}
