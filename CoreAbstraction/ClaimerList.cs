using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace CoreAbstraction
{
    public interface ClaimerList
    {
        List<Person> Get();
    }
}
