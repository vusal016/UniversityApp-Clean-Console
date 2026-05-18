using System.Collections.Generic;

namespace UniversityOrchestrationUI.UniversityPresent
{
    public class FacultyUi(IFacultyService facultyService,IUniversityService universityService)
    {
        public async Task FacultyMenuAsync()
        {
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("╔════════════════════════════════╗");
                    Console.WriteLine("║      FACULTY MENU              ║");
                    Console.WriteLine("╠════════════════════════════════╣");
                    Console.WriteLine("║ 1-Add new Faculty              ║");
                    Console.WriteLine("║ 2-Get Faculty by Id            ║");
                    Console.WriteLine("║ 3-Get All Faculties            ║");
                    Console.WriteLine("║ 4-Edit Faculty                 ║");
                    Console.WriteLine("║ 5-Delete Faculty               ║");
                    Console.WriteLine("║ 0-Back to Main Menu            ║");
                    Console.WriteLine("╚════════════════════════════════╝");
                    Console.ResetColor();

                    int? input = int.TryParse(Console.ReadLine(), out var result) ? result : null;
                    if (input == null)
                        continue;
                    if (input == 0) break;

                    switch (input)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Add new Faculty");
                            Console.ResetColor();

                            Console.WriteLine("Enter Faculty Name");
                            string name = Console.ReadLine();

                            Console.WriteLine("Enter Dean Name");
                            string deanName = Console.ReadLine();

                            Console.WriteLine("Choose Faculty Type");
                            string type = Console.ReadLine();

                            if (!Enum.TryParse(type, true, out FacultyType facultyType))
                                throw new InvalidOperationException("Faculty type choosing is failed");

                            Console.WriteLine("Choose University to add");
                             var unies= await universityService.GetAllUniversitiesAsync();
                            for (int i = 0; i <unies.Count ; i++)
                            {
                                Console.WriteLine($"{i + 1}-{unies[i].Name}");
                            }
                            var inputId = Console.ReadLine();

                            if (!int.TryParse(inputId, out var index))
                            {
                                Console.WriteLine("Invalid input");
                                break;
                            }

                            if (index < 1 || index > unies.Count)
                            {
                                Console.WriteLine("Out of range");
                                break;
                            }
                            var selected = unies[index - 1];
                            FacultyCreateDto facultyCreate = new FacultyCreateDto(name, deanName, facultyType, selected.Id);

                            await facultyService.AddFacultyAsync(facultyCreate);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Faculty successfully added");
                            Console.ResetColor();
                            break;

                        case 2:
                            Console.WriteLine("Get Faculty by Id");

                            var getFaculties = await facultyService.GetAllFacultiesAsync();

                            if (getFaculties.Count == 0)
                            {
                                Console.WriteLine("No faculties found");
                                break;
                            }

                            for (int i = 0; i < getFaculties.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}-{getFaculties[i].Name}");
                            }

                            Console.WriteLine("Choose Faculty number to get");

                            var getFacultyInput = Console.ReadLine();

                            if (!int.TryParse(getFacultyInput, out var getFacultyIndex))
                            {
                                Console.WriteLine("Invalid input");
                                break;
                            }

                            if (getFacultyIndex < 1 || getFacultyIndex > getFaculties.Count)
                            {
                                Console.WriteLine("Out of range");
                                break;
                            }

                            var selectedGetFaculty = getFaculties[getFacultyIndex - 1];

                            var faculty = await facultyService.GetFacultyByIdAsync(selectedGetFaculty.Id);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Faculty Name: {faculty.Name}, Dean Name: {faculty.DeanName}, Type: {faculty.FacultyType}");
                            Console.ResetColor();
                            break;

                        case 3:
                            var facultyList = await facultyService.GetAllFacultiesAsync();

                            if (facultyList.Count == 0)
                            {
                                Console.WriteLine("No faculties found");
                                break;
                            }

                            for (int i = 0; i < facultyList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}-Name: {facultyList[i].Name}, Dean: {facultyList[i].DeanName}, Type: {facultyList[i].FacultyType}");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Edit Faculty");

                            var updateFaculties = await facultyService.GetAllFacultiesAsync();

                            if (updateFaculties.Count == 0)
                            {
                                Console.WriteLine("No faculties found");
                                break;
                            }

                            for (int i = 0; i < updateFaculties.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}-{updateFaculties[i].Name},{updateFaculties[i].DeanName}");
                            }

                            Console.WriteLine("Choose Faculty number for Update");

                            var input2 = Console.ReadLine();

                            if (!int.TryParse(input2, out var fac))
                            {
                                Console.WriteLine("Invalid input");
                                break;
                            }

                            if (fac < 1 || fac > updateFaculties.Count)
                            {
                                Console.WriteLine("Out of range");
                                break;
                            }

                            var selectedFaculty = updateFaculties[fac - 1];

                            Console.WriteLine($"{selectedFaculty.Name},{selectedFaculty.DeanName}");

                            Console.WriteLine("Change Faculty Name");
                            var newName = Console.ReadLine();

                            Console.WriteLine("Change Dean Name");
                            var newDeanName = Console.ReadLine();

                            Console.WriteLine("Change Faculty Type");
                            var newType = Console.ReadLine();

                            if (!Enum.TryParse(newType, true, out FacultyType enType))
                                throw new InvalidOperationException("This type format is wrong");

                            var facUpdate = new FacultyUpdateDto(selectedFaculty.Id, newName, newDeanName, enType, selectedFaculty.UniversityId);

                            await facultyService.UpdateFaculty(selectedFaculty.Id, facUpdate);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Faculty successfully updated");
                            Console.ResetColor();
                            break;

                        case 5:
                            Console.WriteLine("Delete Faculty");

                            var deletFaculties = await facultyService.GetAllFacultiesAsync();

                            if (deletFaculties.Count == 0)
                            {
                                Console.WriteLine("No faculties found");
                                break;
                            }

                            for (int i = 0; i < deletFaculties.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}-{deletFaculties[i].Name}");
                            }

                            Console.WriteLine("Choose Faculty number for Delete");

                            var entDel = Console.ReadLine();

                            if (!int.TryParse(entDel, out var deletF))
                            {
                                Console.WriteLine("Invalid input");
                                break;
                            }

                            if (deletF < 1 || deletF > deletFaculties.Count)
                            {
                                Console.WriteLine("Out of range");
                                break;
                            }

                            var DeletFaculty = deletFaculties[deletF - 1];

                            await facultyService.DeleteFacultyAsync(DeletFaculty.Id);

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Faculty successfully deleted");
                            Console.ResetColor();
                            break;

                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }
    }
}