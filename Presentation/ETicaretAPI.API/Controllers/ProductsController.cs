using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        [HttpGet]
        public async void Get() 
        {
           await _productWriteRepository.AddRangeAsync(new()
            {
                new(){ Id= Guid.NewGuid(),CreateDate= DateTime.UtcNow,Name="Product 1",Price=200,Stock=80},
                new(){ Id= Guid.NewGuid(),CreateDate= DateTime.UtcNow,Name="Product 2",Price=300,Stock=5},
                new(){ Id= Guid.NewGuid(),CreateDate= DateTime.UtcNow,Name="Product 3",Price=400,Stock=57},
                new(){ Id= Guid.NewGuid(),CreateDate= DateTime.UtcNow,Name="Product 4",Price=500,Stock=6},
                new(){ Id= Guid.NewGuid(),CreateDate= DateTime.UtcNow,Name="Product 5",Price=550,Stock=48},
            });
            await _productWriteRepository.SaveAsync();
        }
    }
}
