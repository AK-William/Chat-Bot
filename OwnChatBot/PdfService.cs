﻿using System.Text;
using UglyToad.PdfPig;

public class PdfService
{
    public string ExtractTextFromPdf(string filePath)
    {
        var text = new StringBuilder();
        using (var document = PdfDocument.Open(filePath))
        {
            foreach (var page in document.GetPages())
            {
                text.Append(page.Text);
            }
        }
        return text.ToString();
    }
}
