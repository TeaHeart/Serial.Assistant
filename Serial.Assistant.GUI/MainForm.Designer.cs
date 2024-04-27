namespace Serial.Assistant.GUI;

partial class MainForm {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        panel1 = new Panel();
        cbNewLine = new ComboBox();
        label8 = new Label();
        cbEncoding = new ComboBox();
        label7 = new Label();
        cbParity = new ComboBox();
        label6 = new Label();
        cbStopBits = new ComboBox();
        label5 = new Label();
        cbHandshake = new ComboBox();
        label4 = new Label();
        cbDataBits = new ComboBox();
        cbBaud = new ComboBox();
        label3 = new Label();
        label2 = new Label();
        cbPort = new ComboBox();
        label1 = new Label();
        btnPort = new Button();
        panel2 = new Panel();
        tbView = new TextBox();
        panel3 = new Panel();
        cbKeep = new CheckBox();
        btnClear = new Button();
        cbMode = new CheckBox();
        tbSend = new TextBox();
        btnSend = new Button();
        panel1.SuspendLayout();
        panel2.SuspendLayout();
        panel3.SuspendLayout();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        panel1.Controls.Add(cbNewLine);
        panel1.Controls.Add(label8);
        panel1.Controls.Add(cbEncoding);
        panel1.Controls.Add(label7);
        panel1.Controls.Add(cbParity);
        panel1.Controls.Add(label6);
        panel1.Controls.Add(cbStopBits);
        panel1.Controls.Add(label5);
        panel1.Controls.Add(cbHandshake);
        panel1.Controls.Add(label4);
        panel1.Controls.Add(cbDataBits);
        panel1.Controls.Add(cbBaud);
        panel1.Controls.Add(label3);
        panel1.Controls.Add(label2);
        panel1.Controls.Add(cbPort);
        panel1.Controls.Add(label1);
        panel1.Location = new Point(11, 12);
        panel1.Name = "panel1";
        panel1.Size = new Size(235, 479);
        panel1.TabIndex = 0;
        // 
        // cbNewLine
        // 
        cbNewLine.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        cbNewLine.FormattingEnabled = true;
        cbNewLine.Location = new Point(97, 354);
        cbNewLine.Name = "cbNewLine";
        cbNewLine.Size = new Size(131, 28);
        cbNewLine.TabIndex = 8;
        // 
        // label8
        // 
        label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label8.AutoSize = true;
        label8.Location = new Point(6, 357);
        label8.Name = "label8";
        label8.Size = new Size(72, 20);
        label8.TabIndex = 0;
        label8.Text = "NewLine";
        // 
        // cbEncoding
        // 
        cbEncoding.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        cbEncoding.DropDownStyle = ComboBoxStyle.DropDownList;
        cbEncoding.FormattingEnabled = true;
        cbEncoding.Location = new Point(97, 307);
        cbEncoding.Name = "cbEncoding";
        cbEncoding.Size = new Size(131, 28);
        cbEncoding.TabIndex = 7;
        // 
        // label7
        // 
        label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label7.AutoSize = true;
        label7.Location = new Point(6, 310);
        label7.Name = "label7";
        label7.Size = new Size(77, 20);
        label7.TabIndex = 0;
        label7.Text = "Encoding";
        // 
        // cbParity
        // 
        cbParity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        cbParity.DropDownStyle = ComboBoxStyle.DropDownList;
        cbParity.FormattingEnabled = true;
        cbParity.Location = new Point(97, 259);
        cbParity.Name = "cbParity";
        cbParity.Size = new Size(131, 28);
        cbParity.TabIndex = 6;
        // 
        // label6
        // 
        label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label6.AutoSize = true;
        label6.Location = new Point(6, 262);
        label6.Name = "label6";
        label6.Size = new Size(89, 20);
        label6.TabIndex = 0;
        label6.Text = "Handshake";
        // 
        // cbStopBits
        // 
        cbStopBits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        cbStopBits.DropDownStyle = ComboBoxStyle.DropDownList;
        cbStopBits.FormattingEnabled = true;
        cbStopBits.Location = new Point(97, 211);
        cbStopBits.Name = "cbStopBits";
        cbStopBits.Size = new Size(131, 28);
        cbStopBits.TabIndex = 5;
        // 
        // label5
        // 
        label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label5.AutoSize = true;
        label5.Location = new Point(6, 214);
        label5.Name = "label5";
        label5.Size = new Size(70, 20);
        label5.TabIndex = 0;
        label5.Text = "StopBits";
        // 
        // cbHandshake
        // 
        cbHandshake.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        cbHandshake.DropDownStyle = ComboBoxStyle.DropDownList;
        cbHandshake.FormattingEnabled = true;
        cbHandshake.Location = new Point(97, 164);
        cbHandshake.Name = "cbHandshake";
        cbHandshake.Size = new Size(131, 28);
        cbHandshake.TabIndex = 4;
        // 
        // label4
        // 
        label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label4.AutoSize = true;
        label4.Location = new Point(6, 167);
        label4.Name = "label4";
        label4.Size = new Size(50, 20);
        label4.TabIndex = 0;
        label4.Text = "Parity";
        // 
        // cbDataBits
        // 
        cbDataBits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        cbDataBits.DropDownStyle = ComboBoxStyle.DropDownList;
        cbDataBits.FormattingEnabled = true;
        cbDataBits.Location = new Point(97, 116);
        cbDataBits.Name = "cbDataBits";
        cbDataBits.Size = new Size(131, 28);
        cbDataBits.TabIndex = 3;
        // 
        // cbBaud
        // 
        cbBaud.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        cbBaud.DropDownStyle = ComboBoxStyle.DropDownList;
        cbBaud.FormattingEnabled = true;
        cbBaud.Location = new Point(97, 69);
        cbBaud.Name = "cbBaud";
        cbBaud.Size = new Size(131, 28);
        cbBaud.TabIndex = 2;
        // 
        // label3
        // 
        label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label3.AutoSize = true;
        label3.Location = new Point(6, 119);
        label3.Name = "label3";
        label3.Size = new Size(68, 20);
        label3.TabIndex = 0;
        label3.Text = "DataBits";
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label2.AutoSize = true;
        label2.Location = new Point(6, 71);
        label2.Name = "label2";
        label2.Size = new Size(45, 20);
        label2.TabIndex = 0;
        label2.Text = "Baud";
        // 
        // cbPort
        // 
        cbPort.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        cbPort.DropDownStyle = ComboBoxStyle.DropDownList;
        cbPort.FormattingEnabled = true;
        cbPort.Location = new Point(97, 21);
        cbPort.Name = "cbPort";
        cbPort.Size = new Size(131, 28);
        cbPort.TabIndex = 1;
        cbPort.MouseEnter += cbPort_MouseEnter;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        label1.AutoSize = true;
        label1.Location = new Point(6, 24);
        label1.Name = "label1";
        label1.Size = new Size(40, 20);
        label1.TabIndex = 0;
        label1.Text = "Port";
        // 
        // btnPort
        // 
        btnPort.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        btnPort.Location = new Point(3, 132);
        btnPort.Name = "btnPort";
        btnPort.Size = new Size(131, 28);
        btnPort.TabIndex = 9;
        btnPort.Text = "Open";
        btnPort.UseVisualStyleBackColor = true;
        btnPort.Click += btnPort_Click;
        // 
        // panel2
        // 
        panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panel2.Controls.Add(tbView);
        panel2.Location = new Point(252, 12);
        panel2.Name = "panel2";
        panel2.Size = new Size(680, 310);
        panel2.TabIndex = 1;
        // 
        // tbView
        // 
        tbView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tbView.Location = new Point(3, 3);
        tbView.Multiline = true;
        tbView.Name = "tbView";
        tbView.ScrollBars = ScrollBars.Vertical;
        tbView.Size = new Size(674, 304);
        tbView.TabIndex = 10;
        // 
        // panel3
        // 
        panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panel3.Controls.Add(cbKeep);
        panel3.Controls.Add(btnClear);
        panel3.Controls.Add(cbMode);
        panel3.Controls.Add(btnPort);
        panel3.Controls.Add(tbSend);
        panel3.Controls.Add(btnSend);
        panel3.Location = new Point(252, 328);
        panel3.Name = "panel3";
        panel3.Size = new Size(680, 163);
        panel3.TabIndex = 2;
        // 
        // cbKeep
        // 
        cbKeep.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        cbKeep.AutoSize = true;
        cbKeep.Checked = true;
        cbKeep.CheckState = CheckState.Checked;
        cbKeep.Location = new Point(343, 134);
        cbKeep.Name = "cbKeep";
        cbKeep.Size = new Size(64, 24);
        cbKeep.TabIndex = 15;
        cbKeep.Text = "keep";
        cbKeep.UseVisualStyleBackColor = true;
        // 
        // btnClear
        // 
        btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        btnClear.Location = new Point(413, 132);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(129, 28);
        btnClear.TabIndex = 14;
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += btnClear_Click;
        // 
        // cbMode
        // 
        cbMode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        cbMode.AutoSize = true;
        cbMode.Location = new Point(140, 134);
        cbMode.Name = "cbMode";
        cbMode.Size = new Size(54, 24);
        cbMode.TabIndex = 13;
        cbMode.Text = "hex";
        cbMode.UseVisualStyleBackColor = true;
        // 
        // tbSend
        // 
        tbSend.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tbSend.Location = new Point(3, 3);
        tbSend.Multiline = true;
        tbSend.Name = "tbSend";
        tbSend.ScrollBars = ScrollBars.Vertical;
        tbSend.Size = new Size(674, 123);
        tbSend.TabIndex = 11;
        // 
        // btnSend
        // 
        btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        btnSend.Location = new Point(548, 132);
        btnSend.Name = "btnSend";
        btnSend.Size = new Size(129, 28);
        btnSend.TabIndex = 12;
        btnSend.Text = "Send";
        btnSend.UseVisualStyleBackColor = true;
        btnSend.Click += btnSend_Click;
        // 
        // MainForm
        // 
        AcceptButton = btnSend;
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(944, 501);
        Controls.Add(panel3);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Font = new Font("Microsoft YaHei UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
        Margin = new Padding(4);
        MinimumSize = new Size(960, 540);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Serial Assistant";
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        panel3.ResumeLayout(false);
        panel3.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
    private Panel panel2;
    private Panel panel3;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private ComboBox cbPort;
    private ComboBox cbBaud;
    private ComboBox cbDataBits;
    private ComboBox cbParity;
    private ComboBox cbStopBits;
    private ComboBox cbHandshake;
    private ComboBox cbNewLine;
    private ComboBox cbEncoding;
    private Button btnPort;
    private Button btnSend;
    private TextBox tbView;
    private TextBox tbSend;
    private CheckBox cbMode;
    private Button btnClear;
    private CheckBox cbKeep;
}
