namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Name, SignUpFee, DurationInMonths, DiscountRates) VALUES('Pay As You Go', 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes(Name, SignUpFee, DurationInMonths, DiscountRates) VALUES('Monthly', 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes(Name, SignUpFee, DurationInMonths, DiscountRates) VALUES('Quarterly', 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes(Name, SignUpFee, DurationInMonths, DiscountRates) VALUES('Annual', 600, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
