namespace silver_order_api.Data
{
    public class ImageHelper
    {
        public static byte[] ImageToByteArray(string imagePath)
        {
            return File.ReadAllBytes(imagePath);
        }
    }
}
