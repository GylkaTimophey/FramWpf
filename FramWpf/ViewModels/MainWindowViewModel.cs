using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FramWpf.ViewModel {
    public class MainWindowViewModel {
        public ShapesVM ShapesVM { get; set; } = new ShapesVM();
        public MouseBehaviour MouseBehaviour { get; set; } = new MouseBehaviour();
        public CursorPosition CursorPosition { get; set; } = new CursorPosition();
    }
}
