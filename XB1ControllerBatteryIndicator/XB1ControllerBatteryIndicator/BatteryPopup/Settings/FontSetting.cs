using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace XB1ControllerBatteryIndicator.BatteryPopup.Settings
{
	public class FontSetting : SettingBase<string>
	{
		public ICollection<FontFamily> Fonts { get; }

		public FontSetting(string caption, string value) : base(caption, value)
		{
			Fonts = System.Windows.Media.Fonts.SystemFontFamilies.OrderBy(family => family.Source).ToList();
		}
	}
}
