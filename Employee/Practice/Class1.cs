using System;
using System.Text;

namespace Practice
{
    public class Employee
    {
        private static int AutoId { get; set; } = 1000;
        private string id; // Không cần { get; set; } để tránh setter bị bỏ qua

        public string ID
        {
            get => id;
        }

        public string Fullname { get; set; }
        public string Phonenumber { get; set; }
        public string Role { get; set; }
        public float Salary { get; set; }
        public int Workingday { get; set; }
        public float ReceivedSalary { get; set; }

        // Constructor mặc định - ID tự động tạo
        public Employee()
        {
            id = "EMP" + AutoId++; // Đảm bảo mỗi nhân viên có ID duy nhất
        }

        // Constructor đầy đủ
        public Employee(string fullname, string phonenumber, string role, float salary, int workingday)
            : this() // Gọi constructor mặc định để tự động tạo ID
        {
            Fullname = fullname;
            Phonenumber = phonenumber;
            Role = role;
            Salary = salary;
            Workingday = workingday;
        }

        public float CalculateSalary()
        {
            float bonus = (Workingday >= 22) ? 0.2f * Salary : 0;
            ReceivedSalary = Salary * Workingday / 22 + bonus;
            return ReceivedSalary;
        }
    }

    public static class EmployeeUtils
    {
        public static Employee CreateEmployee()
        {
            Console.Write("Họ và tên: ");
            string fullname = Console.ReadLine();
            Console.Write("Số điện thoại: ");
            string phonenumber = Console.ReadLine();
            Console.Write("Chức vụ: ");
            string role = Console.ReadLine();
            Console.Write("Mức lương: ");
            float salary = float.Parse(Console.ReadLine());
            Console.Write("Số ngày làm việc: ");
            int workingday = int.Parse(Console.ReadLine());

            return new Employee(fullname, phonenumber, role, salary, workingday);
        }

        public static void DisplayEmployees(Employee[] employees)
        {
            Console.WriteLine("Danh sách nhân viên:");
            foreach (var employee in employees)
            {
                if (employee != null)
                {
                    Console.WriteLine($"Mã: {employee.ID}, Tên: {employee.Fullname}, Lương: {employee.Salary}, Ngày làm: {employee.Workingday}");
                }
            }
        }

        public static void CalculateSalary(Employee[] employees)
        {
            foreach (Employee employee in employees)
            {
                if (employee != null)
                {
                    float newSalary = employee.CalculateSalary();
                    Console.WriteLine($"Nhân viên {employee.Fullname} đã được tính lương: {newSalary}");
                }
            }
        }

        public static void SortBySalary(Employee[] employees)
        {
            Array.Sort(employees, (x, y) =>
            {
                if (x == null) return 1;
                if (y == null) return -1;
                return y.Salary.CompareTo(x.Salary);
            });

            Console.WriteLine("Danh sách nhân viên theo lương giảm dần:");
            DisplayEmployees(employees);
        }

        public static void SortByWorkingDay(Employee[] employees)
        {
            Array.Sort(employees, (x, y) =>
            {
                if (x == null) return 1;
                if (y == null) return -1;
                return y.Workingday.CompareTo(x.Workingday);
            });

            Console.WriteLine("Danh sách nhân viên theo số ngày làm việc giảm dần:");
            DisplayEmployees(employees);
        }

        public static Employee FindById(Employee[] employees, string id)
        {
            foreach (var employee in employees)
            {
                if (employee != null && employee.ID == id)
                {
                    return employee;
                }
            }
            return null;
        }

        public static bool UpdateSalary(Employee[] employees, string id, float newSalary)
        {
            foreach (var employee in employees)
            {
                if (employee != null && employee.ID == id)
                {
                    employee.Salary = newSalary;
                    return true;
                }
            }
            return false;
        }

        public static bool RemoveById(Employee[] employees, string id)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].ID == id)
                {
                    employees[i] = null;
                    return true;
                }
            }
            return false;
        }
    }
}