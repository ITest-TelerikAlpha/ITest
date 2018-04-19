using ITest.Data.Models.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.Data.Models
{
    public class Category : DataModel
    {
        public Category()
        {
            this.Tests = new HashSet<Test>();
        }
        public string Name { get; set; }

        public ICollection<Test> Tests { get; set; }
    }
}
