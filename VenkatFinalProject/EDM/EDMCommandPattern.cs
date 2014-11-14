using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenkatFinalProject.EDM
{
    public interface Command<T>
    {
        T execute();
    }
}
