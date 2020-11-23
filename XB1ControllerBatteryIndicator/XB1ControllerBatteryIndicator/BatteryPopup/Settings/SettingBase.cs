using System;
using Caliburn.Micro;

namespace XB1ControllerBatteryIndicator.BatteryPopup.Settings
{
	public abstract class SettingBase<T> : PropertyChangedBase
	{
		private string _caption;
		private T _value;

		public string Caption
		{
			get => _caption;
			set => Set(ref _caption, value);
		}

		public T Value
		{
			get => _value;
			set => Set(ref _value, value);
		}

		public event EventHandler<EventArgs> ValueChanged;

		protected SettingBase(string caption, T value)
		{
			Caption = caption;
			_value = value;
		}

		public override void NotifyOfPropertyChange(string propertyName = null)
		{
			base.NotifyOfPropertyChange(propertyName);

			if (propertyName == nameof(Value))
			{
				if (!ValidateValue())
					return;

				OnValueChanged();
			}
		}

		protected virtual void OnValueChanged()
		{
			ValueChanged?.Invoke(this, EventArgs.Empty);
		}

		protected virtual bool ValidateValue()
		{
			return true;
		}
	}
}
