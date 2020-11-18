using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace XB1ControllerBatteryIndicator.BatteryPopup
{
	/// <summary>
	/// Interaction logic for BatteryLevelPopupView.xaml
	/// </summary>
	public partial class BatteryLevelPopupView : Popup
	{
		public static readonly DependencyProperty DisplayDurationProperty = DependencyProperty.Register(
			"DisplayDuration", typeof(TimeSpan), typeof(BatteryLevelPopupView), new PropertyMetadata(TimeSpan.FromSeconds(3)));

		public TimeSpan DisplayDuration
		{
			get { return (TimeSpan) GetValue(DisplayDurationProperty); }
			set { SetValue(DisplayDurationProperty, value); }
		}

		private readonly DispatcherTimer _timer;

		public BatteryLevelPopupView()
		{
			InitializeComponent();
			_timer = new DispatcherTimer(DispatcherPriority.Background, Dispatcher);
			Opened += OnOpened;
		}

		private void OnOpened(object sender, EventArgs e)
		{
			_timer.Interval = DisplayDuration;
			_timer.Start();
			_timer.Tick += TimerOnTick;
		}

		private void TimerOnTick(object sender, EventArgs e)
		{
			_timer.Stop();
			IsOpen = false;
		}
	}
}
