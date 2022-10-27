using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Our logger service will contain four methods for logging our messages:
//Info messages
//Debug messages
//Warning messages
//Error messages
namespace Contracts
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
