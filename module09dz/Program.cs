using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClass;

namespace module09dz
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ONE_FILE = 780;
            int allMemory = 565 * (int)Memory.gigabyte;

            int memoryInFlash = ONE_FILE;

            Storage[] storages = new Flash[1];
            double allTime = 0;//Количество секунд для полной записи

            storages[0] = new Flash(memoryInFlash);

            int i = 0;

            //Запись в Flash
            while (allMemory > 0)
            {
                if (ONE_FILE <= allMemory)
                {
                    if (!storages[i].CanWePut(ONE_FILE))
                    {
                        Array.Resize(ref storages, storages.Length + 1);
                        storages[storages.Length - 1] = new Flash(memoryInFlash);
                        i++;
                    }
                    allTime += storages[i].Copy(ref allMemory);
                }
                else
                {
                    if (allMemory > 0)
                    {
                        if (!storages[i].CanWePut(allMemory))
                        {
                            Array.Resize(ref storages, storages.Length + 1);
                            storages[storages.Length - 1] = new Flash(memoryInFlash);
                            i++;
                        }
                        allTime += (long)storages[i].Copy(ref allMemory);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("Время скачивания: {0}", allTime);
            Console.WriteLine("Понадобилось носителей типа Flash: {0}", storages.Length);

            Console.ReadLine();
        }
    }
}
