using FriendStorage.UI.Command;
using System.Windows.Input;
using Prism.Events;
using FriendStorage.UI.Events;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;
        private IEventAggregator _eventAggregator;

        public NavigationItemViewModel(
            int id,
            string displayMember,
            IEventAggregator eventAggregator)
        {
            Id = id;
            DisplayMember = displayMember;
            OpenFriendEditViewCommand = new DelegateCommand(OnFriendEditViewExecute);
            _eventAggregator = eventAggregator;
        }

        private void OnFriendEditViewExecute(object obj)
        {
            _eventAggregator.GetEvent<OpenFriendEditViewEvent>()
                .Publish(Id);

        }
        
        public int Id { get; private set; }

        public ICommand OpenFriendEditViewCommand { get; private set; }

        public string DisplayMember
        {
            get
            {
                return _displayMember;
            }

            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }
    }
}
