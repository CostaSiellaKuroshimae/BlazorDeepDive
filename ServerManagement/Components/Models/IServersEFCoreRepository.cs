
namespace ServerManagement.Components.Models
{
	public interface IServersEFCoreRepository
	{
		void AddServer(Server server);
		void DeleteServer(int serverId);
		void DeleteServer(Server server);
		Server? GetServerById(int id);
		List<Server> GetServers();
		List<Server> GetServersByCity(string city);
		List<Server> SearchServers(string serverFilter);
		void UpdateServer(Server server, int serverId);
	}
}