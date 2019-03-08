namespace Dal
{
	public interface IUnitOfWork : System.IDisposable
	{
		// **********
		IUserRepository UserRepository { get; }
		// **********

		// **********
		IPersonRepository PersonRepository { get; }
		// **********

		void Save();
	}
}
