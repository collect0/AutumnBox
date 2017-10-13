/* =============================================================================*\
*
* Filename: BreventServiceActivator.cs
* Description: 
*
* Version: 1.0
* Created: 9/22/2017 03:13:12(UTC+8:00)
* Compiler: Visual Studio 2017
* 
* Author: zsh2401
* Company: I am free man
*
\* =============================================================================*/
/*
 黑域激活器
 @zsh2401
 2017/9/8
 */
namespace AutumnBox.Basic.Function.Modules
{
    using AutumnBox.Basic.Executer;
    using AutumnBox.Basic.Function.Args;
    using AutumnBox.Basic.Function.Interface;
    /// <summary>
    /// 黑域服务激活器
    /// </summary>
    public sealed class BreventServiceActivator : FunctionModule
    {
        private const string DEFAULT_COMMAND = "shell \"sh /data/data/me.piebridge.brevent/brevent.sh\"";
        protected override OutputData MainMethod()
        {
            var o = 
                new ActivityLauncher(new ActivityLaunchArgs()
                { PackageName = "me.piebridge.brevent", ActivityName = ".ui.BreventActivity" })
                { DevSimpleInfo = this.DevSimpleInfo}.FastRun();
            o.Append(Ae(DEFAULT_COMMAND));
            return o;
        }
        protected override void HandingOutput(OutputData output, ref ExecuteResult result)
        {
            result = new ExecuteResult(output);
            if (output.Error != null) result.ResultType = ExecuteResult.Type.Unsuccessful;
            if(output.Out.ToString().ToLower().Contains("warning")) result.ResultType = ExecuteResult.Type.Unsuccessful;
            base.HandingOutput(output, ref result);
        }
    }
}
