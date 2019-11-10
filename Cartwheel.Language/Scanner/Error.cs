using System;
using System.Collections.Generic;
using System.Text;

namespace Cartwheel.Language
{
    public class Error
    {

        public bool HasScanError { get; set; }
        public int ScanErrorLocation { get; set; }
        public char ScanErrorChar { get; set; }

    }
}
