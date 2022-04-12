using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    public static class Input
    {

        public static int[] ReadInputs(string input)
        {
            var positionInt = new int[2];
            string[] positionString = input.Split(',');
            positionInt[0] = Convert.ToInt32(positionString[0]);
            positionInt[1]= Convert.ToInt32(positionString[1]);

            return positionInt;
        }
        
       
        
        /*string[] currentPositionString = Console.ReadLine().Split(',');
        int[] currentPositionInt = { Convert.ToInt32(currentPositionString[0]), Convert.ToInt32(currentPositionString[1]) };

        
        string[] targetPositionString = Console.ReadLine().Split(',');
        int[] targetPositionInt = { Convert.ToInt32(targetPositionString[0]), Convert.ToInt32(targetPositionString[1]) };*/
    }
}
