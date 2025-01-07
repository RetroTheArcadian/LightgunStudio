using LightgunStudio.Core.Dtos;
using LightgunStudio.Models;
using LightgunStudio.Utilities;

namespace LightgunStudio.ViewModel
{
    class FrontendsVM : ViewModelBase
    {
        private readonly FrontendPageModel _pageModel;
        public List<FrontEndDto> DisplayFrontends
        {
            get { return _pageModel.FrontendList; }
            set { _pageModel.FrontendList = value; OnPropertyChanged(); }
        }

        public FrontendsVM()
        {
            _pageModel = new FrontendPageModel();
            List<FrontEndDto> frontendList =
            [
                //new FrontEndDto() { Title = "Batocera", DisplayName = "Batocera", Description=@"", ImagePath="/Images/Frontends/batocera.png" },
                new FrontEndDto() { Title = "EsDe", DisplayName = "ES-DE", Description=@"ES-DE is a frontend for browsing and launching games from your multi-platform collection. It's fully customizable, so you can easily expand it with support for additional systems and applications. Open Source!", ImagePath="/Images/Frontends/es-de.png" },
                new FrontEndDto() { Title = "LaunchBox", DisplayName = "LaunchBox", Description=@"We Make Your Games Beautiful. Emulate, Organize, and Beautify Your Game Collection. NOTE: LaunchBox does not offer direct download so you have to visit their page in order to download. Closed source!", ImagePath="/Images/Frontends/launchbox.png" },
            ];
            _pageModel.FrontendList = [.. frontendList.OrderBy(x => x.Title)];
        }

    }
}
