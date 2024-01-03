using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        bool endgame = false;
        int lifeCycles = 0;
        bool correctInput = false;
        int gridSize = 0;
        bool correctInputGrid = false;


        // int[,] StarterGrid = new int[,]
        //{
        // { 1, 1, 0, 1, 0, 0, 0, 0, 1, 0,},
        // { 1, 0, 1, 0, 0, 1, 0, 0, 0, 1,},
        // { 0, 1, 1, 0, 1, 1, 1, 0, 0, 0,},
        // { 0, 1, 0, 0, 0, 1, 0, 0, 0, 0,},
        // { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0,},
        // { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0,},
        // { 0, 1, 0, 0, 1, 0, 0, 1, 0, 0,},
        // { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0,},
        // { 1, 1, 0, 0, 1, 0, 0, 1, 0, 1,},
        // { 0, 0, 0, 1, 0, 1, 1, 1, 0, 1,}
        //};


        GridConstructor gameoflife = new GridConstructor();

        //gameoflife.GetStarterGridSize();

        Console.WriteLine("Input Grid Size as int");
        do
        {
            correctInputGrid = int.TryParse(Console.ReadLine(), out gridSize);
            if (correctInputGrid == false || gridSize <= 0)
            { Console.WriteLine("Please answer only as a poitive integer"); }
        } while (correctInputGrid == false || gridSize <= 0);

        bool[,] StarterGrid = new bool[gridSize, gridSize];

        gameoflife.FillStarterGrid(StarterGrid);

        

        while (endgame == false)
        {
            gameoflife.InitiateGrids(StarterGrid);

            Console.WriteLine("Welcome to my Game of life simulator!");
            Console.WriteLine("How many cycle would you like to see?");
            Console.WriteLine("(Or type 0 to quit)");
            do
            {
                correctInput = int.TryParse(Console.ReadLine(), out lifeCycles);
                if (lifeCycles == 0)
                {
                    endgame = true;
                    break;
                }
                if (correctInput == false || lifeCycles < 0)
                { Console.WriteLine("Please answer only as a poitive integer or 0"); }
                
            } while (correctInput == false || lifeCycles <= 0);

            

            for (int i = 0; i < lifeCycles; i++)
            {
                gameoflife.PlayGame();
            }
        }
    }
}

