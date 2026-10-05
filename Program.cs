namespace Assignment6_1 {
    internal class Program {

        static HouseList houses = new();

        static void Main(string[] args) {

            Console.WriteLine("Select an option:");

            while (true) {

                Console.WriteLine();
                Console.WriteLine("  1 - Add House");
                Console.WriteLine("  2 - Search House");
                Console.WriteLine("  3 - Show All Houses");
                Console.WriteLine("  4 - Move Zeros To The End");
                Console.WriteLine("  x - Quit");

                var choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice) {
                    case '1':
                        AddHouse();
                        break;
                    case '2':
                        SearchHouse();
                        break;
                    case '3':
                        ShowHouses();
                        break;
                    case '4':
                        MoveZeros();
                        break;
                    case 'x':
                        return;
                    default:
                        Console.WriteLine("That is not one of the options, please select something from the list.");
                        continue;
                }

                if (EndPrompt())
                    return;

            }

        }

        static void AddHouse() {

            Console.WriteLine();

            int number;

            while (true) {

                number = ReadInt("House number:", false);

                if (houses.Search(number) == null)
                    break;

                Console.WriteLine("That house number is already on the list, try again.");

            }

            string address = ReadText("Address: ");
            string style = ReadStyle();

            houses.AddLast(number, address, style);

            Console.WriteLine($"Saved house {number}: {style} at {address}.");

        }

        static void SearchHouse() {

            Console.WriteLine();

            if (houses.Count == 0) {
                Console.WriteLine("No houses have been added yet.");
                return;
            }

            int number = ReadInt("House number to find:", false);
            House? found = houses.Search(number);

            if (found == null) {
                Console.WriteLine($"There is no house {number} on the list.");
                return;
            }

            Console.WriteLine($"House number: {found.Number}");
            Console.WriteLine($"Address:      {found.Address}");
            Console.WriteLine($"Style:        {found.Style}");

        }

        static void ShowHouses() {

            Console.WriteLine();

            if (houses.Count == 0) {
                Console.WriteLine("No houses have been added yet.");
                return;
            }

            Console.WriteLine($"Houses on the list ({houses.Count}):");
            houses.Display();

        }

        static void MoveZeros() {

            Console.WriteLine();
            Console.WriteLine("Zeros move to the end, and the other numbers keep their order.");

            int[] numbers = ReadNumbers("Numbers separated by spaces: ");
            string before = string.Join(" ", numbers);

            ArrayFuncs.MoveZerosToEnd(numbers);

            Console.WriteLine($"Before: {before}");
            Console.WriteLine($"After:  {string.Join(" ", numbers)}");

        }

        static bool EndPrompt() {

            Console.WriteLine();
            Console.Write("Press enter to go back to the menu, or 'x' to quit: ");

            var choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            return choice == 'x';

        }

        static int ReadInt(string prompt, bool allowNegative) {

            while (true) {

                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out int value) && (value >= 0 || allowNegative))
                    return value;

                Console.WriteLine(allowNegative ? "Only whole numbers are allowed." : "Only positive whole numbers or 0 are allowed.");

            }

        }

        static string ReadText(string prompt) {

            while (true) {

                Console.Write(prompt);
                string text = Console.ReadLine() ?? "";

                if (text.Trim() != "")
                    return text.Trim();

                Console.WriteLine("Need at least one character, try again.");

            }

        }

        static string ReadStyle() {

            string[] styles = { "House", "Condo", "Townhouse", "Apartment", "Duplex", "Mobile home", "Cabin" };

            Console.WriteLine("Type of house:");

            for (int spot = 0; spot < styles.Length; spot++)
                Console.WriteLine($"  {spot + 1} - {styles[spot]}");

            while (true) {

                Console.Write("Pick a number from the list: ");

                if (int.TryParse(Console.ReadLine(), out int pick) && pick >= 1 && pick <= styles.Length)
                    return styles[pick - 1];

                Console.WriteLine($"Whole numbers from 1 to {styles.Length} only, try again.");

            }

        }

        static int[] ReadNumbers(string prompt) {

            while (true) {

                Console.Write(prompt);
                string[] numInputs = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

                List<int> parsedNums = new();

                foreach (string numInput in numInputs) {
                    if (int.TryParse(numInput, out int value))
                        parsedNums.Add(value);
                }

                if (parsedNums.Count > 0 && parsedNums.Count == numInputs.Length)
                    return parsedNums.ToArray();

                Console.WriteLine("Need at least one number, and only whole numbers.");

            }

        }
    }
}
