using ETicaretAPI.Application.Abstractions.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories.Abstractions.Storage.Azure
{
    //Ortak olmayan sadece Azure a ait özellikler ise burada tanımlanır.
    public interface IAzureStorage:IStorage
    {
    }
}
