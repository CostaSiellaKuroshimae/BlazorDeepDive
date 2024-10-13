namespace ServerManagement.Components.StateStore
{
	public class TorontoOnlineServersStore : Observer
	{
		private int _numServersOnline;
		public int GetNumberServersOnline()
		{
			return _numServersOnline;
		}

		public void SetNumberServersOnline(int numServersOnline)
		{
			_numServersOnline = numServersOnline;
			base.BroadcastStateChange();
		}
	}
}
