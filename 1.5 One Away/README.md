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
I exaggerated a bit with the solution, it not only checks if it is just one edit away but if it is possible to get the same strings when inserting, deleting, or replacing. The code has some repetition and for sure can be refactored.
