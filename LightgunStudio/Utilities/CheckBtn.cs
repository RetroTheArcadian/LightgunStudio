using System.Windows.Controls;
using System.Windows;

namespace LightgunStudio.Utilities
{
    public class CheckBtn : CheckBox
    {
        static CheckBtn()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckBtn), new FrameworkPropertyMetadata(typeof(CheckBtn)));
        }
    }
}
