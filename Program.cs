using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        List<string> hashedPass = new List<string>();
        loadHashedPasswords(hashedPass);
        writeHashedPasswords(hashedPass);
        Console.WriteLine("Conversion termine");
    }

    static void loadHashedPasswords(List<string> hashedPass)
    {
        MD5 hashing = MD5.Create();
        using (StreamReader file = new StreamReader("input.txt"))
        {
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                byte[] data = hashing.ComputeHash(Encoding.UTF8.GetBytes(line));
                hashedPass.Add(BitConverter.ToString(data).Replace("-", "").ToLower());
            }
        }
    }

    static void writeHashedPasswords(List<string> hashedPass)
    {
        using (StreamWriter file = new StreamWriter("output.txt"))
        {
            foreach (string line in hashedPass)
            {
                file.WriteLine(line);
            }
        }
    }
}