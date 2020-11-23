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
		private SolidColorBrush _backgroundBrush;
		private SolidColorBrush _foregroundBrush;
		private Thickness _borderSize;
		private string _controllerName;
		private double _fontSize;
		private Size _size;
		private FontFamily _fontFamily;
		private FontStyle _fontStyle;
		private FontWeight _fontWeight;
		private TextDecorationCollection _textDecoration;

		public SimpleBatteryLevelPopupViewModel(SimpleBatteryPopupSettings settings, string controllerName, string batteryLevel)
		{
			ControllerName = controllerName;
			BatteryLevel = batteryLevel;
			DisplayDuration = settings.DisplayDuration;
			Position = CalculatePosition(settings);
			Size = settings.Size;
			BackgroundColor = settings.BackgroundColor;
			ForegroundColor = settings.ForegroundColor;
			BorderSize = new Thickness(2);
			FontSize = settings.FontSize;
			FontFamilyName = settings.FontName;
			IsBold = settings.FontBold;
			IsItalic = settings.FontItalic;
			IsUnderline = settings.FontUnderline;
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

		public Color BackgroundColor
		{
			get => BackgroundBrush.Color;
			set => BackgroundBrush = new SolidColorBrush(value);
		}

		public SolidColorBrush BackgroundBrush
		{
			get { return _backgroundBrush; }
			set { Set(ref _backgroundBrush, value); }
		}

		public Color ForegroundColor
		{
			get => ForegroundBrush.Color;
			set => ForegroundBrush = new SolidColorBrush(value);
		}

		public SolidColorBrush ForegroundBrush
		{
			get { return _foregroundBrush; }
			set { Set(ref _foregroundBrush, value); }
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

		public string FontFamilyName
		{
			get => FontFamily.Source;
			set => FontFamily = new FontFamily(value);
		}

		public FontFamily FontFamily
		{
			get { return _fontFamily; }
			set { Set(ref _fontFamily, value); }
		}

		public bool IsBold
		{
			get => FontWeight == FontWeights.Bold;
			set => FontWeight = value ? FontWeights.Bold : FontWeights.Normal;
		}

		public FontStyle FontStyle
		{
			get { return _fontStyle; }
			set { Set(ref _fontStyle, value); }
		}

		public bool IsItalic
		{
			get => FontStyle == FontStyles.Italic;
			set => FontStyle = value ? FontStyles.Italic : FontStyles.Normal;
		}

		public FontWeight FontWeight
		{
			get { return _fontWeight; }
			set { Set(ref _fontWeight, value); }
		}

		public bool IsUnderline
		{
			get => TextDecoration == TextDecorations.Underline;
			set => TextDecoration = value ? TextDecorations.Underline : new TextDecorationCollection();
		}

		public TextDecorationCollection TextDecoration
		{
			get { return _textDecoration; }
			set { Set(ref _textDecoration, value); }
		}
	}
}
