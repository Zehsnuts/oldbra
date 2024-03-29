﻿using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Bradesco.Apps.Folhetos
{
    /// <summary>
    /// Interaction logic for FolhetosNavegador.xaml
    /// </summary>

    public partial class FolhetosNavegador : UserControl
    {
        private int idx = 0;

        private DirectoryInfo dir;

        private string currentPDFImgPath;
        private int currentPage;
        private int totalPage;

        public FolhetosNavegador(int nav, string folder)
        {
            InitializeComponent();
            idx = nav - 1;
            dir = new DirectoryInfo(folder);

            Loaded += (s, e) =>
            {
                Cursor = Cursors.None;
                LoadPDF();
            };
        }

        // private bool _resized = false;
        public void LoadPDF()
        {
            String[] filesWithWidenFirstPage = { "01_empresario_area_saude.pdf" };

            int indice = idx;

            if (dir.Exists)
            {
                var folhetoDir = dir.GetDirectories().Where(d => !d.Name.ToUpper().Equals("QR")).ElementAt(indice);

                if (folhetoDir != null)
                {
                    this.currentPage = 1;
                    this.currentPDFImgPath = folhetoDir.FullName;
                    var imgList = folhetoDir.GetFiles();
                    this.totalPage = imgList.Length;

                    var imgFile = imgList[currentPage - 1];                    
                    wbFolhetos.Source = new BitmapImage(new Uri(imgFile.FullName));
                }
            }

            var qr = new DirectoryInfo(dir.ToString() + "\\QR");
            if (qr.Exists)
            {
                var fileQr = qr.GetFiles().ElementAt(indice);
                if (fileQr != null)
                {
                    qrView.Source = new BitmapImage(new Uri(fileQr.FullName));
                }
            }
        }

        private void ContentControl_TouchDown(object sender, TouchEventArgs e)
        {
            GoToNext();
        }

        private void ContentControl_TouchDown_1(object sender, TouchEventArgs e)
        {
            GoToPrevious();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            GoToNext();
        }

        private void UIElement_OnMouseDown1(object sender, MouseButtonEventArgs e)
        {
            GoToPrevious();
        }

        private void GoToNext()
        {
            currentPage++;

            if (currentPage > totalPage)
            {
                currentPage = totalPage;
            }
            
            var imgList = new DirectoryInfo(currentPDFImgPath).GetFiles();
            this.totalPage = imgList.Length;

            var imgFile = imgList[currentPage - 1];
            wbFolhetos.Source = new BitmapImage(new Uri(imgFile.FullName));
        }

        private void GoToPrevious()
        {
            currentPage--;

            if (currentPage < 1)
            {
                currentPage = 1;
            }

            var imgList = new DirectoryInfo(currentPDFImgPath).GetFiles();
            this.totalPage = imgList.Length;

            var imgFile = imgList[currentPage - 1];
            wbFolhetos.Source = new BitmapImage(new Uri(imgFile.FullName));
        }

        public void SetIndex(int index)
        {
            idx = index - 1;
        }
    }
}