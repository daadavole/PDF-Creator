using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PDF_Creator
{
    internal class FileSelectionLogic
    {
        public string[] SelectedFilePaths;
        public void SelectImages() // Image selection method
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the Multiselect to true for selecting multiple files
            openFileDialog.Multiselect = true;

            // Set the default file extension
            openFileDialog.DefaultExt = ".txt";

            // Filter files by extension
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

            // Show the dialog and get the result, ShowDialog() can return nullable bool - bool?
            bool? result = openFileDialog.ShowDialog();

            // Process the result
            if (result == true)
            {
                // The selected file paths are in openFileDialog.FileNames
                string[] selectedFilePaths = openFileDialog.FileNames;

                // File paths for output
                string allPaths = "";

                // Perform actions with the selected file paths
                foreach (string filePath in selectedFilePaths)
                {
                    allPaths += filePath + "\n";
                }
                // Display MessageBox with file paths
                MessageBox.Show($"Selected files: \n{allPaths}");

                // Assign the file paths to public property 
                SelectedFilePaths = selectedFilePaths;
            }
        }
        public void SelectOutputFile() // Output file and pdfs name selection method
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set the default file extension to .pdf
            saveFileDialog.DefaultExt = ".pdf";

            // Filter files to show only PDF files
            saveFileDialog.Filter = "PDF files (.pdf)|*.pdf";

            string filePath = saveFileDialog.FileName;

            // Show the dialog and get the result, ShowDialog() can return nullable bool - bool?
            bool? result = saveFileDialog.ShowDialog();

            if (result == true)
            {
                // The selected file path for output is in saveFileDialog.FileName
                string pdfOutputPath = saveFileDialog.FileName;

                // Perform actions with the selected output file path
                MessageBox.Show($"Selected output file: {pdfOutputPath}");
            }

        }
    }
}
