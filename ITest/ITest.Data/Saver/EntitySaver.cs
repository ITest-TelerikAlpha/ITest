using System;
using System.Collections.Generic;
using System.Text;

namespace ITest.Data.Saver
{
    public class EntitySaver : ISaver
    {
        private readonly ApplicationDbContext context;

        public EntitySaver(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
        public async void SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
