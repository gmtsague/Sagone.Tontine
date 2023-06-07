using Meeting.Web.Dto;
//using static Meeting.Web.Dto.AppPageViewModel<TEntity>;

namespace Meeting.web.Controllers
{
    //public record FormTitle(string CreateTitle, string EditTitle, string DetailsTitle, string DeleteTitle);
    public class FormTitle
    {
        public FormTitle(string ObjName)
        {
            CreateTitle = $"New >> {ObjName}";
            EditTitle = $"Edit >> {ObjName}";
            DetailsTitle = $"Details >> {ObjName}";
            DeleteTitle = $"Confirm Delete >> {ObjName}";
            ListTitle = $">> List of {ObjName}s";
        }

        public string GetTitleFromOperation(int op)
        {
            string title = string.Empty;
            switch (op)
            {
                case (int)AvailableOperation.CREATE: title = this.CreateTitle; break;
                case (int)AvailableOperation.EDIT: title = this.EditTitle; break;
                case (int)AvailableOperation.DETAILS: title = this.DetailsTitle; break;
                case (int)AvailableOperation.DELETE: title = this.DeleteTitle; break;
                default: title = this.ListTitle; break;
            }
            return title;
        }

        public string CreateTitle { get; set; }
        public string EditTitle { get; set; }
        public string DetailsTitle { get; set; }
        public string DeleteTitle { get; set; }
        public string ListTitle { get; set; }
    }
}
