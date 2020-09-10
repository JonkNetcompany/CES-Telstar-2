using System;
using Domain.Models;

namespace CES_Telstar.Services
{
    public interface IPackageService
    {
        void SignPackage(Guid packageId, string signature);

        Package GetPackage(Guid packageId);

        Levarance GetLevaranceForPackage(Guid packageId);
    }
}
