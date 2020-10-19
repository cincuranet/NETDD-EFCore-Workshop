using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;

namespace DAL
{
	// ReplaceService<IHistoryRepository, MyHistoryRepository>()
	class MyHistoryRepository : SqlServerHistoryRepository
	{
		public MyHistoryRepository(HistoryRepositoryDependencies dependencies)
			: base(dependencies)
		{ }
	}
}
