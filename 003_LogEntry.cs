using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Migrator.Framework;
using System.Data;

namespace migro
{
	[Migration(3)]
	public class LogEntry : Migration
	{
		public override void Up()
		{
			Database.ExecuteNonQuery(
			@"
CREATE TABLE [dbo].[ErrorLog](
	[ErrorLogID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[ErrorLevelCode] [nvarchar](50) NULL,
	[ErrorSource] [nvarchar](100) NULL,
	[ErrorDescription] [nvarchar](1000) NULL,
	[CreatedBy] [numeric](18, 0) NULL,
	[CreatedDate] [smalldatetime] NULL CONSTRAINT [DF_ErrorLog_CreatedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[ErrorLogID] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
			");
		}

		public override void Down()
		{
			Database.ExecuteNonQuery(
@"drop TABLE [dbo].[ErrorLog]"
				);
		}
	}
}
