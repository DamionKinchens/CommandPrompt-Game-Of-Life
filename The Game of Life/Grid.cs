using System;



class GridConstructor
{
    bool[,] livegrid;
    bool[,] nextgrid;
    int totalLiveCells = 0;
    int liveNeighbour = 0;
    int gMax = 0;
    int gMin = -1;
    int gridSize;
    bool correctInputGrid = false;

    //public int[,] GetStarterGridSize()
    //{
    //    Console.WriteLine("Input Grid Size as int");
    //    do
    //    {
    //        correctInputGrid = int.TryParse(Console.ReadLine(), out gridSize);
    //        if (correctInputGrid == false || gridSize <= 0)
    //        { Console.WriteLine("Please answer only as a poitive integer"); }
    //    } while (correctInputGrid == false || gridSize <= 0);

    //    int[,] StarterGrid = new int[gridSize,gridSize];
    //    return StarterGrid;
    //}

    //public int[] TransformGrid2DTo1D()
    //{
    //    for (int x = 0; x < gridSize; x++)
    //    {
    //        for (int y = 0; y < gridSize; y++)
    //        {
    //            int[] StarterGrid1D = 
    //        }
    //    }
    //    return StarterGrid1D;
    //}

    public bool[,] FillStarterGrid(bool[,] StarterGrid)
    {
        int gridcol = StarterGrid.GetLength(0);
        int gridrow = StarterGrid.GetLength(1);

        Random randAlive = new Random();
        for (int x = 0; x < gridcol; x++)
        {
            for (int y = 0; y < gridrow; y++)
            {
                int check = randAlive.Next(2);
                if (check == 1)
                { StarterGrid[x, y] = true; }
                else
                { StarterGrid[x, y] = false; }
            }
        }
        //for (int x = 0; x < gridcol; x++)
        //{
        //    for (int y = 0; y < gridrow; y++)
        //    {
        //        Console.Write("{0,2}", StarterGrid[x, y]);
        //    }
        //    Console.WriteLine();
        //}
        return StarterGrid;
    }
    //public int[,] TransformGrid1DTo2D()
    //{

    //}

    public bool[,] InitiateGrids(bool[,] StarterGrid)
    {
        gMax = StarterGrid.GetLength(0);
        livegrid = (bool[,])StarterGrid.Clone();
        nextgrid = (bool[,])livegrid.Clone();
        return livegrid;
    }

    //Method to carry out grid copy and checks
    public void PlayGame()
    {
        // Get number of rows/columns in grid
        int gridcol = livegrid.GetLength(0);
        int gridrow = livegrid.GetLength(1);

        // Nested loop to itterate through grid
        for (int x = 0; x < gridcol; x++)
        {
            for (int y = 0; y < gridcol; y++)
            {
                if (livegrid[x, y] == true)
                {
                    totalLiveCells++;

                    cellDetection(x, y);
                    if (liveNeighbour > 3) // Dies to overpopulation
                    {nextgrid[x, y] = false;}
                    if (liveNeighbour < 2)//Dies to underpopulation
                    {nextgrid[x, y] = false;}
                }
                if (livegrid[x, y] == false)
                {
                    cellDetection(x, y);
                    if (liveNeighbour == 3) //Cell is born
                    { nextgrid[x, y] = true;}
                    
                }
                liveNeighbour = 0;
            }
        }

        // Calling method to display changes and repeat cycle.
        Console.WriteLine();
        displaygrid(livegrid);
        Console.WriteLine();

        int gridSquareHalf = livegrid.GetLength(0);
        int gridSquare = gridSquareHalf * gridSquareHalf;

        Array.Copy(nextgrid, livegrid, gridSquare);

        totalLiveCells = 0;
    }

    private void cellDetection(int x, int y)
    {
        if (x - 1 > gMin)
        {
            if (y - 1 > gMin && livegrid[x - 1, y - 1] == true)
            { liveNeighbour++;}

            if (livegrid[x - 1, y] == true)
            { liveNeighbour++;}

            if (y + 1 < gMax && livegrid[x - 1, y + 1] == true)
            { liveNeighbour++;}
        }
        
        if (y - 1 > gMin && livegrid[x, y - 1] == true)
        { liveNeighbour++;}
        if (y + 1 < gMax && livegrid[x, y + 1] == true)
        { liveNeighbour++;}

        if (x + 1 < gMax && y - 1 > gMin && livegrid[x + 1, y - 1] == true)
        { liveNeighbour++;}
        if (x + 1 < gMax && livegrid[x + 1, y] == true)
        { liveNeighbour++;}
        if (x + 1 < gMax && y + 1 < gMax && livegrid[x + 1, y + 1] == true)
        { liveNeighbour++;}
    }

    public void displaygrid(bool[,] livegrid)
    {
        int gridcol = livegrid.GetLength(0);
        int gridrow = livegrid.GetLength(1);

        List<char> LinePrint = new List<char>();

        for (int x = 0; x < gridcol; x++)
        {

            for (int y = 0; y < gridrow; y++)
            {
                if (livegrid[x, y] == true)
                LinePrint.Add('X');
                if (livegrid[x, y] == false)
                    LinePrint.Add(' ');
            }

            Console.WriteLine(string.Join(" ", LinePrint));
            LinePrint.Clear();
            liveNeighbour = 0;

        }
        Thread.Sleep(100);
        
    }
}