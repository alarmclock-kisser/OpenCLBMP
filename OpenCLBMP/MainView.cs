namespace OpenCLBMP
{
    public partial class MainView : Form
    {
		// ----- ----- ----- ATTRIBUTES ----- ----- ----- \\
		public string Repopath;






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
