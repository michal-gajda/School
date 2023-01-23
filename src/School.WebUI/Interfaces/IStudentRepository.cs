namespace School.WebUI.Interfaces;

using School.WebUI.Models;

public interface IStudentRepository
{
    void Create(Student student);
    Student? Read(int id);
    void Update(Student student);
    void Delete(int id);
    IEnumerable<Student> List();
}
