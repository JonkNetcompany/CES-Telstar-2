using System;
using Domain.Models;
using Persistence.Context;

namespace CES_Telstar.Services
{
    public class PackageService : IPackageService
    {
        private readonly RouteContext _context;

        public PackageService(RouteContext context)
        {
            _context = context;
        }

        public void SignPackage(Guid packageId, string signature)
        {
            throw new NotImplementedException();
        }

        public Package GetPackage(Guid packageId)
        {
            throw new NotImplementedException();
        }

        public Levarance GetLevaranceForPackage(Guid packageId)
        {
            throw new NotImplementedException();
        }
    }
}