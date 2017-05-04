using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalsAgent
{
    class Program
    {
        public static int pellet;
        public static int bigPellet;
        public static int fruit;
        public static int ghost;
        public static int blueGhost;
        public static int pelletVal;
        public static int bigPelletVal;
        public static int fruitVal;
        public static int blueGhostVal;
        public static int blueTimeMax;
        public static int blueTimeCur;
        private static int[] oldValues;
        private static int[] curValues;
        private static bool alive;
        public static int pelletsLeft;
        public static int bigPelletsLeft;
        public static int fruitLeft;
        private static int currentLvl;
        private static int totalGamesPlayed;
        
        static void Main(string[] args)
        {
            initialize();
            string userinput = null;
            int temp = 0;
            alive = true;
            int totalPoints = 0;
            int averagePoints = 0;
            int totalGamesPlayed = 0;
            currentLvl = 1;
            Random rand = new Random();
            while (userinput != "e")
            {
                bool noChange = true;
                while(totalGamesPlayed < 1000)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        while (alive)
                        {
                            if (bigPelletsLeft + pelletsLeft == 0)
                            {
                                if (currentLvl < 5)
                                {
                                    pelletsLeft = 240;
                                    bigPelletsLeft = 4;
                                    fruitLeft = 2;
                                    currentLvl++;
                                }
                                else
                                {
                                    alive = false;

                                    /*Console.WriteLine("These weights lead to a victory!!!!");
                                    Console.WriteLine("Current pellet weight: " + pellet);
                                    Console.WriteLine("Current big pellet weight: " + bigPellet);
                                    Console.WriteLine("Current fruit weight: " + fruit);
                                    Console.WriteLine("Current ghost weight: " + ghost);
                                    Console.WriteLine("Current blue ghost weight: " + blueGhost);
                                    Console.WriteLine("Current best Average Score: " + temp);
                                    Console.WriteLine("Total Games Played: " + (totalGamesPlayed + k + 1));
                                    Console.WriteLine();*/

                                }
                            }
                            
                            int choice = 0;

                            string[] pc = new string[4];
                            pc[0] = "";
                            pc[1] = "";
                            pc[2] = "";
                            pc[3] = "";
                            int paths = rand.Next(2, 5);
                            int[] pathGenInfo = new int[3];
                            pathGenInfo[0] = pelletsLeft;
                            pathGenInfo[1] = bigPelletsLeft;
                            pathGenInfo[2] = fruitLeft;
                            bool noFruit = true;
                            bool noBigPellet = true;
                            for (int i = 0; i < 10; i++)
                            {
                                for (int j = 0; j < paths; j++)
                                {
                                    bool notPossible = true;
                                    string item = "";
                                    while (notPossible)
                                    {
                                        int randRemainingItem = rand.Next(0, 250);
                                        item = randThing(randRemainingItem);
                                        if ((pc[j].Contains("F") && item.Contains("*")) || (pc[j].Contains("*") && item.Contains("F")))
                                        {
                                            notPossible = true;
                                        }
                                        else if (item.Contains("*") && noBigPellet)
                                        {
                                            notPossible = false;
                                            noBigPellet = false;
                                        }
                                        else if (item.Contains("F") && noFruit)
                                        {
                                            notPossible = false;
                                            noFruit = false;
                                        }
                                        else
                                        {
                                            notPossible = false;
                                        }
                                    }
                                    pc[j] = pc[j] + item;
                                }
                            }
                            pelletsLeft = pathGenInfo[0];
                            bigPelletsLeft = pathGenInfo[1];
                            fruitLeft = pathGenInfo[2];
                            for (int i = 0; i < paths; i++)
                            {
                                if (pc[i].Contains("F"))
                                {
                                    fruitLeft--;
                                }
                            }
                                for (int i = 1; i < paths; i++)
                                {
                                    if (sumPoints(pc[i]) > sumPoints(pc[choice]))
                                    {
                                        choice = i;
                                    }
                                }

                            totalPoints += sumActualPoints(pc[choice]);
                            
                            if (blueTimeCur > 0)
                            {
                                blueTimeCur--;
                            }

                        }
                        alive = true;
                        blueTimeCur = 0;
                        pelletsLeft = 240;
                        bigPelletsLeft = 4;
                        fruitLeft = 2;
                        currentLvl = 1;
                    }
                    averagePoints = totalPoints / 5;
                    totalPoints = 0;
                    totalGamesPlayed+= 5;

                    if (temp > averagePoints)
                    {
                        averagePoints = temp;
                        pellet = oldValues[0];
                        bigPellet = oldValues[1];
                        fruit = oldValues[2];
                        ghost = oldValues[3];
                        blueGhost = oldValues[4];
                        curValues = oldValues;
                    }
                    else
                    {
                        temp = averagePoints;
                        noChange = false;
                    }

                    averagePoints = 0;

                    oldValues = fillValues();
                    morphValues(rand);
                    curValues = fillValues();

                    if (totalGamesPlayed % 100 == 0)
                    {
                        Console.WriteLine("Current pellet weight: " + oldValues[0]);
                        Console.WriteLine("Current big pellet weight: " + oldValues[1]);
                        Console.WriteLine("Current fruit weight: " + oldValues[2]);
                        Console.WriteLine("Current ghost weight: " + oldValues[3]);
                        Console.WriteLine("Current blue ghost weight: " + oldValues[4]);
                        Console.WriteLine("Current best Average Score: " + temp);
                        Console.WriteLine("Total Games Played: " + totalGamesPlayed);
                        Console.WriteLine();
                    }

                }
                noChange = true;
                Console.WriteLine("Current pellet weight: " + oldValues[0]);
                Console.WriteLine("Current big pellet weight: " + oldValues[1]);
                Console.WriteLine("Current fruit weight: " + oldValues[2]);
                Console.WriteLine("Current ghost weight: " + oldValues[3]);
                Console.WriteLine("Current blue ghost weight: " + oldValues[4]);
                Console.WriteLine("Current best Average Score: " + temp);
                Console.WriteLine("Total Games Played: " + totalGamesPlayed);

                Console.WriteLine("Enter 'e' to end program: ");
                userinput = Console.ReadLine();
                totalGamesPlayed = 0;
            }
        }

        public static void morphValues(Random rand){
            Random randomChange = rand;
            int modMath = (((1000 - totalGamesPlayed) / 10) + 1);
            int totalChanges = 1;
            for (int i = 0; i < totalChanges; i++)
            {
                int randChange = randomChange.Next(1, 6);
                int randPosNeg = randomChange.Next(0, 2);
                int modifier = randomChange.Next(1, modMath);
                if (randChange == 1)
                {
                    if (randPosNeg == 1)
                    {
                        pellet -= modifier;
                    }
                    else
                    {
                        pellet += modifier;
                    }
                }
                else if (randChange == 2)
                {
                    if (randPosNeg == 1)
                    {
                        bigPellet -= modifier;
                    }
                    else
                    {
                        bigPellet += modifier;
                    }
                }
                else if (randChange == 3)
                {
                    if (randPosNeg == 1)
                    {
                        fruit -= modifier;
                    }
                    else
                    {
                        fruit += modifier;
                    }
                }
                else if (randChange == 4)
                {
                    if (randPosNeg == 1)
                    {
                        ghost -= modifier;
                    }
                    else
                    {
                        ghost += modifier;
                    }
                }
                else
                {
                    if (randPosNeg == 1)
                    {
                        blueGhost -= modifier;
                    }
                    else
                    {
                        blueGhost += modifier;
                    }
                }
            }
        }

        private static int sumPoints(string p)
        {
            int points = 0;
            bool justTurnedBlue = false;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] == '.')
                {
                    points += pellet;
                }
                else if (p[i] == '*')
                {
                    points += bigPellet;
                    justTurnedBlue = true;
                }
                else if (p[i] == 'F')
                {
                    points += fruit;
                }
                else
                {
                    if (blueTimeCur > 0 || justTurnedBlue)
                    {
                        points += blueGhost;
                    }
                    else
                    {
                        points += ghost;
                        return points;
                    }
                }
            }
            return points;
        }

        private static int sumActualPoints(string p)
        {
            int points = 0;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] == '.')
                {
                    points += pelletVal;
                    pelletsLeft--;
                }
                else if (p[i] == '*')
                {
                    points += bigPelletVal;
                    blueTimeCur = blueTimeMax - (currentLvl-1);
                    bigPelletsLeft--;
                }
                else if (p[i] == 'F')
                {
                    points += fruitVal;
                }
                else
                {
                    if (blueTimeCur > 0)
                    {
                        points += blueGhostVal;
                    }
                    else
                    {
                        alive = false;
                        return points;
                    }
                }
            }
            return points;
        }

        private static string randThing(int randItem)
        {
            if (randItem < pelletsLeft)
            {
                pelletsLeft--;
                return ".";
            }
            else if (randItem < pelletsLeft + bigPelletsLeft)
            {
                bigPelletsLeft--;
                return "*";
            }
            else if (randItem < pelletsLeft + bigPelletsLeft + fruitLeft)
            {
                fruitLeft--;
                return "F";
            }
            else if (randItem < pelletsLeft + bigPelletsLeft + fruitLeft + 4)
            {
                return "G";
            }
            else
            {
                return "";
            }
        }

        private static void initialize()
        {
            pellet = 0;
            bigPellet = 0;
            fruit = 0;
            ghost = 0;
            blueGhost = 0;
            pelletVal = 10;
            bigPelletVal = 50;
            fruitVal = 500;
            blueGhostVal = 200;
            blueTimeMax = 5;
            blueTimeCur = 0;
            curValues = new int[5];
            curValues = fillValues();
            oldValues = curValues;
            pelletsLeft = 240;
            bigPelletsLeft = 4;
            fruitLeft = 2;
        }

        private static int[] fillValues()
        {
            int[] array = new int[5];
            array[0] = pellet;
            array[1] = bigPellet;
            array[2] = fruit;
            array[3] = ghost;
            array[4] = blueGhost;
            return array;
        }
    }
}
