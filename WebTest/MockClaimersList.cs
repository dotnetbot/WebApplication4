using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAbstraction;
using Models;

namespace WebTest
{
    public class MockClaimersList : ClaimerList
    {
        List<Person> _persons;
        public MockClaimersList(List<Person> persons)
        {
            _persons = persons;
        }
        public List<Person> Get()
        {
            return _persons;
        }
    }
}
