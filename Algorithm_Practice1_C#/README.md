# Description

In this folder are my solutions to some algorithm exercises. Use C# to define methods to do the operations specified in the method signatures and hints below.

## Deliverable
A starter Program.cs file that answers the questions


### QUESTION 1: 

n2 – number of terms of the series, integer (int)
  * This method prints the following series till n terms: 1, 3, 6, 10, 15, 21……
  * For example, if n2 = 6, output will be:
  1,3,6,10,15,21
  
  * Returns : N/A
  * Return type: void
  * Hint: Series is 1,1+2=3,1+2+3=6,1+2+3+4=10,1+2+3+4+5=15, 1+2+3+4+5+6=21……


 <b> private static void PrintSeries(int n2)</b>

### QUESTION 2:
 On planet “USF” which is similar to that of Earth follows different clock
 where instead of hours they have U , instead of minutes they have S , instead
 of seconds they have F. Similar to earth where each day has 24 hours, each hour
 has 60 minutes and each minute has 60 seconds , USF planet’s day has 36 U , each
 U has 60 S and each S has 45 F. 
 Your task is to write a method usfTime which takes 12HR  format and return string 
 representing input time in USF time format.<br>
 * Input format: A string s with time in 12 hour clock format (i.e. hh:mm:ssAM or hh:mm:ssPM) where 01<= hh<=12, 00<=mm,ss,<=60
 
 * Output format: a string with converted time in USF clock format (i.e. UU:SS:FF ) 
 where 01<= UU<=36, 00<=SS<=59,00<=FF<=45
 
 Sample Input : 09:15:35PM <br>
 Sample Output: 28:20:35 
 
 * returns      : String<br>
 * return type  : string
 
 * Hint: One way of doing this is by calculating total number of seconds in Input time
  and dividing those seconds according to USF time.
 
 
 <b> public static string UsfTime(string s)</b>


### QUESTION 3:
n- total number of integers( 110 )<br>
k-number of numbers per line ( 11)<br>
 * USF Numbers : This method prints the numbers 1 to 110, 11 numbers per line.
 * The method shall print 'U' in place of numbers which are multiple of 3,"S" for 
  multiples of 5,"F" for multiples of 7, 'US' in place of numbers which are multiple 
  of 3 and 5,'SF' in place of numbers which are multiple of 5 and 7 and so on. 
 * The output shall look like:
 * 1 2 U 4 S U F 8 U S 11 U 13 F US 16 17 U 19 S UF 22 23 U S 26 U F 29 US 31 32 U....
 
 * returns      : N/A
 * return type  : void
 

 <b> public static void UsfNumbers(int n3, int k) </b>

### QUESTION 4:

You are given a list of unique words, the task is to find all the pairs of 
  distinct indices (i,j) in the given list such that, the concatenation of two
 words i.e. words[i]+words[j] is a palindrome.
 Example:
 * Input: ["abcd","dcba","lls","s","sssll"]
  * Output: [[0,1],[1,0],[3,2],[2,4]] 
  * Explanation: The palindromes are ["dcbaabcd","abcddcba","slls","llssssll"]
 Example:
 * Input: ["bat","tab","cat"]
  * Output: [[0,1],[1,0]] 
  * Explanation: The palindromes are ["battab","tabbat"]
 
 * returns      : N/A
 * return type  : void
 

<b> public static void PalindromePairs(string[] words) </b>

### QUESTION 5:

You are playing a stone game with one of your friends. There are N number of 
stones in a bag, each time one of you take turns to take out 1 to 3 stones. 
 The player who takes out the last stone will be the winner. In this case you
 will be the first player to remove the stone(s)(Player 1).
 
 * Write a method to determine whether you can win the game given the number of 
  stones in the bag. Print false if you cannot win the game, otherwise print any
  one set of moves where you are winning the game. Array should contain moves by
  both the players.
  
* Input: 4
  * Output: false
  * Explanation: As there are 4 stones in the bag, you will never win the game. No matter 1,2 or 3 stones you take out, the last stone will always be removed by your friend.

* Input: 5
  * Output: [1,1,3]   or [1,2,2] or [1,3,1]
  * Player 1 picks up 1 stone then player 2 picks up 1 or 2 or 3 stones and the  remaining stones are picked up by player 1.
  * Explanation: As there are 5 stones in the bag, you take out one stone.
   As there are 4 stones in the bag and it’s your friend’s turn. He will never win 
   the game because no matter 1,2 or 3 stones he takes out, you will the one to take 
   out the last stone.
  
* returns      : N/A
* return type  : void
 

<b>public static void Stones(int n4)</b>
