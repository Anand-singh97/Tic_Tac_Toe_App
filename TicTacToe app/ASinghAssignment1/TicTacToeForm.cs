/* PROGRAMMER - AnandPravesh Singh
 * ID - 8884337
 * PROFESSOR - Sabbir Ahmed
 * DESCRIPTION - Tic_Tac_Toe Game
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASinghAssignment1
{
    public partial class TicTacToeForm : Form
    {
        private string[,] matrix = new string[3, 3];
        private Dictionary<string, (int, int)> pairs = new Dictionary<string, (int, int)>();
        private int counter = 0;

        public TicTacToeForm()
        {
            InitializeComponent();
            FillDictionary();
        }

        private void pictureBox_click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Image == null)
            {
                if (counter % 2 != 0)
                {
                    ((PictureBox)sender).Image = Resource1.X_logo;
                    
                    updateMatrix("X", ((PictureBox)sender).Name);
                }
                else
                {
                    ((PictureBox)sender).Image = Resource1.O_logo;

                    updateMatrix("O", ((PictureBox)sender).Name);
                }

                counter++;
                if (counter >= 5)
                {
                    checkWinner();
                }
            }
        }

        public void FillDictionary()
        {
            int x = 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    pairs.Add("pbx" + x, (i, j));
                    x++;
                }
            }
        }

        private void updateMatrix(string userLogo, string boxName)
        {
            matrix[pairs[boxName].Item1, pairs[boxName].Item2] = userLogo;
        }

        private void checkWinner()
        {
            string result = "";

            //Check Horozontally.
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == null)
                    {
                        break;
                    }
                    result += matrix[i, j];
                }
                if (result == "XXX" || result == "OOO")
                {
                    MessageBox.Show(result[0].ToString() + " Wins!!");
                    resetGame();
                    break;
                }
                result = "";
            }

            //Check Vertically.
            if (result != "XXX" && result != "OOO")
            {              
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] == null)
                        {
                            break;
                        }

                        result += matrix[i, j];
                    }
                    if (result == "XXX" || result == "OOO")
                    {
                        MessageBox.Show(result[0].ToString() + " Wins!!");
                        resetGame();
                        break;
                    }
                    result = "";
                }
            }

            //Check Diagonally (Left to Right)
            if (result != "XXX" && result != "OOO")
            {        
                for (int j = 0, i = 0; j < matrix.GetLength(0); j++, i++)
                {
                    if (matrix[i, j] == null)
                    {
                        break;
                    }
                    result += matrix[i, j];
                }

                if (result == "XXX" || result == "OOO")
                {
                    MessageBox.Show(result[0].ToString() + " Wins!!");
                    resetGame();
                }
                result = "";
            }

            //Check Diagonally (Right to Left)
            if (result != "XXX" && result != "OOO")
            {
                for (int j = 2, i = 0; i < matrix.GetLength(0); j--, i++)
                {
                    if (matrix[i, j] == null)
                    {
                        break;
                    }
                    result += matrix[i, j];
                }

                if (result == "XXX" || result == "OOO")
                {
                    MessageBox.Show(result[0].ToString() + " Wins!!");
                    resetGame();
                }
                result = "";
            }

            //Check if Draw!!
            if (counter == 9 && result != "XXX" && result != "OOO")
            {
                MessageBox.Show("Draw!!");
                resetGame();
            }
        }

        private void resetGame()
        {
            foreach (PictureBox pb in gbxTicTac.Controls)
            {

                pb.Image = null;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = null;
                }
            }

            counter = 0;
        }
    }
}
