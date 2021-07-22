using Microservice.Domain;
using System.Linq;

namespace Microservice.EF.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EntitiesContext context)
        {
            context.Database.EnsureCreated();
            { 

            }
        }

    }
}
