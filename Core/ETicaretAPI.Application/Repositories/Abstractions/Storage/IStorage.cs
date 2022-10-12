﻿using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Application.Abstractions.Storage
{
    //Tüm servislerde ortak olanlar burada tanımlanır.
    public interface IStorage
    {
        Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);
        Task DeleteAsync(string pathOrContainerName, string fileName);
        List<string> GetFiles(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);
    }
}