using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClass
{
    public class DVD : Storage
    {
        private int speed;
        public const int ONE_SIDED_TYPE_MEMORY = (int)((int)Memory.gigabyte * 4.7);
        public const int TWO_SIDED_TYPE_MEMORY = (int)Memory.gigabyte * 9;

        public DVD(int speed, bool type) : base()
        {
            this.speed = speed;
            memory = type ? ONE_SIDED_TYPE_MEMORY : TWO_SIDED_TYPE_MEMORY;
        }
        public DVD(int speed, bool type, string name, string model) : base()
        {
            this.speed = speed;
            memory = type ? ONE_SIDED_TYPE_MEMORY : TWO_SIDED_TYPE_MEMORY;
            Name = name;
            Model = model;
        }

        public DVD(int speed, string type) : base()
        {
            this.speed = speed;
            switch (type)
            {
                case "Односторонний": memory = ONE_SIDED_TYPE_MEMORY; break;
                case "Двусторонний": memory = TWO_SIDED_TYPE_MEMORY; break;
            }
        }
        public DVD(int speed, string type, string name, string model) : base()
        {
            this.speed = speed;
            switch (type)
            {
                case "Односторонний": memory = ONE_SIDED_TYPE_MEMORY; break;
                case "Двусторонний": memory = TWO_SIDED_TYPE_MEMORY; break;
            }
            Name = name;
            Model = model;
        }

        public DVD(int speed, int type) : base()
        {
            this.speed = speed;
            switch (type)
            {
                case ONE_SIDED_TYPE_MEMORY: memory = ONE_SIDED_TYPE_MEMORY; break;
                case TWO_SIDED_TYPE_MEMORY: memory = TWO_SIDED_TYPE_MEMORY; break;
                default: throw new ArgumentException("Такого типа нет");
            }
        }
        public DVD(int speed, int type, string name, string model) : base()
        {
            this.speed = speed;
            switch (type)
            {
                case ONE_SIDED_TYPE_MEMORY: memory = ONE_SIDED_TYPE_MEMORY; break;
                case TWO_SIDED_TYPE_MEMORY: memory = TWO_SIDED_TYPE_MEMORY; break;
                default: throw new ArgumentException("Такого типа нет");
            }
            Name = name;
            Model = model;
        }

        public override double Copy(ref int memory)
        {
            int freeMemory = GetFreeMemory();
            int recorderMemory;
            if (freeMemory >= memory)
            {
                recorderMemory = memory;
                freeMemory -= memory;
                filledMemory = this.memory - freeMemory;
                memory = 0;
            }
            else
            {
                recorderMemory = freeMemory;
                filledMemory = this.memory;
                memory -= freeMemory;
            }
            return (double)recorderMemory / speed;
        }

        public override string GetAllInformation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Название: {0}\nМодель: {1}\nОбъем памяти: {2}\n", Name, Model, memory);
            string type = memory == ONE_SIDED_TYPE_MEMORY ? "Односторонний" : "Двусторонний";
            stringBuilder.Append(type);
            return stringBuilder.ToString();
        }

        public override int GetAllMemory()
        {
            return memory;
        }

        public override int GetFreeMemory()
        {
            return memory - filledMemory;
        }
    }
}
