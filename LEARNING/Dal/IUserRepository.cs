namespace Dal
{
	public interface IUserRepository : IRepository<Models.User>
	{
		Models.User GetByUsername(string username);

		System.Collections.Generic.IList<Models.User> GetActiveUsers();
	}
}
