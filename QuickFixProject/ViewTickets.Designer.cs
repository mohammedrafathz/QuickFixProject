namespace QuickFixProject
{
    partial class ViewTickets
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
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ticketId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.details = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTickets
            // 
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ticketId,
            this.locations,
            this.customerName,
            this.details});
            this.dgvTickets.Location = new System.Drawing.Point(92, 69);
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.RowHeadersWidth = 51;
            this.dgvTickets.RowTemplate.Height = 24;
            this.dgvTickets.Size = new System.Drawing.Size(768, 450);
            this.dgvTickets.TabIndex = 0;
            this.dgvTickets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTickets_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(306, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "Open Tickets";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ticketId
            // 
            this.ticketId.Frozen = true;
            this.ticketId.HeaderText = "Ticket ID";
            this.ticketId.MinimumWidth = 6;
            this.ticketId.Name = "ticketId";
            this.ticketId.Width = 125;
            // 
            // locations
            // 
            this.locations.Frozen = true;
            this.locations.HeaderText = "Location";
            this.locations.MinimumWidth = 6;
            this.locations.Name = "locations";
            this.locations.Width = 125;
            // 
            // customerName
            // 
            this.customerName.HeaderText = "Customer Name";
            this.customerName.MinimumWidth = 6;
            this.customerName.Name = "customerName";
            this.customerName.Width = 125;
            // 
            // details
            // 
            this.details.HeaderText = "Details";
            this.details.MinimumWidth = 6;
            this.details.Name = "details";
            this.details.Width = 125;
            // 
            // ViewTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 602);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTickets);
            this.Name = "ViewTickets";
            this.Text = "ViewTickets";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTickets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketId;
        private System.Windows.Forms.DataGridViewTextBoxColumn locations;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewLinkColumn details;
    }
}