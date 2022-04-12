using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Checkers
{
    public static class Input
    {

        public static int[] ReadInputs()
        {
            Regex regex = new Regex(@"^[1-9][A-Z]$|^[A-Z][1-9]$|^\d{2}[A-Z]$|^[A-Z]\d{2}$", RegexOptions.IgnoreCase);
            int x, y;

            string position = Console.ReadLine();
            while (!regex.IsMatch(position.ToUpper()))
            {
                Console.Write("\nInvalid input!\nPlease input your initial position: ");
                position = Console.ReadLine();
            }

            if ((int)position.ToUpper()[0] >= 65)
            {
                x = (int)position.ToUpper()[0] - 65;
                y = int.Parse(position.Substring(1)) - 1;
                Console.WriteLine(x + "," + y);
            }
            else
            {
                x = (int)position.ToUpper()[position.Length - 1] - 65;
                y = int.Parse(position.Substring(0, position.Length - 1)) - 1;
                Console.WriteLine(x + "," + y);
            }

            return new int[2] { x, y };
        }
        
       
        
        /*string[] currentPositionString = Console.ReadLine().Split(',');
        int[] currentPositionInt = { Convert.ToInt32(currentPositionString[0]), Convert.ToInt32(currentPositionString[1]) };

        
        string[] targetPositionString = Console.ReadLine().Split(',');
        int[] targetPositionInt = { Convert.ToInt32(targetPositionString[0]), Convert.ToInt32(targetPositionString[1]) };*/
    }
}
