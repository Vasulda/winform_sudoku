using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuProject
{
    public partial class Form1 : Form
    {
        int chosenNum, disabledBut = 0;
        public void EnableButtons()
        {
            switch (disabledBut)
            {
                case 1:
                    But1.Enabled = true;
                    break;
                case 2:
                    But2.Enabled = true;
                    break;
                case 3:
                    But3.Enabled = true;
                    break;
                case 4:
                    But4.Enabled = true;
                    break;
                case 5:
                    But5.Enabled = true;
                    break;
                case 6:
                    But6.Enabled = true;
                    break;
                case 7:
                    But7.Enabled = true;
                    break;
                case 8:
                    But8.Enabled = true;
                    break;
                case 9:
                    But9.Enabled = true;
                    break;
            }
        }

        //lepsi by byla array buttonu ale tak jsem debil no
        public void But1_Click(object sender, EventArgs e)
        {
            Button But1 = sender as Button;
            chosenNum = 1;
            EnableButtons();
            disabledBut = 1;
            But1.Enabled = false;

        }
        public void But2_Click(object sender, EventArgs e)
        {
            Button But2 = sender as Button;
            chosenNum = 2;
            EnableButtons();
            disabledBut = 2;
            But2.Enabled = false;
        }
        public void But3_Click(object sender, EventArgs e)
        {
            Button But3 = sender as Button;
            chosenNum = 3;
            EnableButtons();
            disabledBut = 3;
            But3.Enabled = false;
        }
        public void But4_Click(object sender, EventArgs e)
        {
            Button But4 = sender as Button;
            chosenNum = 4;
            EnableButtons();
            disabledBut = 4;
            But4.Enabled = false;
        }
        public void But5_Click(object sender, EventArgs e)
        {
            Button But5 = sender as Button;
            chosenNum = 5;
            EnableButtons();
            disabledBut = 5;
            But5.Enabled = false;
        }
        public void But6_Click(object sender, EventArgs e)
        {
            Button But6 = sender as Button;
            chosenNum = 6;
            EnableButtons();
            disabledBut = 6;
            But6.Enabled = false;
        }
        private void But7_Click(object sender, EventArgs e)
        {
            Button But7 = sender as Button;
            chosenNum = 7;
            EnableButtons();
            disabledBut = 7;
            But7.Enabled = false;
        }
        private void But8_Click(object sender, EventArgs e)
        {
            Button But8 = sender as Button;
            chosenNum = 8;
            EnableButtons();
            disabledBut = 8;
            But8.Enabled = false;
        }
        private void But9_Click(object sender, EventArgs e)
        {
            Button But9 = sender as Button;
            chosenNum = 9;
            EnableButtons();
            disabledBut = 9;
            But9.Enabled = false;
        }
        private void EraseBtn_Click(object sender, EventArgs e)
        {
            Button EraseBtn = sender as Button;
            chosenNum = 0;
        }



        public Button[,] box = new Button[9, 9];
        public int[,] grid = new int[9, 9] {

                {0, 5, 3, 0, 0, 0, 7, 9, 0},
                {0, 0, 9, 7, 8, 2, 6, 0, 0},
                {0, 0, 0, 5, 0, 3, 0, 0, 0},
                {0, 0, 0, 4, 0, 6, 0, 0, 0},
                {0, 4, 0, 0, 0, 0, 0, 6, 0},
                {8, 0, 5, 1, 0, 9, 3, 0, 2},
                {0, 0, 8, 9, 3, 1, 4, 0, 0},
                {9, 0, 0, 0, 0, 0, 0, 0, 6},
                {0, 0, 4, 0, 0, 0, 8, 0, 0}
            };


        int offset = 0;
        int boxSide = 40, x = 50, y = 0;
        //int numberOfRecursions = 0;



        private void RestartButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        int numSize = 20;

        public Form1()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.Selectable, false);

            for (int i = 0; i < 9; i++)
            {
                x += (i % 3 == 0) ? 45 : 40;

                for (int j = 0; j < 9; j++)
                {
                    y += (j % 3 == 0) ? 45 : 40;

                    box[i, j] = new Button();
                    box[i, j].Size = new Size(boxSide, boxSide);
                    this.Controls.Add(box[i, j]);
                    box[i, j].Location = new Point(x, y);
                    box[i, j].Font = new Font(box[i, j].Font.FontFamily, numSize);
                    box[i, j].Name = i + " " + j;
                    box[i, j].Click += new EventHandler(ButtonClick);
                }

                y = offset;
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i, j] != 0)
                    {
                        box[i, j].Text = grid[i, j].ToString();
                        box[i, j].Enabled = false;
                    }
                }
            }

        }
        //---------------------------------

        protected void ButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (chosenNum == 0)
            {
                button.Text = " ";

            }
            else button.Text = chosenNum.ToString();

            string[] split = button.Name.Split(new Char[] { ' ' });

            int x = System.Convert.ToInt32(split[0]);
            int y = System.Convert.ToInt32(split[1]);

            grid[x, y] = chosenNum;

            if (chosenNum != 0)
            {
                if (!(isRowOK(grid, x, y) == true && isCollumOK(grid, x, y) && isSectorOK(grid, x, y) == true))
                {
                    button.BackColor = Color.Red;
                }
                else button.BackColor = default(Color);
            }
            else button.BackColor = default(Color);

