// See https://aka.ms/new-console-template for more information
using System;

namespace RockScissorsPaper {
    class Game
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>(args);

            if ((args.Length < 3) || ((args.Length % 2) == 0) || args.Length != set.Count)
            {
                Console.WriteLine("You entered wrong data, you need minimum 3 stings to play the game.\nThe number of stings should be odd and the stings shouldn`t repeat!\nFor example: \"Rock\", \"Scissors\", \"Paper\" or \"1\", \"2\", \"3\".");
            }
            else
            {
                Roules roules = new Roules(args);

                GeneratorRandomKey grk = new GeneratorRandomKey();
                byte[] b = grk.GetKey(); 
                
                int moveComputer = new Random().Next(0, args.Length - 1);

                String moveComp = args[moveComputer];

                GeneratorHMAC hmac = new GeneratorHMAC(b);
                String hmacComp = hmac.GetHMAC(moveComp);

                Menu menu = new Menu(args, hmacComp);
                menu.PrintMainMenu();

                String[] mcount = new string[args.Length];
                for (int i = 0; i < args.Length; i++)
                {
                    mcount[i] = (i + 1).ToString();
                }

                Boolean work = true;
                while (work) 
                {
                    String usersChoise = Console.ReadLine();
                    String hmacKey = String.Empty;
                    b.ToList().ForEach(b => hmacKey += b.ToString("X2"));

                    if (mcount.Contains(usersChoise))
                    {
                        String userMove = args[Int32.Parse(usersChoise) - 1];

                        work = false;

                        if (userMove.Equals(roules.WhoWins(userMove, moveComp)))
                        {
                            Console.WriteLine("You win!");
                        }
                        else if (moveComp.Equals(roules.WhoWins(userMove, moveComp)))
                        {
                            Console.WriteLine("Computer win!");
                        }
                        else
                        {
                            Console.WriteLine("Draw!");
                        }
                        Console.WriteLine("HMAC key: " + hmacKey);
                    }
                    else if (usersChoise.Equals("?"))
                    {
                        work = false;

                        menu.PrintHelpMenu();                      
                    }
                    else if (usersChoise.Equals("0"))
                    {
                        work = false;

                        System.Environment.Exit(0);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You entered wrong data. Please, make right decision:");
                        menu.PrintMainMenu();
                    }
                }            
                
            }
        }
    }
}