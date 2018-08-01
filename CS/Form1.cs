using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FilesPreviewGenerator
{
    public partial class Form1 : Form
    {
        List<FileInfo> files;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitData();
            gridControl1.DataSource = files;

            InitViewSettings();
            winExplorerView1.GetThumbnailImage += WinExplorerView_GetThumbnailImage;
        }
   
        private void InitData()
        {
            files = new List<FileInfo>();
            string[] fileNames = Directory.GetFiles("Documents\\");
            foreach (string item in fileNames)
            {
                files.Add(new FileInfo(item, Path.GetFileName(item), Path.GetExtension(item)));
            }

        }
        private void InitViewSettings()
        {
            winExplorerView1.OptionsImageLoad.CacheThumbnails = true;
            winExplorerView1.OptionsImageLoad.LoadThumbnailImagesFromDataSource = false;
            winExplorerView1.OptionsImageLoad.AsyncLoad = true;
            winExplorerView1.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.ExtraLarge;
        }

        private void WinExplorerView_GetThumbnailImage(object sender, DevExpress.Utils.ThumbnailImageEventArgs e)
        {
            string filePath = files[e.DataSourceIndex].Path;
            string documentFormat = files[e.DataSourceIndex].DocumentFormat;

            switch (documentFormat)
            {
                case ".pdf":
                    {
                        int largestEdgeLength = Math.Max(e.DesiredThumbnailSize.Width, e.DesiredThumbnailSize.Height);
                        e.ThumbnailImage = ImageExporterHelper.GenerateImageFromPDF(filePath, largestEdgeLength);
                    }
                    break;
                case ".xlsx":
                        e.ThumbnailImage = ImageExporterHelper.GenerateImageFromExcel(filePath);
                    break;
                case ".docx":
                        e.ThumbnailImage = ImageExporterHelper.GenerateImageFromWord(filePath);
                    break;
            }

        }
    }
}
