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
                new EmulatorDto() { Title = "PCSX2", DisplayName = "PCSX2", Description=@"PCSX2 is a free and open-source PlayStation 2 (PS2) emulator. Its purpose is to emulate the PS2's hardware, using a combination of MIPS CPU Interpreters, Recompilers, and a Virtual Machine that manages hardware states and system memory.", ImagePath="/Images/Emulators/PCSX2.png", Selected = false },
                new EmulatorDto() { Title = "PPSSPP", DisplayName = "PPSSPP", Description=@"PPSSPP can run your PSP games on your PC or Android phone in full HD resolution or even higher. It can also upscale textures to make them sharper, and you can enable post-processing shaders to adjust color and brightness the way you like, and other effects.", ImagePath="/Images/Emulators/PPSSPP.png", Selected = false },
                new EmulatorDto() { Title = "RPCS3", DisplayName = "RPCS3", Description=@"RPCS3 is a multi-platform open-source Sony PlayStation 3 emulator and debugger written in C++ for Windows, Linux, macOS and FreeBSD.", ImagePath="/Images/Emulators/RPCS3.png", Selected = false },
                new EmulatorDto() { Title = "BizHawk", DisplayName = "BizHawk", Description=@"BizHawk is a multi-platform emulator with full rerecording support and Lua scripting. BizHawk focuses on core accuracy and power user tools while still being an easy-to-use emulator for casual gaming.", ImagePath="/Images/Emulators/BizHawk.png", Selected = false },
                new EmulatorDto() { Title = "HypseusSinge", DisplayName = "Hypseus Singe", Description=@"Hypseus is a fork of Matt Ownby's Daphne. A program to play laserdisc arcade games on a PC, Mac or Raspberry Pi. This version includes Singe support for Fan Made and American Laser Games.", ImagePath="/Images/Emulators/HypseusSinge.png", Selected = false },
                new EmulatorDto() { Title = "SegaModel2", DisplayName = "Sega Model II", Description=@"This emulator lets you run games from the Model 2 and later updates, 2A, 2B and 2C, including games of such caliber as Daytona USA, Sega Rally Championship, Virtua Fighter 2, Virtua Cop, House of the Dead and Last Bronx, among many others. The great majority of them can be played on PC without much more effort than choosing the ROM in question.", ImagePath="/Images/Emulators/SegaModel2.png", Selected = false },
                new EmulatorDto() { Title = "Daphne", DisplayName = "Daphne", Description=@"First Ever Multiple Arcade Laserdisc Emulator!  It's a program that lets one play the original versions of many laserdisc arcade games on one's PC.", ImagePath="/Images/Emulators/Daphne.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", DisplayName = "TeknoParrot", Description=@"TeknoParrot is a software package allowing you to run selected PC-based arcade titles on your own hardware, with full support for keyboard and mouse controls, gamepads, steering wheels, and joysticks.", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
            ];
            _pageModel.EmulatorList = [.. emulatorList.OrderBy(x => x.Title)];
        }
    }
}
