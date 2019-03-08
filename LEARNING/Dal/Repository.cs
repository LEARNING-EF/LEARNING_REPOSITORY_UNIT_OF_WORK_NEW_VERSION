namespace Dal
{
	public abstract class Repository<T> : BaseRepository<T> where T : Models.BaseEntity
	{
		internal Repository(Models.DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
		}
	}
}
