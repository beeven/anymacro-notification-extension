using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace anymacro_notification_blazor
{
    public class PluginConfig : INotifyPropertyChanged
    {
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected void SetPropertyField<T>(string propertyName, ref T field, T newValue)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool _pluginEnabled = true;
        public bool PluginEnabled
        {
            get { return _pluginEnabled; }
            set { SetPropertyField(nameof(PluginEnabled), ref _pluginEnabled, value); }
        }

        private int _alarmInterval = 1;
        public int AlarmInterval
        {
            get { return _alarmInterval; }
            set { SetPropertyField(nameof(AlarmInterval), ref _alarmInterval, value); }
        }


        private string _mobile = "";
        public string Mobile
        {
            get { return _mobile; }
            set { SetPropertyField(nameof(Mobile), ref _mobile, value); }
        }

        private bool _mobileNotificationEnabled = false;
        private bool disposedValue;

        public bool MobileNotificationEnabled
        {
            get { return _mobileNotificationEnabled; }
            set { SetPropertyField(nameof(MobileNotificationEnabled), ref _mobileNotificationEnabled, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
    }
}