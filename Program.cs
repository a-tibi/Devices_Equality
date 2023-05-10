using System;

namespace Devices_Equality
{
	class Program
	{
		static void Main(string[] args)
		{
			Device device1 = new Device { PhysicalAddress = "01-01-01-01-01-01", LogicalAddress = "10.0.0.1", Function = DeviceFunctions.Router };
			Device device2 = new Device { PhysicalAddress = "01-01-01-01-01-01", LogicalAddress = "10.0.0.1", Function = DeviceFunctions.Router };

			Console.WriteLine($"device1 == device2: {device1==device2}");
			Console.WriteLine($"device1.Equals(device2): {device1.Equals(device2)}");
			
			Console.WriteLine($"device1's hascode == device2's hash code: {device1.GetHashCode() == device2.GetHashCode()}");
			Console.WriteLine($"devcie1.GetHasCode: {device1.GetHashCode()}");
			Console.WriteLine($"devcie2.GetHasCode: {device2.GetHashCode()}");

			Console.ReadKey();
		}
	}

	class Device
	{
		public string PhysicalAddress { get; set; }
		public string LogicalAddress { get; set; }
		public DeviceFunctions Function { get; set; }

		public override bool Equals(object obj)
		{
			if ((obj is null) || (!(obj is Device)))
				return false;
			var device = obj as Device;

			return this.PhysicalAddress == device.PhysicalAddress &&
				   this.LogicalAddress == device.LogicalAddress &&
				   this.Function == device.Function;
		}

		public override int GetHashCode()
		{
			var hash = 13;
			hash = (hash*7) + this.PhysicalAddress.GetHashCode();
			hash = (hash*7) + this.LogicalAddress.GetHashCode();
			hash = (hash*7) + this.Function.GetHashCode();

			return hash;
		}

		public static bool operator ==(Device ldevcie, Device rdevcie) => ldevcie.Equals(rdevcie);
		public static bool operator !=(Device ldevcie, Device rdevcie) => ldevcie.Equals(rdevcie);
	}

	enum DeviceFunctions
	{
		Hub = 1,
		Switch,
		L3Switch,
		Router,
		AcessPoint,
		FireWall
	}
}
