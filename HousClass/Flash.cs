using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClass
{
    public class Flash : Storage
    {
        private const int SPEED = 600;

        public Flash(int memory) : base()
        {
            this.memory = memory;
        }
        public Flash(int memory, string name, string model) : base()
        {
            this.memory = memory;
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
            return (double)recorderMemory / SPEED;
        }

        public override string GetAllInformation()
        {
            return string.Format("Название: {0}\nМодель: {1}\nОбъем памяти: {2}", Name, Model, memory);
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
