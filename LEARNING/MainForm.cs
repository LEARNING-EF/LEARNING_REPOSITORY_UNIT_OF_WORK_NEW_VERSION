using System.Linq;

namespace LEARNING
{
	public partial class MainForm : System.Windows.Forms.Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			// **************************************************
			// DatabaseContext - Add New User
			// **************************************************
			{
				Models.DatabaseContext databaseContext = null;

				try
				{
					databaseContext =
						new Models.DatabaseContext();

					Models.User user = new Models.User
					{
						IsActive = true,
						Username = "DariushTasdighi",
					};

					databaseContext.Users.Add(user);

					databaseContext.SaveChanges();
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message);
				}
				finally
				{
					if (databaseContext != null)
					{
						databaseContext.Dispose();
						databaseContext = null;
					}
				}
			}
			// **************************************************
			// /DatabaseContext - Add New User
			// **************************************************

			// **************************************************
			// UnitOfWork - Add New User
			// **************************************************
			{
				Dal.UnitOfWork unitOfWork = null;

				try
				{
					unitOfWork =
						new Dal.UnitOfWork();

					Models.User user = new Models.User
					{
						IsActive = true,
						Username = "DariushTasdighi",
					};

					unitOfWork.UserRepository.Insert(user);

					unitOfWork.Save();
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message);
				}
				finally
				{
					if (unitOfWork != null)
					{
						unitOfWork.Dispose();
						unitOfWork = null;
					}
				}
			}
			// **************************************************
			// /UnitOfWork - Add New User
			// **************************************************

			System.Guid id =
				new System.Guid
					("a1a57f49-51fc-4c4b-8f06-19cd117d5c9e");

			string username = "DariushTasdighi";

			// **************************************************
			// DatabaseContext - Get The User From Database -> Update The User -> Save The User Changes To Database
			// **************************************************
			{
				Models.DatabaseContext databaseContext = null;

				try
				{
					databaseContext =
						new Models.DatabaseContext();

					//Models.User user =
					//	databaseContext.Users
					//	.Where(current => current.Id == id)
					//	.FirstOrDefault();

					Models.User user =
						databaseContext.Users
						.Where(current => string.Compare(current.Username, username, true) == 0)
						.FirstOrDefault();

					if (user != null)
					{
						user.IsActive = false;
						user.Username = "AliRezaAlavi";

						databaseContext.SaveChanges();
					}
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message);
				}
				finally
				{
					if (databaseContext != null)
					{
						databaseContext.Dispose();
						databaseContext = null;
					}
				}
			}
			// **************************************************
			// /DatabaseContext - Get The User From Database -> Update The User -> Save The User Changes To Database
			// **************************************************

			// **************************************************
			// UnitOfWork - Get The User From Database -> Update The User -> Save The User Changes To Database
			// **************************************************
			{
				Dal.UnitOfWork unitOfWork = null;

				try
				{
					unitOfWork =
						new Dal.UnitOfWork();

					//Models.User user =
					//	unitOfWork.UserRepository.GetById(id);

					Models.User user =
						unitOfWork.UserRepository.GetByUsername(username);

					if (user != null)
					{
						user.IsActive = false;
						user.Username = "AliRezaAlavi";

						// نوشتن دستور ذیل الزامی نیست! ولی اگر بنویسیم مشکلی ندارد
						//unitOfWork.UserRepository.Update(user);

						unitOfWork.Save();
					}
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message);
				}
				finally
				{
					if (unitOfWork != null)
					{
						unitOfWork.Dispose();
						unitOfWork = null;
					}
				}
			}
			// **************************************************
			// /UnitOfWork - Get The User From Database -> Update The User -> Save The User Changes To Database
			// **************************************************

			// **************************************************
			// DatabaseContext - Just Update The User with Id -> Save The User Changes To Database
			// **************************************************
			{
				Models.DatabaseContext databaseContext = null;

				try
				{
					databaseContext =
						new Models.DatabaseContext();

					Models.User user = new Models.User();

					user.Id = id;
					user.IsActive = false;
					user.Username = "AliRezaAlavi";

					databaseContext.Entry(user).State =
						System.Data.Entity.EntityState.Modified;

					databaseContext.SaveChanges();
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message);
				}
				finally
				{
					if (databaseContext != null)
					{
						databaseContext.Dispose();
						databaseContext = null;
					}
				}
			}
			// **************************************************
			// /DatabaseContext - Just Update The User with Id -> Save The User Changes To Database
			// **************************************************

			// **************************************************
			// UnitOfWork - Just Update The User with Id -> Save The User Changes To Database
			// **************************************************
			{
				Dal.UnitOfWork unitOfWork = null;

				try
				{
					unitOfWork =
						new Dal.UnitOfWork();

					Models.User user = new Models.User();

					user.Id = id;
					user.IsActive = false;
					user.Username = "AliRezaAlavi";

					unitOfWork.UserRepository.Update(user);

					unitOfWork.Save();
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message);
				}
				finally
				{
					if (unitOfWork != null)
					{
						unitOfWork.Dispose();
						unitOfWork = null;
					}
				}
			}
			// **************************************************
			// /UnitOfWork - Just Update The User with Id -> Save The User Changes To Database
			// **************************************************

			// **************************************************
			// DatabaseContext - Get The User From Database -> Delete The User
			// **************************************************
			{
				Models.DatabaseContext databaseContext = null;

				try
				{
					databaseContext =
						new Models.DatabaseContext();

					//Models.User user =
					//	databaseContext.Users
					//	.Where(current => current.Id == id)
					//	.FirstOrDefault();

					Models.User user =
						databaseContext.Users
						.Where(current => string.Compare(current.Username, username, true) == 0)
						.FirstOrDefault();

					if (user != null)
					{
						databaseContext.Users.Remove(user);

						databaseContext.SaveChanges();
					}
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message);
				}
				finally
				{
					if (databaseContext != null)
					{
						databaseContext.Dispose();
						databaseContext = null;
					}
				}
			}
			// **************************************************
			// /DatabaseContext - Get The User From Database -> Delete The User
			// **************************************************

			// **************************************************
			// UnitOfWork - Get The User From Database -> Delete The User
			// **************************************************
			{
				Dal.UnitOfWork unitOfWork = null;

				try
				{
					unitOfWork =
						new Dal.UnitOfWork();

					//Models.User user =
					//	unitOfWork.UserRepository.GetById(id);

					Models.User user =
						unitOfWork.UserRepository.GetByUsername(username);

					if (user != null)
					{
						unitOfWork.UserRepository.Delete(user);

						unitOfWork.Save();
					}
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message);
				}
				finally
				{
					if (unitOfWork != null)
					{
						unitOfWork.Dispose();
						unitOfWork = null;
					}
				}
			}
			// **************************************************
			// /UnitOfWork - Get The User From Database -> Delete The User
			// **************************************************

			// **************************************************
			// DatabaseContext - Just Delete The User with Id
			// **************************************************
			{
				Models.DatabaseContext databaseContext = null;

				try
				{
					databaseContext =
						new Models.DatabaseContext();

					Models.User user = new Models.User();

					user.Id = id;

					databaseContext.Entry(user).State =
						System.Data.Entity.EntityState.Deleted;

					databaseContext.SaveChanges();
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message);
				}
				finally
				{
					if (databaseContext != null)
					{
						databaseContext.Dispose();
						databaseContext = null;
					}
				}
			}
			// **************************************************
			// /DatabaseContext - Just Delete The User with Id
			// **************************************************

			// **************************************************
			// UnitOfWork - Just Delete The User with Id
			// **************************************************
			{
				Dal.UnitOfWork unitOfWork = null;

				try
				{
					unitOfWork =
						new Dal.UnitOfWork();

					Models.User user = new Models.User();

					user.Id = id;

					unitOfWork.UserRepository.Delete(user);

					unitOfWork.Save();
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message);
				}
				finally
				{
					if (unitOfWork != null)
					{
						unitOfWork.Dispose();
						unitOfWork = null;
					}
				}
			}
			// **************************************************
			// /UnitOfWork - Just Delete The User with Id
			// **************************************************

			// **************************************************
			// DatabaseContext - Get Users For Filling DropDownList
			// **************************************************
			{
				Models.DatabaseContext databaseContext = null;

				try
				{
					databaseContext =
						new Models.DatabaseContext();

					//var users =
					//	databaseContext.Users
					//	.ToList()
					//	;

					//var users =
					//	databaseContext.Users
					//	.OrderBy(current => current.Username)
					//	.ToList()
					//	;

					var users =
						databaseContext.Users
						.Where(current => current.IsActive)
						.OrderBy(current => current.Username)
						.ToList()
						;

					//var users =
					//	databaseContext.Users
					//	.Where(current => current.IsActive)
					//	.Where(current => current.IsDeleted == false)
					//	.OrderBy(current => current.Username)
					//	.ToList()
					//	;
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message);
				}
				finally
				{
					if (databaseContext != null)
					{
						databaseContext.Dispose();
						databaseContext = null;
					}
				}
			}
			// **************************************************
			// /DatabaseContext - Get Users For Filling DropDownList
			// **************************************************

			// **************************************************
			// UnitOfWork - Get Users For Filling DropDownList
			// **************************************************
			{
				Dal.UnitOfWork unitOfWork = null;

				try
				{
					unitOfWork =
						new Dal.UnitOfWork();

					var users =
						unitOfWork.UserRepository.GetActiveUsers();
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message);
				}
				finally
				{
					if (unitOfWork != null)
					{
						unitOfWork.Dispose();
						unitOfWork = null;
					}
				}
			}
			// **************************************************
			// /UnitOfWork - Get Users For Filling DropDownList
			// **************************************************
		}
	}
}
