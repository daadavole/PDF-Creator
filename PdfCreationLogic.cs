using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Diagnostics;
using System.Windows;

namespace PDF_Creator
{
    internal class PdfCreationLogic
    {
        public void CreatePdfFromImages(string[] imagePaths, string outputPath)
        {
            // Check if values are null
            if(imagePaths != null && outputPath != null) 
            {
                try
                {
                    // Create PdfWriter
                    using (var pdfWriter = new PdfWriter(outputPath))
                    {
                        // Create a new PDF document
                        using (var pdfDocument = new PdfDocument(pdfWriter))
                        {
                            var document = new Document(pdfDocument);

                            // Iterate the images
                            foreach (var imagePath in imagePaths)
                            {
                                // Adding image to the PDF file
                                var image = new Image(ImageDataFactory.Create(imagePath));
                                document.Add(image);
                            }
                        }
                    }

                    // Open file explorer with given path to show the result
                    Process.Start("explorer.exe", outputPath);
                }
                // Exception handlign
                catch (Exception ex)
                {
                    MessageBox.Show("Exception! \n" + ex.Message + "\n" + ex.GetType() + "\n" + $"Inner Exception: {ex.InnerException?.Message}");
                }
            }
            // Error message handling
            else
            {
                string[] errorMessage = new string[2];
                errorMessage[0] = (imagePaths == null) ? "\nimage paths" : "";
                errorMessage[1] = (outputPath == null) ? "\noutput path" : "";
                MessageBox.Show($"You have not entered:{errorMessage[0] + errorMessage[1]}");
            }
        }
    }
}
