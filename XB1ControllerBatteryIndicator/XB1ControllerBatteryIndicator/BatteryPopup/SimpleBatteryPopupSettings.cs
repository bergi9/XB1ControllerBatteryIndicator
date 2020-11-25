using System;
using System.Configuration;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace XB1ControllerBatteryIndicator.BatteryPopup
{
	[SettingsSerializeAs(SettingsSerializeAs.Xml)]
	[Serializable]
	public class SimpleBatteryPopupSettings
	{
		public Size Size { get; set; }
		public double X { get; set; }
		public double Y { get; set; }
		[XmlIgnore]
		public TimeSpan DisplayDuration { get; set; }

		[XmlElement(nameof(DisplayDuration))]
		public string DisplayDurationString
		{
			get => DisplayDuration.ToString("g");
			set => DisplayDuration = TimeSpan.Parse(value);
		}

		[XmlIgnore]
		public Color BackgroundColor { get; set; }

		[XmlElement(nameof(BackgroundColor))]
		public string BackgroundColorString
		{
			get => BackgroundColor.ToString();
			set => BackgroundColor = (Color)ColorConverter.ConvertFromString(value);
		}

		[XmlIgnore]
		public Color ForegroundColor { get; set; }

		[XmlElement(nameof(ForegroundColor))]
		public string ForegroundColorString
		{
			get => ForegroundColor.ToString();
			set => ForegroundColor = (Color)ColorConverter.ConvertFromString(value);
		}

		public double FontSize { get; set; }
		public string FontName { get; set; }
		public bool FontBold { get; set; }
		public bool FontItalic { get; set; }
		public bool FontUnderline { get; set; }
	}
}
