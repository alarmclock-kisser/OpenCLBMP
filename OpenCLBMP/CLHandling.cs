using OpenCL;
using OpenCL.Net;

namespace OpenCLBMP
{
	public class CLHandling
	{
		// ----- ----- ----- ATTRIBUTES ----- ----- ----- \\
		private string Repopath;
		private ListBox LogBox;
		private ComboBox DevicesCombo;
		private Label PlatformLabel;
		private Label RamLabel;
		private ProgressBar RamPbar;
		private PictureBox ViewPbox;

		public int DeviceId = -1;
		public int PlatformId = -1;

		public Device? Dev = null;
		public Platform? Plat = null;

		public Dictionary<Device, Platform> DevicesPlatforms = [];


		// ----- ----- ----- CONSTRUCTOR ----- ----- ----- \\
		public CLHandling(string repopath, ListBox? listBox_log = null, ComboBox? comboBox_devices = null, Label? label_platform = null, Label? label_ram = null, ProgressBar? progressBar_ram = null, PictureBox? pictureBox_view = null)
		{
			// Set attributes
			this.Repopath = repopath;
			this.LogBox = listBox_log ?? new ListBox();
			this.DevicesCombo = comboBox_devices ?? new ComboBox();
			this.PlatformLabel = label_platform ?? new Label();
			this.RamLabel = label_ram ?? new Label();
			this.RamPbar = progressBar_ram ?? new ProgressBar();
			this.ViewPbox = pictureBox_view ?? new PictureBox();

			// Fill devices combo
			FillDevicesCombo();

			// Register events
			DevicesCombo.SelectedIndexChanged += (sender, e) => InitDevice(DevicesCombo.SelectedIndex);

		}





		// ----- ----- ----- METHODS ----- ----- ----- \\
		public void Log(string message, string inner = "", int layer = 1, bool update = false)
		{
			string msg = "[" + DateTime.Now.ToString("HH:mm:ss.fff") + "] ";
			msg += "<CL>";

			for (int i = 0; i <= layer; i++)
			{
				msg += " - ";
			}

			msg += message;

			if (inner != "")
			{
				msg += "  (" + inner + ")";
			}

			if (update)
			{
				LogBox.Items[LogBox.Items.Count - 1] = msg;
			}
			else
			{
				LogBox.Items.Add(msg);
				LogBox.SelectedIndex = LogBox.Items.Count - 1;
			}
		}

		public List<Platform> GetPlatforms()
		{
			List<Platform> platforms = [];
			ErrorCode error = Cl.GetPlatformIDs(0, null, out uint numPlatforms);
			if (error != ErrorCode.Success)
			{
				Log("Error getting platform count", error.ToString());
				return platforms;
			}
			Platform[] platformIDs = new Platform[numPlatforms];
			error = Cl.GetPlatformIDs(numPlatforms, platformIDs, out numPlatforms);
			if (error != ErrorCode.Success)
			{
				Log("Error getting platform IDs", error.ToString());
				return platforms;
			}
			foreach (Platform platform in platformIDs)
			{
				platforms.Add(platform);
			}
			return platforms;
		}

		public void SetDevicesPlatforms()
		{
			DevicesPlatforms = [];
			List<Platform> platforms = GetPlatforms();
			foreach (Platform platform in platforms)
			{
				ErrorCode error = Cl.GetDeviceIDs(platform, DeviceType.All, 0, null, out uint numDevices);
				if (error != ErrorCode.Success)
				{
					Log("Error getting device count", error.ToString());
					return;
				}
				Device[] deviceIDs = new Device[numDevices];
				error = Cl.GetDeviceIDs(platform, DeviceType.All, numDevices, deviceIDs, out numDevices);
				if (error != ErrorCode.Success)
				{
					Log("Error getting device IDs", error.ToString());
					return;
				}
				foreach (Device device in deviceIDs)
				{
					DevicesPlatforms.Add(device, platform);
				}
			}
		}

		public void FillDevicesCombo()
		{
			// Set if empty
			if (DevicesPlatforms.Count == 0)
			{
				SetDevicesPlatforms();
			}

			// Fill combo <DeviceName> (<PlatformName>)
			DevicesCombo.Items.Clear();
			foreach (KeyValuePair<Device, Platform> entry in DevicesPlatforms)
			{
				Device device = entry.Key;
				Platform platform = entry.Value;
				string deviceName = Cl.GetDeviceInfo(device, DeviceInfo.Name, out ErrorCode error).ToString();
				if (error != ErrorCode.Success)
				{
					Log("Error getting device name", error.ToString());
					return;
				}
				string platformName = Cl.GetPlatformInfo(platform, PlatformInfo.Name, out error).ToString();
				if (error != ErrorCode.Success)
				{
					Log("Error getting platform name", error.ToString());
					return;
				}
				DevicesCombo.Items.Add(deviceName + " (" + platformName + ")");
			}
		}

		public void InitDevice(int index)
		{
			// Dispose previous device
			Dispose();

			DeviceId = index;

			// Check if index is valid
			if (index < 0 || index >= DevicesPlatforms.Count)
			{
				Log("Invalid device index", index.ToString());
				return;
			}

			// Get device & platform
			Dev = DevicesPlatforms.Keys.ElementAt(index);
			Plat = DevicesPlatforms.Values.ElementAt(index);

			// Set platform label
			PlatformLabel.Text = Cl.GetPlatformInfo(Plat.Value, PlatformInfo.Name, out ErrorCode error).ToString();

			// Update ram
			GetRam(true);
		}

		public void Dispose()
		{
			// Dispose context & reset device
		}

		public long[] GetRam(bool update = false)
		{
			// Abort if device is not set
			if (Dev == null || Plat == null)
			{
				Log("Device not set");
				return [0, 0, 0];
			}

			// Get RAM
			long total = Cl.GetDeviceInfo(Dev.Value, DeviceInfo.GlobalMemSize, out ErrorCode error).CastTo<long>();
			if (error != ErrorCode.Success)
			{
				Log("Error getting device RAM", error.ToString());
				return [0, 0, 0];
			}

			long used = Cl.GetDeviceInfo(Dev.Value, DeviceInfo.GlobalMemCacheSize, out error).CastTo<long>();
			if (error != ErrorCode.Success)
			{
				Log("Error getting device used RAM", error.ToString());
				return [0, 0, 0];
			}

			long free = total - used;

			if (update)
			{
				// Set label and pbar
				RamLabel.Text = "RAM: " + (used / 1024 / 1024) + " / " + (total / 1024 / 1024) + " MB";
				RamPbar.Maximum = (int) (total / 1024 / 1024);
				RamPbar.Value = (int) (used / 1024 / 1024);
			}

			return [total, used, free];
		}


	}
}