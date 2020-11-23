using System;
using System.Windows;
using Caliburn.Micro;
using XB1ControllerBatteryIndicator.Localization;

namespace XB1ControllerBatteryIndicator.BatteryPopup.Settings
{
	internal class BatteryPopupSettingsViewModel : Screen
	{
		private SimpleBatteryLevelPopupViewModel _currentPopup;

		public BatteryPopupSettingsViewModel()
		{
			X = new NumberSetting(Strings.PopupSettings_X, Properties.Settings.Default.PopupSettings.X * 100, 0, 100, Strings.PopupSettings_Percent);
			Y = new NumberSetting(Strings.PopupSettings_Y, Properties.Settings.Default.PopupSettings.Y * 100, 0, 100, Strings.PopupSettings_Percent);

			Width = new NumberSetting(Strings.PopupSettings_Width, Properties.Settings.Default.PopupSettings.Size.Width, 0, SystemParameters.PrimaryScreenWidth, Strings.PopupSettings_Pixel);
			Width.ValueChanged += (sender, args) => CurrentPopup.Size = new Size(Width.Value, Height.Value);
			Height = new NumberSetting(Strings.PopupSettings_Height, Properties.Settings.Default.PopupSettings.Size.Height, 0, SystemParameters.PrimaryScreenHeight, Strings.PopupSettings_Pixel);
			Height.ValueChanged += (sender, args) => CurrentPopup.Size = new Size(Width.Value, Height.Value);

			BackgroundColor = new ColorSetting(Strings.PopupSettings_Background, Properties.Settings.Default.PopupSettings.BackgroundColor);
			BackgroundColor.ValueChanged += (sender, args) => CurrentPopup.BackgroundColor = BackgroundColor.Value;
			ForegroundColor = new ColorSetting(Strings.PopupSettings_Foreground, Properties.Settings.Default.PopupSettings.ForegroundColor);
			ForegroundColor.ValueChanged += (sender, args) => CurrentPopup.ForegroundColor = ForegroundColor.Value;

			FontSize = new NumberSetting(Strings.PopupSettings_FontSize, Properties.Settings.Default.PopupSettings.FontSize, 1, 100, Strings.PopupSettings_Pixel);
			FontSize.ValueChanged += (sender, args) => CurrentPopup.FontSize = FontSize.Value;
			FontFamily = new FontSetting(Strings.PopupSettings_FontName, Properties.Settings.Default.PopupSettings.FontName);
			FontFamily.ValueChanged += (sender, args) => CurrentPopup.FontFamilyName = FontFamily.Value;
			FontBold = new BoolSetting(Strings.PopupSettings_FontBold, Properties.Settings.Default.PopupSettings.FontBold);
			FontBold.ValueChanged += (sender, args) => CurrentPopup.IsBold = FontBold.Value;
			FontItalic = new BoolSetting(Strings.PopupSettings_FontItalic, Properties.Settings.Default.PopupSettings.FontItalic);
			FontItalic.ValueChanged += (sender, args) => CurrentPopup.IsItalic = FontItalic.Value;
			FontUnderline = new BoolSetting(Strings.PopupSettings_FontUnderline, Properties.Settings.Default.PopupSettings.FontUnderline);
			FontUnderline.ValueChanged += (sender, args) => CurrentPopup.IsUnderline = FontUnderline.Value;

			DisplayDuration = new NumberSetting(Strings.PopupSettings_DisplayDuration, Properties.Settings.Default.PopupSettings.DisplayDuration.Seconds, 1, 30, Strings.PopupSettings_Seconds);
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
		public BoolSetting FontBold { get; }
		public BoolSetting FontItalic { get; }
		public BoolSetting FontUnderline { get; }

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
				FontBold = FontBold.Value,
				FontItalic = FontItalic.Value,
				FontUnderline = FontUnderline.Value,
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
