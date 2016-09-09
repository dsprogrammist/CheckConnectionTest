namespace TracertForm
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.DE
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.destination = new System.Windows.Forms.TextBox();
            this.startTrace = new System.Windows.Forms.Button();
            this.routeList = new System.Windows.Forms.ListView();
            this.hostIPHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hopHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hostNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.roundTripTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.close = new System.Windows.Forms.Button();
            this.tracert = new VRK.Net.Tracert();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(111, 13);
            label1.TabIndex = 0;
            label1.Text = "&Адрес или имя узла:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 39);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 13);
            label2.TabIndex = 4;
            label2.Text = "&Маршрут:";
            // 
            // destination
            // 
            this.destination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destination.Location = new System.Drawing.Point(129, 13);
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(170, 20);
            this.destination.TabIndex = 1;
            // 
            // startTrace
            // 
            this.startTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startTrace.Location = new System.Drawing.Point(316, 12);
            this.startTrace.Name = "startTrace";
            this.startTrace.Size = new System.Drawing.Size(75, 23);
            this.startTrace.TabIndex = 2;
            this.startTrace.Text = "&Начать трассировку";
            this.startTrace.UseVisualStyleBackColor = true;
            this.startTrace.Click += new System.EventHandler(this.startTrace_Click);
            // 
            // routeList
            // 
            this.routeList.AllowColumnReorder = true;
            this.routeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.routeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hostIPHeader,
            this.hopHeader,
            this.hostNameHeader,
            this.roundTripTimeHeader});
            this.routeList.GridLines = true;
            this.routeList.Location = new System.Drawing.Point(12, 58);
            this.routeList.Name = "routeList";
            this.routeList.Size = new System.Drawing.Size(379, 217);
            this.routeList.TabIndex = 3;
            this.routeList.UseCompatibleStateImageBehavior = false;
            this.routeList.View = System.Windows.Forms.View.Details;
            // 
            // hostIPHeader
            // 
            this.hostIPHeader.DisplayIndex = 1;
            this.hostIPHeader.Text = "Узел";
            this.hostIPHeader.Width = 119;
            // 
            // hopHeader
            // 
            this.hopHeader.DisplayIndex = 0;
            this.hopHeader.Text = "Переход";
            this.hopHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hopHeader.Width = 56;
            // 
            // hostNameHeader
            // 
            this.hostNameHeader.Text = "Имя узла";
            this.hostNameHeader.Width = 141;
            // 
            // roundTripTimeHeader
            // 
            this.roundTripTimeHeader.Text = "Время";
            this.roundTripTimeHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.roundTripTimeHeader.Width = 62;
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.Location = new System.Drawing.Point(316, 281);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 5;
            this.close.Text = "&Закрыть";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // tracert
            // 
            this.tracert.HostNameOrAddress = null;
            this.tracert.MaxHops = 30;
            this.tracert.TimeOut = 5000;
            this.tracert.Done += new System.EventHandler(this.tracert_Done);
            this.tracert.RouteNodeFound += new System.EventHandler<VRK.Net.RouteNodeFoundEventArgs>(this.tracert_RouteNodeFound);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 309);
            this.Controls.Add(this.close);
            this.Controls.Add(label2);
            this.Controls.Add(this.routeList);
            this.Controls.Add(this.startTrace);
            this.Controls.Add(this.destination);
            this.Controls.Add(label1);
            this.Name = "MainForm";
            this.Text = "Трассировка маршрута";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox destination;
		private System.Windows.Forms.Button startTrace;
		private System.Windows.Forms.ListView routeList;
		private VRK.Net.Tracert tracert;
		private System.Windows.Forms.Button close;
		private System.Windows.Forms.ColumnHeader hostIPHeader;
		private System.Windows.Forms.ColumnHeader hopHeader;
		private System.Windows.Forms.ColumnHeader hostNameHeader;
		private System.Windows.Forms.ColumnHeader roundTripTimeHeader;
	}
}

