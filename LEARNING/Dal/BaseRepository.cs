using System.Linq;

namespace Dal
{
	public abstract class BaseRepository<T> : object, IRepository<T> where T : Models.BaseEntity
	{
		internal BaseRepository(Models.DatabaseContext databaseContext) : base()
		{
			// **************************************************
			//if (databaseContext == null)
			//{
			//	throw new System.ArgumentNullException(paramName: "databaseContext");
			//}

			//DatabaseContext = databaseContext;
			// **************************************************

			// **************************************************
			DatabaseContext =
				databaseContext ?? throw new System.ArgumentNullException(paramName: "databaseContext");
			// **************************************************

			DbSet = DatabaseContext.Set<T>();
		}

		// **********
		protected System.Data.Entity.DbSet<T> DbSet { get; set; }
		// **********

		// **********
		protected Models.DatabaseContext DatabaseContext { get; set; }
		// **********

		public virtual void Insert(T entity)
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException("entity");
			}

			DbSet.Add(entity);
		}

		public virtual void Update(T entity)
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException("entity");
			}

			// **************************************************
			// Just For Debug!
			// **************************************************
			System.Data.Entity.EntityState
				entityState = DatabaseContext.Entry(entity).State;
			// **************************************************
			// /Just For Debug!
			// **************************************************

			if (entityState == System.Data.Entity.EntityState.Detached)
			{
				DbSet.Attach(entity);
			}

			// **************************************************
			// Just For Debug!
			// **************************************************
			entityState =
				DatabaseContext.Entry(entity).State;
			// **************************************************
			// /Just For Debug!
			// **************************************************

			DatabaseContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

			// **************************************************
			// Just For Debug!
			// **************************************************
			entityState = DatabaseContext.Entry(entity).State;
			// **************************************************
			// /Just For Debug!
			// **************************************************
		}

		public virtual void Delete(T entity)
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException("entity");
			}

			// **************************************************
			// Just For Debug!
			// **************************************************
			System.Data.Entity.EntityState entityState = DatabaseContext.Entry(entity).State;
			// **************************************************
			// /Just For Debug!
			// **************************************************

			if (entityState == System.Data.Entity.EntityState.Detached)
			{
				DbSet.Attach(entity);
			}

			// **************************************************
			// Just For Debug!
			// **************************************************
			entityState = DatabaseContext.Entry(entity).State;
			// **************************************************
			// /Just For Debug!
			// **************************************************

			DbSet.Remove(entity);

			// **************************************************
			// Just For Debug!
			// **************************************************
			entityState = DatabaseContext.Entry(entity).State;
			// **************************************************
			// /Just For Debug!
			// **************************************************
		}

		public virtual T GetById(System.Guid id)
		{
			return DbSet.Find(id);
		}

		public virtual bool DeleteById(System.Guid id)
		{
			T entity = GetById(id);

			if (entity == null)
			{
				return false;
			}
			else
			{
				Delete(entity);

				return true;
			}
		}

		protected virtual System.Linq.IQueryable<T> Get()
		{
			return DbSet;
		}

		public virtual System.Collections.Generic.IList<T> GetAll()
		{
			return Get().ToList();
		}
	}
}
