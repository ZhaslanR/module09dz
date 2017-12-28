using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClass
{
    public abstract class Storage
    {
        

        protected int filledMemory;
        protected int memory;

        public string Name { get; set; }
        public string Model { get; set; }

        public Storage()
        {
            filledMemory = 0;
        }

        public abstract int GetAllMemory();
        public abstract int GetFreeMemory();

        public abstract double Copy(ref int memory);
        public abstract string GetAllInformation();
        public bool CanWePut(int memory)
        {
            return GetFreeMemory() >= memory ? true : false;
        }
    }
}
