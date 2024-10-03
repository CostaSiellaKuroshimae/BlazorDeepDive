namespace ToDoApp.Models
{
	public class ToDoItemsRepository
	{
		private static List<ToDoItem> toDoItems = new List<ToDoItem>()
		{
			new ToDoItem {  Id = 1, Name = "Item 1" },
			new ToDoItem {  Id = 2, Name = "Item 2" },
			new ToDoItem {  Id = 3, Name = "Item 3" },
			new ToDoItem {  Id = 4, Name = "Item 4" },



		};

		public static void AddToDoItem(ToDoItem item)
		{
			if (toDoItems.Count > 0)
			{
				var maxId = toDoItems.Max(s => s.Id);
				item.Id = maxId + 1;
				toDoItems.Add(item);
			}
			else
			{
				item.Id = 1;
				toDoItems.Add(item);
			}

		}

		public static List<ToDoItem> GetToDoItems()
		{
			var sortedItems = toDoItems.
				OrderBy(item => item.IsCompleted).
				ThenByDescending(item => item.Id)
				.ToList();

			return sortedItems;
		}


		public static ToDoItem? GetToDoItemById(int id)
		{
			var ToDoItem = toDoItems.FirstOrDefault(s => s.Id == id);
			if (ToDoItem != null)
			{
				return new ToDoItem
				{
					Id = ToDoItem.Id,
					Name = ToDoItem.Name
				};
			}

			return null;
		}

		public static void UpdateToDoItem(int Id, ToDoItem ToDoItem)
		{
			if (Id != ToDoItem.Id) return;

			var ToDoItemToUpdate = toDoItems.FirstOrDefault(s => s.Id == Id);
			if (ToDoItemToUpdate != null)
			{
				ToDoItemToUpdate.Name = ToDoItem.Name;
			}
		}

		public static void DeleteToDoItem(int Id)
		{
			var ToDoItem = toDoItems.FirstOrDefault(s => s.Id == Id);
			if (ToDoItem != null)
			{
				toDoItems.Remove(ToDoItem);
			}
		}

		public static List<ToDoItem> SearchToDoItems(string ToDoItemFilter)
		{
			return toDoItems.Where(s => s.Name.Contains(ToDoItemFilter, StringComparison.OrdinalIgnoreCase)).ToList();
		}
	}
}
