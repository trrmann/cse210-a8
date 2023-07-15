namespace FinalProject
{
    public class Tasks : DictionaryDescribedObject<Task>
    {
        internal override Task CreateNewDescribedObject(Boolean empty = true)
        {
            TaskType type = TaskType.Task;
            TaskState state = TaskState.Template;
            return Task.CreateTask(type, state, empty);
        }
        internal override Task CreateNewDescribedObject(string taskName, string taskDescription)
        {
            TaskType type = TaskType.Task;
            TaskState state = TaskState.Template;
            return Task.CreateTask(type, state, taskName, taskDescription);
        }
        internal override void DisplayDescribedObjectAlreadyExists(Task task)
        {
            Console.WriteLine($"Task {task.ToNameString()} already exists.");
        }
        internal override void DisplayDescribedObjectCopyMessage()
        {
            Console.WriteLine("\nCopy task");
        }
        internal override void DisplayDescribedObjectSelectObjectMessage()
        {
            Console.WriteLine($"Select the task to copy.");
        }
        internal override void DisplayDescribedObjectNameMessage()
        {
            Console.WriteLine($"\nEnter the name of the copied task.");
        }
        internal override void DisplayDescribedObjectAlreadyExistsMessage(Task task)
        {
            Console.WriteLine($"Task {task.ToNameString()} already exists.");
            Console.Write("overwrite?");
        }
        internal override void DisplayDescribedObjectListMessage()
        {
            Console.WriteLine("\nList tasks");
        }
        internal override void DisplayDescribedObjectRemoveMessage()
        {
            Console.WriteLine("\nRemove task");
        }
        internal override void DisplayDescribedObjectNoneOptionMessage()
        {
            Console.WriteLine("0)  None.");
        }
        internal override void DisplayDescribedObjectSelectObjectToRemoveMessage()
        {
            Console.WriteLine($"Select the task to remove.");
        }
        internal override void DisplayDescribedObjectEditMessage()
        {
            Console.WriteLine("\nEdit task");
        }
        internal override void DisplayDescribedObjectExportMessage()
        {
            Console.WriteLine("\nExport tasks");
        }
        internal override void DisplayDescribedObjectImportMessage()
        {
            Console.WriteLine("\nImport tasks");
        }
        internal override void Edit()
        {
            base.Edit();
        }
    }
}