using System.Linq;

namespace Dal
{
	public class UserRepository : Repository<Models.User>, IUserRepository
	{
		internal UserRepository(Models.DatabaseContext databaseContext) : base(databaseContext)
		{
		}

		public Models.User GetByUsername(string username)
		{
			var result =
				Get()
				.Where(current => string.Compare(current.Username, username, true) == 0)
				.FirstOrDefault();

			return result;
		}

		public System.Collections.Generic.IList<Models.User> GetActiveUsers()
		{
			//var result =
			//	Get()
			//	.ToList()
			//	;

			//var result =
			//	Get()
			//	.OrderBy(current => current.Username)
			//	.ToList()
			//	;

			var result =
				Get()
				.Where(current => current.IsActive)
				.OrderBy(current => current.Username)
				.ToList()
				;

			//var result =
			//	Get()
			//	.Where(current => current.IsActive)
			//	.Where(current => current.IsDeleted == false)
			//	.OrderBy(current => current.Username)
			//	.ToList()
			//	;

			return result;
		}
	}
}
