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
        public double[,] matrix;
        public int size;
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
        string[] Read_FromFile() // Чтение из файла
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Открытие текстового файла";
            openFileDialog1.Filter = "Текстовые файлы|*.txt";
            openFileDialog1.InitialDirectory = "";
            string[] filelines = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string path = Path.GetDirectoryName(openFileDialog1.FileName);
                filelines = File.ReadAllLines(filename);
            }
            return filelines;
        }
        public void Generate_Visual_Matrix(bool is_from_file) // Отображение матрицы на экране
        {
            Matrix_Cells = new TextBox[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Matrix_Cells[i, j] = new TextBox() // Каждый элемент матрицы представляется в текстбоксе
                    {
                        Size = new Size(39, 34),
                        Location = new Point(19 + (39 + 5) * j, (137 + (34 + 5) * i)),
                        Name = "TextBox" + (i * size + j).ToString(),
                        
                    };
                    if (is_from_file) // Если матрица из файла
                    {
                        Matrix_Cells[i, j].Text = matrix[i, j].ToString();
                        Matrix_Cells[i, j].ReadOnly = true;
                    }
                    Controls.Add(Matrix_Cells[i, j]);
                    Matrix_Cells[i, j].KeyDown += new KeyEventHandler(this.KeyDown); // Подписка на событие нажатия клавиши
                }
            }
            Controls.Find(Matrix_Cells[0, 0].Name, false)[0].Focus();
        }
        new void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Нажат энтер
            {
                Controls.Find((sender as TextBox).Name, false)[0].Text = Controls.Find((sender as TextBox).Name, false)[0].Text.Replace('.', ','); // Замена в тексте точки на запятую для корректного парса строки
                if (B_Cells == null) // Первый раз работы программы
                {
                    if (double.TryParse(Controls.Find("TextBox" + current_index.ToString(), false)[0].Text, out matrix[current_index / size, current_index % size])) // Парс текста текстбокса в заданный элемент матрицы
                    {
                        current_index++; // Индекс текущего текстбокса матрицы увеличен
                        string next_name = "TextBox" + current_index.ToString();
                        if (Controls.ContainsKey(next_name))
                        {
                            Controls.Find(next_name, false)[0].Focus(); // Переключение на следующий элемент
                        }
                        else Calculate_B_Values(); // Подсчет
                    }
                    else MessageBox.Show("Некорректный ввод числа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int index = int.Parse(string.Join(string.Empty, (sender as TextBox).Name.Where(ch => char.IsDigit(ch)).ToArray())); // Получение индекса текущего текстбокса
                    if (double.TryParse((sender as TextBox).Text, out matrix[index / size, index % size])) // Парс строки в элемент матрицы с текущим индексом
                    {
                        Calculate_B_Values(); // Подсчет
                    }
                    else MessageBox.Show("Некорректный ввод числа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                e.SuppressKeyPress = true;
            }
        }
        bool Raising_Sequence(int row_index) // Проверка возрастающей последовательности
        {
            for(int j = 1; j < size; j++)
            {
                if (matrix[row_index, j] <= matrix[row_index, j - 1])
                {
                    return false; // Текущий элемент не превосходит предыдущий, поэтому это не возрастающая последовательность
                }
            }
            return true;
        }
        bool Descending_Sequence(int row_index) // Проверка убывающей последовательности
        {
            for (int j = 1; j < size; j++)
            {
                if (matrix[row_index, j] >= matrix[row_index, j - 1])
                {
                    return false; // Текущий элемент не меньше предыдущего, поэтому это не возрастающая последовательность
                }
            }
            return true;
        }
        public void Calculate_B_Values() // Подсчет элементов последовательности b
        {
            b_values = new int[size]; // Элементов столько же, сколько и строк в матрице
            for(int i = 0; i < size; i++)
            {
                if (Raising_Sequence(i) || Descending_Sequence(i)) // Если возрастающая или убывающая последовательность
                    b_values[i] = 1;
                else b_values[i] = 0;
            }
            Print_B_Values();
        }
        void Print_B_Values() // Вывод последовательности на экран
        {
            if (B_Cells == null) // Последовательность еще не была выведена
            {
                B_Cells = new TextBox[size]; // Последовательность выводится массивом текстбоксов
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
                    B_Cells[i].Text = b_values[i].ToString(); // У текущего текстбокса обновляется текст
                }
            }
        }
        public void Remove_Visual_Matrix() // Удаление матрицы с формы
        {
            if (Matrix_Cells != null) // Если еще не удалена
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Controls.Remove(Matrix_Cells[i, j]); // Очищение от каждого тексбокса матрицы
                    }
                }
                Matrix_Cells = null; //Обнуление
                matrix = null;
                current_index = 0;
            }
        }
        public void Remove_B_Cells() // Удаление последовательности с формы
        {
            if (B_Cells != null) // Если еще не удалена
            {
                for (int i = 0; i < size; i++)
                {
                    Controls.Remove(B_Cells[i]); // Очищение от каждого тексбокса матрицы
                }
                Controls.RemoveByKey("B_Label"); // Удаление подписи к последовательности
                B_Cells = null; // Обнуление
                b_values = null;
            }
        }
        public void Convert_From_File() // Считывание из файла
        {
            string[] lines = Read_FromFile();
            if (lines != null) // Не пустой файл
            {
                size = lines.Length; // Количество строк
                if (size <= 20 && size >= 2) // Размер от 2 до 20
                {
                    matrix = new double[size, size];
                    bool is_correct = true;
                    for (int i = 0; i < lines.Length && is_correct; i++)
                    {
                        string[] value_lines = lines[i].Replace('.', ',').Split(' '); // Разбиение строки на подстроки чисел
                        if (value_lines.Length != size) is_correct = false; // Количество чисел в строке не равно количеству строк, матрица не квадратная
                        for (int j = 0; j < size && is_correct; j++)
                        {
                            is_correct = double.TryParse(value_lines[j], out matrix[i, j]); // Парс строки в элемент матрицы
                        }
                    }
                    if (!is_correct) // Некорректный ввод
                    {
                        matrix = null; // Обнуление
                        size = 0;
                        MessageBox.Show("Файл содержит некорректные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        InputLabel.Text = "Матрица из файла: "; 
                        InputLabel.Visible = true;
                        Generate_Visual_Matrix(true); // Вывод матрицы
                        Calculate_B_Values(); // Подсчет
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
            if (e.KeyCode == Keys.Enter) // Нажат энтер
            {
                if (int.TryParse(InputSize.Text, out size) && size >= 2 && size <= 20) // Введено целое число от 2 до 20
                {
                    InputLabel.Text = "Введите данные в таблицу:";
                    InputLabel.Visible = true;
                    matrix = new double[size, size];
                    Generate_Visual_Matrix(false); // Генерация текстбоксов матрицы для заполнения
                }
                else MessageBox.Show("Введите натуральное число от 2 до 20!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.SuppressKeyPress = true;
            }

        }

        private void InputSize_TextChanged(object sender, EventArgs e)
        {
            if (Matrix_Cells != null) Remove_Visual_Matrix(); // Очищение от матрицы
            if (B_Cells != null) Remove_B_Cells(); // Очищение от последовательности
        }

        private void ввестиВручнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Очищение формы
            Remove_Visual_Matrix();
            Remove_B_Cells();
            InputLabel.Visible = false;
            SizeChoice.Visible = true;
            InputSize.Visible = true;
            InputSize.Focus();
        }

        private void ввестиИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Очищение формы
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
