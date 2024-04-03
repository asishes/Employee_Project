using DAL.Models;
using EmpTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpTest.Controllers
{
    public class EmployeeController : Controller
    {
        
        ModelEmp Modelemployee = new ModelEmp();
        // GET: Employee

        #region LIST
        public ActionResult Index()
        {
            
            var albums =this.Modelemployee.EMPLOYEEs.ToList();
            List<DTO_Employee> return_list = new List<DTO_Employee>();
            foreach (var obj in albums)
            {
                return_list.Add(new DTO_Employee
                {
                    Id = obj.EMP_ID,
                    Name = obj.EMP_NAME,
                    Description = obj.EMP_DESCRIPTION,
                    Age = obj.EMP_AGE,
                    Salary = obj.EMP_SALARY,
                    Joindate = obj.EMP_JOINDATE

                });
            }
            return this.View(return_list);

        }
        #endregion



        #region DETAILS
        public ActionResult Details(int id)
        {
            DTO_Employee return_obj = new DTO_Employee();
            EMPLOYEE tbl_obj = Modelemployee.EMPLOYEEs.Find(id);
            return_obj.Id = tbl_obj.EMP_ID;
            return_obj.Name = tbl_obj.EMP_NAME;
            return_obj.Description = tbl_obj.EMP_DESCRIPTION;
            return_obj.Age = tbl_obj.EMP_AGE;
            return_obj.Salary = tbl_obj.EMP_SALARY;
            return_obj.Joindate = tbl_obj.EMP_JOINDATE;
            return View(return_obj);
        }

        #endregion



        #region CREATE
        public ActionResult Create()
        {
            return View();
        }


        // POST: /Employee/Create

        [HttpPost]
        public ActionResult Create(DTO_Employee collection)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    EMPLOYEE tbl_obj = new EMPLOYEE();
                    tbl_obj.EMP_ID = collection.Id;
                    tbl_obj.EMP_NAME = collection.Name;
                    tbl_obj.EMP_DESCRIPTION = collection.Description;

                    tbl_obj.EMP_AGE = collection.Age;
                    tbl_obj.EMP_SALARY = collection.Salary;
                    tbl_obj.EMP_JOINDATE = collection.Joindate;



                    this.Modelemployee.EMPLOYEEs.Add(tbl_obj);
                    this.Modelemployee.SaveChanges();
                    return this.RedirectToAction("Index");
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        #endregion



        #region EDIT
        public ActionResult Edit(int id)
        {
            DTO_Employee return_obj = new DTO_Employee();
            EMPLOYEE tbl_obj = Modelemployee.EMPLOYEEs.Find(id);
            return_obj.Id = tbl_obj.EMP_ID;
            return_obj.Name = tbl_obj.EMP_NAME;
            return_obj.Description = tbl_obj.EMP_DESCRIPTION;
            return_obj.Age = tbl_obj.EMP_AGE;
            return_obj.Salary = tbl_obj.EMP_SALARY;
            return_obj.Joindate = tbl_obj.EMP_JOINDATE;
            return View(return_obj);
        }


        // POST: /Employee/Edit/

        [HttpPost]
        public ActionResult Edit( DTO_Employee collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EMPLOYEE tbl_obj = new EMPLOYEE();
                    tbl_obj.EMP_ID = collection.Id;
                    tbl_obj.EMP_NAME = collection.Name;
                    tbl_obj.EMP_DESCRIPTION = collection.Description;

                    tbl_obj.EMP_AGE = collection.Age;
                    tbl_obj.EMP_SALARY = collection.Salary;
                    tbl_obj.EMP_JOINDATE = collection.Joindate;


                    // Update to the database
                    this.Modelemployee.Entry(tbl_obj).State = EntityState.Modified;
                    this.Modelemployee.SaveChanges();

                    return this.RedirectToAction("Index");
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }
        #endregion



        #region DELETE
        public ActionResult Delete(int id)
        {
            DTO_Employee return_obj = new DTO_Employee();
            EMPLOYEE tbl_obj = Modelemployee.EMPLOYEEs.Find(id);
            return_obj.Id = tbl_obj.EMP_ID;
            return_obj.Name = tbl_obj.EMP_NAME;
            return_obj.Description = tbl_obj.EMP_DESCRIPTION;
            return_obj.Age = tbl_obj.EMP_AGE;
            return_obj.Salary = tbl_obj.EMP_SALARY;
            return_obj.Joindate = tbl_obj.EMP_JOINDATE;
            return View(return_obj);
           
;
        }

        //
        // POST: /Employee/Delete/

        [HttpPost]
        public ActionResult Delete(int id,FormCollection formCollection)
        {
            try
            {
                EMPLOYEE user = this.Modelemployee.EMPLOYEEs.Find(id);
                this.Modelemployee.EMPLOYEEs.Remove(user);
                this.Modelemployee.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }


}