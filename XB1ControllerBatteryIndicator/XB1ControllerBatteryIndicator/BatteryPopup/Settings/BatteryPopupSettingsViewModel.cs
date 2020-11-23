using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Caliburn.Micro;
using XB1ControllerBatteryIndicator.Localization;

namespace XB1ControllerBatteryIndicator.BatteryPopup.Settings
{
	internal class BatteryPopupSettingsViewModel : Screen
	{
		private SimpleBatteryLevelPopupViewModel _currentPopup;

		public BatteryPopupSettingsViewModel()
		{
			X = new NumberSetting(Strings.PopupSettings_X, (int)(Properties.Settings.Default.PopupSettings.X * 100), 0, 100, Strings.PopupSettings_Percent);
			Y = new NumberSetting(Strings.PopupSettings_Y, (int)(Properties.Settings.Default.PopupSettings.Y * 100), 0, 100, Strings.PopupSettings_Percent);

			Width = new NumberSetting(Strings.PopupSettings_Width, (int)Properties.Settings.Default.PopupSettings.Size.Width, 0, (int)SystemParameters.PrimaryScreenWidth, Strings.PopupSettings_Pixel);
			Height = new NumberSetting(Strings.PopupSettings_Height, (int)Properties.Settings.Default.PopupSettings.Size.Height, 0, (int)SystemParameters.PrimaryScreenHeight, Strings.PopupSettings_Pixel);

			Width.PropertyChanged += WidthOnPropertyChanged;
			Height.PropertyChanged += HeightOnPropertyChanged;

			BackgroundColor = new ColorSetting(Strings.PopupSettings_Background, Properties.Settings.Default.PopupSettings.BackgroundColor);
			BackgroundColor.PropertyChanged += BackgroundColorOnPropertyChanged;
			ForegroundColor = new ColorSetting(Strings.PopupSettings_Foreground, Properties.Settings.Default.PopupSettings.ForegroundColor);
			ForegroundColor.PropertyChanged += ForegroundColorOnPropertyChanged;

			FontSize = new NumberSetting(Strings.PopupSettings_FontSize, (int) Properties.Settings.Default.PopupSettings.FontSize, 1, 100, Strings.PopupSettings_Pixel);
			FontSize.PropertyChanged += FontSizeOnPropertyChanged;
			FontFamily = new FontSetting(Strings.PopupSettings_FontName, Properties.Settings.Default.PopupSettings.FontName);
			FontFamily.PropertyChanged += FontFamilyOnPropertyChanged;

			DisplayDuration = new NumberSetting(Strings.PopupSettings_DisplayDuration, Properties.Settings.Default.PopupSettings.DisplayDuration.Seconds, 1, 30, Strings.PopupSettings_Seconds);
		}

		private void FontFamilyOnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(FontSetting.Value))
			{
				CurrentPopup.FontFamily = new FontFamily(FontFamily.Value);
			}
		}

		private void WidthOnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(NumberSetting.Value))
			{
				CurrentPopup.Size = new Size(Width.Value, Height.Value);
			}
		}

		private void FontSizeOnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(NumberSetting.Value))
			{
				CurrentPopup.FontSize = FontSize.Value;
			}
		}

		private void ForegroundColorOnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(ColorSetting.Value))
			{
				CurrentPopup.ForegroundColor = new SolidColorBrush(ForegroundColor.Value);
			}
		}

		private void BackgroundColorOnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(ColorSetting.Value))
			{
				CurrentPopup.BackgroundColor = new SolidColorBrush(BackgroundColor.Value);
			}
		}

		private void HeightOnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(NumberSetting.Value))
			{
				CurrentPopup.Size = new Size(Width.Value, Height.Value);
			}
		}

		public SimpleBatteryLevelPopupViewModel CurrentPopup
		{
			get => _currentPopup;
			set => Set(ref _currentPopup, value);
		}

		public NumberSetting X { get; }
		public NumberSetting Y { get; }
		public NumberSetting Width { get; }
		public NumberSetting Height { get; }

		public ColorSetting BackgroundColor { get; }
		public ColorSetting ForegroundColor { get; }

		public NumberSetting FontSize { get; }
		public FontSetting FontFamily { get; }

		public NumberSetting DisplayDuration { get; }

		public void Save()
		{
			Properties.Settings.Default.PopupSettings = new SimpleBatteryPopupSettings()
			{
				X = X.Value / 100.0,
				Y = Y.Value / 100.0,
				Size = new Size(Width.Value, Height.Value),
				BackgroundColor = BackgroundColor.Value,
				ForegroundColor = ForegroundColor.Value,
				FontSize = FontSize.Value,
				DisplayDuration = TimeSpan.FromSeconds(DisplayDuration.Value),
				FontName = FontFamily.Value,
			};

			Properties.Settings.Default.Save();

			TryClose(true);
		}

		public void Cancel()
		{
			TryClose(false);
		}
	}
}
