using PagedList;
using System.ComponentModel.DataAnnotations;

namespace BelingualAcademy.Models
{
    public class GroupSearchModel
    {
        public int? Page { get; set; }
        [Display(Name = "Course")]
        public int CourseID { get; set; }
        public IPagedList<Group> SearchResults { get; set; }
        public string SearchButton { get; set; }

        
    }
}