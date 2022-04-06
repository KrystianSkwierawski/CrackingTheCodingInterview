## Question
Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4
bytes, write a method to rotate the image by 90 degrees.

## My Solution
The algorithm is replacing edge values going from outside to inside.

Time complexity: O(n*t) when t is sum of all temparray lenghts(I.e, n=3 then t=3, n=4 then t=6, n=6 then t=12). <br>
Space complexity: O(n²).<br>
Auxiliary space complexity: O(n²).<br>

![Przechwytywanie](https://user-images.githubusercontent.com/52860350/162009477-68b1dd16-b373-40fd-98ee-4d4b6fa81bde.png)<br>
