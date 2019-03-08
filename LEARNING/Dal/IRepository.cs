namespace Dal
{
	public interface IRepository<T> where T : Models.BaseEntity
	{
		void Insert(T entity);

		void Update(T entity);

		void Delete(T entity);

		T GetById(System.Guid id);

		bool DeleteById(System.Guid id);

		System.Collections.Generic.IList<T> GetAll();
	}
}
