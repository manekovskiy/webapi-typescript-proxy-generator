using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApiService
{
	[RoutePrefix("api/todos")]
	public class TodoController : ApiController
	{
		private readonly TodoRepository todos;

		public TodoController()
		{
			todos = new TodoRepository();
		}

		[Route("all")]
		[HttpGet]
		[ResponseType(typeof(IEnumerable<Todo>))]
		public IHttpActionResult GetAllTodos()
		{
			return Ok(todos.GetAll());
		}

		[Route("{key:guid}")]
		[HttpGet]
		[ResponseType(typeof(Todo))]
		public IHttpActionResult GetTodoById(Guid id)
		{
			return Ok(todos.Get(id));
		}

		[Route("create")]
		[HttpPost]
		[ResponseType(typeof(Todo))]
		public IHttpActionResult CreateTodo(Todo item)
		{
			return Ok(todos.Save(item));
		}

		[Route("delete")]
		[HttpDelete]
		[ResponseType(typeof(Guid))]
		public IHttpActionResult DeleteTodo(Guid id)
		{
			return Ok(todos.Delete(id));
		}
	}
}
