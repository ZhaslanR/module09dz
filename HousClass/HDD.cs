using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClass
{
    public class HDD : Storage
    {
        private const int speed = 60;
        private int memoryInSector;
        private int countOfSectors;

        public HDD(int countOfSectors, int memoryInSector) : base()
        {
            memory = memoryInSector * countOfSectors;
            this.memoryInSector = memoryInSector;
            this.countOfSectors = countOfSectors;
        }

        public HDD(int countOfSectors, int memoryInSector, string name, string model) : base()
        {
            memory = memoryInSector * countOfSectors;
            this.memoryInSector = memoryInSector;
            this.countOfSectors = countOfSectors;
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
            return string.Format("Название: {0}\nМодель: {1}\nОбъем памяти: {2}\nКоличество разделов: {3}\nКоличество памяти в разделах: {4}", Name, Model, memory, countOfSectors, memoryInSector);
        }

        public override int GetAllMemory()
        {
            return countOfSectors * memoryInSector;
        }

        public override int GetFreeMemory()
        {
            return countOfSectors * memoryInSector - filledMemory;
        }
    }
}
