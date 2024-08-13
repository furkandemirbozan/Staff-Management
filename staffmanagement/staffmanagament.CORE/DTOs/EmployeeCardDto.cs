namespace staffmanagament.CORE;

public class EmployeeCardDto
{
    public string EmployeeFirstName { get; set; }
    public string EmployeeLastName { get; set; }
    public string EmployeeEmail { get; set; }
    public string EmployeePhoneNumber { get; set; }
    public string? ImageUrl { get; set; }
    public string JobTitle { get; set; }
    public string DepartmentName { get; set; }
    public string ManagerName { get; set; }
    public DateTime HireDate { get; set; }
}
