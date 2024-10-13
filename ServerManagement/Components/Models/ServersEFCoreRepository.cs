using Microsoft.EntityFrameworkCore;
using ServerManagement.Data;

namespace ServerManagement.Components.Models
{
	public class ServersEFCoreRepository
	{
		private readonly IDbContextFactory<ServerManagementContext> _contextFactory;

		public ServersEFCoreRepository(IDbContextFactory<ServerManagementContext> contextFactory)
		{
			_contextFactory = contextFactory;
		}

		public void AddServer(Server server)
		{

			using var db = this._contextFactory.CreateDbContext();
			db.Servers.Add(server);

			db.SaveChanges();
		}

		public List<Server> GetServers()
		{
			using var db = this._contextFactory.CreateDbContext();
			return db.Servers.ToList();
		}

		public List<Server> GetServersByCity(string city)
		{

			using var db = this._contextFactory.CreateDbContext();
			return db.Servers.Where(x => x.City != null && x.City.ToLower().IndexOf(city.ToLower()) >= 0).ToList();
		}

		public Server? GetServerById(int id)
		{
			using var db = this._contextFactory.CreateDbContext();

			var server = db.Servers.Find(id);
			if (server is not null) return server;

			return new Server();
		}

		public void UpdateServer(Server server, int serverId)
		{
			if (server == null) throw new ArgumentNullException(nameof(server));

			if (serverId != server.ServerId) return;

			using var db = this._contextFactory.CreateDbContext();

			var serverToUpdate = db.Servers.Find(serverId);

			if (serverToUpdate is not null)
			{
				serverToUpdate.IsOnline = server.IsOnline;
				serverToUpdate.City = server.City;
				serverToUpdate.Name = server.Name;
			}

			db.SaveChanges();

		}
		public void DeleteServer(Server server)
		{
			using var db = this._contextFactory.CreateDbContext();
			db.Servers.Remove(server);
		}

		public void DeleteServer(int serverId)
		{
			using var db = this._contextFactory.CreateDbContext();

			var serverToUpdate = db.Servers.Find(serverId);
			if (serverToUpdate is null) return;
			db.Servers.Remove(serverToUpdate);

			db.SaveChanges();
		}


		public List<Server> SearchServers(string serverFilter)
		{
			using var db = this._contextFactory.CreateDbContext();

			return db.Servers.Where(x => x.Name != null && x.Name.ToLower().IndexOf(serverFilter.ToLower()) > -1).ToList();
		}
	}
}
