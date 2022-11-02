using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Sync
{
    [RunInstaller(true)]
    public partial class InstVisSyncSrv : System.Configuration.Install.Installer
    {
        public InstVisSyncSrv()
        {
            InitializeComponent();
        }
    }
}
