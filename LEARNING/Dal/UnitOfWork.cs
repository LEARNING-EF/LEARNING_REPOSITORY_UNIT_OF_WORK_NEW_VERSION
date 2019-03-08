namespace Dal
{
	public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
	{
		public UnitOfWork() : base()
		{
		}

		// **************************************************
		//private IXXXXXRepository xXXXXRepository;

		//public IXXXXXRepository XXXXXRepository
		//{
		//	get
		//	{
		//		if (xXXXXRepository == null)
		//		{
		//			xXXXXRepository =
		//				new XXXXXRepository(DatabaseContext);
		//		}

		//		return xXXXXRepository;
		//	}
		//}
		// **************************************************

		// **************************************************
		private IUserRepository userRepository;

		public IUserRepository UserRepository
		{
			get
			{
				if (userRepository == null)
				{
					userRepository =
						new UserRepository(DatabaseContext);
				}

				return userRepository;
			}
		}
		// **************************************************

		// **************************************************
		private IPersonRepository personRepository;

		public IPersonRepository PersonRepository
		{
			get
			{
				if (personRepository == null)
				{
					personRepository =
						new PersonRepository(DatabaseContext);
				}

				return personRepository;
			}
		}
		// **************************************************
	}
}
