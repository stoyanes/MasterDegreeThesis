﻿using System.Web.Http;
using Server.Data.Model;
using Server.Business.Interfaces;
using Server.Business.Dto;
using Server.Business.Services;
using Microsoft.AspNet.Identity;

namespace Server.Services.Controllers
{
    [Authorize]
    [RoutePrefix("Employees")]
    public class EmployeeController : ApiController
    {
        IEmployeeService employeeService;

        public EmployeeController(IEmployeeService empService)
        {
            employeeService = empService;
        }

        [HttpGet]
        [Route("")]
        [Authorize(Roles = "admin")]
        public IHttpActionResult GetAll()
        {
            var entities = employeeService.GetAll();
            return Ok(entities);
        }

        [NonAction]
        private EmployeeDto GetEmployeeById(int id)
        {
            EmployeeDto entity = employeeService.GetById(id);

            return entity;
        }
        [HttpGet]
        [Route("current")]
        public IHttpActionResult GetCurrentUserInfo ()
        {
            int currentEmployeeId = this.User.Identity.GetUserId<int>();
            EmployeeDto currentEmployee = this.GetEmployeeById(currentEmployeeId);

            if (currentEmployee != null)
            {
                return Ok(currentEmployee);
            }
            else
            {
                return NotFound();
            }


        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int entityId)
        {
            EmployeeDto entity = employeeService.GetById(entityId);

            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "admin")]
        public IHttpActionResult CreateEntity([FromBody] EmployeeDto newEntity)
        {
            var createResult = employeeService.CreateEntity(newEntity);
            return Ok(createResult);
        }

        [HttpPut]
        [Route("")]
        [Authorize(Roles = "admin")]
        public IHttpActionResult UpdateEntity([FromBody] EmployeeDto newEntity)
        {
            bool updateResult = employeeService.UpdateEntity(newEntity);
            if (updateResult)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "admin")]
        public IHttpActionResult DeleteEntity(int id)
        {
            bool deleteResult = employeeService.DeleteEntityById(id);
            if (deleteResult)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
    }
}
