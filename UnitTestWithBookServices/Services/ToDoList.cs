namespace UnitTestWithBookServices.API.Services
{
    public class ToDoList
    {
        public record ToDoItem(string Content)
        {
            public int Id { get; set; }
            public bool Complete { get; set; }
        }

        private readonly List<ToDoItem> _toDoItems = new List<ToDoItem>();
        private int idCounter = 1;
        public void Add(ToDoItem item)
        {
            _toDoItems.Add(item);
        }
        public IEnumerable<ToDoItem> All => _toDoItems;

        public void Complete(int id)
        {
            var item = _toDoItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _toDoItems.Remove(item);
                var completedItem = item with { Id = idCounter++, Complete = true };
                _toDoItems.Add(completedItem);
            }


        }

    }
}
