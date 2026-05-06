namespace new2026
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRepeat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.Start = new System.Windows.Forms.ToolStripMenuItem();
            this.Reference = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReference = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.Language = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRussian = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnRepeat = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnCut = new System.Windows.Forms.ToolStripButton();
            this.btnInsert = new System.Windows.Forms.ToolStripButton();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.btnInfo = new System.Windows.Forms.ToolStripButton();
            this.txtInput = new System.Windows.Forms.RichTextBox();
            this.btnSize = new System.Windows.Forms.NumericUpDown();
            this.Font = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSize)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Edit,
            this.Start,
            this.Reference,
            this.Language});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1267, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdd,
            this.menuOpen,
            this.menuSave,
            this.menuSaveAs,
            this.Exit});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(59, 24);
            this.File.Text = "Файл";
            // 
            // menuAdd
            // 
            this.menuAdd.Name = "menuAdd";
            this.menuAdd.Size = new System.Drawing.Size(192, 26);
            this.menuAdd.Text = "Создать";
            this.menuAdd.Click += new System.EventHandler(this.menuAdd_Click);
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(192, 26);
            this.menuOpen.Text = "Открыть";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // menuSave
            // 
            this.menuSave.Name = "menuSave";
            this.menuSave.Size = new System.Drawing.Size(192, 26);
            this.menuSave.Text = "Сохранить ";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(192, 26);
            this.menuSaveAs.Text = "Сохранить как";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(192, 26);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Edit
            // 
            this.Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCancel,
            this.menuRepeat,
            this.menuCut,
            this.menuCopy,
            this.menuInsert,
            this.menuDelete,
            this.menuDeleteAll});
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(74, 24);
            this.Edit.Text = "Правка";
            // 
            // menuCancel
            // 
            this.menuCancel.Name = "menuCancel";
            this.menuCancel.Size = new System.Drawing.Size(176, 26);
            this.menuCancel.Text = "Отмена";
            this.menuCancel.Click += new System.EventHandler(this.menuCancel_Click);
            // 
            // menuRepeat
            // 
            this.menuRepeat.Name = "menuRepeat";
            this.menuRepeat.Size = new System.Drawing.Size(176, 26);
            this.menuRepeat.Text = "Возврат";
            this.menuRepeat.Click += new System.EventHandler(this.menuRepeat_Click);
            // 
            // menuCut
            // 
            this.menuCut.Name = "menuCut";
            this.menuCut.Size = new System.Drawing.Size(176, 26);
            this.menuCut.Text = "Вырезать";
            this.menuCut.Click += new System.EventHandler(this.menuCut_Click);
            // 
            // menuCopy
            // 
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(176, 26);
            this.menuCopy.Text = "Копировать";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuInsert
            // 
            this.menuInsert.Name = "menuInsert";
            this.menuInsert.Size = new System.Drawing.Size(176, 26);
            this.menuInsert.Text = "Вставить ";
            this.menuInsert.Click += new System.EventHandler(this.menuInsert_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(176, 26);
            this.menuDelete.Text = "Удалить";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuDeleteAll
            // 
            this.menuDeleteAll.Name = "menuDeleteAll";
            this.menuDeleteAll.Size = new System.Drawing.Size(176, 26);
            this.menuDeleteAll.Text = "Удалить все";
            this.menuDeleteAll.Click += new System.EventHandler(this.menuDeleteAll_Click);
            // 
            // Start
            // 
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(55, 24);
            this.Start.Text = "Пуск";
            this.Start.Click += new System.EventHandler(this.Start_Click_1);
            // 
            // Reference
            // 
            this.Reference.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReference,
            this.menuAbout});
            this.Reference.Name = "Reference";
            this.Reference.Size = new System.Drawing.Size(81, 24);
            this.Reference.Text = "Справка";
            // 
            // menuReference
            // 
            this.menuReference.Name = "menuReference";
            this.menuReference.Size = new System.Drawing.Size(197, 26);
            this.menuReference.Text = "Вызов справки";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(197, 26);
            this.menuAbout.Text = "О программе";
            // 
            // Language
            // 
            this.Language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEnglish,
            this.btnRussian});
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(57, 24);
            this.Language.Text = "Язык";
            // 
            // btnEnglish
            // 
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Size = new System.Drawing.Size(175, 26);
            this.btnEnglish.Text = "Английский";
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);
            // 
            // btnRussian
            // 
            this.btnRussian.Name = "btnRussian";
            this.btnRussian.Size = new System.Drawing.Size(175, 26);
            this.btnRussian.Text = "Русский";
            this.btnRussian.Click += new System.EventHandler(this.btnRussian_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnOpen,
            this.btnSave,
            this.btnCancel,
            this.btnRepeat,
            this.btnCopy,
            this.btnCut,
            this.btnInsert,
            this.btnStart,
            this.btnHelp,
            this.btnInfo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1267, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::new2026.Properties.Resources.icons8_добавить_50;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 24);
            this.btnAdd.Text = "Создать";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::new2026.Properties.Resources.icons8_файл_50;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(29, 24);
            this.btnOpen.Text = "Открыть";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::new2026.Properties.Resources.icons8_сохранить_50;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(29, 24);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancel.Image = global::new2026.Properties.Resources.icons8_налево_50;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(29, 24);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRepeat
            // 
            this.btnRepeat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRepeat.Image = global::new2026.Properties.Resources.icons8_направо_50;
            this.btnRepeat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(29, 24);
            this.btnRepeat.Text = "Возврат";
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopy.Image = global::new2026.Properties.Resources.icons8_скопировать_50__1_;
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(29, 24);
            this.btnCopy.Text = "Копировать";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnCut
            // 
            this.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCut.Image = global::new2026.Properties.Resources.icons8_вырезать_50;
            this.btnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(29, 24);
            this.btnCut.Text = "Вырезать";
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInsert.Image = global::new2026.Properties.Resources.icons8_вставить_50;
            this.btnInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(29, 24);
            this.btnInsert.Text = "Вставить";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnStart
            // 
            this.btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStart.Image = global::new2026.Properties.Resources.icons8_начало_50;
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(29, 24);
            this.btnStart.Text = "Пуск";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHelp.Image = global::new2026.Properties.Resources.icons8_помощь_50__1_;
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(29, 24);
            this.btnHelp.Text = "Вызов справки";
            // 
            // btnInfo
            // 
            this.btnInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInfo.Image = global::new2026.Properties.Resources.icons8_информация_50;
            this.btnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(29, 24);
            this.btnInfo.Text = "О программе";
            // 
            // txtInput
            // 
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.Location = new System.Drawing.Point(0, 0);
            this.txtInput.Margin = new System.Windows.Forms.Padding(0);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(1267, 507);
            this.txtInput.TabIndex = 2;
            this.txtInput.TabStop = false;
            this.txtInput.Text = "";
            // 
            // btnSize
            // 
            this.btnSize.Location = new System.Drawing.Point(525, 26);
            this.btnSize.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.btnSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.btnSize.Name = "btnSize";
            this.btnSize.Size = new System.Drawing.Size(120, 22);
            this.btnSize.TabIndex = 4;
            this.btnSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.btnSize.ValueChanged += new System.EventHandler(this.btnSize_ValueChanged);
            // 
            // Font
            // 
            this.Font.AutoSize = true;
            this.Font.Location = new System.Drawing.Point(405, 28);
            this.Font.Name = "Font";
            this.Font.Size = new System.Drawing.Size(114, 16);
            this.Font.TabIndex = 5;
            this.Font.Text = "Размер шрифта:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.dgvResults);
            this.panel1.Controls.Add(this.txtOutput);
            this.panel1.Controls.Add(this.txtInput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1267, 507);
            this.panel1.TabIndex = 7;
            // 
            // dgvResults
            // 
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLocation,
            this.colDescription});
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvResults.Location = new System.Drawing.Point(0, 179);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersWidth = 51;
            this.dgvResults.RowTemplate.Height = 24;
            this.dgvResults.Size = new System.Drawing.Size(1267, 328);
            this.dgvResults.TabIndex = 4;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(0, 272);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(1153, 177);
            this.txtOutput.TabIndex = 3;
            this.txtOutput.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(746, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 9;
            // 
            // colLocation
            // 
            this.colLocation.HeaderText = "Местоположение";
            this.colLocation.MinimumWidth = 6;
            this.colLocation.Name = "colLocation";
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Описание ошибки";
            this.colDescription.MinimumWidth = 6;
            this.colDescription.Name = "colDescription";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 562);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Font);
            this.Controls.Add(this.btnSize);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Compiler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSize)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem Edit;
        private System.Windows.Forms.ToolStripMenuItem Start;
        private System.Windows.Forms.ToolStripMenuItem Reference;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAdd;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem menuCancel;
        private System.Windows.Forms.ToolStripMenuItem menuCut;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuInsert;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteAll;
        private System.Windows.Forms.ToolStripMenuItem menuReference;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnRepeat;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnCut;
        private System.Windows.Forms.ToolStripButton btnInsert;
        private System.Windows.Forms.ToolStripButton btnStart;
        private System.Windows.Forms.ToolStripButton btnHelp;
        private System.Windows.Forms.ToolStripButton btnInfo;
        private System.Windows.Forms.RichTextBox txtInput;
        private System.Windows.Forms.NumericUpDown btnSize;
        private System.Windows.Forms.Label Font;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem Language;
        private System.Windows.Forms.ToolStripMenuItem btnEnglish;
        private System.Windows.Forms.ToolStripMenuItem btnRussian;
        private System.Windows.Forms.ToolStripMenuItem menuRepeat;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}

