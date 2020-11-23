using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Caliburn.Micro;

namespace XB1ControllerBatteryIndicator.BatteryPopup.Settings
{
	public class FontSetting : PropertyChangedBase
	{
		private string _value;
		private string _caption;

		public string Value
		{
			get => _value;
			set => Set(ref _value, value);
		}

		public string Caption
		{
			get => _caption;
			set => Set(ref _caption, value);
		}

		public ICollection<FontFamily> Fonts { get; }

		public FontSetting(string caption, string value)
		{
			Fonts = System.Windows.Media.Fonts.SystemFontFamilies.OrderBy(family => family.Source).ToList();

			Caption = caption;
			Value = value;
		}
	}
}
