﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataLayer
{
    public class ApplicationUser : IdentityUser
    {
      

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            
            userIdentity.AddClaim(new Claim(ClaimTypes.Email,this.Email));
            userIdentity.AddClaim(new Claim(ClaimTypes.GivenName,this.Fullname));

            return userIdentity;
        }

        public string Fullname { get; set; }
        public bool IsActive { get; set; }

  
    }

    
}