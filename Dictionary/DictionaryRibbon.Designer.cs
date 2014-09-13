namespace Dictionary
{
    partial class DictionaryRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public DictionaryRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.translateEnableCheckBox = this.Factory.CreateRibbonCheckBox();
            this.Import_Dictionary = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabReferences";
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabReferences";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.translateEnableCheckBox);
            this.group1.Items.Add(this.Import_Dictionary);
            this.group1.Name = "group1";
            // 
            // translateEnableCheckBox
            // 
            this.translateEnableCheckBox.Label = "Translate";
            this.translateEnableCheckBox.Name = "translateEnableCheckBox";
            this.translateEnableCheckBox.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.translateEnableCheckBox_Click);
            // 
            // Import_Dictionary
            // 
            this.Import_Dictionary.Label = "Import Dictionary";
            this.Import_Dictionary.Name = "Import_Dictionary";
            this.Import_Dictionary.ScreenTip = "Import a Excel Dictionary File";
            this.Import_Dictionary.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Import_Dictionary_Click);
            // 
            // DictionaryRibbon
            // 
            this.Name = "DictionaryRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.DictionaryRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox translateEnableCheckBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Import_Dictionary;
    }

    partial class ThisRibbonCollection
    {
        internal DictionaryRibbon DictionaryRibbon
        {
            get { return this.GetRibbon<DictionaryRibbon>(); }
        }
    }
}
