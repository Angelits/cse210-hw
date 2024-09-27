using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


public class entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public Datetime Date { get; set; }

    public Entry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now;
    }
}

public class Journal
{
    private List<Entry>entries = new List<Entry>();
    private readonly string[] prompts = {
        "Who was the most intersting person I interacted with Today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life Today?",
        "What was the strongest emotion I felt Today?",
        "If I had one thing I could do over Today, what would it be? ",
        "What can I do right now to feel better?",
        "Record an amazing experince youve had recently",    
    };

    public void AddEntry(string Response)
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Entry entry  = new Entry (prompt, response);
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach ( var entry in entries)
        {
            Console.WriteLine($"{entry.Date}: {entry.Prompt}\n{entry.Response}\n");
        }
    }

    public void SaveToFile(string filename)
    {
        string json = Json.Convert.SerializeObject(entries, Formatting.Indented);
        File.WriteAllText(filename, json);
    }

    public void LoadFromFile(string filename)
    {
        if (filename.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            entries = JsonConvert.DeserealizeObject<List<Entry>>(json);
        }
        else 
        {
            Console.WriteLine("File not found");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal ();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(response);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                        journal.LoadFromFile(loadFile);
                break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option please try again. ");
                    break;

            }
        }
    }
}
