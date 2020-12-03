using System;
using System.Collections.Generic;

namespace Assignment1_ElJbari
{
    class Program
    {
        static void Main(string[] args)
        {
           
            // Test Question 1
            int n2 = 8;
            PrintSeries(n2);
            
            // Test Question 2
            string s = "09:15:35PM";
            string t = UsfTime(s);
            Console.WriteLine(t);
            
            // Test Question 3
            int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);
            
            // Test Question 4
            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            PalindromePairs(words);
            
            // Test Question 5
            Stones(20);// Should ouput False
            Stones(5);// Should output moves to win
            
        }


        private static void PrintPattern(int n)
        {
            try
            {

                // removeCount variable will indicate how many numbers to remove from pattern depending on iteration
                //Since we want to start with the entire pattern, it is initiated at 0 meaning nothing is to be 
                //deleted during the first iteration
                int removeCount = 0;

                //set up a count variable to stop the for loop before the output produces 0
                for (int nCount = n; nCount > 0; nCount--)
                {
                    string pattern;//declare a string variable 
                    int nextNumber = n - 1;

                    //For loop to generate all numbers below n larger than 0 and assign it to the variable pattern
                    for (pattern = ""; nextNumber != 0; nextNumber--)
                    {
                        pattern += nextNumber;//Increment variable pattern with the next number using nextNumber variable  
                    }
                    //Final output variable should display n followed by the pattern not including 0.
                    string output = n + pattern;

                    //Use remove method to remove whatever is in the index 0 each iteration
                    Console.WriteLine(output.Remove(0, removeCount));

                    //Increment the mainLoopCount variable to determine the number
                    removeCount++;
                }

            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printPattern");
            }
        }


        private static void PrintSeries(int n2)
        {
            try
            {
                string fullSeries = "";//Declare string variable to hold the series
                int firstValue = 1;//Declare and initiate firstValue as 1
                int addNumber = 0;

                for (int seriesCount = 0; seriesCount < n2; seriesCount++)
                //declare variable to stop outputting series once n2 is reached
                {
                    addNumber += seriesCount;
                    //Code to mathematically represent the series
                    int nextValue = firstValue + addNumber;

                    if (seriesCount == n2 - 1)
                    {
                        fullSeries += nextValue;//Don't add comma to the end if the final number has been reached
                    }
                    else
                    {
                        fullSeries += nextValue + ",";//Seperate values with a comma and increment series with nextValue
                    }


                    addNumber++;
                }

                Console.WriteLine(fullSeries);
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }
        }


        public static string UsfTime(string s)
        {
            try
            {
                //Write your code here .!!
                //Convert the time to integers
                // Convert each integer to usfTime equivalent using formulas
                // Concatenate the three into a string and return it

                string hourString = s.Substring(0, 2);//assign the hour portion of string to hourString
                string minutesString = s.Substring(3, 2);//assign the minute portion of string to minuteString
                string secondsString = s.Substring(6, 2);//assign the second portion of string to secondsString

                int hours;// declare variable to hold integer hours

                if (s.Contains("PM"))
                {
                    hours = int.Parse(hourString) + 12;//Convert string to int in 24H format to differentiate PM from AM
                }
                else
                {
                    hours = int.Parse(hourString);
                }

                int minutes = int.Parse(minutesString);//turn the string to int
                int seconds = int.Parse(secondsString);// turn the string to int
                int totalSeconds = (hours * 3600) + (minutes * 60) + seconds;//convert the time to seconds

                //Declare and initiate hour, minute and second for USF Time
                int hourU = 0;
                int minS = 0;
                int secT = 0;


                for (int i = 1; i <= totalSeconds; i++)//loop until we have allocated each second
                {
                    if (i % 45 == 0)
                    {
                        minS += 1;// add a minute every time we get 45 seconds
                        secT = 0;// reset the seconds for a new minute
                    }
                    else
                    {
                        secT++;// if the number of seconds is not divisible by 45 then add one second
                    }
                    if (minS == 60)
                    {
                        hourU += 1;// increment hours by 1 every time we hit 60 minnutes
                        minS = 0;//reset minutes to 0 after every hour
                    }

                }

                string USFTime = hourU + ":" + minS + ":" + secT;// combine USF hours, minutes and Seconds into a string

                return USFTime;//return the USF Time string
            }

            catch
            {
                Console.WriteLine("Exception Occured while computing UsfTime");
            }
            return null;
        }


