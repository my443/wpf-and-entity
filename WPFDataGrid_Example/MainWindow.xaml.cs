using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFDataGrid_Example.Models;

namespace WPFDataGrid_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Source of example: https://www.c-sharpcorner.com/UploadFile/mahesh/datagrid-in-wpf/
    /// 
    /// Instead of adding the ADO.net you scaffold the database: 
    /// https://stackoverflow.com/questions/70580916/adding-ado-net-entity-framework-gives-the-projects-target-framework-does-not-c
    /// https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx
    /// https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio
    /// Scaffold-DbContext "Server=CENTRAL;Database=snippets;Trusted_Connection=True;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
    /// </summary>
    public partial class MainWindow : Window
    {
       SnippetsContext db = new SnippetsContext();

        public MainWindow()
        {
            InitializeComponent();
            McDataGrid.ItemsSource = LoadListOfAuthors();
        }

        /// <summary>
        /// List of Authors
        /// </summary>
        /// <returns></returns>

        // Used initially but no longer needed. 
        private List<Author> LoadCollectionData()
        {
            Author author = createAuthor();

            List<Author> authors = new List<Author>();

            authors.Add(author);

            return authors;
        }

        private Author createAuthor() {

            Author author = new Author()
            {
                Name = "Mahesh Chand",
                BookTitle = "Graphics Programming with GDI+",
                Dob = new DateTime(1975, 2, 23),
                IsMvp = false
            };

            db.Add(author);
            db.SaveChanges();

            return author;
        }

        private List<Author> LoadListOfAuthors()
        {
            List<Author> authors = new List<Author>();
            Author author = createAuthor();
            authors.Add(author);

            authors = db.Authors.ToList();

            return authors;
        }



        //private List<Author> LoadCollectionData()
        //{
        //    List<Author> authors = new List<Author>();
        //    authors.Add(new Author()
        //    {
        //        ID = 101,
        //        Name = "Mahesh Chand",
        //        BookTitle = "Graphics Programming with GDI+",
        //        DOB = new DateTime(1975, 2, 23),
        //        IsMVP = false
        //    });

        //    authors.Add(new Author()
        //    {
        //        ID = 201,
        //        Name = "Mike Gold",
        //        BookTitle = "Programming C#",
        //        DOB = new DateTime(1982, 4, 12),
        //        IsMVP = true
        //    });

        //    authors.Add(new Author()
        //    {
        //        ID = 244,
        //        Name = "Mathew Cochran",
        //        BookTitle = "LINQ in Vista",
        //        DOB = new DateTime(1985, 9, 11),
        //        IsMVP = true
        //    });

        //    return authors;
        //}
    }
}