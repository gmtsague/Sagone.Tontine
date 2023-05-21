using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Meeting.Web.Dto
{
    public class AppPageViewModel<TEntity> where TEntity : class
    {
        public static AnneeDto? WorkingYear { get; set; }
        public static EtablissementDto? WorkingEtab { get; set; }
        public static AntenneDto? WorkingAntena { get; set; }

        public TEntity? SingleData { get; set; }
        public IList<TEntity> DataRecords { get; set; }

        public AvailableOperation Operation { get; set; }
        public string? FormTitre { get; set; }
        

    }
 
        public enum AvailableOperation
        {
            READ,
            CREATE,
            EDIT,
            DETAILS,
            DELETE
        }

}