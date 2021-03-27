## Commands for EF (must be executed from within Shop.Database folder)

add new migration:
dotnet ef --startup-project ../WebApplication migrations add init 

dotnet ef --startup-project ../WebApplication database update