﻿using GHelper.Helpers;
using System.Diagnostics;

namespace GHelper.Battery
{
    internal class BatteryControl
    {

        public static void SetBatteryChargeLimit(int limit = -1)
        {

            if (limit < 0) limit = AppConfig.Get("charge_limit");
            if (limit < 40 || limit > 100) return;

            Program.settingsForm.VisualiseBattery(limit);

            Program.acpi.DeviceSet(AsusACPI.BatteryLimit, limit, "BatteryLimit");

            try
            {
                OptimizationService.SetChargeLimit(limit);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            AppConfig.Set("charge_limit", limit);

        }

    }
}
