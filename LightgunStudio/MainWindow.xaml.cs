using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using LighgunStudioCore;
using LighgunStudioCore.RawInput;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LightgunStudio
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public List<RawInputController> _Controllers = new List<RawInputController>();
        private AppWindow _apw;
        private OverlappedPresenter _presenter;

        public MainWindow()
        {
            this.InitializeComponent();
            GetAppWindowAndPresenter();
            _apw.IsShownInSwitchers = false;
            _presenter.SetBorderAndTitleBar(false, false);
            GetRawInputDevices();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
        }
        /// <summary>
        /// Enumerates the Raw Input Devices and places their corresponding RawInputDevice structures into a List<string>
        /// We just filter to remove Keyboard devices and keep Mouse + HID devices
        /// </summary>
        private void GetRawInputDevices()
        {
            uint deviceCount = 0;
            var dwSize = (Marshal.SizeOf(typeof(RawInputDeviceList)));

            if (Win32API.GetRawInputDeviceList(IntPtr.Zero, ref deviceCount, (uint)dwSize) == 0)
            {
                var pRawInputDeviceList = Marshal.AllocHGlobal((int)(dwSize * deviceCount));
                Win32API.GetRawInputDeviceList(pRawInputDeviceList, ref deviceCount, (uint)dwSize);

                for (var i = 0; i < deviceCount; i++)
                {
                    // On Window 8 64bit when compiling against .Net > 3.5 using .ToInt32 you will generate an arithmetic overflow. Leave as it is for 32bit/64bit applications
                    RawInputDeviceList rid = (RawInputDeviceList)Marshal.PtrToStructure(new IntPtr((pRawInputDeviceList.ToInt64() + (dwSize * i))), typeof(RawInputDeviceList));

                    RawInputController c = new RawInputController(rid.hDevice, rid.dwType);

                    if (c.DeviceType == RawInputDeviceType.RIM_TYPEHID || c.DeviceType == RawInputDeviceType.RIM_TYPEMOUSE)
                    {
                        _Controllers.Add(c);
                    }
                }
                Marshal.FreeHGlobal(pRawInputDeviceList);
                return;
            }
            throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public void GetAppWindowAndPresenter()
        {
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WindowId myWndId = Win32Interop.GetWindowIdFromWindow(hWnd);
            _apw = AppWindow.GetFromWindowId(myWndId);
            _presenter = _apw.Presenter as OverlappedPresenter;
        }
    }
}
