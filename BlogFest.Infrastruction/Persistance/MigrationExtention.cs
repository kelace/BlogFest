using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogFest.Infrastruction.Persistance
{
    public static class MigrationExtention
    {
        public static void AddTriggers(this MigrationBuilder builder)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Persistance", "SQL_Scripts", "Triggers", "AddTriggers.sql");
            var sqlTriggers = File.ReadAllText(path);
            builder.Sql(sqlTriggers);
        }

        public static void DropTriggers(this MigrationBuilder builder)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Persistance", "SQL_Scripts", "Triggers", "DropTriggers.sql");
            var sqlTriggers = File.ReadAllText(path);
            builder.Sql(sqlTriggers);
        }
    }
}
