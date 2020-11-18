using System;
using System.Windows;
using System.Windows.Media;
using Caliburn.Micro;

namespace XB1ControllerBatteryIndicator.BatteryPopup
{
	public class SimpleBatteryLevelPopupViewModel : PropertyChangedBase, IBatteryLevelPopupViewModel
	{
		private string _message;
		private TimeSpan _displayDuration;
		private Rect _position;
		private CornerRadius _cornerRadius;
		private SolidColorBrush _background;
		private SolidColorBrush _borderColor;
		private Thickness _borderSize;

		public string Message
		{
			get { return _message; }
			set { Set(ref _message, value); }
		}

		public TimeSpan DisplayDuration
		{
			get { return _displayDuration; }
			set { Set(ref _displayDuration, value); }
		}

		public Rect Position
		{
			get { return _position; }
			set { Set(ref _position, value); }
		}

		public CornerRadius CornerRadius
		{
			get { return _cornerRadius; }
			set { Set(ref _cornerRadius, value); }
		}

		public SolidColorBrush Background
		{
			get { return _background; }
			set { Set(ref _background, value); }
		}

		public SolidColorBrush BorderColor
		{
			get { return _borderColor; }
			set { Set(ref _borderColor, value); }
		}

		public Thickness BorderSize
		{
			get { return _borderSize; }
			set { Set(ref _borderSize, value); }
		}
	}
}
