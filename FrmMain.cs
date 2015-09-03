using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diff_smrt
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            var x = core.Factory.AnalyzeDirectory(@"f:\users\PLRADSLI\Documents\Work\PROJECTS\EcoMotionTool\");
            var y = core.Factory.AnalyzeDirectory(@"f:\users\PLRADSLI\Documents\Work\PROJECTS\EcoMotion\");

            core.Factory.Compare(x, y);
        }
    }
}
