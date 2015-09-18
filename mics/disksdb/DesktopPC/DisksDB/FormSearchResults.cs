using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DisksDB.DataBase;
using DisksDB.Utils;

namespace DisksDB.UserInterface
{
    public partial class FormSearchResults : DisksDB.Language.FormI18NDC
    {
        public FormSearchResults(FormMain mainForm)
        {
            this.mainForm = mainForm;

            InitializeComponent();
        }

        public void SetData(DataSetSearch ds)
        {
            this.Invoke(new SetDataHandler(SetDataInternal), ds);
        }

        private void SetDataInternal(DataSetSearch ds)
        {
            if (null == this.hashMap)
            {
                this.hashMap = new Dictionary<Icon, Bitmap>();
            }

            this.hashMap.Clear();

            ds.Files.Columns.Add("Icon", typeof(System.Drawing.Image));
            this.filesBindingSource.DataSource = ds;

            Bitmap folderIco = FileIcons.GetFolderIcon(null, true, false).ToBitmap();

            foreach (DataSetSearch.FilesRow dr in ds.Files)
            {
                if (dr.Size == 0)
                {
                    dr["Icon"] = folderIco;
                }
                else
                {
                    dr["Icon"] = GetIcon(dr.FileName);
                }
            }

            if (false == this.dataGridView1.Columns.Contains("Icon"))
            {
                DataGridViewImageColumn dgc = new DataGridViewImageColumn();

                dgc.Name = "Icon";
                dgc.DataPropertyName = "Icon";
                dgc.HeaderText = "Icon";
                dgc.Width = 20;
                dgc.Resizable = DataGridViewTriState.False;

                this.dataGridView1.Columns.Insert(0, dgc);
            }
        }

        private Bitmap GetIcon(string fileName)
        {
            Icon icon = FileIcons.GetFileIcon(fileName);

            return icon.ToBitmap();

            if (null != icon)
            {
                Bitmap b = null;

                if (true == this.hashMap.TryGetValue(icon, out b))
                {
                    return b;
                }
                else
                {
                    b = icon.ToBitmap();

                    this.hashMap.Add(icon, b);
                }

                return b;
            }

            return null;
        }

        private DataSetSearch.FilesRow GetSelectedRow()
        {
            try
            {

                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    return (DataSetSearch.FilesRow)((DataRowView)this.dataGridView1.SelectedRows[0].DataBoundItem).Row;
                }

                return null;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return null;
            }
        }

        private void goToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSetSearch.FilesRow dr = GetSelectedRow();

            if (null != dr)
            {
                this.mainForm.GoToFile(dr.CategoryId, dr.BoxId, dr.DiskId, dr.FileParentId);
            }
        }

        private void goToDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSetSearch.FilesRow dr = GetSelectedRow();

            if (null != dr)
            {
                this.mainForm.GoToDisk(dr.CategoryId, dr.BoxId, dr.DiskId);
            }
        }

        private void goToBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSetSearch.FilesRow dr = GetSelectedRow();

            if (null != dr)
            {
                this.mainForm.GoToBox(dr.CategoryId, dr.BoxId);
            }
        }

        private void goToCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSetSearch.FilesRow dr = GetSelectedRow();

            if (null != dr)
            {
                this.mainForm.GoToCategory(dr.CategoryId);
            }
        }

        private void FormSearchResults_Load(object sender, EventArgs e)
        {
            fileNameDataGridViewTextBoxColumn.Width = DisksDB.Config.Config.Instance.GetValue(gridId + fileNameDataGridViewTextBoxColumn.Name, 100);
            sizeDataGridViewTextBoxColumn.Width = DisksDB.Config.Config.Instance.GetValue(gridId + sizeDataGridViewTextBoxColumn.Name, 100);
            fileDateDataGridViewTextBoxColumn.Width = DisksDB.Config.Config.Instance.GetValue(gridId + fileDateDataGridViewTextBoxColumn.Name, 100);
            diskDataGridViewTextBoxColumn.Width = DisksDB.Config.Config.Instance.GetValue(gridId + diskDataGridViewTextBoxColumn.Name, 100);
            boxDataGridViewTextBoxColumn.Width = DisksDB.Config.Config.Instance.GetValue(gridId + boxDataGridViewTextBoxColumn.Name, 100);
            categoryDataGridViewTextBoxColumn.Width = DisksDB.Config.Config.Instance.GetValue(gridId + categoryDataGridViewTextBoxColumn.Name, 100);
        }

        private void FormSearchResults_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisksDB.Config.Config.Instance.SetValue(gridId + fileNameDataGridViewTextBoxColumn.Name, fileNameDataGridViewTextBoxColumn.Width);
            DisksDB.Config.Config.Instance.SetValue(gridId + sizeDataGridViewTextBoxColumn.Name, sizeDataGridViewTextBoxColumn.Width);
            DisksDB.Config.Config.Instance.SetValue(gridId + fileDateDataGridViewTextBoxColumn.Name, fileDateDataGridViewTextBoxColumn.Width);
            DisksDB.Config.Config.Instance.SetValue(gridId + diskDataGridViewTextBoxColumn.Name, diskDataGridViewTextBoxColumn.Width);
            DisksDB.Config.Config.Instance.SetValue(gridId + boxDataGridViewTextBoxColumn.Name, boxDataGridViewTextBoxColumn.Width);
            DisksDB.Config.Config.Instance.SetValue(gridId + categoryDataGridViewTextBoxColumn.Name, categoryDataGridViewTextBoxColumn.Width);
        }

        private delegate void SetDataHandler(DataSetSearch ds);
        private System.Collections.Generic.Dictionary<Icon, Bitmap> hashMap = null;
        private FormMain mainForm = null;
        private static string gridId = "SearcRezGrid.";
    }
}
