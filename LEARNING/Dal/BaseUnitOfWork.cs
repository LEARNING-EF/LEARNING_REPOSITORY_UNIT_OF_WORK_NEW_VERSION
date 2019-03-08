namespace Dal
{
	public abstract class BaseUnitOfWork : object
	{
		public BaseUnitOfWork() : base()
		{
			IsDisposed = false;
		}

		// **********
		protected bool IsDisposed { get; set; }
		// **********

		// **********
		// **********
		// **********
		private Models.DatabaseContext databaseContext;
		// **********

		// **********
		protected Models.DatabaseContext DatabaseContext
		{
			get
			{
				if (databaseContext == null)
				{
					databaseContext =
						new Models.DatabaseContext();
				}

				return databaseContext;
			}
		}
		// **********
		// **********
		// **********

		public virtual void Save()
		{
			DatabaseContext.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (IsDisposed == false)
			{
				if (disposing)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}

			IsDisposed = true;
		}

		public void Dispose()
		{
			Dispose(true);

			System.GC.SuppressFinalize(this);
		}
	}
}
