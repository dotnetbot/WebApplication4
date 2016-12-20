using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PersonGateway
    {
        public Claimer GetClaimer(int Id)
        {
            var personData = new Person();
            return new Claimer(personData);
        }
    }
}
