using ColorMine.ColorSpaces;
using ColorMine.ColorSpaces.Comparisons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ColorPaletteHelper
{
    internal static class ColorPaletteHelper
    {
        private static readonly string[] IMAGE_EXTENSIONS = { ".png" };
        
        private const string OUT_FOLDER = "all";
        private const string OUT_PREFIX = "bg_";

        public static void ProcessImages(string folderPath, Dictionary<string, Rgb> allowedColors)
        {
            string outputFolder = Path.Combine(folderPath, OUT_FOLDER);
            
            Directory.CreateDirectory(outputFolder);

            var imageFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
                .Where(f => IMAGE_EXTENSIONS.Contains(Path.GetExtension(f).ToLower()));

            int iter = 0;
            foreach (var imagePath in imageFiles)
            {
                try
                {
                    using (var image = new Bitmap(imagePath))
                    {
                        var dominantColor = GetDominantColor(image);
                        var closestColorName = FindClosestColorName(dominantColor, allowedColors);

                        string imageDirectoryPath = Path.GetDirectoryName(imagePath);
                        if(imageDirectoryPath == null)
                            continue;
                        
                        string parentFolderName = new DirectoryInfo(imageDirectoryPath).Name;

                        string newFileName = $"{OUT_PREFIX}{closestColorName}_{parentFolderName}";
                        string fileOutputFolder = outputFolder + $"\\{parentFolderName}";
                        string newFilePath = Path.Combine(fileOutputFolder, newFileName); ;

                        if(!Directory.Exists(fileOutputFolder))
                            Directory.CreateDirectory(fileOutputFolder);

                        if (File.Exists(newFilePath + ".png"))
                            newFilePath += $"_copy_{iter}";

                        newFilePath += ".png";
                        
                        File.Copy(imagePath, newFilePath, overwrite: true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"Ошибка при обработке файла {imagePath}: {ex.Message}");
                    return;
                }

                iter++;
            }

            MessageBox.Show(@"Готово!");
        }

        public static Color GetDominantColor(Bitmap image)
        {
            var colorCount = new Dictionary<Color, int>();
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    var pixelColor = image.GetPixel(x, y);
                    
                    if (pixelColor.A == 0)
                        continue;

                    if (colorCount.ContainsKey(pixelColor))
                        colorCount[pixelColor]++;
                    else
                        colorCount[pixelColor] = 1;
                }
            }

            if (colorCount.Count == 0)
                return Color.Transparent;

            return colorCount.OrderByDescending(kv => kv.Value).First().Key;
        }

        public static string FindClosestColorName(Color targetColor, Dictionary<string, Rgb> allowedColors)
        {
            var targetRgb = new Rgb { R = targetColor.R, G = targetColor.G, B = targetColor.B };
            string closestColor = "Неизвестный";
            double minDistance = double.MaxValue;

            foreach (var colorEntry in allowedColors)
            {
                var distance = targetRgb.Compare(colorEntry.Value, new Cie1976Comparison());
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestColor = colorEntry.Key;
                }
            }

            return closestColor;
        }
    }
}
