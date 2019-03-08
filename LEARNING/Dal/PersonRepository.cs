using System.Linq;

namespace Dal
{
	public class PersonRepository : Repository<Models.Person>, IPersonRepository
	{
		internal PersonRepository(Models.DatabaseContext databaseContext) : base(databaseContext)
		{
		}
	}
}
