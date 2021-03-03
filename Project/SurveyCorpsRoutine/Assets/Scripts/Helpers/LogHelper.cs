using System;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Helpers
{
    public class LogHelper : MonoBehaviour
    {
        public static void LogMessage(string message, LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Info:
                    Debug.Log(message);
                    break;
                case LogLevel.Warn:
                    Debug.LogWarning(message);
                    break;
                case LogLevel.Error:
                    Debug.LogError(message);
                    break;
            }
        }
    
        public static void LogDeletedDuplicateSingletonComponent(MonoBehaviour deletedComponent, 
            GameObject firstSingletonGO, LogLevel logLevel = LogLevel.Warn)
        {
            string message = String.Format("{0} already exist on '{1}', Component on '{2}' was deleted",
                deletedComponent.GetType().ToString(), firstSingletonGO, deletedComponent.gameObject);
            LogMessage(message, logLevel);
        }
    }
}
