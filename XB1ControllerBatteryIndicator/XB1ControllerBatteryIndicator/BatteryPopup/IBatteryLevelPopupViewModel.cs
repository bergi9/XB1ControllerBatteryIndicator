using System;
using System.Windows;

namespace XB1ControllerBatteryIndicator.BatteryPopup
{
	public interface IBatteryLevelPopupViewModel
	{
		TimeSpan DisplayDuration { get; }
		Rect Position { get; }
	}
}
