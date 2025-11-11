using geerirajwebapis.Model;
using geerirajwebapis.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace geerirajwebapis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Productsontroller : ControllerBase
    {
        private readonly IProductAsyncRepository repoproducts;
        public Productsontroller(IProductAsyncRepository repoproducts)
        {
            this.repoproducts = repoproducts;
        }
        [HttpPost("AddNewProducts")]
        public async Task<IActionResult> AddNewProducts(Products products)
        {
            products.updatePdf = true;
            products.updateVideo = true;
            BaseRespons baserespone=new BaseRespons();
            try
            {
                var result = await repoproducts.AddNewProducts(products);

                if(result>0)
                {
                    baserespone.ResponseData = result;
                    baserespone.StatusCode=StatusCodes.Status200OK;
                    baserespone.StatusMessage = $"Product Added Successfully...!";
                    return Ok(baserespone);
                }
                else
                {
                    baserespone.StatusCode = StatusCodes.Status400BadRequest;
                    baserespone.StatusMessage = "Something is wrong...!";
                    return Ok(baserespone);
                }

            }
            catch (Exception ex)
            {
                baserespone.StatusMessage = ex.Message;
                baserespone.StatusCode = StatusCodes.Status409Conflict;
                return Ok(baserespone);
            }
          
            
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProducts(Products products)
        {
            BaseRespons baserespone = new BaseRespons();
            try
            {
                var result = await repoproducts.UPdateProducts(products);

                if (result > 0)
                {
                    baserespone.ResponseData = result;
                    baserespone.StatusCode = StatusCodes.Status200OK;
                    baserespone.StatusMessage = $"Product Updated Successfully...!";
                    return Ok(baserespone);
                }
                else
                {
                    baserespone.StatusCode = StatusCodes.Status400BadRequest;
                    baserespone.StatusMessage = "Something is wrong...!";
                    return Ok(baserespone);
                }

            }
            catch (Exception ex)
            {
                baserespone.StatusMessage = ex.Message;
                baserespone.StatusCode = StatusCodes.Status409Conflict;
                return Ok(baserespone);
            }


        }
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            BaseRespons baserespone = new BaseRespons();
            try
            {
                var result = await repoproducts.GetAllProducts();

                if (result.Count() > 0)
                {
                    baserespone.ResponseData = result;
                    baserespone.StatusCode = StatusCodes.Status200OK;
                    baserespone.StatusMessage = $"Product fetch Successfully...!";
                    return Ok(baserespone);
                }
                else
                {
                    baserespone.StatusCode = StatusCodes.Status400BadRequest;
                    baserespone.StatusMessage = "Something is wrong...!";
                    return Ok(baserespone);
                }

            }
            catch (Exception ex)
            {
                baserespone.StatusMessage = ex.Message;
                baserespone.StatusCode = StatusCodes.Status409Conflict;
                return Ok(baserespone);
            }


        }
        [HttpGet("GetAllProductsByTypeId")]
        public async Task<IActionResult> GetAllProductsByTypeId(int TypeId)
        {
            BaseRespons baserespone = new BaseRespons();
            try
            {
                var result = await repoproducts.GetAllProductsTypeId(TypeId);

                if (result.Count() > 0)
                {
                    baserespone.ResponseData = result;
                    baserespone.StatusCode = StatusCodes.Status200OK;
                    baserespone.StatusMessage = $"Products fetch Successfully...!";
                    return Ok(baserespone);
                }
                else
                {
                    baserespone.StatusCode = StatusCodes.Status400BadRequest;
                    baserespone.StatusMessage = "Something is wrong...!";
                    return Ok(baserespone);
                }

            }
            catch (Exception ex)
            {
                baserespone.StatusMessage = ex.Message;
                baserespone.StatusCode = StatusCodes.Status409Conflict;
                return Ok(baserespone);
            }


        }
        [HttpGet("GetAllProductsById")]
        public async Task<IActionResult> GetAllProductsById(int Id)
        {
            BaseRespons baserespone = new BaseRespons();
            try
            {
                var result = await repoproducts.GetProductById(Id);

                if (result !=null)
                {
                    baserespone.ResponseData = result;
                    baserespone.StatusCode = StatusCodes.Status200OK;
                    baserespone.StatusMessage = $"Products fetch Successfully...!";
                    return Ok(baserespone);
                }
                else
                {
                    baserespone.StatusCode = StatusCodes.Status400BadRequest;
                    baserespone.StatusMessage = "Something is wrong...!";
                    return Ok(baserespone);
                }

            }
            catch (Exception ex)
            {
                baserespone.StatusMessage = ex.Message;
                baserespone.StatusCode = StatusCodes.Status409Conflict;
                return Ok(baserespone);
            }


        }


        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int Id) 
        {
            BaseRespons baserespone = new BaseRespons();
            try
            {
                var result = await repoproducts.DeleteProduct(Id);

                if (result > 0)
                {
                    baserespone.ResponseData = result;
                    baserespone.StatusCode = StatusCodes.Status200OK;
                    baserespone.StatusMessage = $"Product Deleted Successfully...!";
                    return Ok(baserespone);
                }
                else
                {
                    baserespone.StatusCode = StatusCodes.Status400BadRequest;
                    baserespone.StatusMessage = "Something is wrong...!";
                    return Ok(baserespone);
                }

            }
            catch (Exception ex)
            {
                baserespone.StatusMessage = ex.Message;
                baserespone.StatusCode = StatusCodes.Status409Conflict;
                return Ok(baserespone);
            }

        }
        
        [Route("api/products/{productId}/images")]
        [HttpPost]
        public async Task<IActionResult> UploadProductImagesToDb(int productId,bool isupdate, [FromForm] List<IFormFile> images)
        {
            try
            {
                int result = 0;
                if (images == null || images.Count == 0)
                    return BadRequest("No files uploaded.");

                var uploadedFiles = new List<ProductImage>();
                if(isupdate==true)
                {
                    int res=await repoproducts.DeleteProductimages(productId);
                }
                foreach (var file in images)
                {
                    using (var ms = new MemoryStream())
                    {
                        await file.CopyToAsync(ms);
                        var imageData = ms.ToArray();

                        var productImage = new ProductImage
                        {
                            ProductId = productId,
                            ImageName = file.FileName,
                            ImageData = imageData,
                            CreatedBy = 1 // Replace with current user id
                        };

                        // Save to database using Dapper


                        result = await repoproducts.ProductsImages(productImage);
                        



                    }
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return Ok("exeption"+ex.Message);
            }
           
        }

    }
}
