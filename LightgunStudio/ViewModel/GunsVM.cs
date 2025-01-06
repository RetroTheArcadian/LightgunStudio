using LightgunStudio.Utilities;
using System.Runtime.InteropServices;
using LighgunStudio.Core;
using LighgunStudio.Core.RawInput;
using LightgunStudio.Models;
using LightgunStudio.Core.Utilities;

namespace LightgunStudio.ViewModel
{
    class GunsVM : ViewModelBase
    {
        public List<RawInputController> _Controllers = [];
        private readonly GunsPageModel _pageModel;
        public List<Core.Dtos.AutoConfigDto.Lightgun> DisplayLightguns
        {
            get { return _pageModel.Lightguns; }

            set { _pageModel.Lightguns = value; OnPropertyChanged(); }
        }

        public GunsVM()
        {
            _pageModel = new GunsPageModel();
            GetAttachedLightGuns();
        }

        public void GetAttachedLightGuns()
        {
            GetRawInputDevices();
            _pageModel.Lightguns = new AutoConfig().GetActiveLightguns(_Controllers.Select(x => x.DeviceName).ToList());
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

                    var c = new RawInputController(rid.hDevice, rid.dwType);

                    if (c.DeviceType == RawInputDeviceType.RIM_TYPEHID || c.DeviceType == RawInputDeviceType.RIM_TYPEMOUSE)
                    {
                        _Controllers.Add(c);
                    }
                }
                Marshal.FreeHGlobal(pRawInputDeviceList);
                return;
            }
            throw new Exception(Marshal.GetLastWin32Error().ToString());
        }
    }
}
