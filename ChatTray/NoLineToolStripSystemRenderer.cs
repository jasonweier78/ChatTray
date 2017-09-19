using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatTray
{
    class NoLineToolStripSystemRenderer : ToolStripRenderer
    {
        public NoLineToolStripSystemRenderer() { }
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // Skip this to avoid a bug in the system renderere that leaves a lower border.
            //base.OnRenderToolStripBorder(e);
        }
    }
}
