using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class DatabaseContext : DbContext
	{
		static DatabaseContext()
		{
			// فقط به درد برنامه‌نويسان، آن هم در زمان پياده‌سازی می‌خورد
			//System.Data.Entity.Database.SetInitializer
			//	(new DropCreateDatabaseAlways<DatabaseContext>());

			// فقط به درد برنامه‌نويسان، آن هم در زمان پياده‌سازی می‌خورد
			Database.SetInitializer
				(new DropCreateDatabaseIfModelChanges<DatabaseContext>());

			// به درد مشتری می‌خورد
			//System.Data.Entity.Database.SetInitializer
			//	(new CreateDatabaseIfNotExists<DatabaseContext>());


			//Database.SetInitializer(new DatabaseContextInitializer());
		}
		public DatabaseContext(): base() 
		{

		}

		public DbSet<PageGroup> PageGroups { get; set; }

		public DbSet<Page> Pages { get; set; }

		public DbSet<PageComment> PageComments { get; set; }
	}
}
