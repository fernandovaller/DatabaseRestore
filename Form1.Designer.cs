namespace DatabaseRestore;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblFile = new Label();
        txtFilePath = new TextBox();
        btnBrowse = new Button();
        lblDatabase = new Label();
        txtDatabase = new TextBox();
        lblUser = new Label();
        txtUser = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        lblHost = new Label();
        txtHost = new TextBox();
        lblPort = new Label();
        numPort = new NumericUpDown();
        btnRestore = new Button();
        lblOutput = new Label();
        txtOutput = new TextBox();
        openFileDialog = new OpenFileDialog();
        ((System.ComponentModel.ISupportInitialize)numPort).BeginInit();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.Location = new Point(24, 22);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(249, 30);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Database Restore";
        // 
        // lblFile
        // 
        lblFile.AutoSize = true;
        lblFile.Location = new Point(27, 82);
        lblFile.Name = "lblFile";
        lblFile.Size = new Size(110, 15);
        lblFile.TabIndex = 1;
        lblFile.Text = "Arquivo .sql ou .gz";
        // 
        // txtFilePath
        // 
        txtFilePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtFilePath.Location = new Point(27, 101);
        txtFilePath.Name = "txtFilePath";
        txtFilePath.ReadOnly = true;
        txtFilePath.Size = new Size(584, 23);
        txtFilePath.TabIndex = 2;
        // 
        // btnBrowse
        // 
        btnBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnBrowse.Location = new Point(625, 100);
        btnBrowse.Name = "btnBrowse";
        btnBrowse.Size = new Size(124, 25);
        btnBrowse.TabIndex = 3;
        btnBrowse.Text = "Selecionar";
        btnBrowse.UseVisualStyleBackColor = true;
        btnBrowse.Click += BtnBrowse_Click;
        // 
        // lblDatabase
        // 
        lblDatabase.AutoSize = true;
        lblDatabase.Location = new Point(27, 151);
        lblDatabase.Name = "lblDatabase";
        lblDatabase.Size = new Size(86, 15);
        lblDatabase.TabIndex = 4;
        lblDatabase.Text = "Base de dados";
        // 
        // txtDatabase
        // 
        txtDatabase.Location = new Point(27, 170);
        txtDatabase.Name = "txtDatabase";
        txtDatabase.Size = new Size(220, 23);
        txtDatabase.TabIndex = 5;
        // 
        // lblUser
        // 
        lblUser.AutoSize = true;
        lblUser.Location = new Point(270, 151);
        lblUser.Name = "lblUser";
        lblUser.Size = new Size(47, 15);
        lblUser.TabIndex = 6;
        lblUser.Text = "Usuário";
        // 
        // txtUser
        // 
        txtUser.Location = new Point(270, 170);
        txtUser.Name = "txtUser";
        txtUser.Size = new Size(180, 23);
        txtUser.TabIndex = 7;
        txtUser.Text = "root";
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(473, 151);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(39, 15);
        lblPassword.TabIndex = 8;
        lblPassword.Text = "Senha";
        // 
        // txtPassword
        // 
        txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtPassword.Location = new Point(473, 170);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '*';
        txtPassword.Size = new Size(276, 23);
        txtPassword.TabIndex = 9;
        // 
        // lblHost
        // 
        lblHost.AutoSize = true;
        lblHost.Location = new Point(27, 216);
        lblHost.Name = "lblHost";
        lblHost.Size = new Size(32, 15);
        lblHost.TabIndex = 10;
        lblHost.Text = "Host";
        // 
        // txtHost
        // 
        txtHost.Location = new Point(27, 235);
        txtHost.Name = "txtHost";
        txtHost.Size = new Size(220, 23);
        txtHost.TabIndex = 11;
        txtHost.Text = "localhost";
        // 
        // lblPort
        // 
        lblPort.AutoSize = true;
        lblPort.Location = new Point(270, 216);
        lblPort.Name = "lblPort";
        lblPort.Size = new Size(35, 15);
        lblPort.TabIndex = 12;
        lblPort.Text = "Porta";
        // 
        // numPort
        // 
        numPort.Location = new Point(270, 235);
        numPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
        numPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numPort.Name = "numPort";
        numPort.Size = new Size(100, 23);
        numPort.TabIndex = 13;
        numPort.Value = new decimal(new int[] { 3306, 0, 0, 0 });
        // 
        // btnRestore
        // 
        btnRestore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnRestore.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnRestore.Location = new Point(625, 233);
        btnRestore.Name = "btnRestore";
        btnRestore.Size = new Size(124, 28);
        btnRestore.TabIndex = 14;
        btnRestore.Text = "Processar";
        btnRestore.UseVisualStyleBackColor = true;
        btnRestore.Click += BtnRestore_Click;
        // 
        // lblOutput
        // 
        lblOutput.AutoSize = true;
        lblOutput.Location = new Point(27, 290);
        lblOutput.Name = "lblOutput";
        lblOutput.Size = new Size(26, 15);
        lblOutput.TabIndex = 15;
        lblOutput.Text = "Log";
        // 
        // txtOutput
        // 
        txtOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtOutput.Location = new Point(27, 309);
        txtOutput.Multiline = true;
        txtOutput.Name = "txtOutput";
        txtOutput.ReadOnly = true;
        txtOutput.ScrollBars = ScrollBars.Vertical;
        txtOutput.Size = new Size(722, 167);
        txtOutput.TabIndex = 16;
        // 
        // openFileDialog
        // 
        openFileDialog.Filter = "Arquivos SQL (*.sql;*.gz)|*.sql;*.gz|Todos os arquivos (*.*)|*.*";
        openFileDialog.Title = "Selecione o arquivo de restore";
        // 
        // Form1
        // 
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(784, 501);
        Controls.Add(txtOutput);
        Controls.Add(lblOutput);
        Controls.Add(btnRestore);
        Controls.Add(numPort);
        Controls.Add(lblPort);
        Controls.Add(txtHost);
        Controls.Add(lblHost);
        Controls.Add(txtPassword);
        Controls.Add(lblPassword);
        Controls.Add(txtUser);
        Controls.Add(lblUser);
        Controls.Add(txtDatabase);
        Controls.Add(lblDatabase);
        Controls.Add(btnBrowse);
        Controls.Add(txtFilePath);
        Controls.Add(lblFile);
        Controls.Add(lblTitle);
        MinimumSize = new Size(800, 540);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "DatabaseRestore";
        ((System.ComponentModel.ISupportInitialize)numPort).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitle;
    private Label lblFile;
    private TextBox txtFilePath;
    private Button btnBrowse;
    private Label lblDatabase;
    private TextBox txtDatabase;
    private Label lblUser;
    private TextBox txtUser;
    private Label lblPassword;
    private TextBox txtPassword;
    private Label lblHost;
    private TextBox txtHost;
    private Label lblPort;
    private NumericUpDown numPort;
    private Button btnRestore;
    private Label lblOutput;
    private TextBox txtOutput;
    private OpenFileDialog openFileDialog;
}
