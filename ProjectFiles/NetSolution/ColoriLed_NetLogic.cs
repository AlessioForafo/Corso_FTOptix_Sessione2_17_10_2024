#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.WebUI;
using FTOptix.Recipe;
using FTOptix.DataLogger;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.OPCUAServer;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.Alarm;
#endregion

public class ColoriLed_NetLogic : BaseNetLogic
{
    private IUAVariable varPLC;

    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        varPLC = Project.Current.GetVariable("Model/ColoriLed");
        varPLC.VariableChange += VarPLC_VariableChange;
    }

    private void VarPLC_VariableChange(object sender, VariableChangeEventArgs e)
    {
        var mioLed = (Led)Owner;
        if (e.NewValue > 5)
            mioLed.Color = Colors.Red;
        else
            mioLed.Color = Colors.Green;
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        varPLC.VariableChange -= VarPLC_VariableChange;
    }
}
