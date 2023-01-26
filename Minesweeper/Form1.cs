using System;
using System.CodeDom.Compiler;
using System.Media;
using System.Diagnostics;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices;
using static System.Reflection.Metadata.BlobBuilder;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;

class Cell : Button
{
    public Point point;
    public bool was_opened = false;
    public bool was_flagged = false;
    public virtual void Reset()
    { 
        FlatStyle = FlatStyle.Flat;
        BackgroundImage = Minesweeper.Properties.Resources.Minesweeper_unopened;
    }
}

namespace Minesweeper
{
    public partial class Minesweeper : Form
    {
        private static Random rng = new();
        private Stopwatch stopwatch;
        List<Cell> cells = new();
        private int columns = 15;
        private int rows = 15;
        private int cell_size = 30;
        private int bombs_count;
        private int flags_left;
        private int[,] field;
        private bool check_near = false;

        SoundPlayer explosion = new(Properties.Resources.explosion);
        SoundPlayer open = new (Properties.Resources.open);
        SoundPlayer flag = new (Properties.Resources.flag1);
        SoundPlayer win = new (Properties.Resources.win1);

        enum State
        {
            Pregame,
            Ingame,
            Paused,
            Generation,
            Game_Over,
            Game_Won
        }
        enum Difficulty
        {
            Easy,
            Normal,
            Hard,
            Custom
        }

        private State state = State.Pregame;
        private Difficulty difficulty = Difficulty.Easy;

        public Minesweeper()
        {
            InitializeComponent();
        }

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();
        private void Form1_Load(object sender, EventArgs e)
        {
            //AllocConsole();
            stopwatch = new();
            field = new int[columns, rows];
            Icon = Icon.FromHandle(Properties.Resources.bomb.GetHicon());
            Restart(sender, e);
            ToolStrip maints = ((ToolStripMenuItem)menuStrip1.Items[0]).DropDown;
            ToolStrip ts = ((ToolStripMenuItem)maints.Items[0]).DropDown;
            check_set(ts.Items, 0);
            ts = ((ToolStripMenuItem)maints.Items[1]).DropDown;
            check_set(ts.Items, 2);
            Flags.Font = new Font("Segoe UI", 30);
            Stopwatch1.Font = new Font("Segoe UI", 30);
        }

        static Image Paint_number(int n)
        {
            switch(n)
            {
                case 1:
                    return Properties.Resources.Minesweeper_1;
                case 2:
                    return Properties.Resources.Minesweeper_2;
                case 3:
                    return Properties.Resources.Minesweeper_3;
                case 4:
                    return Properties.Resources.Minesweeper_4;
                case 5:
                    return Properties.Resources.Minesweeper_5;
                case 6:
                    return Properties.Resources.Minesweeper_6;
                case 7:
                    return Properties.Resources.Minesweeper_7;
                case 8:
                    return Properties.Resources.Minesweeper_8;
            }
            return Properties.Resources.Minesweeper_0;
        }

        void Check_neighbour(Cell cell)
        {
            if (cell.was_opened || cell.was_flagged)
                return;
            int bombs_nearby = field[cell.point.X, cell.point.Y];
            if (bombs_nearby < 0)
            {
                explosion.Play();
                state = State.Game_Over;
                stopwatch.Stop();
                restart_button.BackgroundImage = Properties.Resources.lost;
                OpenField();
                return;
            }
            if (bombs_nearby > 0)
            {
                cell.was_opened = true;
                cell.BackgroundImage = Paint_number(bombs_nearby);
                return;
            }
            int x = cell.point.X;
            int y = cell.point.Y;
            cell.was_opened = true;
            cell.BackgroundImage = Paint_number(bombs_nearby);
            for (int i = y - 1; i <= y + 1; i++)
            {
                for (int j = x - 1; j <= x + 1; j++)
                {
                    if (j < columns && j >= 0 && i < rows && i >= 0)
                        Check_neighbour(cells[i * columns + j]);
                }
            }
        }

