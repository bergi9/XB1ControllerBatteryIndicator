using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SharpDX.XInput;

namespace XB1ControllerBatteryIndicator
{
	internal static class XInputWrapper
	{
		private const ushort GuideGamepadButtonFlag = 0x0400;

		[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "#100")]
		private static extern int XInputGetStateEx(int controllerIndex, out State state);

		public static bool IsGuidePressed(UserIndex controllerIndex)
		{
			State state;
			if (XInputGetStateEx((int) controllerIndex, out state) == 0)
				return ((ushort)state.Gamepad.Buttons & GuideGamepadButtonFlag) != 0;
			return false;
		}
	}
}
