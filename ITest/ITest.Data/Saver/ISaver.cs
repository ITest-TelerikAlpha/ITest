using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.Data.Saver
{
    public interface ISaver
    {
        void SaveChanges();
        void SaveChangesAsync();
    }

}
