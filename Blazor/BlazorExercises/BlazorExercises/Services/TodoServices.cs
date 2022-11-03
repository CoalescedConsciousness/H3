namespace BlazorExercises.Services
{
	public class TodoServices : ITodoServices
	{
        public List<TodoItem> todos = new();
        public string? newTodo;


        public void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(newTodo))
            {
                todos.Add(new TodoItem { Title = newTodo });
                newTodo = string.Empty;
            }
        }

    }
}
