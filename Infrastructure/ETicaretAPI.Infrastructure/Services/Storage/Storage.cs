using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Storage
{
    //Mimarideki storage işeminde, ortak davranış sergileyen fakat davranışları farklı olmayan işlemleri bu sınıf içinde yapıyoruz.
    //Ortak davranış sergileyen fakat davranış biçimleri farklı olanlar ise IStorage' dan implemente edilecekti. Her servisin Ekleme, silme, varlık kontrolü... ortak davranışıdır fakat implemente sonrası yazım biçimleri farklıdır.
    public class Storage
    {
         public  string FileRenameAsync(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string oldName = Path.GetFileNameWithoutExtension(fileName);
            Regex regex = new Regex("[*'\",+-._&#^@|/<>~]");
            string newFileName = regex.Replace(oldName, string.Empty);
            DateTime datetimenow = DateTime.UtcNow;
            string datetimeutcnow = datetimenow.ToString("yyyyMMddHHmmss");
            string fullName = $"{newFileName}-{datetimeutcnow}{extension}";

            return fullName;
        }

    }
}
