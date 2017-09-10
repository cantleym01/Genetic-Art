using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genetic_Art
{
    public partial class genArtForm : Form
    {
        //variables to use everywhere
        private Bitmap originalArt;
        List<Color[,]> population = new List<Color[,]>();
        private Color[,] avgColors = new Color[32, 32]; //going to do 16x16 pixel boxes, so the total is 32x32 average colors
        private Random rng = new Random();

        public genArtForm()
        {
            InitializeComponent();
        }

        /*
        Genetic Algorithm Functions
        */

        //fitness function for genetic algorithm. The closer to 0, the better.
        private double FitnessFunction(Color[,] source, Color[,] test)
        {
            double fitness = 0;

            for(int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    double red = Math.Abs(source[x, y].R - test[x, y].R);
                    double green = Math.Abs(source[x, y].G - test[x, y].G);
                    double blue = Math.Abs(source[x, y].B - test[x, y].B);

                    fitness += red + blue + green;
                }
            }
            return fitness;
        }

        private Color[,] MutatePop(Color[,] pop)
        {
            double chance = .02; //% chance that a color will mutate

            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    double mutateQuery = rng.NextDouble() * 100.0; //0.0 - 100.0

                    //mutate only if the random double is within the chance allowed
                    if (mutateQuery <= chance)
                    {
                        pop[x, y] = Color.FromArgb(rng.Next(256), rng.Next(256), rng.Next(256)); //random color
                    }
                }
            }

            return pop;
        }

        private void OrganizeBestFits()
        {
            //get the fitness of all populations
            double pop1Fit = FitnessFunction(avgColors, population[0]);
            double pop2Fit = FitnessFunction(avgColors, population[1]);
            double pop3Fit = FitnessFunction(avgColors, population[2]);

            //organize from best to worst
            if (pop1Fit < pop2Fit)
            {
                if (pop2Fit < pop3Fit) //1, 2, 3
                {
                    //no change in order
                }
                else
                {
                    if (pop1Fit < pop3Fit) //1, 3, 2
                    {
                        Color[,] temp = population[1];
                        population[1] = population[2];
                        population[2] = temp;
                    }
                    else // 3, 1, 2
                    {
                        Color[,] temp = population[0];
                        population[0] = population[2];
                        population[2] = population[1];
                        population[1] = temp;
                    }
                }
            }
            else
            {
                if (pop1Fit < pop3Fit) //2, 1, 3
                {
                    Color[,] temp = population[0];
                    population[0] = population[1];
                    population[1] = temp;
                }
                else
                {
                    if (pop2Fit < pop3Fit) //2, 3, 1
                    {
                        Color[,] temp = population[0];
                        population[0] = population[1];
                        population[1] = population[2];
                        population[2] = temp;
                    }
                    else //3, 2, 1
                    {
                        Color[,] temp = population[0];
                        population[0] = population[2];
                        population[2] = temp;
                    }
                }
            }
        }

        //this is hardcoded for 3 populations for now
        private void CrossoverEntirePop()
        {
            /*
            Crossover works by the fittest individual always making it to the next generation (Elitism).
            The second fittest has a uniform crossover with the fittest individual.
            The third fittest is replaced by a modified uniform crossover between all three individuals.
            */

            //organize best fits in descending order in the population list
            OrganizeBestFits();

            //Use chances for uniform crossover
            double chanceForSecond = .5;
            double chanceForThirdFirst = .35;
            double chanceForThirdSecond = .65;

            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    //r -> g -> b
                    for (int z = 0; z < 3; z++)
                    {
                        double crossoverQuery = rng.NextDouble(); //0.0 - 1.0

                        //second fittest gains qualities of the fittest
                        if (crossoverQuery < chanceForSecond)
                        {
                            switch(z)
                            {
                                case 0: //exchange Red hue
                                    population[1][x, y] = Color.FromArgb(population[0][x, y].R, population[1][x, y].G, population[1][x, y].B);
                                    break;
                                case 1: //exchange Green hue
                                    population[1][x, y] = Color.FromArgb(population[1][x, y].R, population[0][x, y].G, population[1][x, y].B);
                                    break;
                                case 2: //exchange Blue hue
                                    population[1][x, y] = Color.FromArgb(population[1][x, y].R, population[1][x, y].G, population[0][x, y].B);
                                    break;
                            }
                        }

                        //third fittest gains qualities of the fittest
                        if (crossoverQuery < chanceForThirdFirst)
                        {
                            switch (z)
                            {
                                case 0: //exchange Red hue
                                    population[2][x, y] = Color.FromArgb(population[0][x, y].R, population[2][x, y].G, population[2][x, y].B);
                                    break;
                                case 1: //exchange Green hue
                                    population[2][x, y] = Color.FromArgb(population[2][x, y].R, population[0][x, y].G, population[2][x, y].B);
                                    break;
                                case 2: //exchange Blue hue
                                    population[2][x, y] = Color.FromArgb(population[2][x, y].R, population[2][x, y].G, population[0][x, y].B);
                                    break;
                            }
                        }

                        //third fittest gains qualities of the second fittest
                        if (crossoverQuery > chanceForThirdSecond)
                        {
                            switch (z)
                            {
                                case 0: //exchange Red hue
                                    population[2][x, y] = Color.FromArgb(population[1][x, y].R, population[2][x, y].G, population[2][x, y].B);
                                    break;
                                case 1: //exchange Green hue
                                    population[2][x, y] = Color.FromArgb(population[2][x, y].R, population[1][x, y].G, population[2][x, y].B);
                                    break;
                                case 2: //exchange Blue hue
                                    population[2][x, y] = Color.FromArgb(population[2][x, y].R, population[2][x, y].G, population[1][x, y].B);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        //meant to be ran in a thread outside main program. Will do wierd stuff if more than 1 at once.
        private void GenerateArt(object sender, DoWorkEventArgs e)
        {
            try
            {
                int currentGen = 0;

                //continue to refine the art with the genetic algorithm
                while (true)
                {
                    //inform user of the current generation
                    this.SetGeneration(currentGen.ToString());

                    //get the best fit out of the population and then draw it.
                    OrganizeBestFits();

                    //get graphics reference and set the drawing pen color
                    Graphics graph = genArtPanel.CreateGraphics();

                    //draw the best fit
                    for (int x = 0; x < 32; x++)
                    {
                        for (int y = 0; y < 32; y++)
                        {
                            //set brush color (population[0] is the best fit due to the OrganizeBestFits() function)
                            SolidBrush brush = new SolidBrush(population[0][x, y]);

                            //fill in the current grid piece.
                            graph.FillRectangle(brush, x * 16, y * 16, x * 16 + 15, y * 16 + 15);
                        }
                    }

                    //crossover the population
                    CrossoverEntirePop();

                    //mutate all populations
                    for (int i = 0; i < population.Count; i++)
                    {
                        population[i] = MutatePop(population[i]);
                    }

                    currentGen++;
                }
            }
            catch {}
        }

        /*
        Helper Functions
        */

        //return the color of the pixel at the x, y coords on the Bitmap that's passed in.
        private Color GetPixelColor(Bitmap container, int xCoord, int yCoord)
        {
            //reduce by 1 if at end for offset
            if (xCoord == 512)
            {
                xCoord--;
            }
            if (yCoord == 512)
            {
                yCoord--;
            }

            return container.GetPixel(xCoord, yCoord);
        }

        //return the average color of a cluster of pixels x2Coord*y2Coord size at location xCoord,yCoord on the Bitmap container
        private Color GetAvgColor(Bitmap container, int xCoord, int yCoord, int x2Coord, int y2Coord)
        {
            int r = 0;
            int g = 0;
            int b = 0;
            int count = 0;

            //average everything
            for (int x = xCoord; x < x2Coord; x++)
            {
                for (int y = yCoord; y < y2Coord; y++)
                {
                    //get total of all colors, we'll average them out at the end
                    Color temp = GetPixelColor(container, x, y);
                    r += temp.R;
                    g += temp.G;
                    b += temp.B;
                    count++;
                }
            }

            //average colors and alphas
            int avgRed = r / (Math.Abs(x2Coord - xCoord) * Math.Abs(x2Coord - xCoord));
            int avgGreen = g / (Math.Abs(x2Coord - xCoord) * Math.Abs(x2Coord - xCoord));
            int avgBlue = b / (Math.Abs(x2Coord - xCoord) * Math.Abs(x2Coord - xCoord));

            return Color.FromArgb(avgRed, avgGreen, avgBlue);
        }
      
        //set the text of the generation from inside GenerateArt thread
        private void SetGeneration(string gen)
        {
            if (this.genNumLabel.InvokeRequired)
            {
                SetTextCallback dele = new SetTextCallback(SetGeneration);
                this.Invoke(dele, new object[] { gen });
            }
            else
            {
                this.genNumLabel.Text = gen;
            }
        }

        //help set text from GenerateArt thread
        delegate void SetTextCallback(string text);

        /*
        Form Click Functions
        */

        //Load an image when load button is clicked.
        private void PicLoadClick(object sender, EventArgs e)
        {
            //Try to load the image in the picLoadTextBox. Error handle if things get crazy
            try
            {
                //Images not 512x512 will be cut-off. Do image resizing later (Perhaps only scale vertically and then black box the sides to fill)
                Image originalImage = Image.FromFile(picLoadTextBox.Text.ToString());
                pictureBox1.Image = originalImage;

                //obtain bitmap of the image that is going to be generated. This will never change.
                originalArt = new Bitmap(pictureBox1.Image);

                /*
                Generage 2D array of average colors. This will be very useful for testing fitness function speed if we do it early
                */

                //need these two variables to reference avgColors array
                int recordX = 0;
                int recordY = 0;
                for (int x = 0; x < 512; x += 16)
                {
                    for (int y = 0; y < 512; y += 16)
                    {
                        avgColors[recordX, recordY] = GetAvgColor(originalArt, x, y, x + 16, y + 16); //16x16 pixel block color
                        recordY++;
                    }
                    recordX++;
                    recordY = 0;
                }
            }
            catch (System.OutOfMemoryException)
            {
                MessageBox.Show("Error: File does not have a supported format. BMP, GIF, JPEG, PNG, and TIFF are supported.");
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Error: File not found.");
            }
            catch (System.Exception)
            {
                MessageBox.Show("Error: Failed to load image.");
            }
        }

        private void GenArtClick(object sender, EventArgs e)
        {
            //hardcode a population of 2. Expand later.
            population.Add(new Color[32, 32]);
            population.Add(new Color[32, 32]);
            population.Add(new Color[32, 32]);

            //want random starting populations, so start with that.
            for (int pop = 0; pop < 3; pop++)
            {
                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        //for population pop, insert a random number from 0 to 255 at location x, y
                        population[pop][x, y] = Color.FromArgb(rng.Next(256), rng.Next(256), rng.Next(256));
                    }
                }
            }

            /*
            create grid on original image for viewer aid
            */
            //get graphics reference and set the drawing pen color
            Graphics graph = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(alpha: 50, baseColor: Color.Black)); //will be transparent-ish grid

            //Draw Y grid
            for (int x = 0; x < 512; x += 16)
            {
                graph.DrawLine(pen, new Point(x, 0), new Point(x, 512));
            }
            graph.DrawLine(pen, new Point(511, 0), new Point(511, 511)); //last line with 1 pixel offset so visible

            //Draw X grid
            for (int y = 0; y < 512; y += 16)
            {
                graph.DrawLine(pen, new Point(0, y), new Point(512, y));
            }
            graph.DrawLine(pen, new Point(0, 511), new Point(511, 511)); //last line with 1 pixel offset so visible

            //Run the genetic art in a new thread so it doesn't freeze up.
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(GenerateArt);
            worker.RunWorkerAsync();
        }
    }
}
