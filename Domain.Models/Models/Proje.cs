
namespace Models
{
    public class Proje:IEntity
    {
        public int Id;
        public int no;
        private Marka _marka;
        public Marka marka { get { if (_marka == null) { _marka = new(); } return _marka; } set { _marka = value; } }
        
        public string kod;

        private Kullanici _kullanici;
        public Kullanici kullanici { get { if (_kullanici == null) { _kullanici = new(); } return _kullanici; } set { _kullanici = value; } }
    }
}