/*
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i, j] != 0) MessageBox.Show("VYHRAL JSI");
                }
            }
*/
        }
        // SOLVING ALGHORITHM -----------------------------------------------------------------------------------------------------------------

        public int solveSudoku(int[,] grid, int last_i, int last_j)
        {
            bool isThereSpace = false;


            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    if (grid[i, j] == 0)
                    {
                        last_i = i;
                        last_j = j;

                        isThereSpace = true;
                        break;// jeste existuje prazdne policko
                    }
                   
                }
                if (isThereSpace == true) break;
            }
         

            if (isThereSpace == false)
            {
                 for (int i = 0; i < 9; i++)
                 {
                     for (int j = 0; j < 9; j++)
                     {
                         box[i, j].Text = grid[i, j].ToString();
                     }
                 }
                 //insert printing 
                return 1; //sudoku je finito 
            } else {
                do
                {
                    do
                    {
                        grid[last_i, last_j] += 1;
                       
                        if (grid[last_i, last_j] == 10)
                        {
                        
                            grid[last_i, last_j] = 0; //back track
                            return -1;
                        }

                    } while (!(isRowOK(grid, last_i, last_j) == true && isCollumOK(grid, last_i, last_j) == true && isSectorOK(grid, last_i, last_j) == true));

                } while (solveSudoku(grid, last_i, last_j) == -1);

                return 1;
            }
        }
        // IN GAME LOGIC ------------------------------------------------------------------------------------------------------------------------
        public bool isRowOK(int[,] grid, int last_i, int last_j)
        {

            for (int j = 0; j < 9; j++)
            {

                if (j != last_j)
                {
                    if (grid[last_i, j] == grid[last_i, last_j]) return false; // nektere hodnota v polickach je stejna
                }
            }
            return true;
        }

      

        public bool isCollumOK(int[,] grid, int last_i, int last_j)
        {

            for (int i = 0; i < 9; i++)
            {

                if (i != last_i)
                {

                    if (grid[i, last_j] == grid[last_i, last_j]) return false; // nektere hodnota v polickach je stejna
                }
            }
            return true;
        }

        public bool isSectorOK(int[,] grid, int last_i, int last_j)
        {

            int start_i = 0, start_j = 0; // roh daneho sektoru 0,3 0,6 ....

            if ((last_i >= 0 && last_i <= 2) && (last_j >= 0 && last_j <= 2))
            {
                start_i = 0;
                start_j = 0;
            }

            if ((last_i >= 0 && last_i <= 2) && (last_j >= 3 && last_j <= 5))
            {
                start_i = 0;
                start_j = 3;
            }

            if ((last_i >= 0 && last_i <= 2) && (last_j >= 6 && last_j <= 8))
            {
                start_i = 0;
                start_j = 6;
            }

            if ((last_i >= 3 && last_i <= 5) && (last_j >= 0 && last_j <= 2))
            {
                start_i = 3;
                start_j = 0;
            }

            if ((last_i >= 3 && last_i <= 5) && (last_j >= 3 && last_j <= 5))
            {
                start_i = 3;
                start_j = 3;
            }

            if ((last_i >= 3 && last_i <= 5) && (last_j >= 6 && last_j <= 8))
            {
                start_i = 3;
                start_j = 6;
            }

            if ((last_i >= 6 && last_i <= 8) && (last_j >= 0 && last_j <= 2))
            {
                start_i = 6;
                start_j = 0;
            }

            if ((last_i >= 6 && last_i <= 8) && (last_j >= 3 && last_j <= 5))
            {
                start_i = 6;
                start_j = 3;
            }

            if ((last_i >= 6 && last_i <= 8) && (last_j >= 6 && last_j <= 8))
            {
                start_i = 6;
                start_j = 6;
            }

            for (int i = start_i; i < start_i + 3; i++)
            {
                for (int j = start_j; j < start_j + 3; j++)
                {
                    if (i != last_i && j != last_j)
                        if (grid[i, j] == grid[last_i, last_j]) return false;
                }
            }
            return true;
        }

        public void SolveButton_Click(object sender, EventArgs e)
        {
            solveSudoku(grid, 0, 0);

        }

    }
}
