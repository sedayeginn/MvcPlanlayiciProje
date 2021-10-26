using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcPlanlayiciProje.Data;
using MvcPlanlayiciProje.Data.Entities;
using MvcPlanlayiciProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPlanlayiciProje.Controllers
{
    public class PlanController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PlanController(ApplicationDbContext db)
        {
            _db = db;
        }
       public JsonResult GetPlans()
        {
            var model=_db.Plans.Include(x=>x.user).Select(x=>new PlanViewModel() {
                Id=x.Id,
                StartDate=x.StartDate,
                EndDate=x.EndDate,
                Description=x.Description,
                Title=x.Title,
                UserId=x.Id
            });
            return Json(model);
               
        }

        [HttpPost]
        public JsonResult AddOrUpdatePlan(AddOrUpdatePlanModel model)
        {
            if(model.Id==0)
            {
                Plan entity = new Plan()
                {
                    CreatedDate = DateTime.Now,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Title = model.Title,
                    Description = model.Description,
                    UserId = model.UserId
                };

                _db.Add(entity);
                _db.SaveChanges();
            }
            else
            {
                var entity = _db.Plans.SingleOrDefault(x => x.Id == model.Id);
                if(entity==null)
                {
                    return Json("Güncellenecek birşey bulunamadı.");
                }
                entity.UpdatedDate = DateTime.Now;
                entity.Description = model.Description;
                entity.Title = model.Title;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.UserId = model.UserId;

                _db.Update(entity);
                _db.SaveChanges();
            }
            return Json("200");
        }

        public JsonResult DeletePlan(int id=0)
        {
            var entity = _db.Plans.SingleOrDefault(x => x.Id == id);
            if(entity==null)
            {
                return Json("Kayıt bulunamadı");
            }
            _db.Remove(entity);
            _db.SaveChanges();
            return Json("200");
        }
    }
}
