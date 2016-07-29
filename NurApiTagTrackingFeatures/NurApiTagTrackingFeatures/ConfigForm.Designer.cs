namespace NurApiTagTrackingFeatures 
{
    partial class ConfigForm
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.physAntListView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checklist_flags = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checklist_events = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(12, 390);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(263, 209);
            this.propertyGrid1.TabIndex = 0;
            // 
            // physAntListView
            // 
            this.physAntListView.CheckBoxes = true;
            this.physAntListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.physAntListView.Location = new System.Drawing.Point(12, 12);
            this.physAntListView.Name = "physAntListView";
            this.physAntListView.Size = new System.Drawing.Size(263, 186);
            this.physAntListView.TabIndex = 2;
            this.physAntListView.UseCompatibleStateImageBehavior = false;
            this.physAntListView.View = System.Windows.Forms.View.Details;
            this.physAntListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.physAntListView_ItemChecked);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Physical Antenna";
            this.columnHeader2.Width = 230;
            // 
            // checklist_flags
            // 
            this.checklist_flags.FormattingEnabled = true;
            this.checklist_flags.Location = new System.Drawing.Point(12, 217);
            this.checklist_flags.Name = "checklist_flags";
            this.checklist_flags.Size = new System.Drawing.Size(262, 64);
            this.checklist_flags.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Flags";
            // 
            // checklist_events
            // 
            this.checklist_events.FormattingEnabled = true;
            this.checklist_events.Location = new System.Drawing.Point(12, 305);
            this.checklist_events.Name = "checklist_events";
            this.checklist_events.Size = new System.Drawing.Size(262, 79);
            this.checklist_events.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Events";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 611);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checklist_events);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checklist_flags);
            this.Controls.Add(this.physAntListView);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "ConfigForm";
            this.Text = "Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.ConfigForm_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ListView physAntListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.CheckedListBox checklist_flags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checklist_events;
        private System.Windows.Forms.Label label2;
    }
}