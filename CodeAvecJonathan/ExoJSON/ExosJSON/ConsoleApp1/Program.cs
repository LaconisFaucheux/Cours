using System;
using Newtonsoft.Json;

namespace ExoJSON
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public bool Majeur;

        public Person() { }

        public void Afficher()
        {
            Console.WriteLine($"Nom: {Name} - Age: {Age} ans");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person personne1 = new Person();
            personne1.Name = "Bruce Wayne";
            personne1.Age = 42;
            personne1.Majeur = true;    

            personne1.Afficher();

            string json = JsonConvert.SerializeObject(personne1);

            Console.WriteLine(json);

            string jsonPersonne2 = "{\"name\":\"Dick Grayson\",\"age\":15,\"majeur\":false}";
            Person personne2 = JsonConvert.DeserializeObject<Person>(jsonPersonne2);
            personne2.Afficher();
            
        }
    }
}