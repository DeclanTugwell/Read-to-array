# Read-to-array
Reads a text file and converts it directly into a 2 Dimensional array.
In order to format the file for this to work, each column within the text file must be marked using a ";" at the end.
An example of a suitably formatted text file is as follows...

Example format:
----------------------------------------
- example1;example2;example3;
----------------------------------------
This table above would result in a 2D array that has 1 row and 3 columns.

# Usage:
```c#
String[,] example = (string[,])To2DArray("C:\Users\example\source\repos\files\example.txt")
```
This is my first c# project and I made it in order to practise and learn more about c# as well as coding in general.
