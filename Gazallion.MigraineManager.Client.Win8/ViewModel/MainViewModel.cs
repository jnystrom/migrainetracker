using GalaSoft.MvvmLight;
using Gazallion.MigraineManager.Client.Common.Service.I;
using Gazallion.MigraineManager.Common.Data.DTOs;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Gazallion.MigraineManager.Client.Win8.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IUserService _Service;

        private UserDto _User;
        public UserDto User
        {
            get
            {
                return _User;
            }
            set
            {
                _User = value;
                base.Set("User", ref this._User, value);
            }
        }

        private ObservableCollection<AddressDto> _Addresses;
        public ObservableCollection<AddressDto> Addresses
        {
            get
            {
                return _Addresses;
            }
            set
            {
                _Addresses = value;
                if (Set("Addresses", ref _Addresses, value))
                {
                    RaisePropertyChanged(() => Addresses);
                }
              
            }
        }
        

       

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IUserService service)
        {
            _Service = service;

            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.

             
            }
            else
            {
               // User = await _Service.GetUser(1);
                
            }
            Addresses = new ObservableCollection<AddressDto> { 
            new AddressDto
            {
             StreetName  ="Street Name",
             StreetNumber = "1234",
             City = "Test City"
            }};

              
        }


        public async Task GetData()
        {
            User = await _Service.GetUser(1);
            Addresses.Clear();
            foreach (var item in User.Addresses)
            {
                Addresses.Add(item);
            }
        }
    }
}