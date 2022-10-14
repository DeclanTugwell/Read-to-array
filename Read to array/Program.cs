using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.PerformanceData;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Read_to_array
{
    internal class Program
    {
       static Array To2DArray(string path) //main function
        {
            int counter = 0;
            int currentrow = 1;
            List<int> Counterset = Fetchpoints(path, 0); //creates a list of points showing the end of each column
            int rows = FLength(path); //finds the # of rows
            int columns = Counterset.ToArray().Length; //finds the # of columns
            string[ , ] finalarr = new string[rows, columns]; // creates 2D array to store everything in
            StreamReader file = new StreamReader(path);
            string placer = null;
            string[] builder = {"placer"};
            for (int i = 0; i < rows; i++) //repeats for ever row in the array
            {
                if (counter > 0) //checks if its the first row
                { 
                    currentrow = currentrow + 1; //counts which row its on
                    placer = file.ReadLine(); //skips through the rows until the desired row is found
                    Counterset = Fetchpoints(path, currentrow); //fetches the position of the end of each column for every row
                }
                for (int columncounter = 0; columncounter < columns; columncounter++) //repeats for how ever many colums there are
                {
                    if (columncounter == 0) //checks if its the first column
                    {
                        builder[0] = Convert.ToString(Convert.ToChar(file.Read())); //starts building up the array to enter into the 2D array
                        for (int x = 0; x < Counterset.ElementAt(0) - 1; x++) //loops until the ;
                        {
                            builder[0] = builder[0] + Convert.ToString(Convert.ToChar(file.Read())); 
                            finalarr[counter, 0] = builder[0]; //places array into the 2D array
                        }
                    }
                    else
                    {
                        
                        builder[0] = Convert.ToString(Convert.ToChar(file.Read())); //skips previous semi colon
                        builder[0] = Convert.ToString(Convert.ToChar(file.Read()));
                        for (int x = Counterset.ElementAt(columncounter - 1); x < Counterset.ElementAt(columncounter) - 2; x++)
                        {
                             builder[0] = builder[0] + Convert.ToString(Convert.ToChar(file.Read()));
                             finalarr[counter, columncounter] = builder[0];
                        }
                        
                        
                    }
                    

                        
                    
                }
                counter = counter + 1;
            }
            return finalarr;
        }
        static int FLength(string path) //finds the number of rows in the array
        {
            StreamReader rawfile = new StreamReader(path);
            string line = rawfile.ReadLine();
            string[] filearr = { line };
            while (line !=null)
            {
                filearr = filearr.Append(line).ToArray();
                line = rawfile.ReadLine();
            }
            int length = filearr.Length - 1;
            return length;
        }

        static List<int> Fetchpoints(string path, int row)
        {
            using (StreamReader srarr = new StreamReader(path))
            {
                for (int x = 0; x < row - 1; x++)
                {
                    srarr.ReadLine(); //skips rows depending on the row its trying to find the column position for
                }
                char fetcher = Convert.ToChar(srarr.Read());
                string checker = Convert.ToString(fetcher);
                int catcher = 1;
                int counter = -1;
                List<int> counterset = new List<int>();
                while (catcher != 0)
                {
                    counter = counter + 1;
                    if (checker == ";")
                    {
                        counterset.Add(counter); //adds the position of the end of the column to the list
                    }
                    try
                    {
                        checker = Convert.ToString(Convert.ToChar(srarr.Read()));
                        if (checker == "\n")
                        {
                            catcher = 0;
                        }
                    }
                    catch
                    {
                        catcher = 0;
                    }
                }
                return counterset;
            }

        }
    }
}
