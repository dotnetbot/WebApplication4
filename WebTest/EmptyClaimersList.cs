﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAbstraction;
using Models;

namespace WebTest
{
    public class EmptyClaimersList : ClaimerList
    {
        public List<Person> Get()
        {
            return new List<Person>();
        }
    }
}