        public static void UsfNumbers(int n3, int k)
        {
            try
            {
                // Write your code here
                string x;//Declare string that will hold the string output depending on condition


                for (int i = 1; i <= n3; i++)// loop through n3 times
                {


                    if (i % 3 == 0 && i % 5 == 0)// if divisible by 3 AND 5 string should output US
                    {
                        x = "US";
                    }
                    else if (i % 5 == 0 && i % 7 == 0)// if divisible by 7 AND 5 string should output SF
                    {
                        x = "SF";
                    }
                    else if (i % 3 == 0 && i % 7 == 0)// if divisible by 3 AND  string should output UF
                    {
                        x = "UF";
                    }

                    else if (i % 3 == 0)//if divisible by 3 but not also by 5 or 7, output U
                    {
                        x = "U";
                    }
                    else if (i % 5 == 0)//if divisible by 5 but not also by 3 or 7, output S
                    {
                        x = "S";
                    }
                    else if (i % 7 == 0)//if divisible by 7 but not also by 5 or 3, output F
                    {
                        x = "F";
                    }

                    else
                    {
                        x = i.ToString();// if no conditions apply, output i
                    }


                    if (i % k == 0)
                    {
                        Console.Write(x + " \n");// New Line every time we have k characters ina line
                    }
                    else
                    {
                        Console.Write(x + " ");// add item to same line if we haven't reached 11 yet
                    }


                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }
        }



        public static void PalindromePairs(string[] words)
        {
            try
            {

                var wordsList = new List<string>();//Declare list to hold the combinations of strings

                //Declare a list of lists that will hold the indices of the two original strings that combined to make each comobination
                List<List<int>> indexList = new List<List<int>>();

                for (int i = 0; i < words.Length; i++)
                {

                    for (int j = 0; j < words.Length; j++)
                    {
                        if (i != j)// conditional statement to avoid combining a word with itself
                        {
                            string combo1 = words[i] + words[j];// combine words

                            if (wordsList.Contains(combo1) == false)// conditional statement to avoid duplicates
                            {
                                wordsList.Add(combo1);//add the combination to list
                                //add the indices of the words that combined to make the word to a list of lists
                                indexList.Add(new List<int> { i, j });
                            }

                            string combo2 = words[j] + words[i];//combine words in inverse order



                            if (wordsList.Contains(combo2) == false)// conditional statement to avoid duplicates
                            {
                                wordsList.Add(combo2);//add the combination to list
                                //add the indices of the words that combined to make the word to a list of lists
                                indexList.Add(new List<int> { j, i });
                            }
                        }
                    }
                }

                string[] wordCombinations = wordsList.ToArray();// Convert list to an array

                int indexOfI = 0;//declare and initiate a variable that will represent the index of the word in the combination list

                foreach (string i in wordCombinations)//loop through each combination in the array
                {

                    char[] iArray = i.ToCharArray();// convert each word to a character array
                    Array.Reverse(iArray);// switch the order of the letters
                    string reverseI = new string(iArray);//convert the inverse back to a string


                    if (i == reverseI)// if palindrome, then the reverse of the word should match the original
                    {
                        //Output the index of the words that are palindromes from lists of lists

                        Console.WriteLine("[" + indexList[indexOfI][0] + "," + indexList[indexOfI][1] + "]");

                    }

                    indexOfI++;///increment the index for the next iteration
                }


            }
            catch
            {

                Console.WriteLine("Exception occured while computing PalindromePairs()");
            }
        }

        public static void Stones(int n4)
        {
            try
            {
                
                List<int> moves = new List<int>();

                for (int turn = 1; n4 > 0; turn++)// loop through each turn, pick a set number of stones, stop loop when no more stones left
                {                   
                        // Since we are assuming both players want to win, the strategy for both has to be the same
                        int x = n4 - 3;//  

                    //if n4 is divisible by 4, player whose turn it is will lose, and therefore will not matter what they pick
                    // if x is divisible by 4, then we want to pick 3 to win
                    //if n4 equals 3, the player will pick 3 to win the game
                    if (n4 % 4 == 0 || x % 4 == 0|| n4==3)
                        {
                            moves.Add(3);
                            n4 -= 3;

                        }
                    // if n4 is even, but not divisible by 4, picking 2 will ensure the player wins
                    else if (n4 % 2 == 0 && n4 % 4 != 0)

                        {
                            n4 -= 2;
                            moves.Add(2);
                        }
                    //if n4 is odd and x is not divisible by 4, picking 1 will ensure the player wins
                    else if (n4 % 2 != 0 && x % 4 != 0)
                        {
                            n4 -= 1;
                            moves.Add(1);
                        }
                                       
                    else
                    {
                        // if n4 does not satisfy these conditions, then it must be an invalid value i.e. negative
                        Console.WriteLine("Invalid value for n4");
                    }
                    }
                   
                if (moves.Count % 2 == 0)
                {
                    //if there are an even number of moves when the game ends, player 2 won
                    Console.WriteLine("False");
                }
                else
                {
                    ////if there are an odd number of moves when the game ends, player 1(me) won

                    int count = 1;// intiate count variable

                    Console.Write("[");
                    foreach (int move in moves)// foreach loop to output the moves in a string
                    {
                        if (count==moves.Count)
                        {
                            Console.Write(move);// don't insert comma after the last move
                        }
                        else
                        {
                            Console.Write(move + ",");
                        }
                        

                        count++;
                    }
                    Console.Write("]");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Stones()");
            }
        }


    }
}
