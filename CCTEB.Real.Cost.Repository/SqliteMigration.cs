using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCTEB.Real.Cost.Repository
{
    public class SqliteMigration
    {
        private readonly IServiceProvider _serviceProvider;
        private SqliteDbContext _context;


        public SqliteMigration(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _context = (SqliteDbContext)serviceProvider.GetService(typeof(SqliteDbContext));
        }

        public void Migrator()
        {


        }
    }
}
