//using Infragistics.Win.UltraWinEditors;

namespace OAuth2
{
    partial class MSAForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label deliveredQuantityLabel;
            System.Windows.Forms.Label productCodeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MSAForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnHost = new System.Windows.Forms.Button();
            this.msaBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.msaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.claimBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.msiIdTextBox = new System.Windows.Forms.TextBox();
            this.dateDateTimePickerDelivery = new System.Windows.Forms.DateTimePicker();
            this.txtCustomerUniqueID = new System.Windows.Forms.TextBox();
            this.txtCustomerAccountNumber = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtMarketerReceiptNumber = new System.Windows.Forms.TextBox();
            this.txtOriginalMarketerReceiptNumber = new System.Windows.Forms.TextBox();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.txtLineNumber = new System.Windows.Forms.TextBox();
            this.txtMarketerAccountNumber = new System.Windows.Forms.TextBox();
            this.txtTransactionType = new System.Windows.Forms.TextBox();
            this.txtPONumber = new System.Windows.Forms.TextBox();
            this.txtReleaseNumber = new System.Windows.Forms.TextBox();
            this.txtNumberOrdered = new System.Windows.Forms.TextBox();
            this.txtDrumToteToBulkIndicator = new OAuth2.NumericTextBox();
            this.txtUnitNumber = new OAuth2.NumericTextBox();
            this.txtPartialDelivery = new OAuth2.NumericTextBox();
            this.txtServiceFees = new OAuth2.NumericTextBox();
            this.txtAutomaticSendIndicator = new OAuth2.NumericTextBox();
            this.txtBlanketPurchaseOrder = new OAuth2.NumericTextBox();
            this.txtCorporatePurchaseOrderId = new OAuth2.NumericTextBox();
            this.txtJobNumber = new OAuth2.NumericTextBox();
            this.txtRequistionNumber = new OAuth2.NumericTextBox();
            this.txtDeliveredQty = new OAuth2.NumericTextBox();
            this.txtPackageCode = new OAuth2.NumericTextBox();
            this.txtProductCode = new OAuth2.NumericTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            deliveredQuantityLabel = new System.Windows.Forms.Label();
            productCodeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.msaBindingNavigator)).BeginInit();
            this.msaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msaBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deliveredQuantityLabel
            // 
            deliveredQuantityLabel.AutoSize = true;
            deliveredQuantityLabel.Location = new System.Drawing.Point(527, 170);
            deliveredQuantityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            deliveredQuantityLabel.Name = "deliveredQuantityLabel";
            deliveredQuantityLabel.Size = new System.Drawing.Size(117, 16);
            deliveredQuantityLabel.TabIndex = 43;
            deliveredQuantityLabel.Text = "Delivered Quantity";
            // 
            // productCodeLabel
            // 
            productCodeLabel.AutoSize = true;
            productCodeLabel.Location = new System.Drawing.Point(527, 86);
            productCodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            productCodeLabel.Name = "productCodeLabel";
            productCodeLabel.Size = new System.Drawing.Size(92, 16);
            productCodeLabel.TabIndex = 40;
            productCodeLabel.Text = "Product Code:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 409);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Delivery Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 327);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(166, 16);
            this.label11.TabIndex = 23;
            this.label11.Text = "Customer Account Number";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(48, 84);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 16);
            this.label12.TabIndex = 21;
            this.label12.Text = "Customer unique id";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(527, 129);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 16);
            this.label14.TabIndex = 25;
            this.label14.Text = "Package Code";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(306, 609);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 26;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnHost
            // 
            this.btnHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHost.ForeColor = System.Drawing.Color.Red;
            this.btnHost.Location = new System.Drawing.Point(675, 605);
            this.btnHost.Margin = new System.Windows.Forms.Padding(4);
            this.btnHost.Name = "btnHost";
            this.btnHost.Size = new System.Drawing.Size(147, 34);
            this.btnHost.TabIndex = 27;
            this.btnHost.Text = "UPLOAD MSA";
            this.btnHost.UseVisualStyleBackColor = true;
            this.btnHost.Click += new System.EventHandler(this.btnHost_Click);
            // 
            // msaBindingNavigator
            // 
            this.msaBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.msaBindingNavigator.BindingSource = this.msaBindingSource;
            this.msaBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.msaBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.msaBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msaBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.claimBindingNavigatorSaveItem,
            this.toolStripButton1});
            this.msaBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.msaBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.msaBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.msaBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.msaBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.msaBindingNavigator.Name = "msaBindingNavigator";
            this.msaBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.msaBindingNavigator.Size = new System.Drawing.Size(1032, 27);
            this.msaBindingNavigator.TabIndex = 32;
            this.msaBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(65, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // claimBindingNavigatorSaveItem
            // 
            this.claimBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.claimBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("claimBindingNavigatorSaveItem.Image")));
            this.claimBindingNavigatorSaveItem.Name = "claimBindingNavigatorSaveItem";
            this.claimBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 24);
            this.claimBindingNavigatorSaveItem.Text = "Save Data";
            this.claimBindingNavigatorSaveItem.Click += new System.EventHandler(this.claimBindingNavigatorSaveItem_Click);
            // 
            // msiIdTextBox
            // 
            this.msiIdTextBox.Location = new System.Drawing.Point(259, 37);
            this.msiIdTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.msiIdTextBox.Name = "msiIdTextBox";
            this.msiIdTextBox.ReadOnly = true;
            this.msiIdTextBox.Size = new System.Drawing.Size(147, 22);
            this.msiIdTextBox.TabIndex = 0;
            this.msiIdTextBox.TabStop = false;
            // 
            // dateDateTimePickerDelivery
            // 
            this.dateDateTimePickerDelivery.Location = new System.Drawing.Point(183, 414);
            this.dateDateTimePickerDelivery.Margin = new System.Windows.Forms.Padding(4);
            this.dateDateTimePickerDelivery.Name = "dateDateTimePickerDelivery";
            this.dateDateTimePickerDelivery.Size = new System.Drawing.Size(265, 22);
            this.dateDateTimePickerDelivery.TabIndex = 9;
            // 
            // txtCustomerUniqueID
            // 
            this.txtCustomerUniqueID.Location = new System.Drawing.Point(259, 79);
            this.txtCustomerUniqueID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerUniqueID.Name = "txtCustomerUniqueID";
            this.txtCustomerUniqueID.Size = new System.Drawing.Size(147, 22);
            this.txtCustomerUniqueID.TabIndex = 1;
            // 
            // txtCustomerAccountNumber
            // 
            this.txtCustomerAccountNumber.Location = new System.Drawing.Point(259, 330);
            this.txtCustomerAccountNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerAccountNumber.Name = "txtCustomerAccountNumber";
            this.txtCustomerAccountNumber.Size = new System.Drawing.Size(147, 22);
            this.txtCustomerAccountNumber.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 670);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1032, 22);
            this.statusStrip1.TabIndex = 46;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 16);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 16);
            this.label2.TabIndex = 47;
            this.label2.Text = "Marketer Receipt Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 165);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 16);
            this.label5.TabIndex = 48;
            this.label5.Text = "Original Marketer Receipt Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 206);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 49;
            this.label6.Text = "Order Number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 246);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 50;
            this.label7.Text = "Line Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 287);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 16);
            this.label8.TabIndex = 51;
            this.label8.Text = "Marketer Account Number";
            // 
            // dateTimePickerOrderDate
            // 
            this.dateTimePickerOrderDate.Location = new System.Drawing.Point(183, 372);
            this.dateTimePickerOrderDate.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
            this.dateTimePickerOrderDate.Size = new System.Drawing.Size(265, 22);
            this.dateTimePickerOrderDate.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 368);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 53;
            this.label3.Text = "Order Date";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(48, 449);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 16);
            this.label13.TabIndex = 54;
            this.label13.Text = "Transaction Type";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(48, 490);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 16);
            this.label15.TabIndex = 55;
            this.label15.Text = "PO Number";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(49, 543);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 16);
            this.label16.TabIndex = 56;
            this.label16.Text = "Release Number";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(527, 41);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 16);
            this.label9.TabIndex = 57;
            this.label9.Text = "Number Ordered";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(527, 215);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 16);
            this.label10.TabIndex = 58;
            this.label10.Text = "Requisition Number";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(527, 258);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 16);
            this.label17.TabIndex = 59;
            this.label17.Text = "Job Number";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(527, 297);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 16);
            this.label18.TabIndex = 60;
            this.label18.Text = "Unit Number";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(527, 341);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(180, 16);
            this.label19.TabIndex = 61;
            this.label19.Text = "Corporate Purchase Order ID";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(527, 382);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(149, 16);
            this.label20.TabIndex = 62;
            this.label20.Text = "Blanket Purchase Order";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(527, 421);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(155, 16);
            this.label21.TabIndex = 63;
            this.label21.Text = "Automatic Send Indicator";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(527, 463);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(173, 16);
            this.label22.TabIndex = 64;
            this.label22.Text = "Drum Tote To Bulk Indicator";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(527, 508);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(87, 16);
            this.label23.TabIndex = 65;
            this.label23.Text = "Service Fees";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(527, 546);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(95, 16);
            this.label24.TabIndex = 66;
            this.label24.Text = "PartialDelivery";
            // 
            // txtMarketerReceiptNumber
            // 
            this.txtMarketerReceiptNumber.Location = new System.Drawing.Point(259, 121);
            this.txtMarketerReceiptNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtMarketerReceiptNumber.Name = "txtMarketerReceiptNumber";
            this.txtMarketerReceiptNumber.Size = new System.Drawing.Size(147, 22);
            this.txtMarketerReceiptNumber.TabIndex = 2;
            // 
            // txtOriginalMarketerReceiptNumber
            // 
            this.txtOriginalMarketerReceiptNumber.Location = new System.Drawing.Point(259, 162);
            this.txtOriginalMarketerReceiptNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtOriginalMarketerReceiptNumber.Name = "txtOriginalMarketerReceiptNumber";
            this.txtOriginalMarketerReceiptNumber.Size = new System.Drawing.Size(147, 22);
            this.txtOriginalMarketerReceiptNumber.TabIndex = 3;
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(259, 204);
            this.txtOrderNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(147, 22);
            this.txtOrderNumber.TabIndex = 4;
            // 
            // txtLineNumber
            // 
            this.txtLineNumber.Location = new System.Drawing.Point(259, 246);
            this.txtLineNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtLineNumber.Name = "txtLineNumber";
            this.txtLineNumber.Size = new System.Drawing.Size(147, 22);
            this.txtLineNumber.TabIndex = 5;
            // 
            // txtMarketerAccountNumber
            // 
            this.txtMarketerAccountNumber.Location = new System.Drawing.Point(259, 288);
            this.txtMarketerAccountNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtMarketerAccountNumber.Name = "txtMarketerAccountNumber";
            this.txtMarketerAccountNumber.Size = new System.Drawing.Size(147, 22);
            this.txtMarketerAccountNumber.TabIndex = 6;
            // 
            // txtTransactionType
            // 
            this.txtTransactionType.Location = new System.Drawing.Point(259, 455);
            this.txtTransactionType.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransactionType.Name = "txtTransactionType";
            this.txtTransactionType.Size = new System.Drawing.Size(147, 22);
            this.txtTransactionType.TabIndex = 10;
            // 
            // txtPONumber
            // 
            this.txtPONumber.Location = new System.Drawing.Point(259, 497);
            this.txtPONumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPONumber.Name = "txtPONumber";
            this.txtPONumber.Size = new System.Drawing.Size(147, 22);
            this.txtPONumber.TabIndex = 11;
            // 
            // txtReleaseNumber
            // 
            this.txtReleaseNumber.Location = new System.Drawing.Point(259, 543);
            this.txtReleaseNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtReleaseNumber.Name = "txtReleaseNumber";
            this.txtReleaseNumber.Size = new System.Drawing.Size(147, 22);
            this.txtReleaseNumber.TabIndex = 12;
            // 
            // txtNumberOrdered
            // 
            this.txtNumberOrdered.Location = new System.Drawing.Point(729, 41);
            this.txtNumberOrdered.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumberOrdered.Name = "txtNumberOrdered";
            this.txtNumberOrdered.Size = new System.Drawing.Size(132, 22);
            this.txtNumberOrdered.TabIndex = 13;
            // 
            // txtDrumToteToBulkIndicator
            // 
            this.txtDrumToteToBulkIndicator.AllowCurrency = false;
            this.txtDrumToteToBulkIndicator.EnforceDecimal = true;
            this.txtDrumToteToBulkIndicator.Location = new System.Drawing.Point(729, 460);
            this.txtDrumToteToBulkIndicator.Margin = new System.Windows.Forms.Padding(4);
            this.txtDrumToteToBulkIndicator.Name = "txtDrumToteToBulkIndicator";
            this.txtDrumToteToBulkIndicator.Size = new System.Drawing.Size(132, 22);
            this.txtDrumToteToBulkIndicator.TabIndex = 23;
            // 
            // txtUnitNumber
            // 
            this.txtUnitNumber.AllowCurrency = false;
            this.txtUnitNumber.EnforceDecimal = true;
            this.txtUnitNumber.Location = new System.Drawing.Point(729, 290);
            this.txtUnitNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnitNumber.Name = "txtUnitNumber";
            this.txtUnitNumber.Size = new System.Drawing.Size(132, 22);
            this.txtUnitNumber.TabIndex = 19;
            // 
            // txtPartialDelivery
            // 
            this.txtPartialDelivery.AllowCurrency = false;
            this.txtPartialDelivery.EnforceDecimal = true;
            this.txtPartialDelivery.Location = new System.Drawing.Point(728, 539);
            this.txtPartialDelivery.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartialDelivery.Name = "txtPartialDelivery";
            this.txtPartialDelivery.Size = new System.Drawing.Size(132, 22);
            this.txtPartialDelivery.TabIndex = 25;
            // 
            // txtServiceFees
            // 
            this.txtServiceFees.AllowCurrency = false;
            this.txtServiceFees.EnforceDecimal = true;
            this.txtServiceFees.Location = new System.Drawing.Point(729, 505);
            this.txtServiceFees.Margin = new System.Windows.Forms.Padding(4);
            this.txtServiceFees.Name = "txtServiceFees";
            this.txtServiceFees.Size = new System.Drawing.Size(132, 22);
            this.txtServiceFees.TabIndex = 24;
            // 
            // txtAutomaticSendIndicator
            // 
            this.txtAutomaticSendIndicator.AllowCurrency = false;
            this.txtAutomaticSendIndicator.EnforceDecimal = true;
            this.txtAutomaticSendIndicator.Location = new System.Drawing.Point(728, 417);
            this.txtAutomaticSendIndicator.Margin = new System.Windows.Forms.Padding(4);
            this.txtAutomaticSendIndicator.Name = "txtAutomaticSendIndicator";
            this.txtAutomaticSendIndicator.Size = new System.Drawing.Size(132, 22);
            this.txtAutomaticSendIndicator.TabIndex = 22;
            // 
            // txtBlanketPurchaseOrder
            // 
            this.txtBlanketPurchaseOrder.AllowCurrency = false;
            this.txtBlanketPurchaseOrder.EnforceDecimal = true;
            this.txtBlanketPurchaseOrder.Location = new System.Drawing.Point(729, 374);
            this.txtBlanketPurchaseOrder.Margin = new System.Windows.Forms.Padding(4);
            this.txtBlanketPurchaseOrder.Name = "txtBlanketPurchaseOrder";
            this.txtBlanketPurchaseOrder.Size = new System.Drawing.Size(132, 22);
            this.txtBlanketPurchaseOrder.TabIndex = 21;
            // 
            // txtCorporatePurchaseOrderId
            // 
            this.txtCorporatePurchaseOrderId.AllowCurrency = false;
            this.txtCorporatePurchaseOrderId.EnforceDecimal = true;
            this.txtCorporatePurchaseOrderId.Location = new System.Drawing.Point(729, 331);
            this.txtCorporatePurchaseOrderId.Margin = new System.Windows.Forms.Padding(4);
            this.txtCorporatePurchaseOrderId.Name = "txtCorporatePurchaseOrderId";
            this.txtCorporatePurchaseOrderId.Size = new System.Drawing.Size(132, 22);
            this.txtCorporatePurchaseOrderId.TabIndex = 20;
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.AllowCurrency = false;
            this.txtJobNumber.EnforceDecimal = true;
            this.txtJobNumber.Location = new System.Drawing.Point(729, 247);
            this.txtJobNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.Size = new System.Drawing.Size(132, 22);
            this.txtJobNumber.TabIndex = 18;
            // 
            // txtRequistionNumber
            // 
            this.txtRequistionNumber.AllowCurrency = false;
            this.txtRequistionNumber.EnforceDecimal = true;
            this.txtRequistionNumber.Location = new System.Drawing.Point(729, 213);
            this.txtRequistionNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtRequistionNumber.Name = "txtRequistionNumber";
            this.txtRequistionNumber.Size = new System.Drawing.Size(132, 22);
            this.txtRequistionNumber.TabIndex = 17;
            // 
            // txtDeliveredQty
            // 
            this.txtDeliveredQty.AllowCurrency = false;
            this.txtDeliveredQty.EnforceDecimal = true;
            this.txtDeliveredQty.Location = new System.Drawing.Point(729, 164);
            this.txtDeliveredQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeliveredQty.Name = "txtDeliveredQty";
            this.txtDeliveredQty.Size = new System.Drawing.Size(132, 22);
            this.txtDeliveredQty.TabIndex = 16;
            // 
            // txtPackageCode
            // 
            this.txtPackageCode.AllowCurrency = false;
            this.txtPackageCode.EnforceDecimal = true;
            this.txtPackageCode.Location = new System.Drawing.Point(729, 119);
            this.txtPackageCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtPackageCode.MaxLength = 3;
            this.txtPackageCode.Name = "txtPackageCode";
            this.txtPackageCode.Size = new System.Drawing.Size(132, 22);
            this.txtPackageCode.TabIndex = 15;
            // 
            // txtProductCode
            // 
            this.txtProductCode.AllowCurrency = false;
            this.txtProductCode.EnforceDecimal = true;
            this.txtProductCode.Location = new System.Drawing.Point(729, 79);
            this.txtProductCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductCode.MaxLength = 6;
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(132, 22);
            this.txtProductCode.TabIndex = 14;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // MSAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 692);
            this.Controls.Add(this.txtDrumToteToBulkIndicator);
            this.Controls.Add(this.txtUnitNumber);
            this.Controls.Add(this.txtPartialDelivery);
            this.Controls.Add(this.txtServiceFees);
            this.Controls.Add(this.txtAutomaticSendIndicator);
            this.Controls.Add(this.txtBlanketPurchaseOrder);
            this.Controls.Add(this.txtCorporatePurchaseOrderId);
            this.Controls.Add(this.txtJobNumber);
            this.Controls.Add(this.txtRequistionNumber);
            this.Controls.Add(this.txtDeliveredQty);
            this.Controls.Add(this.txtNumberOrdered);
            this.Controls.Add(this.txtReleaseNumber);
            this.Controls.Add(this.txtPONumber);
            this.Controls.Add(this.txtTransactionType);
            this.Controls.Add(this.txtMarketerAccountNumber);
            this.Controls.Add(this.txtLineNumber);
            this.Controls.Add(this.txtOrderNumber);
            this.Controls.Add(this.txtOriginalMarketerReceiptNumber);
            this.Controls.Add(this.txtMarketerReceiptNumber);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dateTimePickerOrderDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtPackageCode);
            this.Controls.Add(this.txtCustomerAccountNumber);
            this.Controls.Add(this.txtCustomerUniqueID);
            this.Controls.Add(deliveredQuantityLabel);
            this.Controls.Add(productCodeLabel);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.dateDateTimePickerDelivery);
            this.Controls.Add(this.msiIdTextBox);
            this.Controls.Add(this.msaBindingNavigator);
            this.Controls.Add(this.btnHost);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MSAForm";
            this.Text = "MSA Entry";
            this.Load += new System.EventHandler(this.DataCollection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.msaBindingNavigator)).EndInit();
            this.msaBindingNavigator.ResumeLayout(false);
            this.msaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msaBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnHost;
        private System.Windows.Forms.BindingSource msaBindingSource;
        private System.Windows.Forms.BindingNavigator msaBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton claimBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox msiIdTextBox;
        private System.Windows.Forms.DateTimePicker dateDateTimePickerDelivery;
        private System.Windows.Forms.TextBox txtCustomerUniqueID;
        private System.Windows.Forms.TextBox txtCustomerAccountNumber;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private NumericTextBox txtPackageCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerOrderDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private NumericTextBox txtProductCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtMarketerReceiptNumber;
        private System.Windows.Forms.TextBox txtOriginalMarketerReceiptNumber;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.TextBox txtLineNumber;
        private System.Windows.Forms.TextBox txtMarketerAccountNumber;
        private System.Windows.Forms.TextBox txtTransactionType;
        private System.Windows.Forms.TextBox txtPONumber;
        private System.Windows.Forms.TextBox txtReleaseNumber;
        private System.Windows.Forms.TextBox txtNumberOrdered;
        private NumericTextBox txtDeliveredQty;
        private NumericTextBox txtRequistionNumber;
        private NumericTextBox txtJobNumber;
        private NumericTextBox txtCorporatePurchaseOrderId;
        private NumericTextBox txtBlanketPurchaseOrder;
        private NumericTextBox txtAutomaticSendIndicator;
        private NumericTextBox txtServiceFees;
        private NumericTextBox txtPartialDelivery;
        private NumericTextBox txtUnitNumber;
        private NumericTextBox txtDrumToteToBulkIndicator;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}