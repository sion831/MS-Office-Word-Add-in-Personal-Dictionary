using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace Dictionary
{
    public partial class DictionaryRibbon
    {
        private void DictionaryRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void translateEnableCheckBox_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.setTranslateFlag(((RibbonCheckBox)sender).Checked);
        }

        private void Import_Dictionary_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.LoadDictionary();
        }

        private void highlight_Click(object sender, RibbonControlEventArgs e)
        {

        }
    }
}
