using System;
using System.IO;
using System.Threading.Tasks;


string msg = "Kalimera";

await PrintMessage(msg);

string message = await ReadMessage();
Console.Write(message);


async Task PrintMessage(string? message)
{
    using (StreamWriter streamer = new StreamWriter("kalimera.txt"))
    {
        await streamer.WriteLineAsync(message);
    }
    Console.WriteLine("Message Succesfully Written!!");
}

async Task<string> ReadMessage()
{
    using(StreamReader reader = new StreamReader("kalimera.txt"))
    {
        string? line = await reader.ReadLineAsync();
        
        try
        {
            if(line is null)
                throw new NullLineException("There is Nothing to read!");
            else
            {
                string tmp = line;
                return tmp;
            }        
        }
        catch (NullLineException ex)
        {
            Console.WriteLine(ex.Message);
            return string.Empty;
        }
        catch (Exception)
        {
            Console.WriteLine("General Exception!");
            return string.Empty;
        }
        
    }
}