using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserSignup.DAL;
using UserSignup.Models;

namespace UserSignup.Controllers
{
    public class StudentController : Controller
    {

        StudetDal _studentDal = new StudetDal();

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
     
            public ActionResult Create(Student model, HttpPostedFileBase imageFile, HttpPostedFileBase pdfFile)

            {
                if (ModelState.IsValid)
                {
                    var student = new Student
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Phone = model.Phone,
                        Address = model.Address,
                        Gender = model.Gender,
                        Dob = model.Dob,
                        City = model.City,
                        State = model.State,
                        Pin = model.Pin,
                         Email = model.Email
                    };

                    if (imageFile != null && imageFile.ContentLength > 0)
                    {
                        using (var binaryReader = new BinaryReader(imageFile.InputStream))
                        {
                            student.ImageData = binaryReader.ReadBytes(imageFile.ContentLength);
                        }
                    }

                    if (pdfFile != null && pdfFile.ContentLength > 0)
                    {
                        using (var binaryReader = new BinaryReader(pdfFile.InputStream))
                        {
                            student.PdfData = binaryReader.ReadBytes(pdfFile.ContentLength);
                        }
                    }

                    bool result = _studentDal.InsertStudent(student);

                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to insert student record.");
                    }
                }

                return View(model);
            }





            // GET: Student/Edit/5
            public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
