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
                new FrontEndDto() { Title = "Batocera", DisplayName = "Batocera", Description=@"", ImagePath="/Images/Frontends/batocera.png" },
                new FrontEndDto() { Title = "EsDe", DisplayName = "ES-DE", Description=@"", ImagePath="/Images/Frontends/es-de.png" },
                new FrontEndDto() { Title = "LaunchBox", DisplayName = "LaunchBox", Description=@"", ImagePath="/Images/Frontends/launchbox.png" },
            ];
            _pageModel.FrontendList = [.. frontendList.OrderBy(x => x.Title)];
        }

    }
}
