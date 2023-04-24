using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public enum ServerStatus
    {
        Normal = 0,
        Stop = 1,
    }


    public class ServerInfo :Entity, IAwake
    {
        public int Int_Status;
        public string Str_ServerName;

    }
}
