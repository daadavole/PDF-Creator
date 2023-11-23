using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Windows;

namespace PDF_Creator
{
    internal class PdfCreationLogic
    {
        public void CreatePdfFromImages(string[] imagePaths, string outputPath)
        {
            if(imagePaths != null && outputPath != null) 
            {
                try
                {
                    using (var pdfWriter = new PdfWriter(outputPath))
                    {
                        using (var pdfDocument = new PdfDocument(pdfWriter))
                        {
                            var document = new Document(pdfDocument);

                            foreach (var imagePath in imagePaths)
                            {
                                var image = new Image(ImageDataFactory.Create(imagePath));
                                document.Add(image);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception! \n" + ex.Message + "\n" + ex.GetType() + "\n" + $"Inner Exception: {ex.InnerException?.Message}");
                }
            }
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
