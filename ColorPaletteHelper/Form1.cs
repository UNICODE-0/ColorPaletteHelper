using ColorMine.ColorSpaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ColorPaletteHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Path.Text))
                {
                    MessageBox.Show(@"Директория не существует!");
                    return;
                }

                // Словарь допустимых цветов (название → Rgb)
                var allowedColors = new Dictionary<string, Rgb>
                {
                    // Можно добавить свои цвета
                };

                if (dataGridView1.Rows.Count == 1 && allowedColors.Count == 0)
                {
                    MessageBox.Show(@"Необходимо заполнить таблицу цветов");
                    return;
                }
            
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value == null) continue;

                    Color color = row.Cells[0].Style.BackColor;
                    allowedColors.Add(row.Cells[0].Value.ToString(), new Rgb() { R = color.R, G = color.G, B = color.B });
                }

                ColorPaletteHelper.ProcessImages(Path.Text, allowedColors);
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Что то пошло не так: {ex.Message}");
            }
        }

        private void ChoosePath_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    Path.Text = folderBrowserDialog1.SelectedPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Что то пошло не так: {ex.Message}");
            }
        }

        private void AddColor_Click(object sender, EventArgs e)
        {
            try
            {
                if(colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    Color color = colorDialog1.Color;
                
                    dataGridView1.Rows.Add(color.IsNamedColor ? color.Name : "color");
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[0].Style = new DataGridViewCellStyle 
                    { 
                        SelectionBackColor = color,
                        BackColor = color,
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Что то пошло не так: {ex.Message}");
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colorHex = dataGridView1.CurrentCell.Value.ToString();
                if (!Regex.IsMatch(colorHex, @"^#?([0-9A-Fa-f]{3}|[0-9A-Fa-f]{6})$"))
                    return;

                Color color = HexToColor(colorHex);
                dataGridView1.CurrentCell.Style = new DataGridViewCellStyle
                {
                    SelectionBackColor = color,
                    BackColor = color,
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Что то пошло не так: {ex.Message}");
            }
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        
        private Color HexToColor(string hex)
        {
            hex = hex.Replace("#", "");

            if (hex.Length == 3) // Короткий формат (#RGB → #RRGGBB)
                hex = $"{hex[0]}{hex[0]}{hex[1]}{hex[1]}{hex[2]}{hex[2]}";

            if (hex.Length != 6)
                throw new ArgumentException("HEX должен быть в формате #RRGGBB или #RGB.");

            byte r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);

            return Color.FromArgb(r, g, b);
        }
    }
}
