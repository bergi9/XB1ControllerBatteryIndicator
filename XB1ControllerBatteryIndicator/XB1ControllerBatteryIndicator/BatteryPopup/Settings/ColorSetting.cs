using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Caliburn.Micro;

namespace XB1ControllerBatteryIndicator.BatteryPopup.Settings
{
	internal class ColorSetting : PropertyChangedBase
	{
		private string _caption;
		private Color _value;

		public string Caption
		{
			get => _caption;
			set => Set(ref _caption, value);
		}

		public Color Value
		{
			get => _value;
			set => Set(ref _value, value);
		}

		public IEnumerable<KeyValuePair<string, Color>> Colors { get; }

		public ColorSetting(string caption, Color value)
		{
			Colors = typeof(Colors).GetProperties().Select(info => new KeyValuePair<string, Color>(info.Name, (Color)info.GetValue(null))).ToList();

			Caption = caption;
			Value = value;
		}
	}
}
