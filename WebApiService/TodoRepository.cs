using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiService
{
	public class TodoRepository
	{
		private static Dictionary<Guid, Todo> TodosById;

		static TodoRepository()
		{
			TodosById = new Dictionary<Guid, Todo>();
		}

		public IEnumerable<Todo> GetAll()
		{
			return TodosById.Values.ToList();
		}

		public Todo Get(Guid id)
		{
			return TodosById[id];
		}

		public object Save(Todo item)
		{
			item.Id = Guid.NewGuid();
			TodosById[item.Id] = item;

			return item;
		}

		public Guid Delete(Guid id)
		{
			TodosById.Remove(id);

			return id;
		}
	}
}
