using FramWpf.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace FramWpf.ViewModel {
    public class CursorPosition : INotifyPropertyChanged {
        private double _panelX;
        private double _panelY;

        public double PanelX {
            get {
                return _panelX;
            }
            set {
                if (value.Equals(_panelX)) {
                    return;
                }
                _panelX = value;
                OnPropertyChanged("PanelX");
            }
        }

        public double PanelY {
            get {
                return _panelY;
            }
            set {
                if (value.Equals(_panelY)) {
                    return;
                }
                _panelY = value;
                OnPropertyChanged("PanelY");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {
            VerifyPropertyName(propertyName);
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName) {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null) {
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
            }
        }
    }
}
