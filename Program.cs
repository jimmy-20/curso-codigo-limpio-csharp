List<string> TaskList = new List<string>();


int menuSelected = 0;
do
{
    menuSelected = ShowMainMenu();
    if ((Menu)menuSelected == Menu.Add)
    {
        ShowMenuAdd();
    }
    else if ((Menu)menuSelected == Menu.Remove)
    {
        ShowMenuRemove();
    }
    else if ((Menu)menuSelected == Menu.List)
    {
        ShowMenuTaskList();
    }
} while ((Menu)menuSelected != Menu.Exit);

void SeparatorLine() => Console.WriteLine("----------------------------------------");

/// <summary>
/// Show the option for Task
/// 1. Nueva tarea
/// 2. Remover Tarea
/// 3. Tareas pendientes
/// 4. Salir
/// </summary>
/// <returns>Returns option indicated by user</returns>
int ShowMainMenu()
{
    SeparatorLine();
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string optionSelect = Console.ReadLine();
    return Convert.ToInt32(optionSelect);
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        ShowMenuTaskList();

        string indexTask = Console.ReadLine();
        int indexToRemove = Convert.ToInt32(indexTask) - 1;

        if (indexToRemove > TaskList.Count - 1 || indexToRemove < 0)
        {
            Console.WriteLine("Número de tarea seleccionado no es válido");
            return;
        }

        if (indexToRemove > -1 && TaskList.Count > 0)
        {
            string task = TaskList[indexToRemove];
            TaskList.RemoveAt(indexToRemove);
            Console.WriteLine($"Tarea {task} eliminada");

        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string task = Console.ReadLine();

        if (task == string.Empty || string.IsNullOrWhiteSpace(task))
        {
            Console.WriteLine("La tarea no puede estar en blanco");
            return;
        }

        TaskList.Add(task);
        Console.WriteLine("Tarea registrada");
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al ingresar una nueva tarea");
    }
}

void ShowMenuTaskList()
{
    //Solo puede ingresar si se cumple es mayor a 0
    if (TaskList?.Count > 0)
    {
        SeparatorLine();
        var indexTask = 0;
        TaskList.ForEach(t => Console.WriteLine($"{++indexTask}. {t}"));
        SeparatorLine();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

enum Menu
{
    Add = 1, Remove = 2, List = 3, Exit = 4
}