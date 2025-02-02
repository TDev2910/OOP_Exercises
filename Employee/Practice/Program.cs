using System;
using System.Text;

namespace Practice
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int choice;
            Employee[] employees = new Employee[100];
            int size = 0;
            do
            {
                Console.WriteLine("======================= CÁC CHỨC NĂNG =======================");
                Console.WriteLine("1. Thêm mới 1 nhân viên.");
                Console.WriteLine("2. Hiển thị danh sách nhân viên.");
                Console.WriteLine("3. Tính lương.");
                Console.WriteLine("4. Sắp xếp theo lương giảm dần.");
                Console.WriteLine("5. Sắp xếp theo số ngày làm việc giảm dần.");
                Console.WriteLine("6. Tìm nhân viên theo mã.");
                Console.WriteLine("7. Cập nhật lương.");
                Console.WriteLine("8. Xóa nhân viên.");
                Console.WriteLine("9. Thoát chương trình.");
                Console.Write("Nhập lựa chọn: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        var acc = EmployeeUtils.CreateEmployee();
                        employees[size++] = acc;
                        break;
                    case 2:
                        EmployeeUtils.DisplayEmployees(employees);
                        break;
                    case 3:
                        EmployeeUtils.CalculateSalary(employees);
                        break;
                    case 4:
                        EmployeeUtils.SortBySalary(employees);
                        break;
                    case 5:
                        EmployeeUtils.SortByWorkingDay(employees);
                        break;
                    case 6:
                        Console.Write("Nhập mã nhân viên: ");
                        string id = Console.ReadLine();
                        var result = EmployeeUtils.FindById(employees, id);
                        if (result != null)
                        {
                            Console.WriteLine("==> Tìm thấy nhân viên: <==");
                            var resultArr = new Employee[] { result };
                            EmployeeUtils.DisplayEmployees(resultArr);
                        }
                        else
                        {
                            Console.WriteLine("==> Không tìm thấy nhân viên! <==");
                        }
                        break;
                    case 7:
                        if (size > 0)
                        {
                            Console.WriteLine(" Danh sách nhân viên trước khi cập nhật:");
                            EmployeeUtils.DisplayEmployees(employees);

                            Console.Write(" Nhập mã nhân viên cần cập nhật lương: ");
                            string updateId = Console.ReadLine().Trim();

                            Console.Write(" Nhập mức lương mới: ");
                            if (!float.TryParse(Console.ReadLine(), out float newSalary))
                            {
                                Console.WriteLine(" Lương không hợp lệ!");
                                break;
                            }

                            if (EmployeeUtils.UpdateSalary(employees, updateId, newSalary))
                            {
                                Console.WriteLine("Cập nhật lương thành công!");
                            }
                            else
                            {
                                Console.WriteLine(" Cập nhật lương thất bại! Kiểm tra lại mã nhân viên.");
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Danh sách nhân viên trống!");
                        }
                        break;

                    case 8:
                        {
                            if(size >0)
                            {
                                Console.WriteLine("Danh sach nhan vien truoc khi xoa : ");
                                EmployeeUtils.DisplayEmployees(employees);
                                Console.WriteLine("Nhap ma nhan vien can xoa : ");
                                string removeId = Console.ReadLine().Trim();
                                if (EmployeeUtils.RemoveById(employees, removeId))
                                {
                                    Console.WriteLine("Xoa nhan vien thanh cong !");
                                    size--;
                                }
                                else
                                {
                                    Console.WriteLine("Xoa nhan vien that bai !");
                                }
                            }
                        }
                        break;
                    case 9:
                        Console.WriteLine("Chương trình kết thúc.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            } while (choice != 9);
        }
    }
}