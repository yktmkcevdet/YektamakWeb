
namespace Models
{
    public class Proje:IEntity
    {
        public int Id;
        public int no;
        public string ProjeKodString()
        {
            int repeatCount = 4 - no.ToString().Length;
            return _marka.prefix + "-" + string.Concat(Enumerable.Repeat("0",repeatCount)) + no.ToString();
        }
        private Marka _marka;
        public Marka marka { get { if (_marka == null) { _marka = new(); } return _marka; } set { _marka = value; } }
        
        public string kod;

        private Personel _personel;
        public Personel personel { get { if (_personel == null) { _personel = new(); } return _personel; } set { _personel = value; } }
    }
}