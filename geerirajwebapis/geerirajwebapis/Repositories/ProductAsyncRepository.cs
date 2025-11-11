using Dapper;
using geerirajwebapis.Context;
using geerirajwebapis.Model;
using geerirajwebapis.Repositories.Interface;
using Microsoft.VisualBasic;
using System;
using System.Data;

namespace geerirajwebapis.Repositories
{
    public class ProductAsyncRepository:IProductAsyncRepository
    {
        private readonly DapperContext context;
        public ProductAsyncRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> AddNewProducts(Products prod)
        {
            var Proc = "sp_InsertProduct";
            using(var connection=context.CreateConnection()) 
            {
                var parameters = new DynamicParameters();
                //parameters.Add("@Id", prod.Id);
                parameters.Add("@ProductName", prod.ProductName);
                parameters.Add("@ProductType", prod.ProductType);
                parameters.Add("@ProductMrp", prod.ProductMrp);
                parameters.Add("@ProductPrice", prod.ProductPrice);
                parameters.Add("@Height", prod.Height); // if you already renamed to Height, use prod.Height
                parameters.Add("@Width", prod.Width);
                parameters.Add("@Diameter", prod.Diameter);
                parameters.Add("@Brand", prod.Brand);
                parameters.Add("@Colour", prod.Colour);
                parameters.Add("@Material", prod.Material);
                parameters.Add("@RecommendedUsesFor", prod.RecommendedUsesFor);
                parameters.Add("@SpecialFeature", prod.SpecialFeature);
                parameters.Add("@DoorStyle", prod.DoorStyle);
                parameters.Add("@WeightLimit", prod.WeightLimit);
                parameters.Add("@ProductSummery", prod.ProductSummery);
                parameters.Add("@CreatedBy", prod.CreatedBy);
                if(prod.updatePdf)
                {
                    parameters.Add("@PdfFileName", prod.FileName);
                    parameters.Add("@PdfFileDate", prod.FileData);
                }
              
               
                if(prod.updateVideo)
                {
                    parameters.Add("@videoFileName", prod.videoFileName);
                    parameters.Add("@videoFileData", prod.videoFileData);
                }
             
                //  parameters.Add("@ModifiedBy", prod.ModifiedBy);
                //  parameters.Add("@ModifiedDate", prod.ModifiedDate ?? DateTime.Now);
                var result=await connection.QuerySingleAsync<int>(Proc, parameters,commandType:CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<int> ProductsImages(ProductImage images)
        {
            var proc = "sp_InsertProductImage";
            using(var connection=context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", images.ProductId);
                parameters.Add("@ImageName", images.ImageName);
                parameters.Add("@ImageData", images.ImageData);
                parameters.Add("@CreatedBy", images.CreatedBy);

                var result=await connection.ExecuteAsync(proc, parameters, commandType:CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> DeleteProduct(int Id)
        {
            string Proc = "sp_DeleteProduct";
            using (var connection = context.CreateConnection())
            {
                DynamicParameters parme = new DynamicParameters();
                parme.Add("@Id", Id);
                var result = await connection.ExecuteAsync(Proc, parme, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<Products>> GetAllProducts()
        {
            var proc = "sp_GetAllProducts";
            using(var connection=context.CreateConnection())
            {
                var result=await connection.QueryAsync<Products>(proc,commandType:CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public async Task<List<GetProducts>> GetAllProductsTypeId(int TypeId)
        {
            var proc = "sp_GetProductsByTypeId";
            var procGetImage = "GetProductImages";
            using (var connection = context.CreateConnection())
            {
                var parameter = new DynamicParameters();
                
                parameter.Add("@ProductType", TypeId);

                var result = await connection.QueryAsync<GetProducts>(proc,parameter, commandType: CommandType.StoredProcedure);
                foreach(var product in result)

                {
                    var parameter1 = new DynamicParameters();

                    parameter1.Add("@ProductId", product.Id);
                    var result1 = await connection.QueryAsync<ProductImageModel>(procGetImage, parameter1, commandType: CommandType.StoredProcedure);
                    if(result1 != null)
                    {
                        product.Productimages = result1.ToList();
                    }
                   
                }
               
                return result.ToList();
            }
        }

        public async Task<GetProducts> GetProductById(int Id)
        {
            var proc = "SP_GetProrductsById";
            var procGetImage = "GetProductImages";
            using (var connection = context.CreateConnection())
            {
                var parameter = new DynamicParameters();

                parameter.Add("@Id", Id);

                var result = await connection.QueryFirstOrDefaultAsync<GetProducts>(proc, parameter, commandType: CommandType.StoredProcedure);
               
                    var parameter1 = new DynamicParameters();

                    parameter1.Add("@ProductId",Id);
                    var result1 = await connection.QueryAsync<ProductImageModel>(procGetImage, parameter1, commandType: CommandType.StoredProcedure);
                if(result!=null)
                { 
                if (result1.Count() > 0)
                    {
                        result.Productimages = result1.ToList();
                    }

                }

                return result;
            }
        }

        public Task<List<Products>> GetProductsbyName(string SearchTesx)
        {
            throw new NotImplementedException();
        }

        public Task<List<Products>> GetProductsByTypeId(int TypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UPdateProducts(Products prod)
        {
            var proc = "sp_UpdateProduct";
            using(var conection = context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", prod.Id);
                parameters.Add("@ProductName", prod.ProductName);
                parameters.Add("@ProductType", prod.ProductType);
                parameters.Add("@ProductMrp", prod.ProductMrp);
                parameters.Add("@ProductPrice", prod.ProductPrice);
                parameters.Add("@Height", prod.Height); // if you already renamed to Height, use prod.Height
                parameters.Add("@Width", prod.Width);
                parameters.Add("@Diameter", prod.Diameter);
                parameters.Add("@Brand", prod.Brand);
                parameters.Add("@Colour", prod.Colour);
                parameters.Add("@Material", prod.Material);
                parameters.Add("@RecommendedUsesFor", prod.RecommendedUsesFor);
                parameters.Add("@SpecialFeature", prod.SpecialFeature);
                parameters.Add("@DoorStyle", prod.DoorStyle);
                parameters.Add("@WeightLimit", prod.WeightLimit);
                parameters.Add("@ProductSummery", prod.ProductSummery);
                parameters.Add("@ModifiedBy", prod.ModifiedBy);
                parameters.Add("@ModifiedDate", prod.ModifiedDate ?? DateTime.Now);
                parameters.Add("@PdfFileName", prod.FileName);
                parameters.Add("@PdfFileDate", prod.FileData);
                parameters.Add("@videoFileName", prod.videoFileName);
                parameters.Add("@videoFileData", prod.videoFileData);
                parameters.Add("@updatePdf", prod.updatePdf);
                parameters.Add("@updateVideo", prod.updateVideo);
                

                var result =await conection.ExecuteAsync(proc, parameters,commandType:CommandType.StoredProcedure);
                return result;

            }
        }

        public async Task<int> DeleteProductimages(int productId)
        {
            var query = "delete from tblProductImages where ProductId=@ProdId";
            using(var connection=context.CreateConnection())
            {
                var result=await connection.ExecuteAsync(query, new {ProdId=productId});
                return result;             
            }
        }
    }
}       
