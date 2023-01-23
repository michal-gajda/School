namespace School.WebUI.Models;

using System.ComponentModel.DataAnnotations;

public sealed class Student
{
    public int Id { set; get; } = default;
    [Required]
    public string FirstName { set; get; } = string.Empty;
    [Required]
    public string LastName { set; get; } = string.Empty;
    [Required]
    public string Email { set; get; } = string.Empty;
    [Required]
    public string Mobile { set; get; } = string.Empty;
    public string Address { set; get; } = string.Empty;
}
