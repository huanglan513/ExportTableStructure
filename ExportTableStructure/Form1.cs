using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace ExportTableStructure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (tbxSelectedFolder.Text.Trim() == "")
            {
                MessageBox.Show("请选择文件夹", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbxSelectedFolder.Focus();
            }
            if(!Directory.Exists(tbxSelectedFolder.Text.Trim()))
            {
                MessageBox.Show("此文件夹不存在，请重新选择有效的文件夹", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbxSelectedFolder.Focus();
            }
            btnExport.Text = "请等待......";

            string filePath = string.Empty;
            if (tbxSelectedFolder.Text.Trim().LastIndexOf("\\") == tbxSelectedFolder.Text.Trim().Length-1)
                filePath = tbxSelectedFolder.Text.Trim();
            else
                filePath = tbxSelectedFolder.Text.Trim() + "\\";
            filePath += cboDBName.Text + "DBStructure" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close(); 
            }

            InsertIntoExcel(filePath);
            btnExport.Text = "导出表结构";
        }

        private void InsertIntoExcel(string filePath)
        {
            //    string filePath = "D:\\SCCCAIDBStructure20121120152025.xls";
            //   string strConn = "server=10.12.1.96;uid=SCCCAIUser;pwd=scccaidbuser;database=SCCCAI";
            // SqlHelper sqlHelper = new SqlHelper(strConn);


            SqlHelper sqlHelper = new SqlHelper(tbxServerName.Text.Trim(), cboDBName.Text, tbxUserName.Text.Trim(), tbxPassword.Text.Trim());

            //第一条Sql查出所有的表名，第二条Sql查出所有表下的列的属性
            string sql = @"select name as TableName,'' as [Desc] from dbo.SysObjects where xtype='U' order by name;
                           SELECT obj.name as  N'表名', col.colorder as N'字段序号', col.name as  N'字段名', 
                            (case when COLUMNPROPERTY( col.id,col.name,'IsIdentity')=1 then '√'else '' end) as  N'标识', 
                            (case when (SELECT count(*) 
                                        FROM sysobjects WHERE (name in 
                                                               (SELECT name 
                                                                FROM sysindexes 
                                                                WHERE (id = col.id) AND (indid in 
                                                                     (SELECT indid 
                                                                        FROM sysindexkeys 
                                                                        WHERE (id = col.id) AND (colid in 
                                                                              (SELECT colid  FROM syscolumns 
                                                                                 WHERE (id = col.id) AND (name = col.name))))))) 
                                                                                 AND 
                            (xtype = 'PK'))>0 then '√' else '' end) as N'主键', 
                            type.name as N'类型', 
                            col.length N'占用字节数', 
                            COLUMNPROPERTY(col.id,col.name,'PRECISION') as N'字段定义的长度', 
                            isnull(COLUMNPROPERTY(col.id,col.name,'Scale'),0) as N'小数点后位数', 
                            (case when col.isnullable=1 then '√'else '' end) as N'是否允许空', 
                            isnull(e.text,'') as N'默认值',
                            isnull(g.[value],'') as N'字段说明' 

                            FROM syscolumns col left join systypes type
                            on col.xtype=type.xusertype 
                            inner join sysobjects obj 
                            on col.id=obj.id and obj.xtype='U' and obj.name<>'dtproperties' 
                            left join syscomments e 
                            on col.cdefault=e.id 
                            left join sys.extended_properties   g 
                            on col.id=g.major_id AND col.colid = g.minor_id 
                            order by object_name(col.id),col.colorder ";
            DataSet ds = sqlHelper.ExecuteSqlDataSet(sql);


            Microsoft.Office.Interop.Excel.Application app = new ApplicationClass();
            try
            {
                #region
                System.Data.DataTable excelTable = null;
                app.Visible = false;
                Workbook wBook = app.Workbooks.Add(true);
                Worksheet wSheet = null;
                string columnSpan = string.Empty;
                for (int k = 0; k < ds.Tables.Count; k++)
                {
                    if (wBook.Worksheets.Count < k + 1)
                    {
                        wSheet = wBook.Worksheets.Add(Type.Missing, wBook.Worksheets[wBook.Worksheets.Count], Type.Missing, Type.Missing) as Worksheet;
                    }
                    else
                    {
                        wSheet = wBook.Worksheets[k + 1] as Worksheet;
                    }
                    wSheet.Cells.Clear();

                    if (k == 0)
                    {
                        wSheet.Name = "Tables Name";
                        columnSpan = "B";
                    }
                    else
                    {
                        wSheet.Name = "Columns Name";
                        columnSpan = "L";
                    }

                    excelTable = ds.Tables[k];
                    if (excelTable.Rows.Count > 0)
                    {
                        int row = excelTable.Rows.Count;
                        int col = excelTable.Columns.Count;

                        Range range = SetRangeProperty(wSheet, row, columnSpan);

                        if (k == 0)
                        {
                            for (int i = 0; i < row; i++)
                            {
                                for (int j = 0; j < col - 1; j++)
                                {
                                    string str = excelTable.Rows[i][j].ToString();
                                    wSheet.Cells[i + 2, j + 1] = str;
                                }
                            }
                        }
                        else
                        {
                            string preTableName = excelTable.Rows[0][0].ToString();
                            for (int i = 0; i < row; i++)
                            {
                                if (preTableName != excelTable.Rows[i][0].ToString())
                                {
                                    wSheet.Range[wSheet.Cells[i + 2, 1], wSheet.Cells[i + 2, col]].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                                    wSheet.Range[wSheet.Cells[i + 2, 1], wSheet.Cells[i + 2, col]].Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlMedium;
                                    preTableName = excelTable.Rows[i][0].ToString();
                                }
                                for (int j = 0; j < col; j++)
                                {
                                    string str = excelTable.Rows[i][j].ToString();
                                    wSheet.Cells[i + 2, j + 1] = str;
                                }
                            }
                        }
                    }

                    int size = excelTable.Columns.Count;
                    for (int i = 0; i < size; i++)
                    {
                        wSheet.Cells[1, 1 + i] = excelTable.Columns[i].ColumnName;

                    }
                }
                //设置禁止弹出保存和覆盖的询问提示框   
                app.DisplayAlerts = false;
                app.AlertBeforeOverwriting = false;
                //保存工作簿   
               // wBook.Save();
                  wBook.SaveCopyAs(filePath);
                //保存excel文件   
               // app.Save(filePath);
               // app.SaveWorkspace(filePath);
                app.Quit();
                app = null;
                #endregion
                MessageBox.Show("导出成功", "提示信息",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception err)
            {
                MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static Range SetRangeProperty(Worksheet wSheet, int row,string columnSpan)
        {
            Range range = wSheet.get_Range("A1", columnSpan + (row + 1).ToString());
            range.Font.Size = 10;     //设置字体大小
            range.Font.Name = "黑体";     //设置字体的种类
            range.ColumnWidth = 33;     //设置单元格的宽度
            //   range.EntireColumn.AutoFit();     //自动调整列宽
            range.Borders.LineStyle = 1;     //设置单元格边框的粗细
           
            range.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, System.Drawing.Color.Black.ToArgb());     //给单元格加边框

            Range rangeHeader = wSheet.get_Range("A1", columnSpan+"1");
            rangeHeader.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangeHeader.Font.Bold = true;
            rangeHeader.Cells.Interior.Color = System.Drawing.Color.FromArgb(255, 204, 153).ToArgb();     //设置单元格的背景色
            return range;
        }

        //private void btnSearchServer_Click(object sender, EventArgs e)
        //{
        //    cboServers.Items.Clear();
        //    SQLDMO.ApplicationClass sqlApp = new SQLDMO.ApplicationClass();
        //    SQLDMO.NameList namelist;
        //    namelist = sqlApp.ListAvailableSQLServers();
        //    for(int i=0;i<namelist.Count;i++)
        //    {
        //        object obj = namelist.Item(i);
        //        if (obj != null)
        //        {
        //            this.cboServers.Items.Add(obj);
        //        }
        //    }
        //    if (this.cboServers.Items.Count > 0)
        //        this.cboServers.SelectedIndex = 0;
        //    else
        //        this.cboServers.Text = "<No available SQL Servers>";
        //}

        private void btnConnectTest_Click(object sender, EventArgs e)
        {
            if (tbxServerName.Text.Trim() == "")
            {
                MessageBox.Show("请输入服务器名称", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbxServerName.Focus();
            }
            if (tbxUserName.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbxUserName.Focus();
            }
            if (tbxPassword.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbxPassword.Focus();
            }

            cboDBName.Items.Clear();
            SQLDMO.SQLServer srv = new SQLDMO.SQLServerClass();
            try
            {
                srv.Connect(tbxServerName.Text.Trim(),tbxUserName.Text.Trim(),tbxPassword.Text.Trim());
                foreach(SQLDMO.Database db in srv.Databases)
                {
                    if(db.Name!=null)
                    {
                        cboDBName.Items.Add(db.Name);
                    }
                }
                if(this.cboDBName.Items.Count!=0)
                    cboDBName.SelectedIndex=0;
                MessageBox.Show("服务器连接成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                btnExport.Visible = true;
            }
            catch
            {
                MessageBox.Show("连接服务器：" + this.tbxServerName.Text.Trim() + "失败！\n请核对用户名和密码。", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectedFolder_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (this.folderBrowserDialog1.SelectedPath.Trim() != "")
                    this.tbxSelectedFolder.Text = this.folderBrowserDialog1.SelectedPath.Trim();
            }
        }

     

       

      
    }
}
