## Question
Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4
bytes, write a method to rotate the image by 90 degrees.

## My Solution
The algorithm is replacing edge values going from outside to inside.
![Przechwytywanie](https://user-images.githubusercontent.com/52860350/160625226-4260c1c5-31cc-4eec-af71-e3c2a09cb786.JPG)<br>

Time complexity: O(n*t) when t is sum of all temparray lenghts(I.e, n=3 then t=3, n=4 then t=6, n=6 then t=12) <br>
Space complexity: O(n²).<br>
Auxiliary space complexity: O(n²).
