using System;
using System.Windows;
using System.Windows.Media;
using Caliburn.Micro;

namespace XB1ControllerBatteryIndicator.BatteryPopup
{
	public class SimpleBatteryLevelPopupViewModel : PropertyChangedBase, IBatteryLevelPopupViewModel
	{
		private string _batteryLevel;
		private TimeSpan _displayDuration;
		private Point _position;
		private CornerRadius _cornerRadius;
		private SolidColorBrush _backgroundColor;
		private SolidColorBrush _foregroundColor;
		private Thickness _borderSize;
		private string _controllerName;
		private double _fontSize;
		private Size _size;
		private FontFamily _fontFamily;

		public SimpleBatteryLevelPopupViewModel(SimpleBatteryPopupSettings settings, string controllerName, string batteryLevel)
		{
			ControllerName = controllerName;
			BatteryLevel = batteryLevel;
			DisplayDuration = settings.DisplayDuration;
			Position = CalculatePosition(settings);
			Size = settings.Size;
			BackgroundColor = new SolidColorBrush(settings.BackgroundColor);
			ForegroundColor = new SolidColorBrush(settings.ForegroundColor);
			BorderSize = new Thickness(2);
			FontSize = settings.FontSize;
			FontFamily = new FontFamily(settings.FontName);
		}

		private Point CalculatePosition(SimpleBatteryPopupSettings settings)
		{
			var displaySize = new Size(SystemParameters.PrimaryScreenWidth, SystemParameters.PrimaryScreenHeight);
			var x = displaySize.Width * settings.X - settings.Size.Width / 2;
			var y = displaySize.Height * settings.Y - settings.Size.Height / 2;
			return new Point(x, y);
		}

		public string ControllerName
		{
			get { return _controllerName; }
			set { Set(ref _controllerName, value); }
		}

		public string BatteryLevel
		{
			get { return _batteryLevel; }
			set { Set(ref _batteryLevel, value); }
		}

		public TimeSpan DisplayDuration
		{
			get { return _displayDuration; }
			set { Set(ref _displayDuration, value); }
		}

		public Point Position
		{
			get { return _position; }
			set { Set(ref _position, value); }
		}

		public Size Size
		{
			get { return _size; }
			set
			{
				if (Set(ref _size, value))
					CornerRadius = new CornerRadius(Size.Height / 2);
			}
		}

		public CornerRadius CornerRadius
		{
			get { return _cornerRadius; }
			private set { Set(ref _cornerRadius, value); }
		}

		public SolidColorBrush BackgroundColor
		{
			get { return _backgroundColor; }
			set { Set(ref _backgroundColor, value); }
		}

		public SolidColorBrush ForegroundColor
		{
			get { return _foregroundColor; }
			set { Set(ref _foregroundColor, value); }
		}

		public Thickness BorderSize
		{
			get { return _borderSize; }
			set { Set(ref _borderSize, value); }
		}

		public double FontSize
		{
			get { return _fontSize; }
			set { Set(ref _fontSize, value); }
		}

		public FontFamily FontFamily
		{
			get { return _fontFamily; }
			set { Set(ref _fontFamily, value); }
		}
	}
}
