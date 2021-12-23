using System.Threading.Tasks;

namespace WhatToWear.Core
{
    public interface IMailService
    {
        Task SendMailAsync(int id, int h, int m);
    }
}
