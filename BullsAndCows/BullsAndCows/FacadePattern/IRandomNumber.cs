using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public interface IRandomNumber
    {
        int GetRandomNumber(int min, int max);
    }
}
