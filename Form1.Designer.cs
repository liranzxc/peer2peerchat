﻿namespace LiranNachmanPeer2PeerChat
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
            this.label1 = new System.Windows.Forms.Label();
            this.chatbox = new System.Windows.Forms.TextBox();
            this.messagebox = new System.Windows.Forms.TextBox();
            this.send = new System.Windows.Forms.Button();
            this.mylist = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clearSelect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.sendfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "chat p2p Liran Nachman";
            // 
            // chatbox
            // 
            this.chatbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatbox.Location = new System.Drawing.Point(56, 89);
            this.chatbox.Multiline = true;
            this.chatbox.Name = "chatbox";
            this.chatbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatbox.Size = new System.Drawing.Size(436, 425);
            this.chatbox.TabIndex = 1;
            // 
            // messagebox
            // 
            this.messagebox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messagebox.Location = new System.Drawing.Point(56, 536);
            this.messagebox.Name = "messagebox";
            this.messagebox.Size = new System.Drawing.Size(436, 29);
            this.messagebox.TabIndex = 2;
            this.messagebox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messagebox_KeyDown);
            // 
            // send
            // 
            this.send.BackColor = System.Drawing.SystemColors.Control;
            this.send.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.send.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.send.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.send.Location = new System.Drawing.Point(498, 536);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(87, 29);
            this.send.TabIndex = 3;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = false;
            this.send.Click += new System.EventHandler(this.button1_Click);
            // 
            // mylist
            // 
            this.mylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mylist.FormattingEnabled = true;
            this.mylist.ItemHeight = 20;
            this.mylist.Location = new System.Drawing.Point(529, 89);
            this.mylist.Name = "mylist";
            this.mylist.ScrollAlwaysVisible = true;
            this.mylist.Size = new System.Drawing.Size(216, 224);
            this.mylist.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(593, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "user list";
            // 
            // clearSelect
            // 
            this.clearSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearSelect.Location = new System.Drawing.Point(529, 330);
            this.clearSelect.Name = "clearSelect";
            this.clearSelect.Size = new System.Drawing.Size(216, 31);
            this.clearSelect.TabIndex = 6;
            this.clearSelect.Text = "Clear Select";
            this.clearSelect.UseVisualStyleBackColor = true;
            this.clearSelect.Click += new System.EventHandler(this.clearSelect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(525, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "  select to private message";
            // 
            // sendfile
            // 
            this.sendfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendfile.Location = new System.Drawing.Point(591, 536);
            this.sendfile.Name = "sendfile";
            this.sendfile.Size = new System.Drawing.Size(108, 29);
            this.sendfile.TabIndex = 8;
            this.sendfile.Text = "Send File";
            this.sendfile.UseVisualStyleBackColor = true;
            this.sendfile.Click += new System.EventHandler(this.sendfile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(776, 586);
            this.Controls.Add(this.sendfile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clearSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mylist);
            this.Controls.Add(this.send);
            this.Controls.Add(this.messagebox);
            this.Controls.Add(this.chatbox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "p2p Liran Nachman Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox chatbox;
        private System.Windows.Forms.TextBox messagebox;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.ListBox mylist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clearSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sendfile;
    }
}

