using Caliburn.Micro;

namespace XB1ControllerBatteryIndicator.BatteryPopup.Settings
{
	internal class NumberSetting : PropertyChangedBase
	{
		private int _value;
		private int _minValue;
		private int _maxValue;
		private string _caption;
		private string _unit;

		public NumberSetting(string caption, int value, int minValue, int maxValue, string unit)
		{
			Caption = caption;
			Value = value;
			MinValue = minValue;
			MaxValue = maxValue;
			Unit = unit;
		}

		public string Caption
		{
			get => _caption;
			set => Set(ref _caption, value);
		}

		public int Value
		{
			get => _value;
			set => Set(ref _value, value);
		}

		public int MinValue
		{
			get => _minValue;
			set => Set(ref _minValue, value);
		}

		public int MaxValue
		{
			get => _maxValue;
			set => Set(ref _maxValue, value);
		}

		public string Unit
		{
			get => _unit;
			set => Set(ref _unit, value);
		}
	}
}
