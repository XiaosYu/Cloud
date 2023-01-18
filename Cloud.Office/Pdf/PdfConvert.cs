using Spire.Pdf;


namespace Cloud.Office.Pdf
{
    public static class PdfConvert
    {
        public static void Convert(string sourceFile, string targetFile, FileType type)
        {
            PdfDocument document = new PdfDocument(sourceFile);
            document.SaveToFile(targetFile, (FileFormat)type);
        }
        public static void Convert(Stream sourceStream, Stream targetStream, FileType type)
        {
            PdfDocument document = new PdfDocument(sourceStream);
            document.SaveToStream(targetStream, (FileFormat)type);
        }
    }
}
