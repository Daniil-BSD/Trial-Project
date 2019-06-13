using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Trial_Task.Domain.Enumerations
{
    public enum EFlightStatus : byte
    {
        [Description("under approval")]
        Pending = 0,

        [Description("approved")]
        Approved = 1,

        [Description("rejected")]
        Rejected = 2
    }
}
