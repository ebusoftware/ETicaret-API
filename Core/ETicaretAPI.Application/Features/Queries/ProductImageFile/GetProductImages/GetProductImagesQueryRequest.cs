using ETicaretAPI.Application.Features.Queries.Product.GetAllProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.ProductImageFile.GetProductImages
{
    //GetProductImage ye ait Requestler (istek), buradan geçerek Handler sınıfına yönlenir.
    //Handler sınıfında gerekli işlemleri yapar.
    //GetProductImage 'e gelen Request'e karşı Response yani cevap dönecek,
    //Buna karşılık IRequest interface'i kullanarak, Response dönecek nesneyi GetProductImagesQueryResponse olarak verdik.
    public class GetProductImagesQueryRequest:IRequest<List<GetProductImagesQueryResponse>>
    {
        public string Id { get; set; }
    }
}
