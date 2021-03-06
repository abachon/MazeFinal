﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCS_Week_003_final
{
    public partial class Form1 : Form
    {
        Color currentColor = Color.White;
        private int XTILES = 25; //Number of X tiles
        private int YTILES = 25; //Number of Y tiles
        private int TILESIZE = 10; //Size of the tiles (pixles)
        private PictureBox[,] mazeTiles;

        public Form1()
        {
            InitializeComponent();
            createNewMaze();
        }

        private void createNewMaze()
        {
            mazeTiles = new PictureBox[XTILES, YTILES];

            //Loop for getting all tiles
            for (int i = 0; i < XTILES; i++)
            {
                for (int j = 0; j < YTILES; j++)
                {
                    //initialize a new PictureBox array at cordinate XTILES, YTILES
                    mazeTiles[i, j] = new PictureBox();

                   
                    //calculate size and location
                    int xPosition = (i * TILESIZE) + 13; //13 is padding from left
                    int yPosition = (j * TILESIZE) + 45; //45 is padding from top
                    mazeTiles[i, j].SetBounds(xPosition, yPosition, TILESIZE, TILESIZE);

                    //make top left and right bottom corner light blue. Used for start and finish
                    if ((i == 0 && j == 0) || (i == XTILES - 1 && j == YTILES - 1))
                        mazeTiles[i, j].BackColor = Color.LightBlue;
                    else
                    {
                        //make all other tiles white
                        mazeTiles[i, j].BackColor = Color.Black;
                        //make it clickable
                   
 
                    }

                    //Add to controls to form (display picture box)
                    this.Controls.Add(mazeTiles[i, j]);
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //Create a previously searched array
            bool[,] alreadySearched = new bool[XTILES,YTILES];

            //Starts the recursive solver at tile (0,0). If false maze can not be solved.
            if(!solveMaze(0,0, alreadySearched))
                MessageBox.Show("Maze can not be solved.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Change all greay tiles to white
            for (int i = 0; i < XTILES; i++)
            {
                for (int j = 0; j < YTILES; j++)
                {
                    if (mazeTiles[i, j].BackColor == Color.Gray)
                        mazeTiles[i, j].BackColor = Color.White;
                }
            }

            //Reset start and finish to light blue
            mazeTiles[0, 0].BackColor = Color.LightBlue;
            mazeTiles[XTILES - 1, YTILES - 1].BackColor = Color.LightBlue;
        }

        private bool solveMaze(int xPos, int yPos, bool[,] alreadySearched)
        {
            bool correctPath = false;
            //should the computer check this tile
            bool shouldCheck = true;

            //Check for out of boundaries
            if (xPos >= XTILES || xPos < 0 || yPos >= YTILES || yPos < 0)
                shouldCheck = false;
            else
            {
                //Check if at finish, not (0,0 and colored light blue)
                if (mazeTiles[xPos, yPos].BackColor == Color.LightBlue && (xPos != 0 && yPos != 0))
                {
                    correctPath = true;
                    shouldCheck = false;
                }

                //Check for a wall
                if (mazeTiles[xPos, yPos].BackColor == Color.Black)
                    shouldCheck = false;

                //Check if previously searched
                if (alreadySearched[xPos, yPos])
                    shouldCheck = false;
            }

            //Search the Tile
            if (shouldCheck)
            {
                //mark tile as searched
                alreadySearched[xPos, yPos] = true;

                //Check right tile
                correctPath = correctPath || solveMaze(xPos + 1, yPos, alreadySearched);
                //Check down tile
                correctPath = correctPath || solveMaze(xPos, yPos + 1, alreadySearched);
                //check left tile
                correctPath = correctPath || solveMaze(xPos - 1, yPos, alreadySearched);
                //check up tile
                correctPath = correctPath || solveMaze(xPos, yPos - 1, alreadySearched);
            }

            //make correct path gray
            if (correctPath)
                mazeTiles[xPos, yPos].BackColor = Color.Gray;

            return correctPath;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rdm = new Random();
            {



                for (int i = 1; i <= 23; i++)
                {
        
                    mazeTiles[i, 1].BackColor = Color.White;
                    mazeTiles[0, 2].BackColor = Color.White;
                    mazeTiles[0, 1].BackColor = Color.White;
                    mazeTiles[1, 0].BackColor = Color.White;
                    mazeTiles[2, 0].BackColor = Color.White;
                    mazeTiles[1, i].BackColor = Color.White;                   
                    mazeTiles[i, 18].BackColor = Color.White;
                    mazeTiles[i, 23].BackColor = Color.White;
                    mazeTiles[6, i].BackColor = Color.White;
                    mazeTiles[7, 10].BackColor = Color.White;
                    mazeTiles[8, 10].BackColor = Color.White;
                    mazeTiles[9, 10].BackColor = Color.White;
                    mazeTiles[10, 10].BackColor = Color.White;
                    mazeTiles[11, 10].BackColor = Color.White;
                    mazeTiles[12, 10].BackColor = Color.White;
                    mazeTiles[13, 10].BackColor = Color.White;
                    mazeTiles[14, 10].BackColor = Color.White;
                    mazeTiles[15, 10].BackColor = Color.White;
                    mazeTiles[16, 10].BackColor = Color.White;
                    mazeTiles[17, 10].BackColor = Color.White;
                    mazeTiles[18, 10].BackColor = Color.White;
                    mazeTiles[19, 10].BackColor = Color.White;
                    mazeTiles[20, 10].BackColor = Color.White;
                    mazeTiles[20, 11].BackColor = Color.White;
                    mazeTiles[20, 12].BackColor = Color.White;
                    mazeTiles[20, 13].BackColor = Color.White;
                    mazeTiles[20, 14].BackColor = Color.White;
                    mazeTiles[13, 9].BackColor = Color.White;
                    mazeTiles[13, 8].BackColor = Color.White;
                    mazeTiles[13, 7].BackColor = Color.White;
                    mazeTiles[13, 6].BackColor = Color.White;
                    mazeTiles[13, 5].BackColor = Color.White;                   
                    mazeTiles[16, 21].BackColor = Color.White;
                    mazeTiles[15, 21].BackColor = Color.White;
                    mazeTiles[14, 21].BackColor = Color.White;
                    mazeTiles[13, 21].BackColor = Color.White;
                    mazeTiles[12, 21].BackColor = Color.White;
                    mazeTiles[11, 21].BackColor = Color.White;
                    mazeTiles[10, 21].BackColor = Color.White;
                    mazeTiles[17, i].BackColor = Color.White;                  
                    mazeTiles[18, 7].BackColor = Color.White;
                    mazeTiles[19, 7].BackColor = Color.White;
                    mazeTiles[20, 7].BackColor = Color.White;
                    mazeTiles[21, 7].BackColor = Color.White;
                    mazeTiles[22, 7].BackColor = Color.White;
                    mazeTiles[23, 7].BackColor = Color.White;
                    mazeTiles[23, 8].BackColor = Color.White;
                    mazeTiles[23, 9].BackColor = Color.White;
                    mazeTiles[23, 10].BackColor = Color.White;
                    mazeTiles[23, 11].BackColor = Color.White;
                    mazeTiles[23, 12].BackColor = Color.White;
                    mazeTiles[23, 13].BackColor = Color.White;
                    mazeTiles[23, 14].BackColor = Color.White;
                    mazeTiles[23, 15].BackColor = Color.White;
                    mazeTiles[23, 16].BackColor = Color.White;
                    mazeTiles[22, 16].BackColor = Color.White;
                    mazeTiles[21, 16].BackColor = Color.White;
                    mazeTiles[20, 16].BackColor = Color.White;
                    mazeTiles[19, 16].BackColor = Color.White;
                    mazeTiles[23, 2].BackColor = Color.White;
                    mazeTiles[23, 3].BackColor = Color.White;
                    mazeTiles[23, 4].BackColor = Color.White;
                    mazeTiles[23, 5].BackColor = Color.White;
                    mazeTiles[23, 6].BackColor = Color.White;
                    mazeTiles[24, 23].BackColor = Color.White;
                    mazeTiles[23, 24].BackColor = Color.White;                    
                    mazeTiles[3, 8].BackColor = Color.White;
                    mazeTiles[4, 8].BackColor = Color.White;
                    mazeTiles[5, 8].BackColor = Color.White;
                    mazeTiles[3, 7].BackColor = Color.White;
                    mazeTiles[3, 6].BackColor = Color.White;
                    mazeTiles[3, 5].BackColor = Color.White;
                    mazeTiles[3, 4].BackColor = Color.White;
                    mazeTiles[11, 10].BackColor = Color.White;
                    mazeTiles[11, 11].BackColor = Color.White;
                    mazeTiles[11, 12].BackColor = Color.White;
                    mazeTiles[11, 13].BackColor = Color.White;
                    mazeTiles[11, 14].BackColor = Color.White;
                    mazeTiles[11, 15].BackColor = Color.White;
                    mazeTiles[12, 15].BackColor = Color.White;
                    mazeTiles[13, 15].BackColor = Color.White;
                    mazeTiles[14, 15].BackColor = Color.White;
                    mazeTiles[15, 15].BackColor = Color.White;
                    mazeTiles[15, 14].BackColor = Color.White;
                    mazeTiles[15, 13].BackColor = Color.White;
                    mazeTiles[15, 12].BackColor = Color.White;                   
                    mazeTiles[6, 14].BackColor = Color.White;                    
                    mazeTiles[7, 14].BackColor = Color.White;
                    mazeTiles[8, 14].BackColor = Color.White;
                    mazeTiles[9, 14].BackColor = Color.White;
                    mazeTiles[9, 15].BackColor = Color.White;
                    mazeTiles[9, 16].BackColor = Color.White;
                    mazeTiles[9, 17].BackColor = Color.White;
                    mazeTiles[9, 18].BackColor = Color.White;
                    mazeTiles[4, 17].BackColor = Color.White;
                    mazeTiles[4, 16].BackColor = Color.White;
                    mazeTiles[4, 15].BackColor = Color.White;
                    mazeTiles[4, 14].BackColor = Color.White;
                    mazeTiles[4, 13].BackColor = Color.White;
                    mazeTiles[4, 12].BackColor = Color.White;
                    mazeTiles[4, 11].BackColor = Color.White;
                    mazeTiles[3, 11].BackColor = Color.White;
                    mazeTiles[13, 17].BackColor = Color.White;
                    mazeTiles[13, 16].BackColor = Color.White;
                    mazeTiles[16, 12].BackColor = Color.White;
                    mazeTiles[13, 19].BackColor = Color.White;
                    mazeTiles[14, 5].BackColor = Color.White;
                    mazeTiles[15, 5].BackColor = Color.White;
                    mazeTiles[10, 7].BackColor = Color.White;
                    mazeTiles[11, 7].BackColor = Color.White;
                    mazeTiles[20, 2].BackColor = Color.White;
                    mazeTiles[20, 3].BackColor = Color.White;
                    mazeTiles[20, 4].BackColor = Color.White;
                    mazeTiles[20, 5].BackColor = Color.White;
                    mazeTiles[21, 19].BackColor = Color.White;
                    mazeTiles[21, 20].BackColor = Color.White;
                    mazeTiles[21, 20].BackColor = Color.White;
                    mazeTiles[2, 16].BackColor = Color.White;
                    mazeTiles[3, 16].BackColor = Color.White; 
                  
                    mazeTiles[14, 18].BackColor = Color.Black;
                    mazeTiles[11, 13].BackColor = Color.Black;
                    mazeTiles[11, 14].BackColor = Color.Black;
                    mazeTiles[2, 18].BackColor = Color.Black;
                    mazeTiles[3, 18].BackColor = Color.Black;
                    mazeTiles[9, 17].BackColor = Color.Black;
                    mazeTiles[15, 18].BackColor = Color.Black;
                    mazeTiles[16, 18].BackColor = Color.Black;
                    mazeTiles[5, 23].BackColor = Color.Black;
                    mazeTiles[6, 17].BackColor = Color.Black;
                    mazeTiles[6, 16].BackColor = Color.Black;
                    mazeTiles[6, 15].BackColor = Color.Black;
                    mazeTiles[17, 8].BackColor = Color.Black;
                    mazeTiles[17, 9].BackColor = Color.Black;
                    mazeTiles[16, 23].BackColor = Color.Black;
                    mazeTiles[14, 10].BackColor = Color.Black;
                    mazeTiles[15, 10].BackColor = Color.Black;
                    mazeTiles[16, 10].BackColor = Color.Black;
                }

                for (int k = 1; k <= 7; k++)
                {
                    mazeTiles[9, k].BackColor = Color.White;
                    
                }
               
                
                
                

            }





        }
    }
}
