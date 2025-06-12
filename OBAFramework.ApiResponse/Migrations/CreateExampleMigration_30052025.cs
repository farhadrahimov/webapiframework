using FluentMigrator;
using OBAFramework.Domain.Models;

namespace OBAFramework.ApiResponse.Migrations
{
    [Migration(1)]
    public class CreateExampleMigration_30052025 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("ExampleTable")
               .WithColumn(nameof(ExampleModel.Id)).AsInt64().PrimaryKey().Identity().Unique().NotNullable()
               .WithColumn(nameof(ExampleModel.Name)).AsString(int.MaxValue).NotNullable();
        }
    }
}
