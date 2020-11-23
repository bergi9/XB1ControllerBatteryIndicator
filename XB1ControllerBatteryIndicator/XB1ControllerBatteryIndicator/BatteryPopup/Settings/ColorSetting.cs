using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace XB1ControllerBatteryIndicator.BatteryPopup.Settings
{
	internal class ColorSetting : SettingBase<Color>
	{
		public IEnumerable<KeyValuePair<string, Color>> Colors { get; }

		public ColorSetting(string caption, Color value) : base(caption, value)
		{
			Colors = typeof(Colors).GetProperties().Select(info => new KeyValuePair<string, Color>(info.Name, (Color)info.GetValue(null))).ToList();
		}
	}
}
