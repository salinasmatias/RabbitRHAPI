﻿namespace HR.Domain.Dtos;

public class DepartmentDto
{
    public string DepartmentName { get; set; } = null!;
    public virtual List<EmployeeDto>? Employees { get; set; }
    public virtual LocationDto? Location { get; set; }
}
