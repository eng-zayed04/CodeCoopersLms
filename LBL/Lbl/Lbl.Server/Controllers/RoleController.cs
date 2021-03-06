﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Lbl.IdentityModel;
using Lbl.Server.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Lbl.Server.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/Role")]
    public class RoleController : ApiController
    {
        // [Route("CreateRole")]
        public IHttpActionResult Post(RoleBindingModel role)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var applicationUser = User.Identity;

            var applicationRole = new ApplicationRole(role.Name);
            applicationRole.LandingRoute = role.LandingRoute;
            applicationRole.Modified = DateTime.Now;
            applicationRole.ModifiedBy = applicationUser.Name;
            applicationRole.Created = DateTime.Now;
            applicationRole.CreatedBy = applicationUser.Name;

            var idResult = roleManager.Create(applicationRole);
            if (!idResult.Succeeded) return BadRequest("Failed to add application role");

            return Ok();
        }
    }
}