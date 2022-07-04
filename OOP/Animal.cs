using System.ComponentModel;

namespace OOP
{
    public abstract class Animal
    {
        public Animal(int age,string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string? Name { get; set; }
        public int Speed { get; set; }

        //public bool Flyable { get; set; }


        protected bool carnivorous;
        /// <summary>
        /// Carnivorous = True
        /// Herbivorous = False
        /// </summary>
        public bool Carnivorous
        {
            get
            {
                return this.carnivorous;
            }
        }

        public string CV()
        {
            return string.Format("Etçil : {0} İsim : {1} Yaş : {2}", carnivorous, Name, Age);
        }



        public virtual string GetDosage()
        {
            return "";
        }

        public abstract string GetName();
    }

    public class Horse : Animal
    {
        public static Horse operator +(Horse horse, Cat cat) => new Horse();

        public Horse() : base(0,"")
        {
            base.carnivorous = false;
        }

        public WalkingStyle WalkingStyles { get; set; }

        public enum WalkingStyle
        {
            [Description("Dörtnala")]
            Dortnala = 1,
            [Description("Rahvan")]
            Rahvan = 2,

        }
        public override string GetDosage()
        {
            if (Age < 5)
            {
                return "5 kg yapıştır";
            }
            else if (Age > 5)
            {
                return "3 kg";
            }
            else
            {
                return "1 kg";
            }
        }

        public override string GetName()
        {
            return Name;
        }

        /// <summary>
        /// Method Hiding
        /// </summary>
        /// <returns></returns>
        public new string CV()
        {
            return string.Format("Etçil : {0} İsim : {1} Yaş : {2}", carnivorous, Name, Age);
        }
    }

    public class Cat : Animal
    {
        public Cat(int age, string name) : base(age, name)
        {
            base.Age = age;
            base.Name = name;
            base.carnivorous = true;
        }
        public Cat(int age, string name, int speed) : base(age, name)
        {
            base.Age = age;
            base.Name = name;
            base.carnivorous = true;
        }

        public override string GetName()
        {
            return Name;
        }

        public override string GetDosage()
        {
            if (Weight == 10)
            {
                return "500gr mama ver";
            }

            return "";
        }
    }
}