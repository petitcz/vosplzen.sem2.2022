using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using vosplzen.sem2h1.Data;
using vosplzen.sem2h1.Data.Dto;
using vosplzen.sem2h1.Data.Model;
using vosplzen.sem2h1.Services.Interfaces;

namespace vosplzen.sem2h1.Services
{

    public class IdentityService : MasterSeedService, IIdentityService
    {
        public IdentityService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public bool TokenisValid(string token)
        {


            var result = _context.IdentityTokens
                .Where(x => x.Token.Equals(token) && x.ValidTo >= DateTime.Now)
                .Any();

            return result;

        }
    }
}
