using Entity;

namespace Web.ViewModel
{
    public abstract class BaseIntViewModel : BaseEntityClass, IBaseViewModel
    {
        public abstract void CreateMappings();

        public int  Radif { get; set; }
       //public string  FarRadif
       // {
       //     get { return Methods.FarsiNumber(Radif.ToString()); }
       // }

    }
}