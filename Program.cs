using System.Text;

string path = @"C:\Users\VULCAN\Desktop";
Encode(path, path);
Decode(path, path);

void Encode(string inputPath, string outputPath)
{
    string content;
    byte[] bytes;
    try
    {
        using (StreamReader sr = File.OpenText($"{inputPath}\\Lab.txt"))
        {
            content = sr.ReadToEnd();
            bytes = Encoding.Default.GetBytes(content);
        }
        using (StreamWriter sw = new StreamWriter($"{outputPath}\\newLab.utf8"))
        {
            foreach(char c in bytes)
            {
                sw.Write(c);
            }            
        }
    } 
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void Decode(string inputPath, string outputPath)
{
    string content;
    byte[] bytes;
    try
    {
        bytes = File.ReadAllBytes($"{inputPath}\\newLab.utf8");
        content = Encoding.UTF8.GetString(bytes);
        using (StreamWriter sw = new StreamWriter($"{outputPath}\\newLab.txt"))
        {
            sw.WriteLine(content);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}