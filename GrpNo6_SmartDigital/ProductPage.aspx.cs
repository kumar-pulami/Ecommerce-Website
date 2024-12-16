//Group Name: GrpNo6
//Student Number:
//	1.Neerak Jassi: 8965459
//  2.Saipraneeth Kumar Kandepu: 8964643
//  3.Ramadeep Kaur: 8961688
//  4.Ashok Sudbedi: 8972276

using GrpNo6_SmartDigital.DataService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace GrpNo6_SmartDigital
{
    public partial class ProductPage : System.Web.UI.Page
    {

        DataRepository dataRepository;
        protected void Page_Load(object sender, EventArgs e)
        {
            dataRepository = new DataRepository();
        }

        protected void ProductCrudGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Get the FileUpload control
            var fileUpload = (FileUpload)ProductCrudGridView.Rows[e.RowIndex].FindControl("ProductImageFileUpload");

            if (fileUpload.HasFile)
            {
                Guid productId = (Guid)ProductCrudGridView.DataKeys[e.RowIndex].Value;
                UploadImageFile(fileUpload, productId);
            }

            // Reset the edit index
            ProductCrudGridView.EditIndex = -1;

            // Rebind the GridView
            ProductCrudGridView.DataBind();
        }

        protected void ShowAddProductPanel(object sender, EventArgs e)
        {
            AddProductPanel.Visible = true;
        }


        //Adding new product to the database
        //uploading the image inside the images/product folder
        protected void OnClickAddBtn(object sender, EventArgs e)
        {

            //getting fields values
            string name = NameTxt.Text;
            string description = DescriptionTxt.Text;
            string category = CategoryTxt.Text;
            decimal price = decimal.Parse(PriceTxt.Text);

            //assign new id for the product
            Guid id = Guid.NewGuid();
            string imagePath = $"~/Images/Products/{id}{Path.GetExtension(ImageFileUpload.FileName).ToLower()}";

            if (ImageFileUpload.HasFile)
            {
                UploadImageFile(ImageFileUpload, id);
            }

            //insert query
            string sqlQuery = "INSERT INTO Product(Id, Name, Description, Category, Price, ImagePath) VALUES (@id, @name, @description, @category, @price, @imagePath)";

            //dictionary to store the db parameter and its respective value
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@id", id},
                { "@name", name },
                { "@description", description },
                { "@category", category },
                { "@price", price },
                { "@imagePath", imagePath },
            };

            dataRepository.ExecuteNonQueryWithParams(sqlQuery, parameters);

            ClearFields();
            AddProductPanel.Visible = false;
        }

        //Method to clear the add new product fields when clear button is clicked 
        protected void OnClickClearBtn(object sender, EventArgs e)
        {
            ClearFields();
        }


        //Method to resets the values of Add New Product Field's
        private void ClearFields()
        {
            NameTxt.Text = "";
            DescriptionTxt.Text = "";
            CategoryTxt.Text = "";
            PriceTxt.Text = "";
        }


        // Method to upload the image to Images/Products/ folder with product id as a file name.
        private void UploadImageFile(FileUpload imageFileUpload, Guid productId, bool updateToDatabase = true)
        {
            // Validating the file extension
            // Valid file are only image files
            string fileExtension = Path.GetExtension(imageFileUpload.FileName).ToLower();
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

            if (allowedExtensions.Contains(fileExtension))
            {
                string uniqueFileName = productId.ToString() + fileExtension;

                string imagePath = "~/Images/Products/" + uniqueFileName;

                string physicalPath = Server.MapPath(imagePath);
                //saving the uploaded image to the images/product folder
                imageFileUpload.SaveAs(physicalPath);

                //updating the image path to database.
                if (updateToDatabase)
                {
                    string sqlQuery = "UPDATE Product SET ImagePath = @ImagePath WHERE Id = @Id";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@ImagePath", imagePath },
                        { "@Id", productId }
                    };

                    dataRepository.ExecuteNonQueryWithParams(sqlQuery, parameters);

                }
            }
            else
            {
                Console.WriteLine("Invalid file upload. Upload image with .jpg, .jpeg, .png and .gif extension");
                return;
            }
        }
    }
}