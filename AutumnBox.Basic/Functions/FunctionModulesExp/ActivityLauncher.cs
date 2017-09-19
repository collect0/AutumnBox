﻿/*
 Activity启动器
 */
using AutumnBox.Basic.Executer;
using AutumnBox.Basic.Util;
namespace AutumnBox.Basic.Functions
{
    /// <summary>
    /// 活动启动器
    /// </summary>
    public sealed class  ActivityLauncher:FunctionModule
    {
        private ActivityLaunchArgs Args;
        public ActivityLauncher(ActivityLaunchArgs args)  {
            this.Args = args;
        }
        protected override OutputData MainMethod()
        {
            Logger.D(TAG,$"Try Launch {DeviceID} Activity : {Args.ActivityName}");
            string command = $"shell am start -n {Args.PackageName}/{Args.PackageName + Args.ActivityName}";
            executer.ExecuteWithDevice(this.DeviceID,command,out OutputData o);
            return o;
        }
    }
}
