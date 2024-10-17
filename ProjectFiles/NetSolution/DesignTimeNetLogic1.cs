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

public class DesignTimeNetLogic1 : BaseNetLogic
{
    [ExportMethod]
    public void Method1()
    {
        // Insert code to be executed by the method
        Log.Info("Test script DesignTime");
    }

    [ExportMethod]
    public void CreaAllarmi()
    {
        var numeroAllarmi = LogicObject.GetVariable("NumAllarmi");
        for (int i = 0; i < numeroAllarmi.Value; i++) 
        { 
            var mioAllarme = InformationModel.Make<DigitalAlarm>("Allarme_" + i);
            mioAllarme.Message = "Testo allarme " + i;
            mioAllarme.InputValueVariable.SetDynamicLink(Project.Current.GetVariable("Model/Allarmi"), (uint)i, DynamicLinkMode.ReadWrite);
            Project.Current.Get("Alarms").Add(mioAllarme);
        }
    }
}
