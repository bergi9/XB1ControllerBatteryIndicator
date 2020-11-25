using System.Collections.Generic;
using System.Runtime.InteropServices;
using SharpDX.XInput;

namespace XB1ControllerBatteryIndicator
{
	internal static class XInputWrapper
	{
		private const ushort GuideGamepadButtonFlag = 0x0400;

		[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "#100")]
		private static extern int XInputGetStateEx(int controllerIndex, out State state);

		private static readonly Dictionary<UserIndex, bool> GuideStates = new Dictionary<UserIndex, bool>()
		{
			{UserIndex.One, false}, {UserIndex.Two, false}, {UserIndex.Three, false}, {UserIndex.Four, false},
			{UserIndex.Any, false}
		};

		public static bool IsGuidePressed(UserIndex controllerIndex)
		{
			State state;
			var result = XInputGetStateEx((int) controllerIndex, out state);
			if (result == 0)
			{
				var currentState = ((ushort) state.Gamepad.Buttons & GuideGamepadButtonFlag) != 0;
				var previousState = GuideStates[controllerIndex];
				GuideStates[controllerIndex] = currentState;
				return previousState && !currentState;
			}
			if (result == 1167)
			{
				GuideStates[controllerIndex] = false;
			}

			return false;
		}
	}
}
