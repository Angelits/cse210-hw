using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job ("Data analyst", "Amazon", "2016", "2021");
        Job job2 = new Job ("Manager assistant", "Google", "2022", "2024");

        Resume MyResume = new Resume("Name: Alicia Shepherd");
        MyResume.AddJob(job1);
        MyResume.AddJob(job2);

        MyResume.Display();
    }
}