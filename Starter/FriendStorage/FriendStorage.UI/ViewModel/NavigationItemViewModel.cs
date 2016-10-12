using FriendStorage.UI.Command;
using System.Windows.Input;
using Prism.Events;
using FriendStorage.UI.Events;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationItemViewModel
    {
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

        public string DisplayMember { get; private set; }
        public int Id { get; private set; }

        public ICommand OpenFriendEditViewCommand { get; private set; }
    }
}
