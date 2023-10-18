using System;
using System.Security.Cryptography;

namespace Server.Services 
{
    public class GuidGeneratorService : IGuidGeneratorService
    {
        public Guid GenerateUniqueGuid()
        {
            byte[] bytes = new byte[16];
            RandomNumberGenerator.Fill(bytes);
            return new Guid(bytes);
        }
    }
}
