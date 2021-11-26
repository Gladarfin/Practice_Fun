using System.Windows.Forms;

namespace Minesweeper
{
        class NoSelectButton : Button
        {
            public NoSelectButton()
            {
                SetStyle(ControlStyles.Selectable, false);
            }
        }
}
