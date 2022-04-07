## Question
Check Permutation: Given two strings, write a method to decide if one is a permutation of the
other.

## My Solution
First I checked if the strings are not empty and had the same length. For each loop check if the current letter is on both char arrays if yes delete the char from both arrays and go to the next loop. <br>

Time complexity: O(n). <br>
Space complexity: O(n) where n is the length of the string. I created a char list of the string, it is not necessary, but the code is cleaner.

## In my opinion, the best and easiest solution here from the book that I didn't think of the first time.
If two strings are permutations, then we know they have the same characters, but in different orders. Therefore, sorting the strings will put the characters from two permutations in the same order. We just need to compare the sorted versions of the strings.

