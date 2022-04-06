## Question
One Away: There are three types of edits that can be performed on strings: insert a character,
remove a character, or replace a character. Given two strings, write a function to check if they are
one edit (or zero edits) away.<br>
EXAMPLE<br>
pale, ple -> true<br>
pales, pale -> true<br>
pale, bale -> true<br>
pale, bake -> false 

## My Solution
The code has some repetitions and for sure can be refactored. I exaggerated a bit with the solution, it not only can check if it is just one edit away but if it is possible to get the same strings when inserting, deleting, or replacing and how to do it(where insert or delete letter). It is possible to get the same strings inserting or deleting letters.

EXAMPLE<br>
pale, ple - you can remove "e" from first string or add "a" to second string.<br>
pales, pale - you can remove "s" from first string or add "s" to second string.<br>

Time complexity: O(n). <br>
Space complexity: O(n) where n is the length of the longer string.<br>
Auxiliary space complexity: O(n).

