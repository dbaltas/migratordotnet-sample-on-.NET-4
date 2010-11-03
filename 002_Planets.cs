using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Migrator.Framework;

namespace migro
{
	[Migration(2)]
	public class _001_Planets : Migration
	{
		public override void Up()
		{
			Database.AddTable("Planets",
				new Column("Id", DbType.Int32, ColumnProperty.PrimaryKeyWithIdentity),
				new Column("Name", DbType.String, 100, ColumnProperty.NotNull),
				new Column("Diameter", DbType.Double),
				new Column("Mass", DbType.Double),
				new Column("SupportsLife", DbType.Boolean, false)
			);
		}

		public override void Down()
		{
			Database.RemoveTable("Planets");
		}
	}
}
