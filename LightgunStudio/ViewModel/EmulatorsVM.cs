using LightgunStudio.Core.Dtos;
using LightgunStudio.Utilities;

namespace LightgunStudio.ViewModel
{
    class EmulatorsVM : ViewModelBase
    {
        public List<EmulatorDto>? EmulatorList { get; set; }

        public EmulatorsVM()
        {
            EmulatorList =
            [
                new EmulatorDto() { Title = "Dolphin", ImagePath="/Images/Emulators/Dolphin.png", Selected = false },
                new EmulatorDto() { Title = "MAME", ImagePath="/Images/Emulators/MAME.png", Selected = false },
                new EmulatorDto() { Title = "Flycast", ImagePath="/Images/Emulators/Flycast.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false },
                new EmulatorDto() { Title = "TeknoParrot", ImagePath="/Images/Emulators/TeknoParrot.png", Selected = false }
            ];
        }
    }
}
