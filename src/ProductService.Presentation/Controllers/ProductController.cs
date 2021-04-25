using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductService.Application.ProductServices.Commands.Request;
using ProductService.Application.ProductServices.Commands.Response;
using ProductService.Application.ProductServices.Queries.Request;
using ProductService.Application.ProductServices.Queries.Response;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
     
        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult<GetProductQueryResponse>> GetProductById(Guid id)
        {
            var product = await Mediator.Send(new GetProductByIdQueryRequest { Id =id});

            return product;
        }

      
        [HttpGet("GetAllProduct")]
        public async Task<ActionResult<List<GetProductQueryResponse>>> GetAllProduct()
        {
            var productList = await Mediator.Send(new GetAllProductQueryRequest { });

            return productList;
        }

      
        [HttpPost("AddProduct")]
        public async Task<ActionResult<CreateProductCommandResponse>> AddProduct(CreateProductCommandRequest requestModel)
        {
            var productInsertResult = await Mediator.Send(requestModel);

            return productInsertResult;
        }

     
        [HttpPatch("UpdateProduct")]
        public async Task<ActionResult<UpdateProductCommandResponse>> UpdateProduct(UpdateProductCommandRequest requestModel)
        {
            var productUpdateResult = await Mediator.Send(requestModel);

            return productUpdateResult;
        }

        
        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult<DeleteProductCommandResponse>> DeleteProduct(DeleteProductCommandRequest requestModel)
        {
            var productDeleteResult = await Mediator.Send(requestModel);

            return productDeleteResult;
        }

        [HttpGet("SearchWithTitle/{title}")]
        public async Task<ActionResult<List<GetProductQueryResponse>>> SearchWithTitle(string title)
        {
            var productList = await Mediator.Send(new SearchByTitleQueryRequest { Title= title });

            return productList;
        }


        [HttpGet("SearchWithDescription/{description}")]
        public async Task<ActionResult<List<GetProductQueryResponse>>> SearchWithDescription(string description)
        {
            var productList = await Mediator.Send(new SearchByDescriptionQueryRequest { Description = description });

            return productList;
        }

        [HttpGet("SearchWithCategoryName/{categoryName}")]
        public async Task<ActionResult<List<GetProductQueryResponse>>> SearchWithCategoryName(string categoryName)
        {
            var productList = await Mediator.Send(new SearchByCategoryNameQueryRequest { CategoryName = categoryName });

            return productList;
        }

        [HttpGet("SearchWithCategoryName/{minStock}/{maxStock}")]
        public async Task<ActionResult<List<GetProductQueryResponse>>> GetProductsByStockInterval(int minStock,int maxStock)
        {
            var productList = await Mediator.Send(new GetProductsByStockIntervalQueryRequest { MinStockQuantity = minStock,MaxStockQuantity=maxStock });

            return productList;
        }



    }
}



