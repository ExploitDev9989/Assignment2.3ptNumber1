namespace Consoleapptextfile
{
    using System.IO;
    using System.Linq.Expressions;

    internal class Program
    {
        static void Main(string[] args)
        {
            const string path = @"C:\Files\";
            Console.WriteLine("Exploring File IO operations...\n");
            Console.WriteLine("Enter a file name to create with .txt extension:\n");
            string fileName = path + Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter your age: ");
            string age = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter your address: ");
            string address = Console.ReadLine();
            Console.Clear();
            

            StreamWriter writer = null;// not pointing to any file yet


            try //try-catch-finally for file writing
            {
                if (!File.Exists(fileName)) //checking if file exists
                {
                    writer = File.CreateText(fileName);

                    Console.ForegroundColor = ConsoleColor.Red;
                    writer.WriteLine($"Name: {name} \n");
                    writer.WriteLine($"Age: {age} \n");
                    writer.WriteLine($"Address: {address} \n");
                    Console.WriteLine($"Your information has been saved in {fileName}\n\n");
                    Console.ForegroundColor= ConsoleColor.Blue;
                    Console.WriteLine("********************Personal Information********************");

                }
                else //file exists
                {
                    File.AppendAllText(fileName, $"\nFile accessed on {DateTime.Now}");
                    Console.WriteLine("File appended successfully.");

                }

            }
            catch (Exception ex) //catching any exceptions
            {
                Console.WriteLine("An error occurred: " + ex.Message); //displaying error message
            }
            finally //finally block to close the writer
            {
                if (writer != null) //checking if writer is not null
                {
                    writer.Close(); //closing the writer
                }
            }
            try
            {        // Using 'using' statement to handle file reading
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string content = sr.ReadToEnd();
                    Console.WriteLine(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the file: " + ex.Message);
            }



            finally
            {
                Console.WriteLine("File operations completed.");

            }
        }
    }
}

