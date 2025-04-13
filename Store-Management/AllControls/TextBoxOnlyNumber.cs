using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllControls
{
    public class TextBoxOnlyNumber : TextBox
    {
        public TextBoxOnlyNumber()
        {
            this.KeyPress += TextBoxOnlyNumber_KeyPress;
        }

        private void TextBoxOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Left && e.KeyChar != (char)Keys.Right && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }
        }

    }
}
