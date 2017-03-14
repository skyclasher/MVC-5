namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Profile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirsName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        Date_of_Birth = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 60),
                        City = c.String(maxLength: 60),
                        State = c.String(maxLength: 60),
                        Postal = c.String(maxLength: 60),
                        Gender = c.String(nullable: false, maxLength: 1),
                        Department = c.String(nullable: false, maxLength: 60),
                        Designation = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Profiles");
        }
    }
}
