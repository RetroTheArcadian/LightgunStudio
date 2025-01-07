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
            _Controllers = RawInputHelper.GetRawInputDevices().ToList();
            _pageModel.Lightguns = new AutoConfig().GetActiveLightguns(_Controllers.Select(x => x.DeviceName).OrderBy(o=>o).ToList());
        }
    }
}
