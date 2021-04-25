# ProductApi-CQRS-MediatR
A Product CRUD Api Example with CQRS pattern, MediatR and Unit tests

PROJECT LOGIC

Project includes operations...

AddProduct : Adds product.
GetAllProducts : Gets all products without filter.
GetByIdProduct : Gets product with specific ID
UpdateProduct : Updates product.
SearchProductsByDescription : Searchs product with the product description.
SearchProductsByTitle : Searchs product with the product title.
SearchProductsByCategoryName : Searchs product with the category name.

and all products must be have a category.

PROJECT ARCHITECTURE

Onion architecture was used in the project.

ProductApi.Domain : Layer for modelling domain. For the project, product domain.
ProductApi.Infrastructure : Layer for data access and some infra components. Repository and Unit of work pattern were used to access data.
ProductApi.Application : This is the layer used for transaction management and CQRS pattern.
ProductApi.Presentation : Api Layer to present api to clients.

![Capture](https://user-images.githubusercontent.com/45563744/115993555-0b8b5180-a5dc-11eb-93a0-4d5a603fe5a8.PNG)

For layers, all dependencies, directly or indirectly, go into domain layer. However domain layer is not depend on any layer.


Author : M.Çağatay KIZILTAN
