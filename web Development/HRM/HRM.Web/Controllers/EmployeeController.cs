﻿using HRM.Web.Data;
using HRM.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRM.Web.Controllers;
public class EmployeeController : Controller
{
    HRMDBContext db = new();
    public IActionResult Index()
    {
        var employees = db.Employees.ToList();

        return View(employees);
    }

    public IActionResult Add()
    {
        var departments = db.Departments.ToList();
        var selectListItems = departments.Select(x => new SelectListItem { Text = x.Name, Value = x.Name });
        ViewData["DepartmentList"] = selectListItems;
        return View(); 
    }

    [HttpPost]
    public IActionResult Add(Employee employee)
    {
        db.Employees.Add(employee);
        db.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int Id)
    {
        var employee = db.Find<Employee>(Id);
        return View(employee);
    }

    [HttpPost]
    public IActionResult Edit(Employee employee)
    {
        db.Employees.Update(employee);
        db.SaveChanges();

        return RedirectToAction("Index");
    }
    public IActionResult Delete(int Id)
    {
        var employee = db.Find<Employee>(Id);
        return View(employee);
    }

    [HttpPost]
    public IActionResult Delete(Employee employee)
    {
        db.Employees.Remove(employee);
        db.SaveChanges();

        return RedirectToAction("Index");
    }
}










