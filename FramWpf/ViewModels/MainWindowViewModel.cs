using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FramWpf.ViewModel {
    public class MainWindowViewModel {
        public ShapesVM ShapesVM { get; set; } = new ShapesVM();
        public CursorPosition CursorPosition { get; set; } = new CursorPosition();
        public MouseBehaviour MouseBehaviour { get; set; } = new MouseBehaviour();
    }
}
