namespace OAuth2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MSAdbv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cbpmsadeliveryconfpayloads",
                c => new
                    {
                        CbpmsadeliveryconfpayloadID = c.Int(nullable: false, identity: true),
                        customerUniqueId = c.String(),
                        marketerReceiptNumber = c.String(),
                        originalMarketerReceiptNumber = c.String(),
                        orderNumber = c.String(),
                        lineNumber = c.String(),
                        marketerAccountNumber = c.String(),
                        customerAccountNumber = c.String(),
                        orderDate = c.String(),
                        deliveryDate = c.String(),
                        transactionType = c.String(),
                        poNumber = c.String(),
                        releaseNumber = c.String(),
                        productCode = c.String(),
                        packageCode = c.String(),
                        numberOrdered = c.String(),
                        deliveredQuantity = c.String(),
                        requisitionNumber = c.String(),
                        jobNumber = c.String(),
                        unitNumber = c.String(),
                        corporatePurchaseOrderID = c.String(),
                        blanketPurchaseOrder = c.String(),
                        automaticSendIndicator = c.String(),
                        drumToteToBulkIndicator = c.String(),
                        serviceFees = c.String(),
                        partialDelivery = c.String(),
                        Uploaded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CbpmsadeliveryconfpayloadID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cbpmsadeliveryconfpayloads");
        }
    }
}
