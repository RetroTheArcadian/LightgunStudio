using System.Windows.Controls;
using System.Windows;

namespace LightgunStudio.Utilities
{
    public class RadioBtn : RadioButton
    {
        static RadioBtn()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RadioBtn), new FrameworkPropertyMetadata(typeof(RadioBtn)));
        }
    }
}
