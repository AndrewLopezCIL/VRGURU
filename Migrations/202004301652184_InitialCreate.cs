namespace Chapter4CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BundlesModels",
                c => new
                    {
                        BundleID = c.Int(nullable: false, identity: true),
                        HeadsetBundledID = c.Int(nullable: false),
                        BundledItem = c.String(),
                    })
                .PrimaryKey(t => t.BundleID)
                .ForeignKey("dbo.VRHeadsetModels", t => t.HeadsetBundledID, cascadeDelete: true)
                .Index(t => t.HeadsetBundledID);
            
            CreateTable(
                "dbo.StoresModels",
                c => new
                    {
                        StoreID = c.Int(nullable: false),
                        StoreName = c.String(),
                    })
                .PrimaryKey(t => t.StoreID);
            
            CreateTable(
                "dbo.VRHeadsetModels",
                c => new
                    {
                        HeadsetID = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        AvailableStoreName = c.String(),
                        HeadsetName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HeadsetID);
            
            CreateTable(
                "dbo.StoreBundles",
                c => new
                    {
                        StoreID = c.Int(nullable: false),
                        BundleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoreID, t.BundleID })
                .ForeignKey("dbo.StoresModels", t => t.StoreID, cascadeDelete: true)
                .ForeignKey("dbo.BundlesModels", t => t.BundleID, cascadeDelete: true)
                .Index(t => t.StoreID)
                .Index(t => t.BundleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BundlesModels", "HeadsetBundledID", "dbo.VRHeadsetModels");
            DropForeignKey("dbo.StoreBundles", "BundleID", "dbo.BundlesModels");
            DropForeignKey("dbo.StoreBundles", "StoreID", "dbo.StoresModels");
            DropIndex("dbo.StoreBundles", new[] { "BundleID" });
            DropIndex("dbo.StoreBundles", new[] { "StoreID" });
            DropIndex("dbo.BundlesModels", new[] { "HeadsetBundledID" });
            DropTable("dbo.StoreBundles");
            DropTable("dbo.VRHeadsetModels");
            DropTable("dbo.StoresModels");
            DropTable("dbo.BundlesModels");
        }
    }
}
