﻿using System.Collections.Generic;

namespace myDash.Shared
{
    public class WidgetSettings
    {
        public string widget { get; set; }
        public Dictionary<string, object> parameters {get; private set; } = 
            new Dictionary<string, object>();
    }
}