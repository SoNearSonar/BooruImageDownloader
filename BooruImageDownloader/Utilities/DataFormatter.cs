using Microsoft.VisualBasic.ApplicationServices;

namespace BooruImageDownloader.Utilities
{
    public static class DataFormatter
    {
        /**
         * Credit to this user from StackOverflow: https://stackoverflow.com/users/553396/humbads
         * Post from site: https://www.somacon.com/p576.php
         */
        public static string GetBytesReadable(ulong i)
        {
            // Get absolute value
            // Determine the suffix and readable value
            string suffix;
            double readable;
            if (i >= 0x1000000000000000) // Exabyte
            {
                suffix = " EB";
                readable = (i >> 50);
            }
            else if (i >= 0x4000000000000) // Petabyte
            {
                suffix = " PB";
                readable = (i >> 40);
            }
            else if (i >= 0x10000000000) // Terabyte
            {
                suffix = " TB";
                readable = (i >> 30);
            }
            else if (i >= 0x40000000) // Gigabyte
            {
                suffix = " GB";
                readable = (i >> 20);
            }
            else if (i >= 0x100000) // Megabyte
            {
                suffix = " MB";
                readable = (i >> 10);
            }
            else if (i >= 0x400) // Kilobyte
            {
                suffix = " KB";
                readable = i;
            }
            else
            {
                return i.ToString("0 B"); // Byte
            }
            // Divide by 1024 to get fractional value
            readable /= 1024;
            // Return formatted number with suffix
            return readable.ToString("0.##") + suffix;
        }

        public static int GetPrecentage(double currentImageNumber, double totalImages)
        {
            return (int)((currentImageNumber / totalImages) * 100);
        }

        public static int GetScaledDimension(int dimensionSize, double precentage)
        {
            return (int)(dimensionSize * precentage);
        }
    }
}
