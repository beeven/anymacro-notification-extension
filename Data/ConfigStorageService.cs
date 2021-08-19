using System;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;
using WebExtensions.Net;
using System.ComponentModel;
using System.Collections.Generic;
using WebExtensions.Net.Storage;

namespace anymacro_notification_blazor
{
    public class ConfigStorageService: IDisposable
    {
        private readonly IWebExtensionsApi _webExtensions;
        private PluginConfig _config;
        private bool disposedValue;

        public ConfigStorageService(IWebExtensionsApi webExtensions)
        {
            _webExtensions = webExtensions;
        }

        public async Task<PluginConfig> GetConfig()
        {
            if (_config != null)
            {
                return _config;
            }
            else
            {
                _config = await LoadConfigAsync();
                _config.PropertyChanged += OnConfigChanged;
                return _config;
            }
        }

        private async Task<PluginConfig> LoadConfigAsync()
        {
            using var store = await _webExtensions.Storage.GetLocal();

            var values = await store.Get(new StorageAreaGetKeys(typeof(PluginConfig).GetProperties().Select(x => x.Name)));
            var valuesStr = values.GetRawText();
            System.Console.WriteLine(valuesStr);
            var ret = System.Text.Json.JsonSerializer.Deserialize<PluginConfig>(valuesStr);
            return ret;
        }



        private async void OnConfigChanged(object sender, PropertyChangedEventArgs eventArgs)
        {
            using var store = await _webExtensions.Storage.GetLocal();

            await store.Set(new Dictionary<string, object>()
                {
                    {
                        eventArgs.PropertyName,
                        typeof(PluginConfig).GetProperty(eventArgs.PropertyName).GetValue(_config)
                    }
                }
            );
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _config.PropertyChanged -= OnConfigChanged;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ConfigStorageService()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}