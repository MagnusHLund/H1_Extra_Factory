namespace H1_Extra_Factory
{
    internal class Program
    {
        static void Main()
        {
            // 2 dimensional array, which contains a physical object and weight
            string[,] products = new string[,] {
                {"Playstation 5", "6,60"},
                {"Xbox Series X", "4,45"},
                {"Smartphone", "0,25"},
                {"Laptop", "1,50"},
                {"Bluetooth speaker", "0,30"},
                {"Skateboard", "2,30"},
                {"Keyboard", "1,10"},
                {"Bicycle", "9,00"},
                {"VR headset", "0,50"},
                {"Monitor", "5,00"},
            };

            while (true)
            {
                // Creates the menu layout
                Console.WriteLine("Press:    Product:");
                for (int i = 0; i < products.GetLength(0); i++)
                {
                    // Changes the color every line between white and dark gray.
                    if (i % 2 == 0)
                        Console.ForegroundColor = ConsoleColor.White;
                    else
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                    // Writes the number to write to add it to the "pool", as well as the product, so you know what youre adding.
                    Console.WriteLine($"{i}         {products[i, 0]}");
                }

                // Creates a space
                Console.WriteLine();

                // Takes user input and puts it into a char array, called "input"
                char[] input = Console.ReadLine().ToCharArray();

                // Checks if input isnt empty and if the characters used are numbers, by calling the "IsValidCharacters" method
                if (!IsValidCharacters(input) || input.Length == 0)
                {
                    // Outputs an error, waits for user input, then clears the console and starts over.
                    Console.WriteLine("Only write numbers between 0-9! \npress enter to continue!");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                // Converts input to a string called "orderList", with a space between each character
                string orderList = string.Join(" ", input);

                // Converts the orderlist to an int array
                int[] packageId = orderList.Split(" ").Select(x => Convert.ToInt32(x)).ToArray();

                // Creates 2 new variables, to hold information about weight and box number.
                double totalWeight = 0;
                int box = 1;
                int counter = 0;

                // Outputs the first box
                Console.WriteLine($"Box {box}");

                for (int i = 0; i < input.Length; i++)
                {
                    // Puts product names into string "allProducts" and the weight for the same product, into "productWeight"
                    string allProducts = string.Join(" ", products[packageId[i], 0]);
                    double productWeight = double.Parse(products[packageId[i], 1]);

                    // Takes each packageId, which is basically each user input 
                    for (int j = 0; j < packageId.Length; j++)
                    {
                        if (j >= packageId.Length - 1)
                        {
                            // Outputs the box id, products and total weight
                            Console.Write($"Product: {allProducts} ");
                            Console.WriteLine($" Weight: {productWeight} kg");

                            // Creates a new box, if the limit is exceed
                            if (totalWeight + productWeight  >= 10)
                            {
                                box++;
                                Console.WriteLine($"total weight {totalWeight}");
                                Console.WriteLine($"Box {box}");
                                totalWeight = 0;
                            } 
                            else
                            {
                                // Else adds item to existing box and increases the totalWeight
                                totalWeight += productWeight;
                            }
                        }
                    }
                }

                Console.WriteLine();
            }

        }

        static bool IsValidCharacters(char[] input)
        {
            // Creates a string containing each of the allowed characters
            string allowedCharacters = "1234567890";

            // Runs through each character in the user input
            foreach (char c in input)
            {
                // If any of the characters arent 0-9, then it return false
                if (!allowedCharacters.Contains(c.ToString()))
                {
                    return false;
                }
            }

            // If the foreach finishes, then it returns true
            return true;
        } 
    }

    // Testing numbers: 12344554056876796709304692 
}