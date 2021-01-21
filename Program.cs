using System;

namespace ExperienceSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Skill skill = new Skill(100, 1.09f);
            Console.WriteLine(skill.ExperienceToLevel(int.MaxValue));
        }
    }
}
