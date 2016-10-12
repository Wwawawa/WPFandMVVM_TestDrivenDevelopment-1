using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.ViewModel;
using FriendStroage.UITests.Extensions;
using Moq;
using Xunit;

namespace FriendStroage.UITests.ViewModel
{
    public class FriendEditViewModelTest
    {
        private const int _friendId = 5;
        private Mock<IFriendDataProvider> _dataProviderMock;
        private FriendEditViewModel _viewModel;

        public FriendEditViewModelTest()
        {
            _dataProviderMock = new Mock<IFriendDataProvider>();
            _dataProviderMock.Setup(dp => dp.GetFriendById(_friendId))
                .Returns(new Friend() { Id = _friendId, FirstName = "Thomas" });

            _viewModel = new FriendEditViewModel(_dataProviderMock.Object);
        }

        [Fact]
        public void ShouldLoadFriend()
        {
            _viewModel.Load(_friendId);

            Assert.NotNull(_viewModel.Friend);
            Assert.Equal(_friendId, _viewModel.Friend.Id);

            _dataProviderMock.Verify(dp => dp.GetFriendById(_friendId), Times.Once);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventForFriend()
        {
            var fired = _viewModel.IsPropertyChanged(
                () => _viewModel.Load(_friendId),
                nameof(_viewModel.Friend));

            Assert.True(fired);
        }

    }
}
