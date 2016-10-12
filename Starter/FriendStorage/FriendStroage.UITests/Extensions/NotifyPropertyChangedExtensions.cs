using System;
using System.ComponentModel;

namespace FriendStroage.UITests.Extensions
{
    public static class NotifyPropertyChangedExtensions
    {

        public static bool IsPropertyChanged(
            this INotifyPropertyChanged notifyPropertyChanged,
            Action action,
            string propertyName)
        {
            var fired = false;
            notifyPropertyChanged.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == propertyName)
                {
                    fired = true;
                }
            };

            action();

            return fired;
        }
    }
}
