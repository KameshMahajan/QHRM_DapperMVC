create PROCEDURE ShowProduct
 @SN int
AS
BEGIN
  select * from AddProduct
   where SN = @SN;
END