using CoreLocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radar.iOS
{
    public class GPSAtualizacaoEventArgs : EventArgs
    {
        CLLocation location;

        public GPSAtualizacaoEventArgs(CLLocation location)
        {
            this.location = location;
        }

        public CLLocation Location
        {
            get { return location; }
        }
    }
}
