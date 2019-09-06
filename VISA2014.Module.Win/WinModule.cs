using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;

namespace VISA2014.Module.Win
{
    [ToolboxItemFilter("Xaf.Platform.Win")]
    public sealed partial class VISA2014WindowsFormsModule : ModuleBase
    {
        public VISA2014WindowsFormsModule()
        {
            InitializeComponent();
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            return ModuleUpdater.EmptyModuleUpdaters;
        }
    }
}
