namespace RedcapService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRedcapDET : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RedcapDETs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.String(maxLength: 255),
                        UserName = c.String(maxLength: 255),
                        Instrument = c.String(maxLength: 255),
                        RecordName = c.String(maxLength: 255),
                        EventName = c.String(maxLength: 255),
                        ProjectUrl = c.String(maxLength: 255),
                        TriggerTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RedcapDETs");
        }
    }
}
