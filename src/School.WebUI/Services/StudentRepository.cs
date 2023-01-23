namespace School.WebUI.Services;

using LiteDB;
using School.WebUI.Interfaces;
using School.WebUI.Models;

internal sealed class StudentRepository : IStudentRepository
{
    private readonly string connectionString;

    public StudentRepository()
    {
        var fileName = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "School.db");

        var parts = new[]
        {
            new KeyValuePair<string, string>("Filename", fileName),
            new KeyValuePair<string, string>("Connection", nameof(LiteDB.ConnectionType.Shared)),
        };

        this.connectionString = string.Join(";", parts.Select(part => $"{part.Key}={part.Value}"));
    }

    public void Create(Student student)
    {
        using var db = new LiteDatabase(this.connectionString);
        var students = db.GetCollection<Student>(nameof(Student));

        students.Insert(student);
    }

    public void Delete(int id)
    {
        using var db = new LiteDatabase(this.connectionString);
        var students = db.GetCollection<Student>(nameof(Student));

        students.Delete(id);
    }

    public IEnumerable<Student> List()
    {
        using var db = new LiteDatabase(this.connectionString);
        var students = db.GetCollection<Student>(nameof(Student));

        return students.FindAll();
    }

    public Student? Read(int id)
    {
        using var db = new LiteDatabase(this.connectionString);
        var students = db.GetCollection<Student>(nameof(Student));

        return students.FindOne(student => student.Id == id);
    }

    public void Update(Student student)
    {
        using var db = new LiteDatabase(this.connectionString);
        var students = db.GetCollection<Student>(nameof(Student));

        students.Update(student);
    }
}
