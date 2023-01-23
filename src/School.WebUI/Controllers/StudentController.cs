namespace School.WebUI.Controllers;

using Microsoft.AspNetCore.Mvc;
using School.WebUI.Interfaces;
using School.WebUI.Models;

public sealed class StudentController : Controller
{
    private readonly IStudentRepository repository;

    public StudentController(IStudentRepository repository)
        => (this.repository) = (repository);

    // GET: Student
    public ActionResult Index()
    {
        IEnumerable<Student> students = this.repository.List();
        return View(students);
    }

    // GET: Student/Details/5
    public ActionResult Details(int id)
    {
        var student = this.repository.Read(id)!;
        return View(student);
    }

    // GET: Student/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Student/Create
    [HttpPost, ValidateAntiForgeryToken]
    public ActionResult Create(Student student)
    {
        try
        {
            this.repository.Create(student);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: Student/Edit/5
    public ActionResult Edit(int id)
    {
        var student = this.repository.Read(id)!;
        return View(student);
    }

    // POST: Student/Edit/5
    [HttpPost, ValidateAntiForgeryToken]
    public ActionResult Edit(Student student)
    {
        try
        {
            this.repository.Update(student);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: Student/Delete/5
    public ActionResult Delete(int id)
    {
        var student = this.repository.Read(id)!;
        return View(student);
    }

    // POST: Student/Delete/5
    [HttpPost, ValidateAntiForgeryToken]
    public ActionResult Delete(Student student)
    {
        try
        {
            this.repository.Delete(student.Id);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
