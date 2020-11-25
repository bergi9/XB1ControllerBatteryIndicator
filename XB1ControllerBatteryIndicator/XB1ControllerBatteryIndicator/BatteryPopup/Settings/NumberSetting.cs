namespace XB1ControllerBatteryIndicator.BatteryPopup.Settings
{
	internal class NumberSetting : SettingBase<int>
	{
		private int _minValue;
		private int _maxValue;
		private string _unit;

		public NumberSetting(string caption, int value, int minValue, int maxValue, string unit) : base(caption, value)
		{
			MinValue = minValue;
			MaxValue = maxValue;
			Unit = unit;
		}

		public NumberSetting(string caption, double value, double minValue, double maxValue, string unit) : this(caption, (int)value, (int)minValue, (int)maxValue, unit)
		{
		}

		protected override bool ValidateValue()
		{
			if (Value > MaxValue)
			{
				Value = MaxValue;
				return false;
			}

			if (Value < MinValue)
			{
				Value = MinValue;
				return false;
			}

			return true;
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
