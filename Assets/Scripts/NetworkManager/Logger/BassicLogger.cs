using UnityEngine;
using System;

public sealed class BasicLogger : Phoenix.ILogger
{

    #region ILogger implementation

    public void Log(Phoenix.LogLevel level, string source, string message)
    {
        UnityEngine.MonoBehaviour.print(string.Format("[{0}]: {1} - {2}", level, source, message));
    }

    #endregion
}