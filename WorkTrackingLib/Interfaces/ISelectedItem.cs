﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTrackingLib.Interfaces
{
    public interface ISelectedItem : ICloneable
    {
        int Id { get; set; }

        string Name { get; set; }
    }
}
