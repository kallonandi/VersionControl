using Mikrosimulation.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mikrosimulation
{
    public partial class MikroSimulation : Form
    {
        Random rng = new Random(1234);

        List<Person> Population = new List<Person>();
        List<Birthprobability> Birthprobabilities = new List<Birthprobability>();
        List<Deathprobability> Deathprobabilities = new List<Deathprobability>();
         public MikroSimulation()
        {
            InitializeComponent();

            Population = GetPopulation(@"C:\Temp\nép-teszt.csv");
            Birthprobabilities = GetBirthprobability(@"C:\Temp\születés.csv");
            Deathprobabilities = GetDeathprobability(@"C:\Temp\halál.csv");


            for (int year = 2005; year <= 2024; year++)
            {
                for (int i = 0; i < Population.Count; i++)
                {

                }
                int nbrofMales = (from x in Population
                                  where x.Gener == Gender.Male && x.IsAlive
                                  select x).Count();
                int nbrofFemales = (from x in Population
                                  where x.Gener == Gender.Female && x.IsAlive
                                  select x).Count();
                Console.WriteLine(string.Format(
                    "Év: {0}\nFiúk: {1}nLányok: {2}\n",
                    year,
                    nbrofMales,
                    nbrofFemales
                    ));


            }
        }
        private void SimStep(int year, Person person)
        {
            //Ha halott akkor kihagyjuk, ugrunk a ciklus következő lépésére
            if (!person.IsAlive) return;

            // Letároljuk az életkort, hogy ne kelljen mindenhol újraszámolni
            byte age = (byte)(year - person.BirthYear);

            // Halál kezelése
            // Halálozási valószínűség kikeresése
            double pDeath = (from x in DeathProbabilities
                             where x.Gender == person.Gender && x.Age == age
                             select x.P).FirstOrDefault();
            // Meghal a személy?
            if (rng.NextDouble() <= pDeath)
                person.IsAlive = false;

            //Születés kezelése - csak az élő nők szülnek
            if (person.IsAlive && person.Gender == Gender.Female)
            {
                //Szülési valószínűség kikeresése
                double pBirth = (from x in BirthProbabilities
                                 where x.Age == age
                                 select x.P).FirstOrDefault();
                //Születik gyermek?
                if (rng.NextDouble() <= pBirth)
                {
                    Person újszülött = new Person();
                    újszülött.BirthYear = year;
                    újszülött.NbrOfChildren = 0;
                    újszülött.Gender = (Gender)(rng.Next(1, 3));
                    Population.Add(újszülött);
                }
            }
        }

        public List<Person> GetPopulation(string csvPath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvPath,Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    var p = new Person();
                    p.BirthYear = int.Parse(line[0]);
                    p.Gener = (Gender)Enum.Parse(typeof(Gender), line[1]);
                    p.NbrofChildren = int.Parse(line[2]);
                    population.Add(p);
                }
            }
            
            
            return population;
        }
        public List<Birthprobability> GetBirthprobability(string csvPath)
        {
            List<Birthprobability> birthProbabilities = new List<Birthprobability>();

            using (StreamReader sr = new StreamReader(csvPath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    var p = new Birthprobability();
                    p.Age = int.Parse(line[0]);                  
                    p.NbrofChildren = int.Parse(line[1]);
                    p.P = double.Parse(line[2]);
                    birthProbabilities.Add(p);
                }
            }


            return birthProbabilities;
        }
        public List<Deathprobability> GetDeathprobability(string csvPath)
        {
            List<Deathprobability> deathProbabilities = new List<Deathprobability>();

            using (StreamReader sr = new StreamReader(csvPath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    var p = new Deathprobability();
                    p.Age = int.Parse(line[1]);
                    p.Gener = (Gender)Enum.Parse(typeof(Gender), line[0]);
                    p.P = double.Parse(line[2]);
                    deathProbabilities.Add(p);
                }
            }


            return deathProbabilities;
        }
    }
}
