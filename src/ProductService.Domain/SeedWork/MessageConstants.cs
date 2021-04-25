namespace ProductService.Domain.SeedWork
{
    public static class MessageConstants
    {
        public static string StockQuantityCannotBeNegative = "Stock Quantity Cannot Be Negative";
        public static string DescriptionCannotBeNull = "Description Cannot Be Empty";
        public static string TitleCannotBeNull = "Title Code Cannot Be Empty";
        public static string TitleCannotExceed200Characters = "Title Cannot Exceed 200 Characters";
        public static string CreateProductCommandRequestNull = "createProductCommandRequest null !";
        public static string DeleteProductCommandRequestNull = "deleteProductCommandRequest null !";
        public static string UpdateProductCommandRequestNull = "updateProductCommandRequest null !";
        public static string GetProductByIdQueryRequestNull =  "getProductByIdQueryRequest null !";
        public static string GetProductByIdQueryRequestIdNull = "getProductByIdQueryRequest Id paramemeter null !";
        public static string ProductNotFound = "product cannot be found!";
        public static string SearchByCategoryNameQueryRequestNull = "searchByCategoryNameQueryRequestNull null !";
        public static string SearchByCategoryNameQueryRequestCategoryNameNull = "SearchByCategoryNameQueryRequestNull category name parameter found!";
        public static string SearchByDescriptionQueryRequestNull = "searchByDescriptionQueryRequest null !";
        public static string SearchByDescriptionQueryRequestDescriptionNull = "searchByDescriptionQueryRequest description parameter found!";
        public static string SearchByTitleQueryRequestNull = "searchByTitleQueryRequest null !";
        public static string SearchByTitleRequestTitleNull = "searchByTitleQueryRequest title parameter found!";
        public static string MinStockCantBeBiggerThanMaxStock = "Min stock cant be bigger than max stock!";
        public static string DeleteProductCommandRequestIdNull = "deleteProductCommandRequestIdNull Id paramemeter null !";
        public static string UpdateProductCommandRequestIdNull = "UpdateProductCommandRequestIdNull Id paramemeter null !";
        public static string StockQuantityCannotBeLessThanMinStockQuantity = "Stock Quantity Cannot Be Less Than Min Stock Quantity!";
    }
}

