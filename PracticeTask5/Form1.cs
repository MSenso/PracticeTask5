using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeTask5
{
    public partial class Form1 : Form
    {
        double[,] matrix;
        int size;
        int[] b_values;
        TextBox[] B_Cells;
        TextBox[,] Matrix_Cells;
        int current_index = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SizeChoice.Visible = false;
            InputSize.Visible = false;
            InputLabel.Visible = false;
        }
        string[] Read_FromFile()
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Открытие текстового файла";
            openFileDialog1.Filter = "Текстовые файлы|*.txt";
            openFileDialog1.InitialDirectory = "";
            string[] filelines = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                filelines = File.ReadAllLines(filename);
            }
            return filelines;
        }
        void Generate_Visual_Matrix(bool is_from_file)
        {
            Matrix_Cells = new TextBox[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Matrix_Cells[i, j] = new TextBox()
                    {
                        Size = new Size(39, 34),
                        Location = new Point(19 + (39 + 5) * j, (137 + (34 + 5) * i)),
                        Name = "TextBox" + (i * size + j).ToString(),
                        
                    };
                    if (is_from_file)
                    {
                        Matrix_Cells[i, j].Text = matrix[i, j].ToString();
                        Matrix_Cells[i, j].ReadOnly = true;
                    }
                    Controls.Add(Matrix_Cells[i, j]);
                    Matrix_Cells[i, j].KeyDown += new KeyEventHandler(this.KeyDown);
                }
            }
            Controls.Find(Matrix_Cells[0, 0].Name, false)[0].Focus();
        }
        new void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // (sender as TextBox).Text.Replace(',', '.');
                Controls.Find((sender as TextBox).Name, false)[0].Text = Controls.Find((sender as TextBox).Name, false)[0].Text.Replace('.', ',');
                if (B_Cells == null)
                {
                    if (double.TryParse(Controls.Find("TextBox" + current_index.ToString(), false)[0].Text, out matrix[current_index / size, current_index % size]))
                    {
                        current_index++;
                        string next_name = "TextBox" + current_index.ToString();
                        if (Controls.ContainsKey(next_name))
                        {
                            Controls.Find(next_name, false)[0].Focus();
                        }
                        else Calculate_B_Values();
                    }
                    else MessageBox.Show("Некорректный ввод числа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int index = int.Parse(string.Join(string.Empty, (sender as TextBox).Name.Where(ch => char.IsDigit(ch)).ToArray()));
                   if (double.TryParse((sender as TextBox).Text, out matrix[index / size, index % size]))
                    {
                        Calculate_B_Values();
                    }
                    else MessageBox.Show("Некорректный ввод числа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                e.SuppressKeyPress = true;
            }
        }
        bool Raising_Sequence(int row_index)
        {
            bool is_raising = true;
            for(int j = 1; j < size && is_raising == true; j++)
            {
                if (matrix[row_index, j] <= matrix[row_index, j - 1])
                {
                    is_raising = false;
                }
            }
            return is_raising;
        }
        bool Descending_Sequence(int row_index)
        {
            bool is_descending = true;
            for (int j = 1; j < size && is_descending == true; j++)
            {
                if (matrix[row_index, j] >= matrix[row_index, j - 1])
                {
                    is_descending = false;
                }
            }
            return is_descending;
        }
        void Calculate_B_Values()
        {
            b_values = new int[size];
            for(int i = 0; i < size; i++)
            {
                if (Raising_Sequence(i) || Descending_Sequence(i))
                    b_values[i] = 1;
                else b_values[i] = 0;
            }
            Print_B_Values();
        }
        void Print_B_Values()
        {
            if (B_Cells == null)
            {
                B_Cells = new TextBox[size];
                Label B_Label = new Label()
                {
                    Text = "Последовательность b:",
                    Font = new Font(InputLabel.Font.FontFamily, InputLabel.Font.Size, InputLabel.Font.Style),
                    Size = new Size(Text.ToCharArray().Length * 50, 35),
                    Location = new Point(Matrix_Cells[size - 1, 0].Location.X, Matrix_Cells[size - 1, 0].Location.Y + Matrix_Cells[size - 1, 0].Height + 20),
                    Name = "B_Label",
                    BackColor = Color.Transparent,
                    ForeColor = Color.Black
                };
                Controls.Add(B_Label);
                for (int i = 0; i < size; i++)
                {
                    B_Cells[i] = new TextBox()
                    {
                        Size = new Size(39, 34),
                        Location = new Point(Matrix_Cells[size - 1, i].Location.X, Matrix_Cells[size - 1, i].Location.Y + Matrix_Cells[size - 1, i].Height + B_Label.Height + 20),
                        Name = "B" + i.ToString(),
                        ReadOnly = true,
                        BackColor = Color.FromArgb(255, 245, 248),
                        Text = b_values[i].ToString()
                    };
                    Controls.Add(B_Cells[i]);
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    B_Cells[i].Text = b_values[i].ToString();
                }
            }
        }
        void Remove_Visual_Matrix()
        {
            if (Matrix_Cells != null)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Controls.Remove(Matrix_Cells[i, j]);
                    }
                }
                Matrix_Cells = null;
                matrix = null;
                current_index = 0;
            }
        }
        void Remove_B_Cells()
        {
            if (B_Cells != null)
            {
                for (int i = 0; i < size; i++)
                {
                    Controls.Remove(B_Cells[i]);
                }
                Controls.RemoveByKey("B_Label");
                B_Cells = null;
                b_values = null;
            }
        }
        void Convert_From_File()
        {
            string[] lines = Read_FromFile();
            if (lines != null)
            {
                size = lines.Length;
                if (size <= 20 && size >= 2)
                {
                    matrix = new double[size, size];
                    bool is_correct = true;
                    for (int i = 0; i < lines.Length && is_correct; i++)
                    {
                        string[] value_lines = lines[i].Replace('.', ',').Split(' ');
                        if (value_lines.Length != size) is_correct = false;
                        for (int j = 0; j < size && is_correct; j++)
                        {
                            is_correct = double.TryParse(value_lines[j], out matrix[i, j]);
                        }
                    }
                    if (!is_correct)
                    {
                        matrix = null;
                        size = 0;
                        MessageBox.Show("Файл содержит некорректные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        InputLabel.Text = "Матрица из файла: ";
                        InputLabel.Visible = true;
                        Generate_Visual_Matrix(true);
                        Calculate_B_Values();
                    }
                }
                else
                {
                    MessageBox.Show("Размер матрицы должен быть от 2 до 20!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void InputSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(InputSize.Text, out size) && size >= 2 && size <= 20)
                {
                    InputLabel.Text = "Введите данные в таблицу:";
                    InputLabel.Visible = true;
                    matrix = new double[size, size];
                    Generate_Visual_Matrix(false);
                }
                else MessageBox.Show("Введите натуральное число от 2 до 20!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.SuppressKeyPress = true;
            }

        }

        private void InputSize_TextChanged(object sender, EventArgs e)
        {
            if (Matrix_Cells != null) Remove_Visual_Matrix();
            if (B_Cells != null) Remove_B_Cells();
        }

        private void ввестиВручнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove_Visual_Matrix();
            Remove_B_Cells();
            InputLabel.Visible = false;
            SizeChoice.Visible = true;
            InputSize.Visible = true;
            InputSize.Focus();
        }

        private void ввестиИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove_Visual_Matrix();
            Remove_B_Cells();
            InputLabel.Visible = false;
            SizeChoice.Visible = false;
            InputSize.Visible = false;
            InputLabel.Visible = false;
            Convert_From_File();
        }
    }
}
