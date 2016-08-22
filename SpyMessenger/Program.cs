using System;

namespace SpyMessenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 for Encription");
            Console.WriteLine("2 for Decription");
            int value;
            if (int.TryParse(Console.ReadLine(), out value))
            {
                switch (value)
                {
                    case 1:
                        Encription();
                        break;
                    case 2:
                        Decriptor();
                        break;
                    case 3:
                        Console.WriteLine("You Idiot");
                        break;
                }
            }
        }

        private static void Encription()
        {
            var charCount = 0;
            var filteredInput = "";
            var spaceValue = "";
            do
            {
                string input;
                do
                {
                    if (charCount == 0)
                    {
                        Console.WriteLine("Please provide your message for encription");
                    }
                    else
                    {
                        Console.WriteLine("Charecter count in the provided message is more than 81");
                        Console.WriteLine("Please provide your message for encription within 81 chars");
                    }
                    input = Console.ReadLine();
                } while (input == null || input.Trim().Length == 0);

                for (int i = 0; i < input.Length; i++)
                {
                    var character = input[i];
                    if (character != ' ')
                    {
                        filteredInput += character;
                        charCount = charCount + 1;
                    }
                    else
                    {
                        spaceValue += " " + (charCount + 1);
                    }
                }
            } while (charCount > 81);

            var squareRoot = Math.Sqrt(charCount);

            var rows = (int) Math.Floor(squareRoot);

            var columns = (int) Math.Ceiling(squareRoot);

            var grid = new char[rows,columns];

            var index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (index < filteredInput.Length)
                    {
                        grid[i, j] = filteredInput[index];
                    }

                    index++;
                }
            }

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    var output = grid[j, i];
                    if (output != '\0')
                    {
                        Console.Write(output);
                    }
                }
                Console.Write(' ');
            }
            Console.Write("numsp" + spaceValue);

            Console.ReadLine();
        }

        public static void Decriptor()
        {
            Console.WriteLine("Please provide your message for Decription");
            var input = Console.ReadLine();

            var position = input.LastIndexOf("numsp");

            var value = input.Substring(0, position);

            var spaces = input.Substring(position + 5, input.Length -(position + 5 ));

            var rowStrings = value.Trim().Split(' ');

            var rows = rowStrings.Length;

            var columns = rowStrings[0].Length;

            var grid = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                var rowValue = rowStrings[i];
                for (int j = 0; j < columns; j++)
                {
                    if (j < rowValue.Length)
                    {
                        grid[i, j] = rowValue[j];
                    }
                }
            }

            Console.WriteLine("rows: " + rows);

            Console.WriteLine("columns:" + columns);

            Console.WriteLine("value: " + value);

            Console.WriteLine("spaces: " + spaces);

            spaces = " " + spaces + " ";

            var index = 0;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    index++;
                    if (spaces.IndexOf(" " + index + " ", StringComparison.Ordinal) > -1)
                    {
                        Console.Write(" ");
                    }
                    var output = grid[j, i];
                    if (output != '\0')
                    {
                        Console.Write(output);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
