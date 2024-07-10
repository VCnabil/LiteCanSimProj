using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCanSimProj._Globalz
{
    public static class EventsManagerLib
    {
        public delegate void EventLogConsole_Handler(string arg_strval);
        public static event EventLogConsole_Handler OnLogConsoleEvent;
        public static void Call_LogConsole(string srg_str)
        {
            OnLogConsoleEvent?.Invoke(srg_str);
        }

        public delegate void EventLogConsoleCLEAR_Handler();
        public static event EventLogConsoleCLEAR_Handler OnLogConsoleEventCLEAR;
        public static void Call_LogConsoleCLEAR()
        {
            OnLogConsoleEventCLEAR?.Invoke();
        }

        public delegate void EventHandBroadcastHandler(string arg_strval, int arg_intval, bool arg_Bool0);
        public static event EventHandBroadcastHandler OnHandBroadcast;
        public static void CallHandBroadcast(string srg_str, int arg_int, bool arg_bool)
        {
            OnHandBroadcast?.Invoke(srg_str, arg_int, arg_bool);
        }

        public delegate void EventHandTickPingPong();
        public static event EventHandTickPingPong OnHandTickPingPong;
        public static void CallHandTickPingPong()
        {
            OnHandTickPingPong?.Invoke();
        }   
    }
}
