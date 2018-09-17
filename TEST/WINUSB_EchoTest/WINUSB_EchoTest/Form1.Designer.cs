namespace WINUSB_EchoTest
{
   partial class Form1
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
         this.MsgBox = new System.Windows.Forms.ListBox();
         this.SendDataTextBox = new System.Windows.Forms.TextBox();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // MsgBox
         // 
         this.MsgBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.MsgBox.FormattingEnabled = true;
         this.MsgBox.Location = new System.Drawing.Point(425, 7);
         this.MsgBox.Name = "MsgBox";
         this.MsgBox.Size = new System.Drawing.Size(489, 446);
         this.MsgBox.TabIndex = 0;
         this.MsgBox.SelectedIndexChanged += new System.EventHandler(this.MsgBox_SelectedIndexChanged);
         // 
         // SendDataTextBox
         // 
         this.SendDataTextBox.Location = new System.Drawing.Point(27, 71);
         this.SendDataTextBox.Name = "SendDataTextBox";
         this.SendDataTextBox.Size = new System.Drawing.Size(382, 20);
         this.SendDataTextBox.TabIndex = 5;
         this.SendDataTextBox.Text = "30, 31,32, 33, 34, 35, 36, 37, 38, 39, 3A, 3B, 3C, 3D, 3E, 3F";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(27, 111);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(200, 59);
         this.button1.TabIndex = 6;
         this.button1.Text = "button1";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(914, 466);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.SendDataTextBox);
         this.Controls.Add(this.MsgBox);
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ListBox MsgBox;
      private System.Windows.Forms.TextBox SendDataTextBox;
      private System.Windows.Forms.Button button1;
   }
}

