namespace CheckConnection
{
    partial class DisplayConnections
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayConnections));
            this.ConnectionsdataGridView = new System.Windows.Forms.DataGridView();
            this.HistorydataGridView = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.PingtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.TracerttoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ConnectionHistorylabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionsdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistorydataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectionsdataGridView
            // 
            this.ConnectionsdataGridView.AllowUserToAddRows = false;
            this.ConnectionsdataGridView.AllowUserToDeleteRows = false;
            this.ConnectionsdataGridView.AllowUserToOrderColumns = true;
            this.ConnectionsdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionsdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConnectionsdataGridView.Location = new System.Drawing.Point(0, 30);
            this.ConnectionsdataGridView.Name = "ConnectionsdataGridView";
            this.ConnectionsdataGridView.Size = new System.Drawing.Size(786, 128);
            this.ConnectionsdataGridView.TabIndex = 0;
            this.ConnectionsdataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ConnectionsdataGridView_CellEnter);
            // 
            // HistorydataGridView
            // 
            this.HistorydataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HistorydataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HistorydataGridView.Location = new System.Drawing.Point(0, 20);
            this.HistorydataGridView.Name = "HistorydataGridView";
            this.HistorydataGridView.Size = new System.Drawing.Size(786, 198);
            this.HistorydataGridView.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.ConnectionsdataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ConnectionHistorylabel);
            this.splitContainer1.Panel2.Controls.Add(this.HistorydataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(786, 386);
            this.splitContainer1.SplitterDistance = 161;
            this.splitContainer1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PingtoolStripButton,
            this.TracerttoolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(786, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // PingtoolStripButton
            // 
            this.PingtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PingtoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("PingtoolStripButton.Image")));
            this.PingtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PingtoolStripButton.Name = "PingtoolStripButton";
            this.PingtoolStripButton.Size = new System.Drawing.Size(23, 22);
            this.PingtoolStripButton.Text = "Ping";
            this.PingtoolStripButton.Click += new System.EventHandler(this.PingtoolStripButton_Click);
            // 
            // TracerttoolStripButton
            // 
            this.TracerttoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TracerttoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("TracerttoolStripButton.Image")));
            this.TracerttoolStripButton.ImageTransparentColor = System.Drawing.Color.Orange;
            this.TracerttoolStripButton.Name = "TracerttoolStripButton";
            this.TracerttoolStripButton.Size = new System.Drawing.Size(23, 22);
            this.TracerttoolStripButton.Text = "Tracert";
            this.TracerttoolStripButton.Click += new System.EventHandler(this.TracerttoolStripButton_Click);
            // 
            // ConnectionHistorylabel
            // 
            this.ConnectionHistorylabel.AutoSize = true;
            this.ConnectionHistorylabel.Location = new System.Drawing.Point(4, 4);
            this.ConnectionHistorylabel.Name = "ConnectionHistorylabel";
            this.ConnectionHistorylabel.Size = new System.Drawing.Size(120, 13);
            this.ConnectionHistorylabel.TabIndex = 2;
            this.ConnectionHistorylabel.Text = "История подключений";
            // 
            // DisplayConnections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 413);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DisplayConnections";
            this.Text = "Сетевые подключения";
            this.Load += new System.EventHandler(this.DisplayConnections_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionsdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistorydataGridView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ConnectionsdataGridView;
        private System.Windows.Forms.DataGridView HistorydataGridView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label ConnectionHistorylabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton PingtoolStripButton;
        private System.Windows.Forms.ToolStripButton TracerttoolStripButton;
    }
}