        void OpenField()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Cell cur_cell = cells[i * columns + j];
                    if (field[j, i] < 0)
                    {
                        if (!cur_cell.was_flagged)
                        {
                            cur_cell.BackColor = Color.Red;
                            cur_cell.BackgroundImage = Properties.Resources.bomb;
                        }
                    }
                    else if (!cur_cell.was_opened)
                    {
                        if (!cur_cell.was_flagged)
                        {
                            cur_cell.BackgroundImage = Paint_number(field[j, i]);
                        }
                        else
                        {
                            cur_cell.BackgroundImage = Properties.Resources.wrong_flag;
                        }
                    }
                }
            }
        }

        void SetFlags()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Cell cur_cell = cells[i * columns + j];
                    int bombs_nearby = field[j, i];
                    if (bombs_nearby < 0 && !cur_cell.was_flagged)
                    {
                        cur_cell.was_flagged = true;
                        flags_left--;
                        Flags.Text = flags_left.ToString();
                        cur_cell.BackgroundImage = Properties.Resources.flag;
                    }
                }
            }
        }

        public static DialogResult Save(ref String value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button(); 
            form.Text = "Ñîõðàíèòü ðåçóëüòàò";
            label.Text = "Ââåäèòå ñâîå èìÿ:"; 
            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
            label.SetBounds(36, 36, 372, 13);
            textBox.SetBounds(36, 86, 700, 20);
            buttonOk.SetBounds(228, 160, 160, 60);
            buttonCancel.SetBounds(400, 160, 160, 60);
            label.AutoSize = true;
            form.ClientSize = new Size(796, 307);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void Win_check()
        {
            int opened = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    opened += (cells[i * columns + j].was_opened ? 1 : 0);
                }
            }
            if (opened == cells.Count() - bombs_count)
            {
                state = State.Game_Won;
                stopwatch.Stop();
                restart_button.BackgroundImage = Properties.Resources.win;
                win.Play();
                SetFlags();
                OpenField();
                MessageBox.Show($"Your time is {(int)stopwatch.Elapsed.TotalSeconds} seconds!", "Congratulations!", MessageBoxButtons.OK);
                string value = "";
                if (Save(ref value) == DialogResult.OK)
                {
                    char[] arr = value.ToCharArray();

                    arr = Array.FindAll<char>(arr, c => char.IsLetterOrDigit(c));
                    value = new string(arr);
                    if (value.Length > 0)
                    {
                        StreamWriter writer = File.AppendText("highscores.txt");
                        writer.WriteLine($"{difficulty},{columns},{rows},{bombs_count},{(int)stopwatch.Elapsed.TotalSeconds},{value}");
                        writer.Close();
                    }
                }
            }
        }

        private void Cell_check_down(object cell1, MouseEventArgs e)
        {
            if (state != State.Ingame && state != State.Generation)
                return;
            Cell cell = (Cell)cell1;
            MouseEventArgs me = e;
            if (state == State.Generation)
            {
                Gen_Field(cell.point.X, cell.point.Y);
                state = State.Ingame;
                stopwatch.Start();
            }
            if (me.Button == System.Windows.Forms.MouseButtons.Left && cell.was_opened)
            {
                for (int i = cell.point.Y - 1; i <= cell.point.Y + 1; i++)
                {
                    for (int j = cell.point.X - 1; j <= cell.point.X + 1; j++)
                    {
                        if (j < columns && j >= 0 && i < rows && i >= 0)
                        {
                            Cell check_cell = cells[i * columns + j];
                            if (!check_cell.was_opened && !check_cell.was_flagged)
                            {
                                check_cell.BackgroundImage = Properties.Resources.Minesweeper_0;
                            }
                        }
                    }
                }
                check_near = true;
            }
            if (me.Button == System.Windows.Forms.MouseButtons.Left && !cell.was_opened && !cell.was_flagged)
            {
                int bombs_nearby = field[cell.point.X, cell.point.Y];
                if (bombs_nearby < 0)
                {
                    explosion.Play();
                    state = State.Game_Over;
                    stopwatch.Stop();
                    restart_button.BackgroundImage = Properties.Resources.lost;
                    OpenField();
                }
                else
                {
                    open.Play();
                    Check_neighbour(cell);
                }
            }
            if (me.Button == System.Windows.Forms.MouseButtons.Right && !cell.was_opened)
            {
                if (cell.was_flagged)
                {
                    open.Play();
                    cell.was_flagged = !cell.was_flagged;
                    flags_left++;
                    Flags.Text = flags_left.ToString();
                    cell.Reset();
                }
                else if (flags_left > 0)
                {
                    flag.Play();
                    cell.was_flagged = !cell.was_flagged;
                    flags_left--;
                    Flags.Text = flags_left.ToString();
                    cell.BackgroundImage = Properties.Resources.flag;
                }
            }
            Win_check();
        }

        void Cell_check_up(object cell1, MouseEventArgs e)
        {
            if (state != State.Ingame && state != State.Generation)
                return;
            Cell cell = (Cell)cell1;
            MouseEventArgs me = e;
            if (me.Button == System.Windows.Forms.MouseButtons.Left && cell.was_opened && check_near)
            {
                check_near = false;
                for (int i = cell.point.Y - 1; i <= cell.point.Y + 1; i++)
                {
                    for (int j = cell.point.X - 1; j <= cell.point.X + 1; j++)
                    {
                        if (j < columns && j >= 0 && i < rows && i >= 0)
                        {
                            Cell check_cell = cells[i * columns + j];
                            if (!check_cell.was_opened && !check_cell.was_flagged)
                            {
                                check_cell.BackgroundImage = Properties.Resources.Minesweeper_unopened;
                            }
                        }
                    }
                }

                int flags_nearby = 0;
                int bombs_nearby = field[cell.point.X, cell.point.Y];
                for (int i = cell.point.Y - 1; i <= cell.point.Y + 1; i++)
                {
                    for (int j = cell.point.X - 1; j <= cell.point.X + 1; j++)
                    {
                        if (j < columns && j >= 0 && i < rows && i >= 0)
                        {
                            Cell check_cell = cells[i * columns + j];
                            flags_nearby += check_cell.was_flagged ? 1 : 0;
                        }
                    }
                }
                if (flags_nearby == bombs_nearby)
                {
                    for (int i = cell.point.Y - 1; i <= cell.point.Y + 1; i++)
                    {
                        for (int j = cell.point.X - 1; j <= cell.point.X + 1; j++)
                        {
                            if (j < columns && j >= 0 && i < rows && i >= 0)
                            {
                                Cell check_cell = cells[i * columns + j];
                                if (!check_cell.was_opened && !check_cell.was_flagged)
                                {
                                    open.Play();
                                    Check_neighbour(check_cell);
                                }
                            }
                        }
                    }
                }
            }
            Win_check();
        }

        private void Gen_Field(int click_x, int click_y)
        {
            Array.Clear(field, 0, field.Length);
            field = new int[columns, rows];
            int minesToAdd = bombs_count;
            while (minesToAdd > 0)
            {
                int c = rng.Next(0, columns * rows);
                if (field[c % columns, c / columns] != -1 && ((click_x - (c % columns)) * (click_x - (c % columns)) + (click_y - (c / columns)) * (click_y - (c / columns))) > 2)
                {
                    field[c % columns, c / columns] = -1;
                    minesToAdd--;
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (field[col, row] == 0)
                    {
                        for (int i = row - 1; i <= row + 1; i++)
                        {
                            for (int j = col - 1; j <= col + 1; j++)
                            {
                                if (j < columns && j >= 0 && i < rows && i >= 0)
                                    field[col, row] += field[j, i] == -1 ? 1 : 0;
                            }
                        }
                    }
                }
            }
        }

        private void Restart(object sender, EventArgs e)
        {
            foreach (Cell cell in cells)
                Controls.Remove(cell);
            cells.Clear();
            if (difficulty != Difficulty.Custom) bombs_count = columns * rows / (15 - (int)difficulty * 4);
            flags_left = bombs_count;
            restart_button.BackgroundImage = Properties.Resources.restart;
            stopwatch.Reset();

            Flags.Text = flags_left.ToString();

            state = State.Generation;

            Size border = new(this.Width - this.ClientRectangle.Width, this.Height - this.ClientRectangle.Height);

            int padding = label1.Location.Y;
            this.Width = (cell_size) * columns + 2 * border.Width;
            int x_offset = (this.Width - border.Width - (cell_size) * columns) / 2;

            this.Height = padding + (cell_size) * rows + border.Height + 2 * x_offset;
            int y_offset = padding + (this.Height - border.Height - padding - (cell_size) * rows) / 2;

            Point prev = new(x_offset, y_offset);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Cell tmp = new();
                    tmp.point = new Point(j, i);
                    tmp.Size = new Size(cell_size, cell_size);
                    tmp.Location = prev;
                    tmp.BackgroundImageLayout = ImageLayout.Zoom;
                    prev.X = tmp.Right;
                    tmp.Visible = true;
                    tmp.Anchor = AnchorStyles.None;
                    tmp.Margin = new Padding(0, 0, 0, 0);
                    tmp.Reset();
                    cells.Add(tmp);
                    Controls.Add(tmp);
                }
                prev.X = x_offset;
                prev.Y += cell_size;
            }
            foreach (Cell cell in cells)
            {
                cell.MouseDown += new MouseEventHandler(Cell_check_down);
                cell.MouseUp += new MouseEventHandler(Cell_check_up);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Stopwatch1.Text = string.Format("{0:hh\\:mm\\:ss}", stopwatch.Elapsed);
        }

        public static DialogResult Settings(ref Size value, ref int bombs)
        {
            Form2 form = new Form2();
            form.Text = "Íàñòðîéêà èãðû";
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            DialogResult dialogResult = form.ShowDialog();
            value = form.size;
            bombs = form.bombs_count;
            return dialogResult;
        }

        private void ñâîéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check_set(((ToolStripMenuItem)((ToolStripItem)sender).OwnerItem).DropDownItems, 3);
            Size value = new(0, 0);
            int bombs = bombs_count;
            if (Settings(ref value, ref bombs) == DialogResult.OK)
            {
                if (value.Width < 4)
                    value.Width = 4;
                if (value.Width > 20)
                    value.Width = 20;
                if (value.Height < 4)
                    value.Height = 4;
                if (value.Height > 20)
                    value.Height = 20;
                columns = value.Width;
                rows = value.Height;
                if (bombs < 1)
                    bombs = 1;
                if (bombs > columns * rows - 9)
                    bombs = columns * rows - 9;
                difficulty = Difficulty.Custom;
                bombs_count = bombs;
                Restart(sender, e);
            }
        }

        private void check_set(ToolStripItemCollection ms, int id)
        {
            for (int i = 0; i < ms.Count; i++)
                ((ToolStripMenuItem)ms[i]).Checked = false;
            ((ToolStripMenuItem)ms[id]).Checked = true;
        }

        private void ñâîÿToolStripMenuItem_Click(object sender, EventArgs e) //îáà îòêðûâàþò îäíî è òî æå
        {
            check_set(((ToolStripMenuItem)((ToolStripItem)sender).OwnerItem).DropDownItems, 3);
            ñâîéToolStripMenuItem_Click(sender, e);
        }

        private void ë¸ãêàÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check_set(((ToolStripMenuItem)((ToolStripItem)sender).OwnerItem).DropDownItems, 0);
            difficulty = Difficulty.Easy;
            Restart(sender, e);
        }

        private void ñðåäíÿÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check_set(((ToolStripMenuItem)((ToolStripItem)sender).OwnerItem).DropDownItems, 1);
            difficulty = Difficulty.Normal;
            Restart(sender, e);
        }

        private void ñëîæíàÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check_set(((ToolStripMenuItem)((ToolStripItem)sender).OwnerItem).DropDownItems, 2);
            difficulty = Difficulty.Hard;
            Restart(sender, e);
        }

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check_set(((ToolStripMenuItem)((ToolStripItem)sender).OwnerItem).DropDownItems, 0);
            if (difficulty == Difficulty.Custom)
                difficulty = Difficulty.Hard;
            columns = rows = 5;
            Restart(sender, e);
        }

        private void x10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check_set(((ToolStripMenuItem)((ToolStripItem)sender).OwnerItem).DropDownItems, 1);
            if (difficulty == Difficulty.Custom)
                difficulty = Difficulty.Normal;
            columns = rows = 10;
            Restart(sender, e);
        }

        private void x15ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            check_set(((ToolStripMenuItem)((ToolStripItem)sender).OwnerItem).DropDownItems, 2);
            if (difficulty == Difficulty.Custom)
                difficulty = Difficulty.Easy;
            columns = rows = 15;
            Restart(sender, e);
        }

        public static DialogResult Results()
        {
            Form3 form = new Form3();
            form.Text = "Ðåçóëüòàòû";
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            DialogResult dialogResult = form.ShowDialog();
            return dialogResult;
        }

        private void ðåçóëüòàòûToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Results();
        }

        public static DialogResult Info()
        {
            Form form = new Form();
            Label label = new Label();
            Button buttonOk = new Button();
            form.Text = "Î ïðîãðàììå";
            label.Text = "Ãðóïïà: È914Á\nÈìÿ: Åãîðîâ Àëåêñàíäð";
            label.Font = new Font("Segoe UI", 23);
            buttonOk.Text = "OK";
            buttonOk.DialogResult = DialogResult.OK;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label.SetBounds(36, 36, 372, 100);
            buttonOk.SetBounds(36, 160, 372, 60);
            label.AutoSize = false;
            form.ClientSize = new Size(444, 307);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.Controls.AddRange(new Control[] { label, buttonOk});
            form.AcceptButton = buttonOk;
            DialogResult dialogResult = form.ShowDialog();
            return dialogResult;
        }

        private void îÏðîãðàììåToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info();
        }
    }
}