namespace UniversityAppPresentation.AppUI;
public sealed class App(UniversityUI universityUI,FacultyUi facultyUI,StudentUI studentUI)
{
    public async Task RunAsync()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════╗");
            Console.WriteLine("║          MAIN MENU             ║");
            Console.WriteLine("╠════════════════════════════════╣");
            Console.WriteLine("║ 1 - University UI              ║");
            Console.WriteLine("║ 2 - Faculty UI                 ║");
            Console.WriteLine("║ 3 - Student UI                 ║");
            Console.WriteLine("║ 0 - Exit                       ║");
            Console.WriteLine("╚════════════════════════════════╝");
            Console.ResetColor();

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Opening University Menu...");
                    Console.ResetColor();

                    await universityUI.UniversityMenuAsync();
                    break;

                case "2":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Opening Faculty Menu...");
                    Console.ResetColor();

                    await facultyUI.FacultyMenuAsync();
                    break;

                case "3":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Opening Student Menu...");
                    Console.ResetColor();

                    await studentUI.StudentMenuAsync();
                    break;

                case "0":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Exiting application...");
                    Console.ResetColor();
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}