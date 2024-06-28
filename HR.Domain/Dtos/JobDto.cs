namespace HR.Domain.Dtos;

public class JobDto
{
    public string JobTitle { get; set; } = null!;

    public decimal? MinSalary { get; set; }

    public decimal? MaxSalary { get; set; }
}
