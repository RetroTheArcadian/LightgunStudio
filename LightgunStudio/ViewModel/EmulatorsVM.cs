using LightgunStudio.Core.Dtos;
using LightgunStudio.Models;
using LightgunStudio.Utilities;
using System.Windows;

namespace LightgunStudio.ViewModel
{
    class EmulatorsVM : ViewModelBase
    {
        private readonly EmulatorPageModel _pageModel;
        public List<EmulatorDto> DisplayEmulators
        {
            get { return _pageModel.EmulatorList; }
            set { _pageModel.EmulatorList = value; OnPropertyChanged(); }
        }

        public EmulatorsVM()
        {
            _pageModel = new EmulatorPageModel();
            List<EmulatorDto> emulatorList =
            [
                new EmulatorDto() { Title = "Dolphin", ImagePath="/Images/Emulators/Dolphin.png", Selected = false },
                new EmulatorDto() { Title = "MAME", ImagePath="/Images/Emulators/MAME.png", Selected = false },
                new EmulatorDto() { Title = "Flycast", ImagePath="/Images/Emulators/Flycast.png", Selected = false },
                new EmulatorDto() { Title = "PCSX2", ImagePath="/Images/Emulators/PCSX2.png", Selected = false },
                new EmulatorDto() { Title = "PPSSPP", ImagePath="/Images/Emulators/PPSSPP.png", Selected = false },
                new EmulatorDto() { Title = "RPCS3", ImagePath="/Images/Emulators/RPCS3.png", Selected = false },
                new EmulatorDto() { Title = "BizHawk", ImagePath="/Images/Emulators/BizHawk.png", Selected = false },
                new EmulatorDto() { Title = "Hypseus Singe", ImagePath="/Images/Emulators/HypseusSinge.png", Selected = false },
                new EmulatorDto() { Title = "Sega Model 2", ImagePath="/Images/Emulators/SegaModel2.png", Selected = false },
                new EmulatorDto() { Title = "Daphne", ImagePath="/Images/Emulators/Daphne.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false }
            ];
            _pageModel.EmulatorList = [.. emulatorList.OrderBy(x => x.Title)];
        }
    }
}
