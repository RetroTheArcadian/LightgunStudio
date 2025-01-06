using LightgunStudio.Core.Dtos;
using LightgunStudio.Models;
using LightgunStudio.Utilities;

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
                new EmulatorDto() { Title = "Dolphin", DisplayName = "Dolphin", Description=@"Dolphin is an emulator for two recent Nintendo video game consoles: the GameCube and the Wii. It allows PC gamers to enjoy games for these two consoles in full HD (1080p) with several enhancements: compatibility with all PC controllers, turbo speed, networked multiplayer, and even more!", ImagePath="/Images/Emulators/Dolphin.png", Selected = false },
                new EmulatorDto() { Title = "MAME", DisplayName = "MAME", Description=@"MAME is a multi-purpose emulation framework.", ImagePath="/Images/Emulators/MAME.png", Selected = false },
                new EmulatorDto() { Title = "Flycast", DisplayName = "Flycast", Description=@"Flycast is a multi-platform Sega Dreamcast, Naomi, Naomi 2, and Atomiswave emulator derived from reicast.", ImagePath="/Images/Emulators/Flycast.png", Selected = false },
                new EmulatorDto() { Title = "PCSX2", DisplayName = "PCSX2", Description=@"", ImagePath="/Images/Emulators/PCSX2.png", Selected = false },
                new EmulatorDto() { Title = "PPSSPP", DisplayName = "PPSSPP", Description=@"", ImagePath="/Images/Emulators/PPSSPP.png", Selected = false },
                new EmulatorDto() { Title = "RPCS3", DisplayName = "RPCS3", Description=@"", ImagePath="/Images/Emulators/RPCS3.png", Selected = false },
                new EmulatorDto() { Title = "BizHawk", DisplayName = "BizHawk", Description=@"", ImagePath="/Images/Emulators/BizHawk.png", Selected = false },
                new EmulatorDto() { Title = "HypseusSinge", DisplayName = "Hypseus Singe", Description=@"", ImagePath="/Images/Emulators/HypseusSinge.png", Selected = false },
                new EmulatorDto() { Title = "SegaModel2", DisplayName = "Sega Model II", Description=@"", ImagePath="/Images/Emulators/SegaModel2.png", Selected = false },
                new EmulatorDto() { Title = "Daphne", DisplayName = "Daphne", Description=@"", ImagePath="/Images/Emulators/Daphne.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", DisplayName = "TeknoParrot", Description=@"", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
            ];
            _pageModel.EmulatorList = [.. emulatorList.OrderBy(x => x.Title)];
        }
    }
}
