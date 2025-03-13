namespace OpenCLBMP
{
    public partial class MainView : Form
    {
		// ----- ----- ----- ATTRIBUTES ----- ----- ----- \\
		public string Repopath;


		public CLHandling CLH;





		// ----- ----- ----- LAMBDA ----- ----- ----- \\






		// ----- ----- ----- CONSTRUCTOR ----- ----- ----- \\
		public MainView()
        {
			InitializeComponent();
			Repopath = GetRepopath(true);

			// Window position
			this.StartPosition = FormStartPosition.Manual;
			this.Location = new Point(0, 0);

			// Init. classes
			CLH = new CLHandling(Repopath, listBox_log, comboBox_devices, label_platform, label_ram, progressBar_ram, pictureBox_view);

			// Register events


			// Setup UI

		}






		// ----- ----- ----- METHODS ----- ----- ----- \\
		private string GetRepopath(bool root)
		{
			string repo = AppDomain.CurrentDomain.BaseDirectory;

			if (root)
			{
				repo += @"..\..\..\";
			}

			repo = Path.GetFullPath(repo);
			return repo;
		}






		// ----- ----- ----- EVENTS ----- ----- ----- \\






	}
}
