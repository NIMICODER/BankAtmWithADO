using System;
using System.Text;
using System.Threading;

namespace Atm.BLL
{
    public class Utility
    {
        public static void DisplayDotAnimation(int timer = 10)
        {
            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
                //tempUserAccount.CardNumber = i;
            }
            Console.Clear();
        }

        public static string GetSecetInput(string prompt)
        {
            bool isPrompt = true;
            string asterics = "";

            StringBuilder input = new StringBuilder();
            while (true)
            {
                if (isPrompt)
                    Console.WriteLine(prompt);
                isPrompt = false;
                ConsoleKeyInfo inputKey = Console.ReadKey(true);
                if (inputKey.Key == ConsoleKey.Enter)
                {
                    if (input.Length == 4)
                    {
                        break;
                    }
                    else
                    {
                        Displaymsg("\nPlease enter 4 digits", false);
                        input.Clear();
                        isPrompt = true;
                        continue;

                    }
                }

                if (inputKey.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                }
                else if (inputKey.Key != ConsoleKey.Backspace)
                {
                    input.Append(inputKey.KeyChar);
                    Console.Write($"{asterics}*");
                }
            }
            return input.ToString();

        }

        public static void Displaymsg(string msg, bool success)
        {
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            //PressEnterToContinue();
        }

    }

}
